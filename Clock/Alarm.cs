using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
    public class Alarm:IComparable
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
        public Alarm() { }

        public Alarm(DateTime time, string filename, string message)
        {
            Time = time;
            Filename = filename;
            Message = message;
            Triggered = false;
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
        public string WeekdaysToString()
        {
            string[] names = { "Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб" };
            List<string> result = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                if ((Weekdays & (1 << i)) != 0)
                    result.Add(names[i]);
            }

            return result.Count > 0 ? string.Join(" ", result) : "-";
        }


        /*  public int CompareTo(object other)
          {
              return this.Date.CompareTo((other as Alarm).Date) + this.Time.CompareTo((other as Alarm).Time);
          }*/
        public int CompareTo(object obj)
        {
            Alarm other = obj as Alarm;
            if (other == null) return 1;

            // Сначала сравниваем дату
            int dateCompare = this.Date.Date.CompareTo(other.Date.Date);
            if (dateCompare != 0)
                return dateCompare;

            // Если даты одинаковые — сравниваем время
            return this.Time.TimeOfDay.CompareTo(other.Time.TimeOfDay);
        }


        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy} {Time:HH:mm:ss} [{WeekdaysToString()}] {Path.GetFileName(Filename)} {Message}";

        }

    }
}

