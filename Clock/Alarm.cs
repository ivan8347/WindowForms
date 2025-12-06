using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Clock
//{
//    public class Alarm
//    {
//        public DateTime Date {  get; set; }
//        public DateTime Time { get; set; }
//        public byte Weekdays {  get; set; }
//        public string Filename {  get; set; }
//        public void WeekdaysFromArray(int[]days)
//        {
//            if (days.Length > 7) return;
//            for (int i = 0; i < days.Length; i++)
//            {
//                 Weekdays |= (byte) (1<< days[i]);
//                //for (int i = 0; i < clbWeekdays.Items.Count; i++)
//                //    checkedListBoxWeekdays.SetItemChecked(i, days[i]);
//            }
//        }
//        public override string ToString()
//        {
//            return $"{Date.ToString("dd.MM.yyyy")}  {Time.ToString("hh:mm:ss tt")}  {Weekdays}  {Filename.Split('\\').Last()}";
//        } 
//    }
//}
namespace Clock
{
    public class Alarm
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public byte Weekdays { get; set; }
        public string Filename { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Triggered { get; set; } = false;
        public string Message { get; set; } = "";
        public bool IsToday()
        {
            int today = (int)DateTime.Now.DayOfWeek; 
            return (Weekdays & (1 << today)) != 0;
        }
        public void WeekdaysFromArray(int[] days)
        {
            Weekdays = 0;
            foreach (var d in days)
            {
                if (d >= 0 && d <= 6)
                    Weekdays |= (byte)(1 << d);
            }
        }
        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy} {Time:HH:mm:ss} {Weekdays} {System.IO.Path.GetFileName(Filename)} {Message}";
        }
    }
}

