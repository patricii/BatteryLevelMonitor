using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryLevelMonitor
{
    public partial class FormMain : Form
    {
        System.Windows.Forms.Timer timerLevelChart = new System.Windows.Forms.Timer();
        public static string ipAddress = string.Empty;
        string temp = string.Empty;
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

        public void startRoutine()
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

                temp = "begin" + Environment.NewLine;

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
            temp = textBoxStatus.Text;
            string tempVoltage = temp;
            string Battlevel = string.Empty;
            string BattVoltage = string.Empty;

            try
            {
                string regExPattern2 = "voltage" + ":(.*?\\s\\s)";
                MatchCollection fieldValue2 = Regex.Matches(tempVoltage, regExPattern2, RegexOptions.IgnoreCase);

                foreach (var match in fieldValue2)
                {
                    BattVoltage = match.ToString();
                }

                BattVoltage = BattVoltage.Replace("voltage:", "");
                labelVoltage.Text = "Battery Voltage:" + BattVoltage + "V";

                DateTime today = DateTime.Now;
                string time = today.ToString("hh:mm:ss");
                double diffInSeconds = (DateTime.Now - dtInitialCurrentChartTime).TotalSeconds;
                string regExPattern = "level" + ":(.*?\\s\\s)";
                Match fieldValue = Regex.Match(temp, regExPattern, RegexOptions.IgnoreCase);
                Battlevel = fieldValue.Groups[1].Value.Trim();            

                chartBatteryLevel.Series[0].Points.AddXY(time, Battlevel);
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
    }
}
