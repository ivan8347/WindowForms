namespace Clock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowDate = new System.Windows.Forms.CheckBox();
            this.checkBoxWeekDay = new System.Windows.Forms.CheckBox();
            this.buttonHideControls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(49, 32);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(258, 61);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "labelTime";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkBoxShowDate
            // 
            this.checkBoxShowDate.AutoSize = true;
            this.checkBoxShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowDate.Location = new System.Drawing.Point(87, 316);
            this.checkBoxShowDate.Name = "checkBoxShowDate";
            this.checkBoxShowDate.Size = new System.Drawing.Size(226, 36);
            this.checkBoxShowDate.TabIndex = 1;
            this.checkBoxShowDate.Text = "Показать дату";
            this.checkBoxShowDate.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeekDay
            // 
            this.checkBoxWeekDay.AutoSize = true;
            this.checkBoxWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxWeekDay.Location = new System.Drawing.Point(87, 358);
            this.checkBoxWeekDay.Name = "checkBoxWeekDay";
            this.checkBoxWeekDay.Size = new System.Drawing.Size(333, 36);
            this.checkBoxWeekDay.TabIndex = 2;
            this.checkBoxWeekDay.Text = "Показать день недели";
            this.checkBoxWeekDay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBoxWeekDay.UseVisualStyleBackColor = true;
            // 
            // buttonHideControls
            // 
            this.buttonHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHideControls.Location = new System.Drawing.Point(87, 400);
            this.buttonHideControls.Name = "buttonHideControls";
            this.buttonHideControls.Size = new System.Drawing.Size(355, 82);
            this.buttonHideControls.TabIndex = 3;
            this.buttonHideControls.Text = "Скрыть элементы управления";
            this.buttonHideControls.UseVisualStyleBackColor = true;
            this.buttonHideControls.Click += new System.EventHandler(this.buttonHideControls_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 497);
            this.Controls.Add(this.buttonHideControls);
            this.Controls.Add(this.checkBoxWeekDay);
            this.Controls.Add(this.checkBoxShowDate);
            this.Controls.Add(this.labelTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Clock_SPU_411";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxShowDate;
        private System.Windows.Forms.CheckBox checkBoxWeekDay;
        private System.Windows.Forms.Button buttonHideControls;
    }
}

