namespace MapLayout
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.simulateBtn = new System.Windows.Forms.Button();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.lbLocationLog = new System.Windows.Forms.Label();
            this.btnCursor = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Vehicle = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.simulateBtn);
            this.splitContainer1.Panel1.Controls.Add(this.mapPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel2.Controls.Add(this.lbLocationLog);
            this.splitContainer1.Panel2.Controls.Add(this.btnCursor);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.btnWarehouse);
            this.splitContainer1.Panel2.Controls.Add(this.btnShop);
            this.splitContainer1.Size = new System.Drawing.Size(1684, 1265);
            this.splitContainer1.SplitterDistance = 1290;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // simulateBtn
            // 
            this.simulateBtn.Location = new System.Drawing.Point(6, 1192);
            this.simulateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simulateBtn.Name = "simulateBtn";
            this.simulateBtn.Size = new System.Drawing.Size(1256, 73);
            this.simulateBtn.TabIndex = 0;
            this.simulateBtn.Text = "Simulate";
            this.simulateBtn.UseVisualStyleBackColor = true;
            this.simulateBtn.Click += new System.EventHandler(this.simulateBtn_click);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(6, 6);
            this.mapPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(1204, 1158);
            this.mapPictureBox.TabIndex = 1;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.mapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseClick);
            this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
            // 
            // lbLocationLog
            // 
            this.lbLocationLog.AutoSize = true;
            this.lbLocationLog.Location = new System.Drawing.Point(18, 1217);
            this.lbLocationLog.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbLocationLog.Name = "lbLocationLog";
            this.lbLocationLog.Size = new System.Drawing.Size(0, 25);
            this.lbLocationLog.TabIndex = 7;
            // 
            // btnCursor
            // 
            this.btnCursor.BackgroundImage = global::MapLayout.Properties.Resources.cursorIcon;
            this.btnCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCursor.Location = new System.Drawing.Point(256, 8);
            this.btnCursor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(132, 110);
            this.btnCursor.TabIndex = 6;
            this.btnCursor.UseVisualStyleBackColor = true;
            this.btnCursor.Click += new System.EventHandler(this.btnCursor_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Vehicle);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(4, 267);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 271);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vehicle Capacity";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 165);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 31);
            this.textBox2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vehicle Number";
            // 
            // Vehicle
            // 
            this.Vehicle.AutoSize = true;
            this.Vehicle.Location = new System.Drawing.Point(4, 15);
            this.Vehicle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Vehicle.Name = "Vehicle";
            this.Vehicle.Size = new System.Drawing.Size(83, 25);
            this.Vehicle.TabIndex = 4;
            this.Vehicle.Text = "Vehicle";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 94);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(348, 31);
            this.textBox1.TabIndex = 3;
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::MapLayout.Properties.Resources.warehouseIcon1;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Location = new System.Drawing.Point(132, 8);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(132, 110);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnShop
            // 
            this.btnShop.BackgroundImage = global::MapLayout.Properties.Resources.shopIcon;
            this.btnShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShop.Location = new System.Drawing.Point(4, 6);
            this.btnShop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(132, 112);
            this.btnShop.TabIndex = 1;
            this.btnShop.UseVisualStyleBackColor = true;
            this.btnShop.Click += new System.EventHandler(this.btnShop_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1265);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button simulateBtn;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Vehicle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCursor;
        private System.Windows.Forms.Label lbLocationLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

