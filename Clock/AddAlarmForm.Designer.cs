namespace Clock
{
    partial class AddAlarmForm
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
            this.chUseDate = new System.Windows.Forms.CheckBox();
            this.stpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chUseDate
            // 
            this.chUseDate.AutoSize = true;
            this.chUseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chUseDate.Location = new System.Drawing.Point(12, 12);
            this.chUseDate.Name = "chUseDate";
            this.chUseDate.Size = new System.Drawing.Size(314, 36);
            this.chUseDate.TabIndex = 0;
            this.chUseDate.Text = "На конткретную дату";
            this.chUseDate.UseVisualStyleBackColor = true;
            // 
            // stpDate
            // 
            this.stpDate.CustomFormat = "yyyy.MM.dd";
            this.stpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stpDate.Location = new System.Drawing.Point(12, 62);
            this.stpDate.Name = "stpDate";
            this.stpDate.Size = new System.Drawing.Size(196, 38);
            this.stpDate.TabIndex = 1;
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(230, 62);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(196, 38);
            this.dtpTime.TabIndex = 2;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 70;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Items.AddRange(new object[] {
            "пн",
            "вт",
            "ср",
            "чт",
            "пт",
            "сб",
            "вс"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 106);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(680, 37);
            this.checkedListBox1.TabIndex = 3;
            // 
            // AddAlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 327);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.stpDate);
            this.Controls.Add(this.chUseDate);
            this.Name = "AddAlarmForm";
            this.Text = "AddAlarmForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chUseDate;
        private System.Windows.Forms.DateTimePicker stpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}