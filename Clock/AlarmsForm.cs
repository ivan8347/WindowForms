using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AlarmsForm : Form
    {
        public AlarmsForm()
        {
            InitializeComponent();

        }

        private void Alarm_Load(object sender, EventArgs e)
        {
        

            //public override string ToString()
            //{
            //    return $"{Time:HH:mm} | {(Enabled ? "Вкл" : "Выкл")} | {Path.GetFileName(SoundPath)}";
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAlarmForm addAlarm = new AddAlarmForm();
            addAlarm.ShowDialog();
        }
    }

}
