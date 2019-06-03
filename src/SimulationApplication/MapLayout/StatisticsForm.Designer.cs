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
            this.myChart = new LiveCharts.WinForms.CartesianChart();
            this.myChart2 = new LiveCharts.WinForms.CartesianChart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ResetChartTimer
            // 
            this.ResetChartTimer.Interval = 20;
            // 
            // myChart
            // 
            this.myChart.Location = new System.Drawing.Point(527, 12);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(411, 260);
            this.myChart.TabIndex = 2;
            this.myChart.Text = "cartesianChart2";
            // 
            // myChart2
            // 
            this.myChart2.Location = new System.Drawing.Point(12, 12);
            this.myChart2.Name = "myChart2";
            this.myChart2.Size = new System.Drawing.Size(440, 260);
            this.myChart2.TabIndex = 3;
            this.myChart2.Text = "cartesianChart2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(374, 308);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(347, 116);
            this.listBox1.TabIndex = 4;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 522);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.myChart2);
            this.Controls.Add(this.myChart);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Wpf.CartesianChart.Basic_Bars.BasicColumn basicColumn1;
        private System.Windows.Forms.Timer ResetChartTimer;
        private LiveCharts.WinForms.CartesianChart myChart;
        private LiveCharts.WinForms.CartesianChart myChart2;
        private System.Windows.Forms.ListBox listBox1;
    }
}