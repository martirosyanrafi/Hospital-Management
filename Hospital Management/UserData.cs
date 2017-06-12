using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management
{
    public class UserData
    {
        private string[] lines = System.IO.File.ReadAllLines("passwords.txt");
        public static string username = "user";

        public string HidePassword(string password)
        {
            string newPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                int a = Convert.ToInt32(password[i]);
                a = ((~a) << 1) + 500;
                newPassword += a;
            }
            return newPassword;
        }
        public string FindPassword(string password)
        {
            string newPassword = "";
            for (int i = 0; i < password.Length; i += 3)
            {
                int a = Convert.ToInt32(password.Substring(i, 3));
                a = ~((a - 500) >> 1);
                newPassword += Convert.ToChar(a);
            }
            return newPassword;
        }
        public void AddUser(string name,string username, string password)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("passwords.txt");
            for (int i = 0; i < lines.Length; i++)
                writer.WriteLine(lines[i]);
            writer.WriteLine(name);
            writer.WriteLine(username);
            writer.WriteLine(HidePassword(password));
            writer.Close();
        }
        public bool checkUserExistence(string username, string password)
        {
            for (int i = 0; i < lines.Length; i += 3)
            {
                if (lines[i+1] == username)
                {
                    if (FindPassword(lines[i + 2]) == password)
                    {
                        UserData.username = lines[i+1];
                        return true;
                    }
                }
            }
            return false;
        }
        public bool checkUsernameRepeation(string username)
        {
            for (int i = 1; i < lines.Length; i += 3)
            {
                if (lines[i] == username)
                {
                    return true;
                }
            }
            return false;
        }
        public int getNumberOfPatients()
        {
            return lines.Length / 3;
        }
    }
}