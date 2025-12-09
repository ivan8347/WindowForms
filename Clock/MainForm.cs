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
using Microsoft.Win32;
using System.IO;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace Clock
{

    public partial class MainForm : Form
    {
        ColorDialog backgrountDialog;
        ColorDialog foregroundDialog;
        ChooseFont fontDialog;
        AlarmsForm alarms;
        Alarm nextAlarm;
        private WMPLib.WindowsMediaPlayer player;

        public MainForm()
        {
            InitializeComponent();

            SetVisibility(false);
            LoadSettings();
            // SaveSettings();
            backgrountDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new ChooseFont();
            Console.WriteLine(Directory.GetCurrentDirectory());
            // tsmiShowConsole.Checked = true;
            // axWindowsMediaPlayer.Visible = false;
            player = new WMPLib.WindowsMediaPlayer();
            player.settings.volume = 60;

            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);
            alarms = new AlarmsForm(this);
            // tsmiTopmost.Checked = this.TopMost = true;
        }

        Alarm FindNextAlarm()
        {
            nextAlarm = alarms.lbAlarmList.Items.Cast<Alarm>().ToArray().Min();
            return nextAlarm;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //if (Hour24)
            //    labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //else
            if (tsmiHour_12.Checked)
            { labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture); } // 12 часов
            if (tsmiHour_24.Checked) { labelTime.Text = DateTime.Now.ToString("HH:mm:ss "); } //24 часа
                                                                                              // labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            if (nextAlarm != null && !nextAlarm.Triggered && nextAlarm.Time > DateTime.Now)
            {
                TimeSpan remaining = nextAlarm.Time - DateTime.Now;
                lblStatus.Text = $"До будильника: {remaining.Minutes:D2}:{remaining.Seconds:D2}";
            }


            if (checkBoxShowWeekDay.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now:dd.MM.yyyy}";
            notifyIcon.Text = labelTime.Text;
            nextAlarm = FindNextAlarm();
            if (nextAlarm != null) Console.WriteLine(nextAlarm);

            if (
                 nextAlarm != null &&
                 !nextAlarm.Triggered &&
                 nextAlarm.Time.Hour == DateTime.Now.Hour &&
                 nextAlarm.Time.Minute == DateTime.Now.Minute &&
                 nextAlarm.Time.Second == DateTime.Now.Second
                 )
            {
                nextAlarm.Triggered = true;

                player.URL = nextAlarm.Filename;
                player.controls.play();

                using (var dialog = new AlarmTriggerForm(this, nextAlarm.Message))
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        lblStatus.Visible = true;
                        if (dialog.Snooze)
                        {
                            nextAlarm.Time = nextAlarm.Time.AddMinutes(1);
                            nextAlarm.Triggered = false;
                            player.controls.stop();
                            MessageBox.Show("Будильник отложен на 10 минут");
                        }
                        else
                        {
                            player.controls.stop();
                            //lblStatus.Text += "\nСтоп";
                            lblStatus.Visible = false;
                            MessageBox.Show($"Стоп!!!!!");
                            nextAlarm.Triggered = false;
                        }
                    }
                }
            }

        }
        /*axWindowsMediaPlayer.Visible = true;
        axWindowsMediaPlayer.URL = nextAlarm.Filename;
        axWindowsMediaPlayer.settings.volume = 100;
        axWindowsMediaPlayer.Ctlcontrols.play();*/


        void SaveSettings()
        {
            string settingsPath = Path.Combine(Application.StartupPath, "Settings.ini");
            using (StreamWriter sv = new StreamWriter(settingsPath))
            {
                sv.WriteLine(tsmiTopmost.Checked);
                sv.WriteLine(tsmiShowDate.Checked);
                sv.WriteLine(tsmiShowWeekDay.Checked);
                sv.WriteLine(tsmiShowControls.Checked);
                sv.WriteLine(tsmiHour_24.Checked ? "24" : "12");
                sv.WriteLine(labelTime.BackColor.ToArgb());
                sv.WriteLine(labelTime.ForeColor.ToArgb());
                sv.WriteLine(tsmiAutostart.Checked);
                sv.WriteLine(labelTime.Font.Name);
                sv.WriteLine(labelTime.Font.Size);
            }
        }

        void LoadSettings()
        {
            string settingsPath = Path.Combine(Application.StartupPath, "Settings.ini");
            if (!File.Exists(settingsPath)) return;

            using (StreamReader sr = new StreamReader(settingsPath))
            {
                tsmiTopmost.Checked = bool.TryParse(sr.ReadLine(), out var top) ? top : false;
                this.TopMost = tsmiTopmost.Checked;
                tsmiShowDate.Checked = bool.TryParse(sr.ReadLine(), out var date) ? date : true;
                checkBoxShowDate.Checked = tsmiShowDate.Checked;
                tsmiShowWeekDay.Checked = bool.TryParse(sr.ReadLine(), out var week) ? week : true;
                checkBoxShowWeekDay.Checked = tsmiShowWeekDay.Checked;
                tsmiShowControls.Checked = bool.TryParse(sr.ReadLine(), out var controls) ? controls : false;
                string hourFormat = sr.ReadLine();
                tsmiHour_24.Checked = hourFormat == "24";
                tsmiHour_12.Checked = hourFormat != "24";

                string backColorLine = sr.ReadLine();
                string foreColorLine = sr.ReadLine();
                int backColor = int.TryParse(backColorLine, out var bc) ? bc : Color.Black.ToArgb();
                int foreColor = int.TryParse(foreColorLine, out var fc) ? fc : Color.White.ToArgb();
                labelTime.BackColor = Color.FromArgb(backColor);
                labelTime.ForeColor = Color.FromArgb(foreColor);
                tsmiAutostart.Checked = bool.Parse(sr.ReadLine());

                string fontName = sr.ReadLine();
                string fontSizeLine = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(fontName)) fontName = "Segoe UI";
                float fontSize = float.TryParse(fontSizeLine, out var fs) ? fs : 32f;

                try
                {
                    labelTime.Font = new Font(fontName, fontSize);
                }
                catch
                {
                    labelTime.Font = new Font("Segoe UI", 12f);
                }
            }
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
        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

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
            if (backgrountDialog.ShowDialog() == DialogResult.OK)
                labelTime.BackColor = backgrountDialog.Color;
        }

        private void tsmiForegroundColor_Click(object sender, EventArgs e)
        {
            if (foregroundDialog.ShowDialog() == DialogResult.OK)
                labelTime.ForeColor = foregroundDialog.Color;
        }
        private void tsmiChooseFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)

                labelTime.Font = fontDialog.Font;
        }
        //[DllImport("kernel32.dll")]
        //public static extern bool AllocConsole();
        //[DllImport("kernel32.dll")]
        //public static extern bool FreeConsole();

        private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
        {

            bool show = tsmiShowConsole.Checked ? AllocConsole() : FreeConsole();
        }
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        private void tsmiAlarms_Click(object sender, EventArgs e)
        {
            alarms.ShowDialog();
        }

        private void tsmiAutostart_CheckedChanged(object sender, EventArgs e)
        {
            string key_name = "Clock_SPU_411";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (tsmiAutostart.Checked) key.SetValue(key_name, Application.ExecutablePath);
            else key.DeleteValue(key_name, false);
            key.Dispose();
        }

        private void tsmiHour_12_Click(object sender, EventArgs e)
        {
            tsmiHour_12.Checked = true;
            tsmiHour_24.Checked = false;
            //Properties.Settings.Default.Is24HourFormat = tsmiHour_12.Checked;
            //Properties.Settings.Default.Save();
        }

        private void tsmiHour_24_Click(object sender, EventArgs e)
        {
            tsmiHour_24.Checked = true;
            tsmiHour_12.Checked = false;
            //Properties.Settings.Default.Is24HourFormat = tsmiHour_24.Checked;
            //Properties.Settings.Default.Save();
        }
    }
}
