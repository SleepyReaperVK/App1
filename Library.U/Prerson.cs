using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Users
{
     public abstract class Person 
    {
        /// <summary>
        /// unique identifier of this Person
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// returns string UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// returns bool if Person is admin , default is false
        /// </summary>
        public bool IsAdmin { get; set; }

        protected Person(string  user )
        {
            Id = Guid.NewGuid();
            UserName = user;
            IsAdmin = false;
        }
    }
}

