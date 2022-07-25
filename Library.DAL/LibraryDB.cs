using Library.Model;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class LibraryDB : IRepository<LibraryItem>
    {
        DataMock _context = DataMock.Instance;

        private static LibraryItem _currentitem;
        public static LibraryItem CurrentItem
        {
            get
            {
                return _currentitem;
            }
            set
            {
                if (_currentitem == null)
                    _currentitem = value;
            }
        }

        public LibraryItem Add(LibraryItem item)
        {
            _context.LibraryItems.Add(item);

            return item;
        }
        /// <summary>
        /// Returns the First LibraryItem is the List "LibraryItems".
        /// </summary>
        public LibraryItem Current(LibraryItem str)
        {
            return _context.LibraryItems.First();
        }

        public LibraryItem Delete(Guid id)
        {
            var item = _context.LibraryItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _context.LibraryItems.Remove(item);
            return item;
        }


        public LibraryItem Find(string title)
        {
            foreach (var x in _context.LibraryItems)
            {
                if (x.Title == title)
                    return x;
            }
            return null;
        }



        public IQueryable<LibraryItem> Get()
        {
            return _context.LibraryItems.AsQueryable();
        }

        public LibraryItem Get(Guid id)
        {
            return _context.LibraryItems.FirstOrDefault(i => i.Id == id);
        }

        public List<LibraryItem> List()//should be used needs replaceing
        {
            return _context.LibraryItems;
        }

        public LibraryItem Update(LibraryItem item)
        {
            var old = _context.LibraryItems.FirstOrDefault(i => i.Id == item.Id);
            if (old != null)
            {
                _context.LibraryItems.Remove(old);
                _context.LibraryItems.Add(item);
            }
            return item;
        }


    }
}
