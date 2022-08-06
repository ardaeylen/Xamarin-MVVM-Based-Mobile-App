using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Last.Models
{
    public class User
    {
        private int userid;
        private string name;
        private string surname;
        private string username;
        private string password;
        public User() { }
        public int UserId { get => userid; set => userid = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string UserName { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }


    }
}