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
using System.Reflection;
using Microsoft.Win32;
using System.Drawing.Drawing2D;






namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tsmiAutostart.Checked = Properties.Settings.Default.RunOnStartup;                   //загрузка Windows
                                                                                                
            bool savedFormat = Properties.Settings.Default.Is24HourFormat;                      // Формат времени
            tsmiHour_24.Checked = !savedFormat;
            tsmiHour_12.Checked = savedFormat;

            checkBoxShowDate.Checked = Properties.Settings.Default.ShowDate;                    // Дата
            tsmiShowDate.Checked = checkBoxShowDate.Checked;
            checkBoxShowWeekDay.Checked = Properties.Settings.Default.ShowWeekDay;              // День недели
            tsmiShowWeekDay.Checked = checkBoxShowWeekDay.Checked;


            labelTime.ForeColor = Color.FromName(Properties.Settings.Default.ForegroundColor);  // Цвет букв
            tsmiForegroundColor.Click += tsmiForegroundColor_Click;
            labelTime.BackColor = Color.FromName(Properties.Settings.Default.BackgroundColor);  // Цвет фона
            tsmiBackgroundColor.Click += tsmiBackgroundColor_Click;

            tsmiTopmost.Checked = Properties.Settings.Default.IsTopMost;                        // Закрепление на экране

            this.StartPosition = FormStartPosition.Manual;                                      // Стартовая позиция
            var screen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point(screen.Right - this.Width, screen.Top);

            if (Properties.Settings.Default.UseCustomFont)                                      // Кастомный шрифт
            {
                string fontPath = "";
                string fontName = Properties.Settings.Default.FontName;

                if (fontName == "Digital-7 Mono")
                    fontPath = Path.Combine(Application.StartupPath, "digital-7 (mono).ttf");
                else if (fontName == "Ocular Doom")
                    fontPath = Path.Combine(Application.StartupPath, "OcularDoom-Regular.ttf");

                if (!string.IsNullOrEmpty(fontPath) && File.Exists(fontPath))
                    LoadFontFromFile(fontPath);
            }
            else
            {
                var font = new Font(                                                                // Windows шрифт
                    Properties.Settings.Default.FontName,
                    Properties.Settings.Default.FontSize,
                    (FontStyle)Properties.Settings.Default.FontStyle
                );
                labelTime.Font = font;
            }
            string selectedFont = Properties.Settings.Default.FontName;

            tsmiWindows.Checked = !Properties.Settings.Default.UseCustomFont;                       // галочки для шрифта
            tsmiCastom.Checked = Properties.Settings.Default.UseCustomFont;
            tsmiDigital.Checked = (selectedFont == "Digital-7 Mono");
            tsmiDoom.Checked = (selectedFont == "Ocular Doom");

            SetVisibility(false);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (tsmiHour_12.Checked)
            { labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture); } // 12 часов
            if (tsmiHour_24.Checked) { labelTime.Text = DateTime.Now.ToString("HH:mm:ss "); } //24 часа
            if (checkBoxShowWeekDay.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now.ToString("dd.MM.yyyy")}";
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
        private void buttonHideControls_Click(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = false);
        private void labelTime_DoubleClick(object sender, EventArgs e) =>
            SetVisibility(tsmiShowControls.Checked = true);
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
                    tsmiWindows.Checked = true;
                    tsmiCastom.Checked = false;
                    tsmiDigital.Checked = false;
                    tsmiDoom.Checked = false;
                    Properties.Settings.Default.FontName = fontDialog.Font.Name;
                    Properties.Settings.Default.FontSize = fontDialog.Font.Size;
                    Properties.Settings.Default.FontStyle = (int)fontDialog.Font.Style;
                    Properties.Settings.Default.UseCustomFont = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
        PrivateFontCollection privateFonts = new PrivateFontCollection();
        void LoadFontFromFile(string fontPath)
        {
           
            privateFonts.Dispose();
            privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile(fontPath);
           // MessageBox.Show("Загружен шрифт: " + privateFonts.Families[0].Name);

            Font customFont = new Font(privateFonts.Families[0], 32f, FontStyle.Regular);
            labelTime.Font = customFont;
        }

        private void tsmiDigital_Click(object sender, EventArgs e)
        {
            string fontPath = Path.Combine(Application.StartupPath, "digital-7 (mono).ttf");
            LoadFontFromFile(fontPath);
            tsmiWindows.Checked = false;
            tsmiCastom.Checked = true;
            tsmiDigital.Checked = true;
            tsmiDoom.Checked = false;

            Properties.Settings.Default.FontName = privateFonts.Families[0].Name;
            Properties.Settings.Default.UseCustomFont = true;
            Properties.Settings.Default.Save();
        }

        private void tsmiDoom_Click(object sender, EventArgs e)
        {
            string fontPath = Path.Combine(Application.StartupPath, "OcularDoom-Regular.ttf");
            LoadFontFromFile(fontPath);
            tsmiWindows.Checked = false;
            tsmiCastom.Checked = true;
            tsmiDigital.Checked = false;
            tsmiDoom.Checked = true;


            Properties.Settings.Default.FontName = privateFonts.Families[0].Name;
            Properties.Settings.Default.UseCustomFont = true;
            Properties.Settings.Default.Save();
        }


        void SetStartup(bool enable)
        {
            string appName = "Clock";
            string exePath = Application.ExecutablePath;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
                key.SetValue(appName, exePath);
            else
                key.DeleteValue(appName, false);
        }
        private void tsmiAutostart_Click(object sender, EventArgs e)
        {
            bool enable = tsmiAutostart.Checked;
            SetStartup(enable);

            Properties.Settings.Default.RunOnStartup = enable;
            Properties.Settings.Default.Save();
        }
    }
}
