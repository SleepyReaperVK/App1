using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public interface IRepository<T>
    {
        /// <summary>
        /// adds LibraryItem to LibraryItems type
        /// </summary>
        T Add(T item);
        /// <summary>
        /// returns LibraryItems ,Witch is .   
        /// </summary>
        IQueryable<T> Get();
        /// <summary>
        /// returns LibraryItem using Property Guid
        /// </summary>
        T Get(Guid id);

        T Update(T item);
        /// <summary>
        /// Delete LibraryItem using Property Guid 
        /// </summary>
        T Delete(Guid id);

        #region Is it neede?

        /// <summary>
        /// Returns LibraryItem if found else null
        /// </summary>
        T Find(string title);
        /// <summary>
        /// Returns List<LibraryItem >
        /// </summary>
        List<T> List();

        #endregion

    }
}
