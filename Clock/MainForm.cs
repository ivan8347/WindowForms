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

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture); // 12 часов
            //labelTime.Text = DateTime.Now.ToString("HH:mm:ss "); //24 часа
            if (checkBoxShowDate.Checked)
                labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            if (checkBoxWeekDay.Checked)
                labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
        }
        // void SetVisiblity(bool visible)
        // {
        //checkBoxShowDate.Visible = visible;
        //checkBoxWeekDay.Visible =  visible;
        //    this.FormBorderStyle = FormBorderStyle.None;
            
        //    this.TransparencyKey = this.BackColor;
        //    buttonHideControls.Visible = false;
        //    //this.ShowInTaskbar = false;
        //}
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            checkBoxShowDate.Visible = false;
            checkBoxWeekDay.Visible = false;
            this.FormBorderStyle = FormBorderStyle.None;
            
            this.TransparencyKey = this.BackColor;
            buttonHideControls.Visible = false;
            //this.ShowInTaskbar = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            checkBoxShowDate.Visible = true;
            checkBoxWeekDay.Visible =  true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            this.TransparencyKey = Color.Empty;
            buttonHideControls.Visible = false;
            this.ShowInTaskbar = true;
        }

        
    }
}
