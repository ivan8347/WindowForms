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
        Form parent;
        public AlarmsForm()
        {
            InitializeComponent();

        }
        public AlarmsForm(Form parent):this()
        {
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAlarmForm alarmDialog = new AddAlarmForm(this);
           if(alarmDialog.ShowDialog() == DialogResult.OK)
            {
                lbAlarmList.Items.Add(alarmDialog.Alarm);
            }

        }

        private void AlarmsForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X - 200, parent.Location.Y + 150);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                lbAlarmList.Items.Remove(lbAlarmList.SelectedItem);
        }
    }

}
