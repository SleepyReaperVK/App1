using Library.Model;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public  class UserDB : IRepository<Person>

    {

        DataMock _context = DataMock.Instance;

        private static Person _currentuser;
        public static Person CurrentUser 
        { 
            get 
            {
                return _currentuser;
            }
            set
            {
   
            if(_currentuser == null )
                    _currentuser = value;
            }
        }


        public Person Add(Person item)
        {
            _context.Users.Add(item);

            return item;
        }

        public Person Delete(Guid id)
        {
            var item = _context.Users.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.Users.Remove(item);
            return item;
        }

        public Person Find(string username)
        {
            foreach (var x in _context.Users)
            {
                if (x == null)
                    _context.Users.Remove(x);
                else
                if (x.UserName == username)
                    return x;
            }
            return null;
        }

        public IQueryable<Person> Get()
        {
            return _context.Users.AsQueryable();
        }

        public Person Get(Guid id)
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
        }

        public List<Person> List()
        {
            return _context.Users;
        }

        public Person Update(Person item)
        {
            var old = _context.Users.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.Users.Remove(old);
                _context.Users.Add(item);
            }
            return item;
        }

        /// <summary>
        /// Returns Property From type Person, CurrentUser.
        /// </summary>
        public Person Current(Person user)
        {
            if (user != null)
            {
                return CurrentUser = user;
            }

            return _currentuser;
        }
    }
}
