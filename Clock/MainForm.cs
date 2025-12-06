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
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
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


        void LoadSettings()
        {
            StreamReader sr = new StreamReader
                ($"{Path.GetDirectoryName(Application.ExecutablePath)}\\..\\..\\Settings.ini");

            tsmiTopmost.Checked = Boolean.Parse(sr.ReadLine());
            tsmiShowDate.Checked = Boolean.Parse(sr.ReadLine());
            tsmiShowWeekDay.Checked = Boolean.Parse(sr.ReadLine());
            tsmiShowControls.Checked = Boolean.Parse(sr.ReadLine());
            string fontName = sr.ReadLine();
            int fontSize = Convert.ToInt32(sr.ReadLine());
            labelTime.BackColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
            labelTime.ForeColor = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));


            sr.Close();
        }
        void SaveSettings()
        {
            StreamWriter sv = new StreamWriter
                ($"{Path.GetDirectoryName(Application.ExecutablePath)}\\..\\..\\Settings.ini");
            sv.WriteLine($"{tsmiTopmost.Checked}");
            sv.WriteLine($"{tsmiShowDate.Checked}");
            sv.WriteLine($"{tsmiShowWeekDay.Checked}");
            sv.WriteLine($"{tsmiShowControls.Checked}");
            sv.WriteLine($"{labelTime.Font.Name}");
            sv.WriteLine($"{labelTime.Font.Size}");
            sv.WriteLine($"{labelTime.BackColor.ToArgb()}");
            sv.WriteLine($"{labelTime.ForeColor.ToArgb()}");


            sv.Close();
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
           /* var menuItem = sender as ToolStripMenuItem;
            if (menuItem.Checked)
            {
                AllocConsole();
                StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
                writer.AutoFlush = true;
                Console.SetOut(writer);
                // Console.WriteLine("Консоль подключена. Привет из Clock!");
            }
            else
            {
                FreeConsole();
            }
        }

        //AllocConsole();*/
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
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run",true);
            if(tsmiAutostart.Checked)key.SetValue(key_name,Application.ExecutablePath);
            else key.DeleteValue(key_name, false);
            key.Dispose();
        }

        
    }
}
