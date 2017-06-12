using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Calendar
    {
        private int day;
        private int month;
        private int year;
        private int hour;

        public Calendar(string date, int hour)
        {
            ConvertToInt(date);
            this.hour = hour;
        }
        public Calendar(int day, int month, int year, int hour)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.hour = hour;
        }

        private void ConvertToInt(string date)
        {
            day = Convert.ToInt32(date.Substring(0, 2));
            month = Convert.ToInt32(date.Substring(3, 2));
            year = Convert.ToInt32(date.Substring(6, 4));
        }
        public override string ToString()
        {
            return day + " " + month + " " + year + " " + hour;
        }
    }
}
