namespace Clock
{
    partial class AlarmTriggerForm
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(12, 34);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(167, 43);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSnooze
            // 
            this.btnSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSnooze.Location = new System.Drawing.Point(207, 34);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(176, 43);
            this.btnSnooze.TabIndex = 2;
            this.btnSnooze.Text = "Отложить";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // AlarmTriggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 114);
            this.Controls.Add(this.btnSnooze);
            this.Controls.Add(this.btnStop);
            this.Name = "AlarmTriggerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AlarmTriggerForm";
            this.Load += new System.EventHandler(this.AlarmTriggerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSnooze;
    }
}