using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class PatientData
    {
        private string[] lines = System.IO.File.ReadAllLines("patients.txt");

        public PatientData()
        {
            ReadFile();
        }
        
        public void AddUser(string name, int age, string gender, Calendar date, string phone, string address, string disease)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("patients.txt");
            for (int i = 0; i < lines.Length; i++)
                writer.WriteLine(lines[i]);
            writer.WriteLine(UserData.username);
            writer.WriteLine(name);
            writer.WriteLine(age);
            writer.WriteLine(gender);
            writer.WriteLine(date);
            writer.WriteLine(phone);
            writer.WriteLine(address);
            writer.WriteLine(disease);
            writer.Close();
        }
        public void ReadFile()
        {
            for(int i =0; i < lines.Length; i+=8)
            {
                Patient patient = new Patient()
                {
                    Username = lines[i],
                    Name = lines[i + 1],
                    Age = Convert.ToInt32(lines[i + 2]),
                    Gender = lines[i+3],
                    Date = new Calendar(10,10,10,10),
                    Phone = lines[i + 5],
                    Address = lines[i+6],
                    Disease = lines[i+7],
                };
                AllMembers.PatientList.Add(patient);
            }
        }
        public Patient FindPatientByName(string name)
        {
            for (int i = 0; i < AllMembers.PatientList.Count; i++)
            {
                if (AllMembers.PatientList[i].Name == name)
                    return AllMembers.PatientList[i];
            }
            return AllMembers.PatientList[1];
        }
        }
}
