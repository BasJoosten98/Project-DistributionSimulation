namespace MapLayout
{
    partial class CellForm
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.nudDemand = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRow = new System.Windows.Forms.Label();
            this.lbCol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBuilding = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.bSave = new System.Windows.Forms.Button();
            this.gbBInfo = new System.Windows.Forms.GroupBox();
            this.lbIDnum = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.nudRestock = new System.Windows.Forms.NumericUpDown();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lbRestock = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDemand)).BeginInit();
            this.gbBuilding.SuspendLayout();
            this.gbBInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.nudDemand);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lbRow);
            this.gbInfo.Controls.Add(this.lbCol);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Location = new System.Drawing.Point(13, 13);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(144, 83);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Cell";
            // 
            // nudDemand
            // 
            this.nudDemand.Location = new System.Drawing.Point(69, 54);
            this.nudDemand.Name = "nudDemand";
            this.nudDemand.Size = new System.Drawing.Size(53, 20);
            this.nudDemand.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Demand:";
            // 
            // lbRow
            // 
            this.lbRow.AutoSize = true;
            this.lbRow.Location = new System.Drawing.Point(38, 33);
            this.lbRow.Name = "lbRow";
            this.lbRow.Size = new System.Drawing.Size(13, 13);
            this.lbRow.TabIndex = 5;
            this.lbRow.Text = "0";
            // 
            // lbCol
            // 
            this.lbCol.AutoSize = true;
            this.lbCol.Location = new System.Drawing.Point(98, 33);
            this.lbCol.Name = "lbCol";
            this.lbCol.Size = new System.Drawing.Size(13, 13);
            this.lbCol.TabIndex = 4;
            this.lbCol.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Column:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Row:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location";
            // 
            // gbBuilding
            // 
            this.gbBuilding.Controls.Add(this.label6);
            this.gbBuilding.Controls.Add(this.cbType);
            this.gbBuilding.Location = new System.Drawing.Point(163, 13);
            this.gbBuilding.Name = "gbBuilding";
            this.gbBuilding.Size = new System.Drawing.Size(157, 83);
            this.gbBuilding.TabIndex = 1;
            this.gbBuilding.TabStop = false;
            this.gbBuilding.Text = "Building";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Type";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "No Building",
            "Shop",
            "Warehouse"});
            this.cbType.Location = new System.Drawing.Point(6, 49);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(142, 21);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 205);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(308, 41);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // gbBInfo
            // 
            this.gbBInfo.Controls.Add(this.lbIDnum);
            this.gbBInfo.Controls.Add(this.lbID);
            this.gbBInfo.Controls.Add(this.nudRestock);
            this.gbBInfo.Controls.Add(this.nudStock);
            this.gbBInfo.Controls.Add(this.lbRestock);
            this.gbBInfo.Controls.Add(this.lbStock);
            this.gbBInfo.Location = new System.Drawing.Point(13, 103);
            this.gbBInfo.Name = "gbBInfo";
            this.gbBInfo.Size = new System.Drawing.Size(307, 96);
            this.gbBInfo.TabIndex = 3;
            this.gbBInfo.TabStop = false;
            this.gbBInfo.Text = "Building Info";
            // 
            // lbIDnum
            // 
            this.lbIDnum.AutoSize = true;
            this.lbIDnum.Location = new System.Drawing.Point(155, 20);
            this.lbIDnum.Name = "lbIDnum";
            this.lbIDnum.Size = new System.Drawing.Size(13, 13);
            this.lbIDnum.TabIndex = 5;
            this.lbIDnum.Text = "0";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbID.Location = new System.Drawing.Point(9, 20);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 4;
            this.lbID.Text = "ID";
            // 
            // nudRestock
            // 
            this.nudRestock.Location = new System.Drawing.Point(156, 68);
            this.nudRestock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRestock.Name = "nudRestock";
            this.nudRestock.Size = new System.Drawing.Size(142, 20);
            this.nudRestock.TabIndex = 3;
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(156, 42);
            this.nudStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(142, 20);
            this.nudStock.TabIndex = 2;
            // 
            // lbRestock
            // 
            this.lbRestock.AutoSize = true;
            this.lbRestock.Location = new System.Drawing.Point(6, 70);
            this.lbRestock.Name = "lbRestock";
            this.lbRestock.Size = new System.Drawing.Size(54, 13);
            this.lbRestock.TabIndex = 1;
            this.lbRestock.Text = "Restock#";
            // 
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(7, 44);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(35, 13);
            this.lbStock.TabIndex = 0;
            this.lbStock.Text = "Stock";
            // 
            // CellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 253);
            this.Controls.Add(this.gbBInfo);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.gbBuilding);
            this.Controls.Add(this.gbInfo);
            this.Name = "CellForm";
            this.Text = "CellForm";
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDemand)).EndInit();
            this.gbBuilding.ResumeLayout(false);
            this.gbBuilding.PerformLayout();
            this.gbBInfo.ResumeLayout(false);
            this.gbBInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lbCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRow;
        private System.Windows.Forms.NumericUpDown nudDemand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbBuilding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.GroupBox gbBInfo;
        private System.Windows.Forms.NumericUpDown nudRestock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lbRestock;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbIDnum;
    }
}