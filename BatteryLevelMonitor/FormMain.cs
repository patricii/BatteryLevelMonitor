using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryLevelMonitor
{
    public partial class FormMain : Form
    {
        System.Windows.Forms.Timer timerLevelChart = new System.Windows.Forms.Timer(); //timer
        public static string ipAddress = string.Empty;
        string resultFromUnit = string.Empty;
        private static DateTime dtInitialCurrentChartTime;
        private System.Threading.Timer timer;
        int interval = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            ipAddress = textBoxIp.Text;
            labelStatus.Text = "Connected to device =>" + ipAddress + ":5555";
            interval = Convert.ToInt32(comboBoxInterval.Text);

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(interval);
            timer = new System.Threading.Timer((obj) =>
            {
                startRoutine();

            }, null, startTimeSpan, periodTimeSpan);

            timerLevelChart.Interval = (interval + 4) * 1000;
            timerLevelChart.Tick += new EventHandler(timerLevelChart_Tick);
            timerLevelChart.Start();
        }

        public void startRoutine() //CMD.exe commands to unit
        {
            try
            {
                ipAddress = textBoxIp.Text;
                dtInitialCurrentChartTime = DateTime.Now;
                buttonLed.BackColor = Color.Green;
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();

                var outStream = proc.StandardOutput;
                var inStream = proc.StandardInput;

                inStream.WriteLine("adb connect " + ipAddress + ":5555");
                inStream.WriteLine("adb shell dumpsys battery");

                resultFromUnit = "begin" + Environment.NewLine;

                Task.Run(() =>
                {
                    while (true)
                    {
                        textBoxStatus.Text += outStream.ReadLine();
                    }
                });
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            finally
            {
                buttonLed.BackColor = Color.Red;

            }
        }
        public void setValuesLevel()
        {
            resultFromUnit = textBoxStatus.Text;
            string tempVoltage = resultFromUnit;
            string Battlevel = string.Empty;
            string BattVoltage = string.Empty;
            // filepath = "BatteryMonitorLog.csv";
            string filepath = @"\BatteryMonitorLog.csv";

            filepath = textBoxSave.Text + filepath;

            try
            {
                //Voltage regex
                string regExPattern2 = "voltage" + ":(.*?\\s\\s)";
                MatchCollection fieldValue2 = Regex.Matches(tempVoltage, regExPattern2, RegexOptions.IgnoreCase);

                foreach (var match in fieldValue2)
                {
                    BattVoltage = match.ToString();
                }

                BattVoltage = BattVoltage.Replace("voltage:", "");
                labelVoltage.Text = "Battery Voltage:" + BattVoltage + "V";
                //Voltage regex End


                //log dateTime
                DateTime today = DateTime.Now;
                string time = today.ToString("hh:mm:ss");
                double diffInSeconds = (DateTime.Now - dtInitialCurrentChartTime).TotalSeconds;

                //Level Regex
                string regExPattern = "level" + ":(.*?\\s\\s)";
                Match fieldValue = Regex.Match(resultFromUnit, regExPattern, RegexOptions.IgnoreCase);
                Battlevel = fieldValue.Groups[1].Value.Trim();

                labelLevel.Text = "Battery Level:" + Battlevel + "%";


                labelLevel.Text = "Battery Level:" + Battlevel + "%";
                //Level Regex End
                double tmpBattVoltage = 0.0;
                try
                {
                    tmpBattVoltage = double.Parse(BattVoltage) / 1000;
                }
                catch
                {
                    //do nothing!!!
                }

                //Plot Graph
                chartBatteryLevel.Series[0].Points.AddXY(time, Battlevel);

                chartBatteryLevel.Series[1].Points.AddXY(time, tmpBattVoltage.ToString());

                chartBatteryLevel.ChartAreas[0].AxisY.Interval = 5;


                if (!File.Exists(filepath))
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Create, FileAccess.Write)))
                    {
                        writer.WriteLine("sep=,");
                        writer.WriteLine($"{time}, {Battlevel}, {tmpBattVoltage}");
                    }

                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Append, FileAccess.Write)))
                    {
                        writer.WriteLine($"{time}, {Battlevel}, {tmpBattVoltage}");


                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
        }
        void timerLevelChart_Tick(object sender, EventArgs e)
        {
            setValuesLevel();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void buttonFolder_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxSave.Text = folderBrowserDialog1.SelectedPath;
            }

        }
    }
}
