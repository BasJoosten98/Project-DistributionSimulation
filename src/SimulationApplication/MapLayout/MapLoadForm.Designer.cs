namespace MapLayout
{
    partial class MapLoadForm
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
            this.availableMapsListBox = new System.Windows.Forms.ListBox();
            this.availableMapsGroupBox = new System.Windows.Forms.GroupBox();
            this.loadSelectMapBtn = new System.Windows.Forms.Button();
            this.availableMapsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // availableMapsListBox
            // 
            this.availableMapsListBox.FormattingEnabled = true;
            this.availableMapsListBox.ItemHeight = 25;
            this.availableMapsListBox.Location = new System.Drawing.Point(12, 37);
            this.availableMapsListBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.availableMapsListBox.Name = "availableMapsListBox";
            this.availableMapsListBox.Size = new System.Drawing.Size(884, 354);
            this.availableMapsListBox.TabIndex = 0;
            // 
            // availableMapsGroupBox
            // 
            this.availableMapsGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.availableMapsGroupBox.Controls.Add(this.loadSelectMapBtn);
            this.availableMapsGroupBox.Controls.Add(this.availableMapsListBox);
            this.availableMapsGroupBox.Location = new System.Drawing.Point(24, 23);
            this.availableMapsGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.availableMapsGroupBox.Name = "availableMapsGroupBox";
            this.availableMapsGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.availableMapsGroupBox.Size = new System.Drawing.Size(924, 456);
            this.availableMapsGroupBox.TabIndex = 1;
            this.availableMapsGroupBox.TabStop = false;
            this.availableMapsGroupBox.Text = "Available Maps";
            // 
            // loadSelectMapBtn
            // 
            this.loadSelectMapBtn.Location = new System.Drawing.Point(12, 400);
            this.loadSelectMapBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loadSelectMapBtn.Name = "loadSelectMapBtn";
            this.loadSelectMapBtn.Size = new System.Drawing.Size(262, 44);
            this.loadSelectMapBtn.TabIndex = 1;
            this.loadSelectMapBtn.Text = "Load Selected Map";
            this.loadSelectMapBtn.UseVisualStyleBackColor = true;
            this.loadSelectMapBtn.Click += new System.EventHandler(this.loadSelectMapBtn_Click);
            // 
            // MapLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(972, 498);
            this.Controls.Add(this.availableMapsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MapLoadForm";
            this.Text = "Load Map";
            this.availableMapsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox availableMapsListBox;
        private System.Windows.Forms.GroupBox availableMapsGroupBox;
        private System.Windows.Forms.Button loadSelectMapBtn;
    }
}