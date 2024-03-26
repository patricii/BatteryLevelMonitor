using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BatteryLevelMonitor
{
    class SendCommandCMD
    {
        public string SendADBCommandByCMD(string ADBcommand)
        {
            string error = "Failed to Send or Get response!";
            string response = string.Empty;
            StreamReader outputReader = null;
            StreamReader errorReader = null;
            StreamWriter inStream = null;
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
                    inStream.WriteLine(ADBcommand);
                    inStream.WriteLine("exit");

                    process.WaitForExit();

                    string displayText = "Output:" + Environment.NewLine;
                    displayText += outputReader.ReadToEnd();
                    displayText += Environment.NewLine + "End" + Environment.NewLine;
                    displayText += errorReader.ReadToEnd();
                    response = displayText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return error;
            }
            finally
            {
                if (outputReader != null)
                    outputReader.Close();

                if (errorReader != null)
                    errorReader.Close();

                if (inStream != null)
                    inStream.Close();
            }
            return response;
        }
    }
}
