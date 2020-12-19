using System;
using System.Collections.Generic;
using System.Text;

namespace Users
{
    public class User
    {
        private string name;
        private string surname;
        private string phone;
        private int password;

        public User() { }
        public User(string name, string surname, string phone,int password)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.password = password;
        }

        public string GetPhone()
        {
            return phone;
        }
        public void SetPhone(string phone)
        {
            this.phone = phone;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public int GetPassword()
        {
            return password;
        }
    }
}
