using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class Patient : Person
    {
        public Calendar Date { get; set; }
        public string Address { get; set; }
        public string Disease { get; set; }
        public string StatusOfDisease { get; set; }
        public static int numberOfPatients;

        public Patient()
        {
            numberOfPatients++;
        }
    }
}
