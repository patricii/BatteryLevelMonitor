namespace BatteryLevelMonitor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.chartBatteryLevel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLed = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxInterval = new System.Windows.Forms.ComboBox();
            this.labelVoltage = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxSave = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCycle = new System.Windows.Forms.Label();
            this.labelInit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMaxLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxMinLevel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartBatteryLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(522, 29);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(166, 80);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 117);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(46, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Status...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unit IP";
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(9, 34);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(123, 20);
            this.textBoxIp.TabIndex = 5;
            this.textBoxIp.Text = "192.168.137.";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(12, 167);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(327, 397);
            this.textBoxStatus.TabIndex = 6;
            // 
            // chartBatteryLevel
            // 
            this.chartBatteryLevel.BorderlineWidth = 4;
            chartArea3.Area3DStyle.WallWidth = 4;
            chartArea3.Name = "ChartArea1";
            this.chartBatteryLevel.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartBatteryLevel.Legends.Add(legend3);
            this.chartBatteryLevel.Location = new System.Drawing.Point(345, 142);
            this.chartBatteryLevel.Name = "chartBatteryLevel";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.Legend = "Legend1";
            series5.Name = "Battery Level";
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Battery Voltage";
            series6.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series6.YValuesPerPoint = 4;
            this.chartBatteryLevel.Series.Add(series5);
            this.chartBatteryLevel.Series.Add(series6);
            this.chartBatteryLevel.Size = new System.Drawing.Size(866, 444);
            this.chartBatteryLevel.TabIndex = 7;
            this.chartBatteryLevel.Text = "chartBatteryLevel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(421, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Level (%) / Voltage (V)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(683, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Instant (min)";
            // 
            // buttonLed
            // 
            this.buttonLed.Location = new System.Drawing.Point(282, 9);
            this.buttonLed.Name = "buttonLed";
            this.buttonLed.Size = new System.Drawing.Size(38, 37);
            this.buttonLed.TabIndex = 11;
            this.buttonLed.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Interval (min)";
            // 
            // comboBoxInterval
            // 
            this.comboBoxInterval.FormattingEnabled = true;
            this.comboBoxInterval.Items.AddRange(new object[] {
            "5",
            "15",
            "30",
            "60",
            "120",
            "180",
            "240",
            "300"});
            this.comboBoxInterval.Location = new System.Drawing.Point(167, 33);
            this.comboBoxInterval.Name = "comboBoxInterval";
            this.comboBoxInterval.Size = new System.Drawing.Size(46, 21);
            this.comboBoxInterval.TabIndex = 13;
            this.comboBoxInterval.Text = "5";
            // 
            // labelVoltage
            // 
            this.labelVoltage.AutoSize = true;
            this.labelVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVoltage.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelVoltage.Location = new System.Drawing.Point(6, 48);
            this.labelVoltage.Name = "labelVoltage";
            this.labelVoltage.Size = new System.Drawing.Size(102, 13);
            this.labelVoltage.TabIndex = 14;
            this.labelVoltage.Text = "Battery Voltage: ";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelLevel.Location = new System.Drawing.Point(6, 26);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(86, 13);
            this.labelLevel.TabIndex = 15;
            this.labelLevel.Text = "Battery Level:";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1164, 592);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(38, 23);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxSave
            // 
            this.textBoxSave.Location = new System.Drawing.Point(40, 84);
            this.textBoxSave.Name = "textBoxSave";
            this.textBoxSave.Size = new System.Drawing.Size(92, 20);
            this.textBoxSave.TabIndex = 17;
            this.textBoxSave.Text = "C:\\temp";
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(9, 82);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(27, 23);
            this.buttonFolder.TabIndex = 18;
            this.buttonFolder.Text = "...";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Report folder:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BatteryLevelMonitor.Properties.Resources.FLEX_logo;
            this.pictureBox1.Location = new System.Drawing.Point(993, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMinLevel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxMaxLevel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxIp);
            this.groupBox1.Controls.Add(this.buttonFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonLed);
            this.groupBox1.Controls.Add(this.textBoxSave);
            this.groupBox1.Controls.Add(this.comboBoxInterval);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 133);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCycle);
            this.groupBox2.Controls.Add(this.labelInit);
            this.groupBox2.Controls.Add(this.labelVoltage);
            this.groupBox2.Controls.Add(this.labelLevel);
            this.groupBox2.Location = new System.Drawing.Point(1035, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 123);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measures";
            // 
            // labelCycle
            // 
            this.labelCycle.AutoSize = true;
            this.labelCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCycle.Location = new System.Drawing.Point(6, 93);
            this.labelCycle.Name = "labelCycle";
            this.labelCycle.Size = new System.Drawing.Size(49, 13);
            this.labelCycle.TabIndex = 17;
            this.labelCycle.Text = "Cycle nº:";
            // 
            // labelInit
            // 
            this.labelInit.AutoSize = true;
            this.labelInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInit.Location = new System.Drawing.Point(6, 70);
            this.labelInit.Name = "labelInit";
            this.labelInit.Size = new System.Drawing.Size(58, 13);
            this.labelInit.TabIndex = 16;
            this.labelInit.Text = "Start Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 602);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "Developed by A. Patricio";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Commands:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(167, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Max Level";
            // 
            // textBoxMaxLevel
            // 
            this.textBoxMaxLevel.Location = new System.Drawing.Point(167, 84);
            this.textBoxMaxLevel.Name = "textBoxMaxLevel";
            this.textBoxMaxLevel.Size = new System.Drawing.Size(46, 20);
            this.textBoxMaxLevel.TabIndex = 21;
            this.textBoxMaxLevel.Text = "70";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(248, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Min Level";
            // 
            // textBoxMinLevel
            // 
            this.textBoxMinLevel.Location = new System.Drawing.Point(251, 84);
            this.textBoxMinLevel.Name = "textBoxMinLevel";
            this.textBoxMinLevel.Size = new System.Drawing.Size(46, 20);
            this.textBoxMinLevel.TabIndex = 23;
            this.textBoxMinLevel.Text = "1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 618);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartBatteryLevel);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WiFi Battery Level Monitor - WBLMv1.3";
            ((System.ComponentModel.ISupportInitialize)(this.chartBatteryLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBatteryLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.Label labelVoltage;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCycle;
        private System.Windows.Forms.Label labelInit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMinLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMaxLevel;
        private System.Windows.Forms.Label label8;
    }
}

