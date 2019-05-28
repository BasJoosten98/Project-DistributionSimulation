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
            this.lbBuilding = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbGrowth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDemand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRow = new System.Windows.Forms.Label();
            this.lbCol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.gbBInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.lbIDnum = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.lbStock = new System.Windows.Forms.Label();
            this.tbReStock = new System.Windows.Forms.TextBox();
            this.gbWarehouse = new System.Windows.Forms.GroupBox();
            this.tbVehicles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRaduis = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCapacity = new System.Windows.Forms.TextBox();
            this.gbInfo.SuspendLayout();
            this.gbBInfo.SuspendLayout();
            this.gbWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.label8);
            this.gbInfo.Controls.Add(this.tbRaduis);
            this.gbInfo.Controls.Add(this.lbBuilding);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Controls.Add(this.tbGrowth);
            this.gbInfo.Controls.Add(this.label7);
            this.gbInfo.Controls.Add(this.lbDemand);
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.lbRow);
            this.gbInfo.Controls.Add(this.lbCol);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.lbLocation);
            this.gbInfo.Location = new System.Drawing.Point(13, 13);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(125, 154);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Cell";
            // 
            // lbBuilding
            // 
            this.lbBuilding.AutoSize = true;
            this.lbBuilding.Location = new System.Drawing.Point(52, 133);
            this.lbBuilding.Name = "lbBuilding";
            this.lbBuilding.Size = new System.Drawing.Size(33, 13);
            this.lbBuilding.TabIndex = 2;
            this.lbBuilding.Text = "None";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Building:";
            // 
            // tbGrowth
            // 
            this.tbGrowth.Location = new System.Drawing.Point(55, 76);
            this.tbGrowth.Name = "tbGrowth";
            this.tbGrowth.Size = new System.Drawing.Size(60, 20);
            this.tbGrowth.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Growth:";
            // 
            // lbDemand
            // 
            this.lbDemand.AutoSize = true;
            this.lbDemand.Location = new System.Drawing.Point(60, 56);
            this.lbDemand.Name = "lbDemand";
            this.lbDemand.Size = new System.Drawing.Size(13, 13);
            this.lbDemand.TabIndex = 7;
            this.lbDemand.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
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
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocation.Location = new System.Drawing.Point(6, 16);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(56, 13);
            this.lbLocation.TabIndex = 0;
            this.lbLocation.Text = "Location";
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(144, 119);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(126, 48);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // gbBInfo
            // 
            this.gbBInfo.Controls.Add(this.label1);
            this.gbBInfo.Controls.Add(this.tbStock);
            this.gbBInfo.Controls.Add(this.lbIDnum);
            this.gbBInfo.Controls.Add(this.lbID);
            this.gbBInfo.Controls.Add(this.lbStock);
            this.gbBInfo.Controls.Add(this.tbReStock);
            this.gbBInfo.Location = new System.Drawing.Point(144, 13);
            this.gbBInfo.Name = "gbBInfo";
            this.gbBInfo.Size = new System.Drawing.Size(124, 100);
            this.gbBInfo.TabIndex = 3;
            this.gbBInfo.TabStop = false;
            this.gbBInfo.Text = "Shop Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Restock";
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(66, 41);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(48, 20);
            this.tbStock.TabIndex = 6;
            // 
            // lbIDnum
            // 
            this.lbIDnum.AutoSize = true;
            this.lbIDnum.Location = new System.Drawing.Point(65, 20);
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
            // lbStock
            // 
            this.lbStock.AutoSize = true;
            this.lbStock.Location = new System.Drawing.Point(7, 44);
            this.lbStock.Name = "lbStock";
            this.lbStock.Size = new System.Drawing.Size(35, 13);
            this.lbStock.TabIndex = 0;
            this.lbStock.Text = "Stock";
            // 
            // tbReStock
            // 
            this.tbReStock.Location = new System.Drawing.Point(66, 67);
            this.tbReStock.Name = "tbReStock";
            this.tbReStock.Size = new System.Drawing.Size(48, 20);
            this.tbReStock.TabIndex = 7;
            // 
            // gbWarehouse
            // 
            this.gbWarehouse.Controls.Add(this.tbCapacity);
            this.gbWarehouse.Controls.Add(this.label10);
            this.gbWarehouse.Controls.Add(this.tbVehicles);
            this.gbWarehouse.Controls.Add(this.label9);
            this.gbWarehouse.Location = new System.Drawing.Point(144, 13);
            this.gbWarehouse.Name = "gbWarehouse";
            this.gbWarehouse.Size = new System.Drawing.Size(124, 96);
            this.gbWarehouse.TabIndex = 4;
            this.gbWarehouse.TabStop = false;
            this.gbWarehouse.Text = "Warehouse Info";
            // 
            // tbVehicles
            // 
            this.tbVehicles.Location = new System.Drawing.Point(60, 28);
            this.tbVehicles.Name = "tbVehicles";
            this.tbVehicles.Size = new System.Drawing.Size(58, 20);
            this.tbVehicles.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Vehicles:";
            // 
            // tbRaduis
            // 
            this.tbRaduis.Location = new System.Drawing.Point(55, 103);
            this.tbRaduis.Name = "tbRaduis";
            this.tbRaduis.Size = new System.Drawing.Size(60, 20);
            this.tbRaduis.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Radius:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Capacity:";
            // 
            // tbCapacity
            // 
            this.tbCapacity.Location = new System.Drawing.Point(60, 60);
            this.tbCapacity.Name = "tbCapacity";
            this.tbCapacity.Size = new System.Drawing.Size(58, 20);
            this.tbCapacity.TabIndex = 4;
            // 
            // CellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 172);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbWarehouse);
            this.Controls.Add(this.gbBInfo);
            this.Name = "CellForm";
            this.Text = "CellForm";
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbBInfo.ResumeLayout(false);
            this.gbBInfo.PerformLayout();
            this.gbWarehouse.ResumeLayout(false);
            this.gbWarehouse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lbCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.GroupBox gbBInfo;
        private System.Windows.Forms.Label lbStock;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbIDnum;
        private System.Windows.Forms.TextBox tbGrowth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDemand;
        private System.Windows.Forms.Label lbBuilding;
        private System.Windows.Forms.TextBox tbReStock;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.GroupBox gbWarehouse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbVehicles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRaduis;
        private System.Windows.Forms.TextBox tbCapacity;
        private System.Windows.Forms.Label label10;
    }
}