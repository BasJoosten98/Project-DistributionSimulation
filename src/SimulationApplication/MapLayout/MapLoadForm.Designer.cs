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
            this.availableMapListBox = new System.Windows.Forms.ListBox();
            this.availableMapsGroupBox = new System.Windows.Forms.GroupBox();
            this.loadSelectMapBtn = new System.Windows.Forms.Button();
            this.availableMapsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // availableMapListBox
            // 
            this.availableMapListBox.FormattingEnabled = true;
            this.availableMapListBox.Location = new System.Drawing.Point(6, 19);
            this.availableMapListBox.Name = "availableMapListBox";
            this.availableMapListBox.Size = new System.Drawing.Size(444, 186);
            this.availableMapListBox.TabIndex = 0;
            // 
            // availableMapsGroupBox
            // 
            this.availableMapsGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.availableMapsGroupBox.Controls.Add(this.loadSelectMapBtn);
            this.availableMapsGroupBox.Controls.Add(this.availableMapListBox);
            this.availableMapsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.availableMapsGroupBox.Name = "availableMapsGroupBox";
            this.availableMapsGroupBox.Size = new System.Drawing.Size(462, 237);
            this.availableMapsGroupBox.TabIndex = 1;
            this.availableMapsGroupBox.TabStop = false;
            this.availableMapsGroupBox.Text = "Available Maps";
            // 
            // loadSelectMapBtn
            // 
            this.loadSelectMapBtn.Location = new System.Drawing.Point(6, 208);
            this.loadSelectMapBtn.Name = "loadSelectMapBtn";
            this.loadSelectMapBtn.Size = new System.Drawing.Size(131, 23);
            this.loadSelectMapBtn.TabIndex = 1;
            this.loadSelectMapBtn.Text = "Load Selected Map";
            this.loadSelectMapBtn.UseVisualStyleBackColor = true;
            // 
            // MapLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(486, 259);
            this.Controls.Add(this.availableMapsGroupBox);
            this.Name = "MapLoadForm";
            this.Text = "Load Map";
            this.availableMapsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox availableMapListBox;
        private System.Windows.Forms.GroupBox availableMapsGroupBox;
        private System.Windows.Forms.Button loadSelectMapBtn;
    }
}