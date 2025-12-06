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
using System.Runtime.InteropServices;

namespace Clock
{

    public partial class MainForm : Form
    {
        ColorDialog backgrountDialog;
        ColorDialog foregroundDialog;
        ChooseFont fontDialog;
        AlarmsForm alarms;

        public MainForm()
        {
            InitializeComponent();
            
            SetVisibility(false);
            backgrountDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new ChooseFont();



            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);
            alarms = new AlarmsForm(this);
            tsmiTopmost.Checked = this.TopMost = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //if (Hour24)
            //    labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //else
                labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            if (checkBoxShowWeekDay.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now:dd.MM.yyyy}";
            notifyIcon.Text = labelTime.Text;

        }

        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekDay.Visible = visible;
            buttonHideControls.Visible = visible;
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;
           // this.ShowInTaskbar = visible;
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

        private void tsmiTopmost_Click(object sender, EventArgs e) =>
            this.TopMost = tsmiTopmost.Checked;
        private void tsmiShowDate_Click(object sender, EventArgs e) =>
            checkBoxShowDate.Checked = tsmiShowDate.Checked;
        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e) =>
          tsmiShowDate.Checked = checkBoxShowDate.Checked;
        private void tsmiShowWeekDay_Click(object sender, EventArgs e) =>
           checkBoxShowWeekDay.Checked = tsmiShowWeekDay.Checked;
        private void checkBoxShowWeekDay_CheckedChanged(object sender, EventArgs e) =>
          //tsmiShowWeekDay.Checked = checkBoxShowWeekDay.Checked;
          tsmiShowWeekDay.Checked = (sender as CheckBox).Checked;
        private void tsmiShowControls_Click(object sender, EventArgs e) =>
           SetVisibility(tsmiShowControls.Checked);

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            if(backgrountDialog.ShowDialog() == DialogResult.OK)    
            labelTime.BackColor = backgrountDialog.Color;
        }

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            if(foregroundDialog.ShowDialog() == DialogResult.OK)    
                labelTime.ForeColor = foregroundDialog.Color;
        }
        private void tsmiChooseFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)

                labelTime.Font = fontDialog.Font;
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            bool console = (sender as ToolStripMenuItem).Checked ? AllocConsole() : FreeConsole();
        }

        private void tsmiAlarms_Click(object sender, EventArgs e)
        {
            alarms.ShowDialog();
        }
    }
}
