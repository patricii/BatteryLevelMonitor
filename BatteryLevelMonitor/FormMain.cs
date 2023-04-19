using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
            LaunchCommandLineCmd("adb shell dumpsys battery");
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
        private void buttonStart_Click(object sender, EventArgs e)
        {
            ipAddress = textBoxIp.Text;

            if (ipAddress.Length < 13)
            {
                MessageBox.Show("Digite o IP da unidade a ser monitorada!!!");
            }
            else
            {
                buttonLed.BackColor = Color.Green;
                labelStatus.Text = "Connected to device =>" + ipAddress + ":5555";
                interval = Convert.ToInt32(comboBoxInterval.Text);

                timerLevelChart.Interval = interval * 60000;
                timerLevelChart.Tick += new EventHandler(timerLevelChart_Tick);
                timerLevelChart.Start();
            }
        }
        public void LaunchCommandLineCmd(string ADBcommand)
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

                    inStream.WriteLine("adb connect " + ipAddress + ":5555");
                    inStream.WriteLine(ADBcommand);
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
            string logName = ipAddress;
            logName = logName.Replace(".", "");
            string filepath = @"\BatteryMonitorLog" + logName + ".csv";
            string regExPattern2 = "voltage" + ":(.*?\\s\\s)"; //Voltage regex
            string regExPattern = "level" + ":(.*?\\s\\s)"; //Level Regex
            DateTime today = DateTime.Now; //log dateTime
            string time = today.ToString("hh:mm:ss");
            double tmpBattVoltage = 0.0;

            filepath = textBoxSave.Text + filepath;

            try
            {
                MatchCollection fieldValue2 = Regex.Matches(tempVoltage, regExPattern2, RegexOptions.IgnoreCase);
                foreach (var match in fieldValue2)
                {
                    BattVoltage = match.ToString();
                }
                BattVoltage = BattVoltage.Replace("voltage:", "");

                Match fieldValue = Regex.Match(resultFromUnit, regExPattern, RegexOptions.IgnoreCase);
                Battlevel = fieldValue.Groups[1].Value.Trim();
                labelLevel.Text = "Battery Level:" + Battlevel + "%";

                if (countInstant == 0)
                    labelInit.Text = "Start Time:" + time;

                try
                {
                    tmpBattVoltage = double.Parse(BattVoltage) / 1000;
                }
                catch { }

                labelVoltage.Text = "Battery Voltage:" + tmpBattVoltage + "V";
                chartBatteryLevel.ChartAreas[0].AxisY2.Minimum = 3;
                chartBatteryLevel.ChartAreas[0].AxisY.Interval = 5;
                chartBatteryLevel.ChartAreas[0].AxisY2.Interval = 0.1;
                chartBatteryLevel.Series[0].BorderWidth = 4;
                chartBatteryLevel.Series[1].BorderWidth = 4;

                if (tmpBattVoltage != 0)
                {
                    //Plot Graph
                    chartBatteryLevel.Series[0].Points.AddXY(countInstant, Battlevel);
                    chartBatteryLevel.Series[1].Points.AddXY(countInstant, tmpBattVoltage.ToString());
                    //write log report
                    if (!File.Exists(filepath))
                    {
                        using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
                    FileMode.Create, FileAccess.Write)))
                        {
                            writer.WriteLine("sep=,");
                            writer.WriteLine("Time,Instant,BattLevel,BattVoltage");
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
            }
            catch { }

            finally
            {
                try
                {
                    if ((countInstant != 0) && (Convert.ToInt32(Battlevel) <= 1))
                    {
                        timerLevelChart.Enabled = false;
                        buttonLed.BackColor = Color.Red;
                        string fileGraph = textBoxSave.Text + @"\DischargingGraph.png";
                        chartBatteryLevel.SaveImage(fileGraph, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                        MessageBox.Show("....Discharging Analysis completed....!!!");
                    }
                    if ((countInstant != 0) && (Convert.ToInt32(Battlevel) == 70))
                    {
                        timerLevelChart.Enabled = false;
                        buttonLed.BackColor = Color.Red;
                        string fileGraph = textBoxSave.Text + @"\ChargingGraph.png";
                        chartBatteryLevel.SaveImage(fileGraph, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                        MessageBox.Show("....Charging Analysis completed....!!!");

                    }
                }
                catch { }

                Battlevel = "";
                BattVoltage = "";
                resultFromUnit = "";
                countInstant++;
                labelCycle.Text = "Cycle nº:" + countInstant.ToString();
            }
        }
    }
}
