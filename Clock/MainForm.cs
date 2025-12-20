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
using System.Drawing.Text;



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
        bool eyesOpen = true;
        Timer blinkTimer;
        Timer clockTimer;


        public MainForm()
        {
            InitializeComponent();


           // bool savedFormat = Properties.Settings.Default.Is24HourFormat;                      // Формат времени
            //tsmiHour_24.Checked = !savedFormat;
            //tsmiHour_12.Checked = savedFormat;
           // LoadSettings();
            this.DoubleBuffered = true;
            this.Paint += MainForm_Paint;

            // Таймер моргания
            blinkTimer = new Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Tick += (s, e) =>
            {
                eyesOpen = !eyesOpen;
                this.Invalidate();
            };
            blinkTimer.Start();

            // Таймер обновления времени
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) => this.Invalidate();
            clockTimer.Start();
            // Form1 f = new Form1();
            // f.Show();        // окно откроется и будет работать


            SetVisibility(true);

            // this.FormBorderStyle = FormBorderStyle.None;
            // this.BackColor = Color.Magenta;
            // this.TransparencyKey = this.BackColor;
            // this.DoubleBuffered = true;
            // this.Width = 300;
            // this.Height = 400;

            // SetBunnyShape();

            //labelTime.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            //labelTime.ForeColor = Color.Black;
            //labelTime.BackColor = Color.Transparent;
            //labelTime.AutoSize = true;
            //labelTime.Location = new Point((this.Width - labelTime.Width) / 2, 170);





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
             tsmiTopmost.Checked = this.TopMost = true;
            //tsmiShowControls.Checked  = true;
            //tsmiShowControls.Checked = visible;
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
           // if (tsmiHour_12.Checked)
           // { labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture); } // 12 часов
           // if (tsmiHour_24.Checked) { labelTime.Text = DateTime.Now.ToString("HH:mm:ss "); } //24 часа
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
                            lblStatus.Visible = false;
                            MessageBox.Show($"Стоп!!!!!");
                            nextAlarm.Triggered = false;
                        }
                    }
                }
            }

        }
      


        void SetVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;
            checkBoxShowWeekDay.Visible = visible;
           buttonHideControls.Visible = visible;
          // tsmiShowControls.Checked = visible;
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
           // SaveSettings();
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
                labelTime.Font = fontDialog.SelectedFont;


           /* if (fontDialog.ShowDialog() == DialogResult.OK)

                labelTime.Font = fontDialog.Font;*/
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
        {
            bool show = tsmiShowConsole.Checked ? AllocConsole() : FreeConsole();
        }
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

       

        private void tsmiHour_12_Click_1(object sender, EventArgs e)
        {
            tsmiHour_12.Checked = true;
            tsmiHour_24.Checked = false;
           // Properties.Settings.Default.Is24HourFormat = tsmiHour_12.Checked;
            Properties.Settings.Default.Save();
        }
        private void tsmiHour_24_Click(object sender, EventArgs e)
        {
            tsmiHour_24.Checked = true;
            tsmiHour_12.Checked = false;
           // Properties.Settings.Default.Is24HourFormat = tsmiHour_24.Checked;
            Properties.Settings.Default.Save();
        }
       // private void SetBunnyShape()
       // {
          //  GraphicsPath path = new GraphicsPath();
          //
          //  // Голова
          //  path.AddEllipse(50, 100, 200, 200);
          //
          //  // Левое ухо
          //  path.AddEllipse(80, 0, 40, 120);
          //
          //  // Правое ухо
          //  path.AddEllipse(180, 0, 40, 120);
          //
          //  this.Region = new Region(path);
       // }
       // protected override void OnPaint(PaintEventArgs e)
       //  {
            // base.OnPaint(e);
            // Graphics g = e.Graphics;
            // g.SmoothingMode = SmoothingMode.AntiAlias;
            //
            // /*   // Время
            //    string time = DateTime.Now.ToString(tsmiHour_24.Checked ? "HH:mm:ss" : "hh:mm:ss tt");
            //    using (Font font = new Font("Segoe UI", 24, FontStyle.Bold))
            //    using (Brush brush = new SolidBrush(Color.Black))
            //    {
            //        SizeF size = g.MeasureString(time, font);
            //        g.DrawString(time, font, brush, (Width - size.Width) / 2, 160);
            //    }*/
           ////  labelTime.Text = DateTime.Now.ToString(tsmiHour_24.Checked ? "HH:mm:ss" : "hh:mm:ss tt");
            // // Глазки
            // g.FillEllipse(Brushes.Black, 110, 140, 10, 10);
            // g.FillEllipse(Brushes.Black, 180, 140, 10, 10);
            //
            // // Носик
            // Point[] nose = { new Point(145, 160), new Point(155, 160), new Point(150, 170) };
            // g.FillPolygon(Brushes.Black, nose);
            //
            // // Щёчки
            // g.FillEllipse(Brushes.Pink, 95, 155, 20, 20);
            // g.FillEllipse(Brushes.Pink, 185, 155, 20, 20);
         //}
      /*  protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Голова (заливка белым)
            g.FillEllipse(Brushes.Pink, 50, 150, 200, 200);

            // Левое ухо
            g.FillEllipse(Brushes.White, 80, 0, 40, 120);
            g.FillEllipse(Brushes.Pink, 90, 10, 20, 100); // внутренняя часть

            // Правое ухо
            g.FillEllipse(Brushes.White, 180, 0, 40, 120);
            g.FillEllipse(Brushes.Pink, 190, 10, 20, 100); // внутренняя часть

            // Глазки
            g.FillEllipse(Brushes.Black, 110, 140, 10, 10);
            g.FillEllipse(Brushes.Black, 180, 140, 10, 10);

            // Носик
            Point[] nose = { new Point(145, 160), new Point(155, 160), new Point(150, 170) };
            g.FillPolygon(Brushes.Black, nose);

            // Щёчки
            g.FillEllipse(Brushes.Pink, 95, 155, 20, 20);
            g.FillEllipse(Brushes.Pink, 185, 155, 20, 20);
        }*/
  



            private void MainForm_Paint(object sender, PaintEventArgs e)
            {
                int centerX = this.ClientSize.Width / 2;
                int centerY = this.ClientSize.Height / 2 + 40;

                DrawNyusha(e.Graphics, centerX, centerY);
            }

            private void DrawNyusha(Graphics g, int centerX, int centerY)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                int bodyRadius = 80;
                Rectangle bodyRect = new Rectangle(centerX - bodyRadius, centerY - bodyRadius, bodyRadius * 2, bodyRadius * 2);
                Color bodyColor = Color.FromArgb(255, 170, 200);
                Color outlineColor = Color.FromArgb(220, 60, 100);

                using (SolidBrush bodyBrush = new SolidBrush(bodyColor))
                using (Pen outlinePen = new Pen(outlineColor, 4))
                {
                    g.FillEllipse(bodyBrush, bodyRect);
                    g.DrawEllipse(outlinePen, bodyRect);
                }

                using (SolidBrush legBrush = new SolidBrush(outlineColor))
                {
                    int legWidth = 22, legHeight = 40, legOffsetX = 30;
                    g.FillRectangle(legBrush, centerX - legOffsetX - legWidth / 2, centerY + bodyRadius - 10, legWidth, legHeight);
                    g.FillRectangle(legBrush, centerX + legOffsetX - legWidth / 2, centerY + bodyRadius - 10, legWidth, legHeight);
                }

                int posterWidth = 220, posterHeight = 80, posterY = centerY - bodyRadius - 120;
                Rectangle posterRect = new Rectangle(centerX - posterWidth / 2, posterY, posterWidth, posterHeight);

                using (SolidBrush posterBrush = new SolidBrush(Color.White))
                using (Pen posterPen = new Pen(Color.Black, 3))
                {
                    g.FillRectangle(posterBrush, posterRect);
                    g.DrawRectangle(posterPen, posterRect);
                }

                using (Pen armPen = new Pen(bodyColor, 16) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                {
                    g.DrawLine(armPen, centerX - bodyRadius + 10, centerY - 30, posterRect.Left + 30, posterRect.Bottom);
                    g.DrawLine(armPen, centerX + bodyRadius - 10, centerY - 30, posterRect.Right - 30, posterRect.Bottom);
                }

            using (StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            using (Font clockFont = new Font("Arial", 18, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                string timeText = labelTime.Text;   // ← теперь берём текст с твоего labelTime
                g.DrawString(timeText, clockFont, textBrush, posterRect, sf);
            }


            int snoutWidth = 60, snoutHeight = 40;
                Rectangle snoutRect = new Rectangle(centerX - snoutWidth / 2, centerY - 10, snoutWidth, snoutHeight);

                using (SolidBrush snoutBrush = new SolidBrush(outlineColor))
                using (Pen snoutPen = new Pen(Color.DarkRed, 2))
                {
                    g.FillEllipse(snoutBrush, snoutRect);
                    g.DrawEllipse(snoutPen, snoutRect);
                    using (SolidBrush nostrilBrush = new SolidBrush(Color.FromArgb(180, 40, 70)))
                    {
                        g.FillEllipse(nostrilBrush, centerX - 15, centerY, 10, 18);
                        g.FillEllipse(nostrilBrush, centerX + 5, centerY, 10, 18);
                    }
                }

                int eyeWidth = 26, eyeHeight = 20, eyeOffsetX = 22, eyeY = centerY - 40;
                Rectangle leftEye = new Rectangle(centerX - eyeOffsetX - eyeWidth / 2, eyeY, eyeWidth, eyeHeight);
                Rectangle rightEye = new Rectangle(centerX + eyeOffsetX - eyeWidth / 2, eyeY, eyeWidth, eyeHeight);

                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                using (SolidBrush pupilBrush = new SolidBrush(Color.Black))
                using (Pen eyePen = new Pen(Color.Black, 2))
                {
                    if (eyesOpen)
                    {
                        g.FillEllipse(whiteBrush, leftEye);
                        g.FillEllipse(whiteBrush, rightEye);
                        g.DrawEllipse(eyePen, leftEye);
                        g.DrawEllipse(eyePen, rightEye);
                        g.FillEllipse(pupilBrush, centerX - eyeOffsetX - 5, eyeY + 6, 10, 10);
                        g.FillEllipse(pupilBrush, centerX + eyeOffsetX - 5, eyeY + 6, 10, 10);
                    }
                    else
                    {
                        using (Pen lidPen = new Pen(Color.Black, 3))
                        {
                            g.DrawLine(lidPen, leftEye.Left, leftEye.Top + eyeHeight / 2, leftEye.Right, leftEye.Top + eyeHeight / 2);
                            g.DrawLine(lidPen, rightEye.Left, rightEye.Top + eyeHeight / 2, rightEye.Right, rightEye.Top + eyeHeight / 2);
                        }
                    }
                }

                using (Pen mouthPen = new Pen(Color.DarkRed, 3) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                {
                    Rectangle mouthRect = new Rectangle(centerX - 30, centerY + 20, 60, 30);
                    g.DrawArc(mouthPen, mouthRect, 10, 160);
                }

                using (SolidBrush hatBrush = new SolidBrush(outlineColor))
                using (Pen hatPen = new Pen(outlineColor, 3))
                {
                    Rectangle hatRect = new Rectangle(centerX - 35, centerY - bodyRadius - 10, 70, 30);
                    g.FillEllipse(hatBrush, hatRect);
                    g.DrawBezier(hatPen, centerX, hatRect.Top, centerX + 10, hatRect.Top - 20, centerX - 10, hatRect.Top - 30, centerX + 5, hatRect.Top - 40);
                }

                using (SolidBrush flowerBrush = new SolidBrush(Color.FromArgb(255, 80, 120)))
                using (SolidBrush flowerCenterBrush = new SolidBrush(Color.OrangeRed))
                {
                    int flowerCenterX = centerX + bodyRadius - 30;
                    int flowerCenterY = centerY - bodyRadius + 20;
                    int petalRadius = 10;

                    for (int i = 0; i < 5; i++)
                    {
                        double angle = i * 2 * Math.PI / 5;
                        int px = flowerCenterX + (int)(Math.Cos(angle) * petalRadius * 1.6);
                        int py = flowerCenterY + (int)(Math.Sin(angle) * petalRadius * 1.6);
                        g.FillEllipse(flowerBrush, px - petalRadius, py - petalRadius, petalRadius * 2, petalRadius * 2);
                    }

                    g.FillEllipse(flowerCenterBrush, flowerCenterX - petalRadius, flowerCenterY - petalRadius, petalRadius * 2, petalRadius * 2);
                }
            }
        }
    }



