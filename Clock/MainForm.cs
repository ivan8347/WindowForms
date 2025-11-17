using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;


namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            bool savedFormat = Properties.Settings.Default.Is24HourFormat;
            tsmiHour_24.Checked = !savedFormat;
            tsmiHour_12.Checked = savedFormat;

            checkBoxShowDate.Checked = Properties.Settings.Default.ShowDate;
            tsmiShowDate.Checked = checkBoxShowDate.Checked;
            checkBoxShowWeekDay.Checked = Properties.Settings.Default.ShowWeekDay;
            tsmiShowWeekDay.Checked = checkBoxShowWeekDay.Checked;


            labelTime.ForeColor = Color.FromName(Properties.Settings.Default.ForegroundColor);
            tsmiForegroundColor.Click += tsmiForegroundColor_Click;
            labelTime.BackColor = Color.FromName(Properties.Settings.Default.BackgroundColor);
            tsmiBackgroundColor.Click += tsmiBackgroundColor_Click;

            tsmiTopmost.Checked = Properties.Settings.Default.IsTopMost;
            this.TopMost = Properties.Settings.Default.IsTopMost;

            this.StartPosition = FormStartPosition.Manual;
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);

            var font = new Font(
                Properties.Settings.Default.FontName,
                Properties.Settings.Default.FontSize,
                (FontStyle)Properties.Settings.Default.FontStyle
            );
            labelTime.Font = font;

            SetVisibility(false);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (tsmiHour_12.Checked)
            { labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture); } // 12 часов
            if (tsmiHour_24.Checked) { labelTime.Text = DateTime.Now.ToString("HH:mm:ss "); } //24 часа
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            if (checkBoxShowWeekDay.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
        }

        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekDay.Visible = visible;
            buttonHideControls.Visible = visible;
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
            //this.ShowInTaskbar = visible;
        }
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            SetVisibility(tsmiShowControls.Checked = false);
        }
        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            SetVisibility(tsmiShowControls.Checked = true);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }
        private void tsmiQuit_Click(object sender, EventArgs e) => this.Close();

        private void tsmiTopmost_Click(object sender, EventArgs e)
        {

            this.TopMost = tsmiTopmost.Checked;
            Properties.Settings.Default.IsTopMost = tsmiTopmost.Checked;
            Properties.Settings.Default.Save();
        }
        private void tsmiShowDate_Click(object sender, EventArgs e) =>
            checkBoxShowDate.Checked = tsmiShowDate.Checked;
        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowDate.Checked = checkBoxShowDate.Checked;
            Properties.Settings.Default.ShowDate = checkBoxShowDate.Checked;
            Properties.Settings.Default.Save();
        }

        private void tsmiShowWeekDay_Click(object sender, EventArgs e) =>
           checkBoxShowWeekDay.Checked = tsmiShowWeekDay.Checked;
        private void checkBoxShowWeekDay_CheckedChanged(object sender, EventArgs e)
        {

            //tsmiShowWeekDay.Checked = checkBoxShowWeekDay.Checked;
            tsmiShowWeekDay.Checked = (sender as CheckBox).Checked;
            Properties.Settings.Default.ShowWeekDay = checkBoxShowWeekDay.Checked;
            Properties.Settings.Default.Save();
        }
        private void tsmiShowControls_Click(object sender, EventArgs e) =>
           SetVisibility(tsmiShowControls.Checked);
        private void tsmiHour_12_Click(object sender, EventArgs e)
        {
            tsmiHour_12.Checked = true;
            tsmiHour_24.Checked = false;
            Properties.Settings.Default.Is24HourFormat = tsmiHour_12.Checked;
            Properties.Settings.Default.Save();
            // timer_Tick(null, null);

        }
        private void tsmiHour_24_Click(object sender, EventArgs e)
        {
            tsmiHour_24.Checked = true;
            tsmiHour_12.Checked = false;
            Properties.Settings.Default.Is24HourFormat = tsmiHour_24.Checked;
            Properties.Settings.Default.Save();
            // timer_Tick(null, null);

        }



        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = labelTime.ForeColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    labelTime.ForeColor = dlg.Color;
                    Properties.Settings.Default.ForegroundColor = dlg.Color.Name;
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = labelTime.BackColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    labelTime.BackColor = dlg.Color;
                    Properties.Settings.Default.BackgroundColor = dlg.Color.Name;
                    Properties.Settings.Default.Save();
                }
            }
        }


        private void tsmiWindows_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = labelTime.Font;

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    labelTime.Font = fontDialog.Font;
                    // Сохраняем шрифт в настройки
                    Properties.Settings.Default.FontName = fontDialog.Font.Name;
                    Properties.Settings.Default.FontSize = fontDialog.Font.Size;
                    Properties.Settings.Default.FontStyle = (int)fontDialog.Font.Style;
                    Properties.Settings.Default.Save();
                }
            }

        }
    }
}
