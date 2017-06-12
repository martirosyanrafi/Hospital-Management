using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    class AllMembers
    {
        public static List<Patient> PatientList = new List<Patient>();
        public static List<Admin> AdminsList = new List<Admin>();
        public static List<Doctor> DoctorList = new List<Doctor>();

        
        private void ReadPatientsFile()
        {
            string[] patient;
            try {
            patient = System.IO.File.ReadAllLines("patients.txt");
                 }
            catch
            {
                patient = null; 
            }
        }
        private void ReadDoctorsFile()
        {
            string[] doctor;
            try
            {
                doctor = System.IO.File.ReadAllLines("doctors.txt");
            }
            catch
            {
                doctor = null;
            }
        }
        private void ReadAdminsFile()
        {
            string[] admin;
            try
            {
                admin = System.IO.File.ReadAllLines("admins.txt");
            }
            catch
            {
                admin = null;
            }
        }
        public static void RequestForConsultation(string name, int age, string gender, Calendar date, string phone, string address, string disease)
        {
            Patient patient = new Patient()
            {
                Name = name,
                Age = age,
                Gender = gender,
                Phone = phone,
                Date = date,
                Address = address,
                Disease = disease
            };
            PatientList.Add(patient);
        }
    }
}
