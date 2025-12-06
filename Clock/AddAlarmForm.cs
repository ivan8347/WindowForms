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
    public partial class AddAlarmForm : Form
    {
        Form parent;
       public Alarm Alarm { get; private set; }
        OpenFileDialog fileDialog;

        public AddAlarmForm()
        {
            InitializeComponent();

            dtpDate.Enabled = cbUseDate.Checked;
            fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files |*.mp3;*.flacc|MP-3 file (*.mp3)|*.mp3|Flac files (*.flacc)|*.flacc";

            Alarm = new Alarm();
        }
        public AddAlarmForm(Form parent) : this()
        {
            this.parent = parent;
            this.StartPosition = FormStartPosition.Manual;
        }

        private void chUseDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = cbUseDate.Checked;
            clbWeekDays.Enabled = !cbUseDate.Checked;
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            lblFile.Text = fileDialog.FileName;
        }
        private void AddAlarmForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(parent.Location.X + 15, parent.Location.Y + 20);
            this.TopMost = true;
           // this.TopMost = false;
        }

        private void clbWeekDays_MouseUp(object sender, MouseEventArgs e)
        {
            string weekdays = "";
           //string indexes = "";
            for (int i = 0; i < (sender as CheckedListBox).CheckedItems.Count; i++)
            {
                weekdays += (sender as CheckedListBox).CheckedItems[i] + "\t";
                weekdays += (sender as CheckedListBox).CheckedIndices[i] + "\t";

            }
           // MessageBox.Show($"{weekdays}\n{indexes}");
        }
        public int[] WeekdaysToArray()
        {
            List<int> days = new List<int>();
            foreach (int i in clbWeekDays.CheckedIndices)
            {
                days.Add(i);
            }
            return days.ToArray();

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Alarm.Date = dtpDate.Value;
            Alarm.Time = dtpTime.Value;
            Alarm.Filename = lblFile.Text;
            Alarm.WeekdaysFromArray (WeekdaysToArray());
           
            // Alarm.Weekdays = clbWeekDays.CheckedIndices;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
