using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library.Users
{
    public class Employee : Person
    {
        private string _password = string.Empty;

        
        private StreamWriter _whitlist = new StreamWriter("C:\\WhiteList.txt");
        protected string Password { get { return _password; } set {
                if (value != string.Empty)
                    _password = value;
                else
                    throw new ArgumentException("Password cannot be empty", value);
            } }

        public Employee(string user , string password) : base(user)
        {
            IsAdmin= true;
            Password = password;
            _whitlist.WriteLine($"{user}$\t{password}*");
        }
    }
}
