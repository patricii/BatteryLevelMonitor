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
        int countInstant = 0;
        int interval = 0;

        public FormMain()
        {
            InitializeComponent();
        }
        void timerLevelChart_Tick(object sender, EventArgs e)
        {
            LaunchCommandLineCmd();
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
        public void killProcess(string proc)
        {
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonLed.BackColor = Color.Green;
            ipAddress = textBoxIp.Text;
            labelStatus.Text = "Connected to device =>" + ipAddress + ":5555";
            interval = Convert.ToInt32(comboBoxInterval.Text);

            timerLevelChart.Interval = interval * 60000;
            timerLevelChart.Tick += new EventHandler(timerLevelChart_Tick);
            timerLevelChart.Start();

        }

        public void LaunchCommandLineCmd()
        {
            StreamReader outputReader = null;
            StreamReader errorReader = null;
            StreamWriter inStream = null;
            textBoxStatus.Text = "\n CMD Inicializado.... \n\n";

            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
                processStartInfo.ErrorDialog = false;
                processStartInfo.UseShellExecute = false;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.RedirectStandardInput = true;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.CreateNoWindow = true;

                Process process = new Process();
                process.StartInfo = processStartInfo;
                bool processStarted = process.Start();
                if (processStarted)
                {

                    outputReader = process.StandardOutput;
                    errorReader = process.StandardError;
                    inStream = process.StandardInput;

                    // inStream.WriteLine("adb connect " + ipAddress + ":5555");
                    inStream.WriteLine("adb shell dumpsys battery");
                    inStream.WriteLine("exit");

                    process.WaitForExit();

                    string displayText = "Output" + Environment.NewLine;
                    displayText += outputReader.ReadToEnd();
                    displayText += Environment.NewLine + "End" + Environment.NewLine;
                    displayText += errorReader.ReadToEnd();
                    textBoxStatus.Text = displayText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (outputReader != null)
                {
                    outputReader.Close();
                }
                if (errorReader != null)
                {
                    errorReader.Close();
                }
                if (inStream != null)
                {
                    inStream.Close();
                }
            }
        }
        public void setValuesLevel()
        {
            resultFromUnit = textBoxStatus.Text;
            string tempVoltage = resultFromUnit;
            string Battlevel = string.Empty;
            string BattVoltage = string.Empty;
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

                //Level Regex
                string regExPattern = "level" + ":(.*?\\s\\s)";
                Match fieldValue = Regex.Match(resultFromUnit, regExPattern, RegexOptions.IgnoreCase);
                Battlevel = fieldValue.Groups[1].Value.Trim();

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
                chartBatteryLevel.Series[0].Points.AddXY(countInstant, Battlevel);
                chartBatteryLevel.Series[1].Points.AddXY(countInstant, tmpBattVoltage.ToString());
                chartBatteryLevel.ChartAreas[0].AxisY.Interval = 5;

                //write log report
                if (!File.Exists(filepath))
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Create, FileAccess.Write)))
                    {
                        writer.WriteLine("sep=,");
                        writer.WriteLine($"{time},{countInstant},{Battlevel}, {tmpBattVoltage}");
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                FileMode.Append, FileAccess.Write)))
                    {
                        writer.WriteLine($"{time}, {countInstant}, {Battlevel}, {tmpBattVoltage}");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            finally
            {
                Battlevel = "";
                BattVoltage = "";
                resultFromUnit = "";
                countInstant = countInstant + interval;
            }
        }

    }
}
