namespace MapLayout
{
    partial class StatisticsForm
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
            this.components = new System.ComponentModel.Container();
            this.ResetChartTimer = new System.Windows.Forms.Timer(this.components);
            this.myChart2 = new LiveCharts.WinForms.CartesianChart();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.lbVehicles = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTotalGivenDeliveries = new System.Windows.Forms.Label();
            this.lbTotalFinishedDeliveries = new System.Windows.Forms.Label();
            this.lbTotalDrivenTimeUnits = new System.Windows.Forms.Label();
            this.lbTotalNonDrivenTimeUnits = new System.Windows.Forms.Label();
            this.lbDrivingTimePercentage = new System.Windows.Forms.Label();
            this.lbNonDrivingTimePercentage = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTotalDeliveryWaitTime = new System.Windows.Forms.Label();
            this.lbAverageDeliveryWaitTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ResetChartTimer
            // 
            this.ResetChartTimer.Interval = 20;
            // 
            // myChart2
            // 
            this.myChart2.Location = new System.Drawing.Point(12, 12);
            this.myChart2.Name = "myChart2";
            this.myChart2.Size = new System.Drawing.Size(440, 260);
            this.myChart2.TabIndex = 3;
            this.myChart2.Text = "cartesianChart2";
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(12, 298);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(549, 212);
            this.pieChart1.TabIndex = 4;
            this.pieChart1.Text = "pieChart1";
            // 
            // lbVehicles
            // 
            this.lbVehicles.AutoSize = true;
            this.lbVehicles.Location = new System.Drawing.Point(664, 194);
            this.lbVehicles.Name = "lbVehicles";
            this.lbVehicles.Size = new System.Drawing.Size(61, 17);
            this.lbVehicles.TabIndex = 5;
            this.lbVehicles.Text = "Vehicles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "TotalGivenDeliveries";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(667, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "TotalFinishedDeliveries";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(667, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "TotalDrivenTimeUnits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(667, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "TotalNonDrivenTimeUnits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "DrivingTimePercentage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(667, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "NonDrivingTimePercentage";
            // 
            // lbTotalGivenDeliveries
            // 
            this.lbTotalGivenDeliveries.AutoSize = true;
            this.lbTotalGivenDeliveries.Location = new System.Drawing.Point(812, 235);
            this.lbTotalGivenDeliveries.Name = "lbTotalGivenDeliveries";
            this.lbTotalGivenDeliveries.Size = new System.Drawing.Size(46, 17);
            this.lbTotalGivenDeliveries.TabIndex = 12;
            this.lbTotalGivenDeliveries.Text = "label7";
            // 
            // lbTotalFinishedDeliveries
            // 
            this.lbTotalFinishedDeliveries.AutoSize = true;
            this.lbTotalFinishedDeliveries.Location = new System.Drawing.Point(828, 267);
            this.lbTotalFinishedDeliveries.Name = "lbTotalFinishedDeliveries";
            this.lbTotalFinishedDeliveries.Size = new System.Drawing.Size(46, 17);
            this.lbTotalFinishedDeliveries.TabIndex = 13;
            this.lbTotalFinishedDeliveries.Text = "label8";
            // 
            // lbTotalDrivenTimeUnits
            // 
            this.lbTotalDrivenTimeUnits.AutoSize = true;
            this.lbTotalDrivenTimeUnits.Location = new System.Drawing.Point(828, 297);
            this.lbTotalDrivenTimeUnits.Name = "lbTotalDrivenTimeUnits";
            this.lbTotalDrivenTimeUnits.Size = new System.Drawing.Size(46, 17);
            this.lbTotalDrivenTimeUnits.TabIndex = 14;
            this.lbTotalDrivenTimeUnits.Text = "label9";
            // 
            // lbTotalNonDrivenTimeUnits
            // 
            this.lbTotalNonDrivenTimeUnits.AutoSize = true;
            this.lbTotalNonDrivenTimeUnits.Location = new System.Drawing.Point(843, 327);
            this.lbTotalNonDrivenTimeUnits.Name = "lbTotalNonDrivenTimeUnits";
            this.lbTotalNonDrivenTimeUnits.Size = new System.Drawing.Size(54, 17);
            this.lbTotalNonDrivenTimeUnits.TabIndex = 15;
            this.lbTotalNonDrivenTimeUnits.Text = "label10";
            // 
            // lbDrivingTimePercentage
            // 
            this.lbDrivingTimePercentage.AutoSize = true;
            this.lbDrivingTimePercentage.Location = new System.Drawing.Point(843, 355);
            this.lbDrivingTimePercentage.Name = "lbDrivingTimePercentage";
            this.lbDrivingTimePercentage.Size = new System.Drawing.Size(54, 17);
            this.lbDrivingTimePercentage.TabIndex = 16;
            this.lbDrivingTimePercentage.Text = "label11";
            // 
            // lbNonDrivingTimePercentage
            // 
            this.lbNonDrivingTimePercentage.AutoSize = true;
            this.lbNonDrivingTimePercentage.Location = new System.Drawing.Point(855, 382);
            this.lbNonDrivingTimePercentage.Name = "lbNonDrivingTimePercentage";
            this.lbNonDrivingTimePercentage.Size = new System.Drawing.Size(54, 17);
            this.lbNonDrivingTimePercentage.TabIndex = 17;
            this.lbNonDrivingTimePercentage.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(664, 407);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "TotalDeliveryWaitTime";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(667, 436);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(171, 17);
            this.label14.TabIndex = 19;
            this.label14.Text = "AverageDeliveryWaitTime";
            // 
            // lbTotalDeliveryWaitTime
            // 
            this.lbTotalDeliveryWaitTime.AutoSize = true;
            this.lbTotalDeliveryWaitTime.Location = new System.Drawing.Point(821, 407);
            this.lbTotalDeliveryWaitTime.Name = "lbTotalDeliveryWaitTime";
            this.lbTotalDeliveryWaitTime.Size = new System.Drawing.Size(54, 17);
            this.lbTotalDeliveryWaitTime.TabIndex = 20;
            this.lbTotalDeliveryWaitTime.Text = "label15";
            // 
            // lbAverageDeliveryWaitTime
            // 
            this.lbAverageDeliveryWaitTime.AutoSize = true;
            this.lbAverageDeliveryWaitTime.Location = new System.Drawing.Point(845, 436);
            this.lbAverageDeliveryWaitTime.Name = "lbAverageDeliveryWaitTime";
            this.lbAverageDeliveryWaitTime.Size = new System.Drawing.Size(54, 17);
            this.lbAverageDeliveryWaitTime.TabIndex = 21;
            this.lbAverageDeliveryWaitTime.Text = "label16";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 522);
            this.Controls.Add(this.lbAverageDeliveryWaitTime);
            this.Controls.Add(this.lbTotalDeliveryWaitTime);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbNonDrivingTimePercentage);
            this.Controls.Add(this.lbDrivingTimePercentage);
            this.Controls.Add(this.lbTotalNonDrivenTimeUnits);
            this.Controls.Add(this.lbTotalDrivenTimeUnits);
            this.Controls.Add(this.lbTotalFinishedDeliveries);
            this.Controls.Add(this.lbTotalGivenDeliveries);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbVehicles);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.myChart2);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Wpf.CartesianChart.Basic_Bars.BasicColumn basicColumn1;
        private System.Windows.Forms.Timer ResetChartTimer;
        private LiveCharts.WinForms.CartesianChart myChart2;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Label lbVehicles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTotalGivenDeliveries;
        private System.Windows.Forms.Label lbTotalFinishedDeliveries;
        private System.Windows.Forms.Label lbTotalDrivenTimeUnits;
        private System.Windows.Forms.Label lbTotalNonDrivenTimeUnits;
        private System.Windows.Forms.Label lbDrivingTimePercentage;
        private System.Windows.Forms.Label lbNonDrivingTimePercentage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbTotalDeliveryWaitTime;
        private System.Windows.Forms.Label lbAverageDeliveryWaitTime;
    }
}