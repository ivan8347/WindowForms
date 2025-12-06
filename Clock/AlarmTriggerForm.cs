using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class AlarmTriggerForm : Form
    {
        Form parent;
        public bool Snooze { get; private set; } = false;
        public AlarmTriggerForm() //(string message)
        {
            InitializeComponent();
        }
        public AlarmTriggerForm(Form parent,string message) : this()
        {
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Snooze = false;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnSnooze_Click(object sender, EventArgs e)
        {
            Snooze = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void AlarmTriggerForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X - 150, parent.Location.Y + 200);
        }
    }
}
