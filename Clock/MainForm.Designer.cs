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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timeFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_12 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowWeekDay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowControls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChooseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiForegroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAutostart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowDate = new System.Windows.Forms.CheckBox();
            this.checkBoxShowWeekDay = new System.Windows.Forms.CheckBox();
            this.buttonHideControls = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelTime.ContextMenuStrip = this.contextMenuStrip;
            this.labelTime.Font = new System.Drawing.Font("Old English Text MT", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelTime.Location = new System.Drawing.Point(103, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(244, 63);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "labelTime";
            this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeFormatToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsmiTopmost,
            this.toolStripSeparator2,
            this.tsmiShowDate,
            this.tsmiShowWeekDay,
            this.tsmiShowControls,
            this.toolStripSeparator4,
            this.tsmiChooseFont,
            this.tsmiColors,
            this.toolStripSeparator7,
            this.tsmiAutostart,
            this.toolStripSeparator5,
            this.tsmiQuit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(300, 350);
            // 
            // timeFormatToolStripMenuItem
            // 
            this.timeFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_12,
            this.tsmi_24});
            this.timeFormatToolStripMenuItem.Name = "timeFormatToolStripMenuItem";
            this.timeFormatToolStripMenuItem.Size = new System.Drawing.Size(299, 32);
            this.timeFormatToolStripMenuItem.Text = "Time format";
            // 
            // tsmi_12
            // 
            this.tsmi_12.Name = "tsmi_12";
            this.tsmi_12.Size = new System.Drawing.Size(224, 32);
            this.tsmi_12.Text = "12 - hour";
            this.tsmi_12.Click += new System.EventHandler(this.tsmi_12_Click);
            // 
            // tsmi_24
            // 
            this.tsmi_24.Name = "tsmi_24";
            this.tsmi_24.Size = new System.Drawing.Size(224, 32);
            this.tsmi_24.Text = "24 - hour";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiTopmost
            // 
            this.tsmiTopmost.CheckOnClick = true;
            this.tsmiTopmost.Name = "tsmiTopmost";
            this.tsmiTopmost.Size = new System.Drawing.Size(299, 32);
            this.tsmiTopmost.Text = "Topmost";
            this.tsmiTopmost.Click += new System.EventHandler(this.tsmiTopmost_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiShowDate
            // 
            this.tsmiShowDate.CheckOnClick = true;
            this.tsmiShowDate.Name = "tsmiShowDate";
            this.tsmiShowDate.Size = new System.Drawing.Size(299, 32);
            this.tsmiShowDate.Text = "Show date";
            this.tsmiShowDate.Click += new System.EventHandler(this.tsmiShowDate_Click);
            // 
            // tsmiShowWeekDay
            // 
            this.tsmiShowWeekDay.CheckOnClick = true;
            this.tsmiShowWeekDay.Name = "tsmiShowWeekDay";
            this.tsmiShowWeekDay.Size = new System.Drawing.Size(299, 32);
            this.tsmiShowWeekDay.Text = "Show weekday";
            this.tsmiShowWeekDay.Click += new System.EventHandler(this.tsmiShowWeekDay_Click);
            // 
            // tsmiShowControls
            // 
            this.tsmiShowControls.CheckOnClick = true;
            this.tsmiShowControls.Name = "tsmiShowControls";
            this.tsmiShowControls.Size = new System.Drawing.Size(299, 32);
            this.tsmiShowControls.Text = "Show controls";
            this.tsmiShowControls.Click += new System.EventHandler(this.tsmiShowControls_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiChooseFont
            // 
            this.tsmiChooseFont.Name = "tsmiChooseFont";
            this.tsmiChooseFont.Size = new System.Drawing.Size(299, 32);
            this.tsmiChooseFont.Text = "Choose font";
            // 
            // tsmiColors
            // 
            this.tsmiColors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiForegroundColor,
            this.tsmiBackgroundColor});
            this.tsmiColors.Name = "tsmiColors";
            this.tsmiColors.Size = new System.Drawing.Size(299, 32);
            this.tsmiColors.Text = "Colors";
            // 
            // tsmiForegroundColor
            // 
            this.tsmiForegroundColor.Name = "tsmiForegroundColor";
            this.tsmiForegroundColor.Size = new System.Drawing.Size(256, 32);
            this.tsmiForegroundColor.Text = "Foreground Color";
            // 
            // tsmiBackgroundColor
            // 
            this.tsmiBackgroundColor.Name = "tsmiBackgroundColor";
            this.tsmiBackgroundColor.Size = new System.Drawing.Size(256, 32);
            this.tsmiBackgroundColor.Text = "Background Color";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiAutostart
            // 
            this.tsmiAutostart.Name = "tsmiAutostart";
            this.tsmiAutostart.Size = new System.Drawing.Size(299, 32);
            this.tsmiAutostart.Text = "Run on Windows startup";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(296, 6);
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(299, 32);
            this.tsmiQuit.Text = "Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
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
            this.checkBoxShowDate.Location = new System.Drawing.Point(87, 429);
            this.checkBoxShowDate.Name = "checkBoxShowDate";
            this.checkBoxShowDate.Size = new System.Drawing.Size(226, 36);
            this.checkBoxShowDate.TabIndex = 1;
            this.checkBoxShowDate.Text = "Показать дату";
            this.checkBoxShowDate.UseVisualStyleBackColor = true;
            this.checkBoxShowDate.CheckedChanged += new System.EventHandler(this.checkBoxShowDate_CheckedChanged);
            // 
            // checkBoxShowWeekDay
            // 
            this.checkBoxShowWeekDay.AutoSize = true;
            this.checkBoxShowWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxShowWeekDay.Location = new System.Drawing.Point(87, 397);
            this.checkBoxShowWeekDay.Name = "checkBoxShowWeekDay";
            this.checkBoxShowWeekDay.Size = new System.Drawing.Size(333, 36);
            this.checkBoxShowWeekDay.TabIndex = 2;
            this.checkBoxShowWeekDay.Text = "Показать день недели";
            this.checkBoxShowWeekDay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBoxShowWeekDay.UseVisualStyleBackColor = true;
            this.checkBoxShowWeekDay.CheckedChanged += new System.EventHandler(this.checkBoxShowWeekDay_CheckedChanged);
            // 
            // buttonHideControls
            // 
            this.buttonHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHideControls.Location = new System.Drawing.Point(87, 471);
            this.buttonHideControls.Name = "buttonHideControls";
            this.buttonHideControls.Size = new System.Drawing.Size(355, 82);
            this.buttonHideControls.TabIndex = 3;
            this.buttonHideControls.Text = "Скрыть элементы управления";
            this.buttonHideControls.UseVisualStyleBackColor = true;
            this.buttonHideControls.Click += new System.EventHandler(this.buttonHideControls_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Clock_SPU_411";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(496, 565);
            this.Controls.Add(this.buttonHideControls);
            this.Controls.Add(this.checkBoxShowWeekDay);
            this.Controls.Add(this.checkBoxShowDate);
            this.Controls.Add(this.labelTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Clock_SPU_411";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox checkBoxShowDate;
        private System.Windows.Forms.CheckBox checkBoxShowWeekDay;
        private System.Windows.Forms.Button buttonHideControls;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiTopmost;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDate;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowWeekDay;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowControls;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem timeFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_12;
        private System.Windows.Forms.ToolStripMenuItem tsmi_24;
        private System.Windows.Forms.ToolStripMenuItem tsmiChooseFont;
        private System.Windows.Forms.ToolStripMenuItem tsmiColors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiForegroundColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutostart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}

