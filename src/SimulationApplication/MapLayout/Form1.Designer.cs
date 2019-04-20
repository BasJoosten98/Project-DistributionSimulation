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
            this.btnDrawDijkstra = new System.Windows.Forms.Button();
            this.btnGetRoute = new System.Windows.Forms.Button();
            this.tbToLocationID = new System.Windows.Forms.TextBox();
            this.btnDrawRoute = new System.Windows.Forms.Button();
            this.tbFromLocationID = new System.Windows.Forms.TextBox();
            this.shortesRoutesRichTbx = new System.Windows.Forms.RichTextBox();
            this.lbLocationLog = new System.Windows.Forms.Label();
            this.btnCursor = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCreateDistributionManager = new System.Windows.Forms.Button();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateDistributionManager);
            this.splitContainer1.Panel2.Controls.Add(this.btnDrawDijkstra);
            this.splitContainer1.Panel2.Controls.Add(this.btnGetRoute);
            this.splitContainer1.Panel2.Controls.Add(this.tbToLocationID);
            this.splitContainer1.Panel2.Controls.Add(this.btnDrawRoute);
            this.splitContainer1.Panel2.Controls.Add(this.tbFromLocationID);
            this.splitContainer1.Panel2.Controls.Add(this.shortesRoutesRichTbx);
            this.splitContainer1.Panel2.Controls.Add(this.lbLocationLog);
            this.splitContainer1.Panel2.Controls.Add(this.btnCursor);
            this.splitContainer1.Panel2.Controls.Add(this.btnWarehouse);
            this.splitContainer1.Panel2.Controls.Add(this.btnShop);
            this.splitContainer1.Size = new System.Drawing.Size(863, 570);
            this.splitContainer1.SplitterDistance = 634;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // simulateBtn
            // 
            this.simulateBtn.Location = new System.Drawing.Point(3, 620);
            this.simulateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.simulateBtn.Name = "simulateBtn";
            this.simulateBtn.Size = new System.Drawing.Size(628, 38);
            this.simulateBtn.TabIndex = 0;
            this.simulateBtn.Text = "Simulate";
            this.simulateBtn.UseVisualStyleBackColor = true;
            this.simulateBtn.Click += new System.EventHandler(this.simulateBtn_click);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mapPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(602, 538);
            this.mapPictureBox.TabIndex = 1;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.mapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseClick);
            this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
            // 
            // btnDrawDijkstra
            // 
            this.btnDrawDijkstra.Location = new System.Drawing.Point(2, 487);
            this.btnDrawDijkstra.Name = "btnDrawDijkstra";
            this.btnDrawDijkstra.Size = new System.Drawing.Size(90, 23);
            this.btnDrawDijkstra.TabIndex = 14;
            this.btnDrawDijkstra.Text = "Draw Dijkstra";
            this.btnDrawDijkstra.UseVisualStyleBackColor = true;
            this.btnDrawDijkstra.Click += new System.EventHandler(this.btnDrawDijkstra_Click);
            // 
            // btnGetRoute
            // 
            this.btnGetRoute.Location = new System.Drawing.Point(2, 516);
            this.btnGetRoute.Name = "btnGetRoute";
            this.btnGetRoute.Size = new System.Drawing.Size(90, 23);
            this.btnGetRoute.TabIndex = 13;
            this.btnGetRoute.Text = "Get Route";
            this.btnGetRoute.UseVisualStyleBackColor = true;
            this.btnGetRoute.Click += new System.EventHandler(this.btnGetRoute_Click);
            // 
            // tbToLocationID
            // 
            this.tbToLocationID.Location = new System.Drawing.Point(128, 490);
            this.tbToLocationID.Name = "tbToLocationID";
            this.tbToLocationID.Size = new System.Drawing.Size(27, 20);
            this.tbToLocationID.TabIndex = 12;
            // 
            // btnDrawRoute
            // 
            this.btnDrawRoute.Location = new System.Drawing.Point(3, 544);
            this.btnDrawRoute.Name = "btnDrawRoute";
            this.btnDrawRoute.Size = new System.Drawing.Size(89, 23);
            this.btnDrawRoute.TabIndex = 11;
            this.btnDrawRoute.Text = "Draw Route";
            this.btnDrawRoute.UseVisualStyleBackColor = true;
            this.btnDrawRoute.Click += new System.EventHandler(this.btnDrawRoute_Click);
            // 
            // tbFromLocationID
            // 
            this.tbFromLocationID.Location = new System.Drawing.Point(98, 490);
            this.tbFromLocationID.Name = "tbFromLocationID";
            this.tbFromLocationID.Size = new System.Drawing.Size(27, 20);
            this.tbFromLocationID.TabIndex = 10;
            // 
            // shortesRoutesRichTbx
            // 
            this.shortesRoutesRichTbx.Location = new System.Drawing.Point(8, 66);
            this.shortesRoutesRichTbx.Margin = new System.Windows.Forms.Padding(2);
            this.shortesRoutesRichTbx.Name = "shortesRoutesRichTbx";
            this.shortesRoutesRichTbx.Size = new System.Drawing.Size(182, 421);
            this.shortesRoutesRichTbx.TabIndex = 8;
            this.shortesRoutesRichTbx.Text = "";
            // 
            // lbLocationLog
            // 
            this.lbLocationLog.AutoSize = true;
            this.lbLocationLog.Location = new System.Drawing.Point(9, 633);
            this.lbLocationLog.Name = "lbLocationLog";
            this.lbLocationLog.Size = new System.Drawing.Size(0, 13);
            this.lbLocationLog.TabIndex = 7;
            // 
            // btnCursor
            // 
            this.btnCursor.BackgroundImage = global::MapLayout.Properties.Resources.cursorIcon;
            this.btnCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCursor.Location = new System.Drawing.Point(128, 4);
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(66, 57);
            this.btnCursor.TabIndex = 6;
            this.btnCursor.UseVisualStyleBackColor = true;
            this.btnCursor.Click += new System.EventHandler(this.btnCursor_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackgroundImage = global::MapLayout.Properties.Resources.warehouseIcon1;
            this.btnWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWarehouse.Location = new System.Drawing.Point(66, 4);
            this.btnWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(66, 57);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnShop
            // 
            this.btnShop.BackgroundImage = global::MapLayout.Properties.Resources.shopIcon;
            this.btnShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShop.Location = new System.Drawing.Point(2, 3);
            this.btnShop.Margin = new System.Windows.Forms.Padding(2);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(66, 58);
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
            // btnCreateDistributionManager
            // 
            this.btnCreateDistributionManager.Location = new System.Drawing.Point(98, 516);
            this.btnCreateDistributionManager.Name = "btnCreateDistributionManager";
            this.btnCreateDistributionManager.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDistributionManager.TabIndex = 15;
            this.btnCreateDistributionManager.Text = "Create Dist";
            this.btnCreateDistributionManager.UseVisualStyleBackColor = true;
            this.btnCreateDistributionManager.Click += new System.EventHandler(this.btnCreateDistributionManager_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 570);
            this.Controls.Add(this.splitContainer1);
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
        private System.Windows.Forms.Button btnDrawRoute;
        private System.Windows.Forms.TextBox tbFromLocationID;
        private System.Windows.Forms.TextBox tbToLocationID;
        private System.Windows.Forms.Button btnGetRoute;
        private System.Windows.Forms.Button btnDrawDijkstra;
        private System.Windows.Forms.Button btnCreateDistributionManager;
    }
}

