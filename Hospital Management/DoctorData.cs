using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class DoctortData
    {
        private string[] lines = System.IO.File.ReadAllLines("doctors.txt");

        public DoctortData()
        {
            ReadFile();
        }

        public void AddUser(string name, int age, string gender, string phone,string history)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("doctors.txt");
            for (int i = 0; i < lines.Length; i++)
                writer.WriteLine(lines[i]);
            writer.WriteLine(UserData.username);
            writer.WriteLine(name);
            writer.WriteLine(age);
            writer.WriteLine(gender);
            writer.WriteLine(phone);
            writer.WriteLine(history);
            writer.Close();
        }
        public void ReadFile()
        {
            for (int i = 0; i < lines.Length; i += 6)
            {
                Doctor doctor = new Doctor()
                {
                    Username = lines[i],
                    Name = lines[i + 1],
                    Age = Convert.ToInt32(lines[i + 2]),
                    Gender = lines[i + 3],
                    Phone = lines[i + 4],
                    PatientHistory = lines[i + 5]
                };
                AllMembers.DoctorList.Add(doctor);
            }
        }
        public Doctor FindDoctorByName(string name)
        {
            for (int i = 0; i < AllMembers.DoctorList.Count; i++)
            {
                if (AllMembers.DoctorList[i].Name == name)
                    return AllMembers.DoctorList[i];
            }
            return AllMembers.DoctorList[1];
        }
    }
}