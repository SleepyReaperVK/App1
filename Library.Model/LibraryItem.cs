using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public abstract class LibraryItem
    {
        /// <summary>
        /// unique identifier of this item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// title of name of item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// print or publish date of item
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// price of item in Int
        /// </summary>
        public int Price { get; set ; } 

        /// <summary>
        /// create a instance of library item
        /// </summary>
        /// <param name="title">the name or title of the new item</param>
        /// <param name="publishDate">the orint or publish date of the new item</param>
        protected LibraryItem(string title, DateTime publishDate)
        {
            Id = Guid.NewGuid();
            Title = title;
            PublishDate = publishDate;
            Price = 0;
        }
    }
}
    
