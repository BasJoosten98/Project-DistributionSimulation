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
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shortesRoutesRichTbx = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer1.Panel2.Controls.Add(this.shortesRoutesRichTbx);
            this.splitContainer1.Panel2.Controls.Add(this.lbLocationLog);
            this.splitContainer1.Panel2.Controls.Add(this.btnCursor);
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
            this.simulateBtn.Margin = new System.Windows.Forms.Padding(4);
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
            this.mapPictureBox.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnCursor.Margin = new System.Windows.Forms.Padding(6);
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(132, 110);
            this.btnCursor.TabIndex = 6;
            this.btnCursor.UseVisualStyleBackColor = true;
            this.btnCursor.Click += new System.EventHandler(this.btnCursor_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::MapLayout.Properties.Resources.warehouseIcon1;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Location = new System.Drawing.Point(132, 8);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnShop.Margin = new System.Windows.Forms.Padding(4);
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
            // shortesRoutesRichTbx
            // 
            this.shortesRoutesRichTbx.Location = new System.Drawing.Point(16, 127);
            this.shortesRoutesRichTbx.Name = "shortesRoutesRichTbx";
            this.shortesRoutesRichTbx.Size = new System.Drawing.Size(360, 805);
            this.shortesRoutesRichTbx.TabIndex = 8;
            this.shortesRoutesRichTbx.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 1265);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button simulateBtn;
        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnCursor;
        private System.Windows.Forms.Label lbLocationLog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox shortesRoutesRichTbx;
    }
}

