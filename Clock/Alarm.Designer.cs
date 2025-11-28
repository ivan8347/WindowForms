namespace Clock
{
    partial class Alarm
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button = new System.Windows.Forms.Button();
            this.buttonAlarm = new System.Windows.Forms.Button();
            this.listBoxAlarm = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 181);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(200, 38);
            this.dateTimePicker.TabIndex = 0;
            // 
            // button
            // 
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button.Location = new System.Drawing.Point(8, 364);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(204, 60);
            this.button.TabIndex = 1;
            this.button.Text = "выбрать звук";
            this.button.UseVisualStyleBackColor = true;
            // 
            // buttonAlarm
            // 
            this.buttonAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAlarm.Location = new System.Drawing.Point(288, 364);
            this.buttonAlarm.Name = "buttonAlarm";
            this.buttonAlarm.Size = new System.Drawing.Size(206, 59);
            this.buttonAlarm.TabIndex = 2;
            this.buttonAlarm.Text = "добавить";
            this.buttonAlarm.UseVisualStyleBackColor = true;
            // 
            // listBoxAlarm
            // 
            this.listBoxAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxAlarm.FormattingEnabled = true;
            this.listBoxAlarm.ItemHeight = 31;
            this.listBoxAlarm.Location = new System.Drawing.Point(8, -1);
            this.listBoxAlarm.Name = "listBoxAlarm";
            this.listBoxAlarm.Size = new System.Drawing.Size(486, 66);
            this.listBoxAlarm.TabIndex = 3;
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxAlarm);
            this.Controls.Add(this.buttonAlarm);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "Alarm";
            this.Text = "Alarm";
            this.Load += new System.EventHandler(this.Alarm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button buttonAlarm;
        private System.Windows.Forms.ListBox listBoxAlarm;
    }
}