using Library.DAL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{ 


    public sealed partial class Menu : Page
    {
        public readonly IRepository<LibraryItem> _db;
        public Menu()
        {
            this.InitializeComponent();
            _db = new LibraryDB();
            updateBookList();


        }
        public void updateBookList()
        {
            ListBook.Items.Clear();

            foreach (var x in _db.Get())
            {
                ListViewItem b = new ListViewItem();
                b.Content = $"{x.Title} | {x.PublishDate:d} | {x.Price} ";
                b.Name = x.Title;
                ListBook.Items.Add(b);
                b.Tapped += B_Tapped;
            }

        }
        public void updateBookList(List<LibraryItem> t)
        {
            ListBook.Items.Clear();
            foreach (var x in t)
            {
                ListViewItem b = new ListViewItem();
                b.Content = $"{x.Title} | {x.PublishDate:d}  | {x.Price} ";

                if (_db.Find(x.Title) == null)
                    _db.Add(x);

                ListBook.Items.Add(b);
                b.Tapped += B_Tapped;
            }
        }
        public LibraryItem FindInList(ListViewItem x)
        {
            LibraryItem item = _db.Find((string)x.Name);

            if (item == null)
            {
                throw new Exception(Name + " Error Item");
            }
            else
            {
                return item;
            }


        }

        public void B_Tapped(object sender, TappedRoutedEventArgs e)//send should be always and UI obj , this sender is ListViewItem//
        {
            
            this.Frame.Navigate(typeof(Info), sender);


        }

        private void byTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _db.List().Sort((book1, book2) => book1.Title.CompareTo(book2.Title));
            updateBookList();

        }

        private void byDate_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _db.List().Sort((book1, book2) => book1.PublishDate.CompareTo(book2.PublishDate));
            updateBookList();
        }

        private void byPriceHL_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _db.List().Sort((book1, book2) => book1.Price.CompareTo(book2.Price));
            updateBookList();
        }

        private void byPriceLH_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _db.List().Sort((book1, book2) => book2.Price.CompareTo(book1.Price));
            updateBookList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddBook));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)// if e.parametar is repo it came from addbook \\ if LibraryItem then or Remove book or Edit Book
        {
            base.OnNavigatedTo(e);
            Debug.WriteLine(e.Content);
            Debug.WriteLine(e.Parameter);

                //if (e.Parameter != null)
                //    if (e.Parameter.GetType() == typeof(Book))//Book to edit / remove from _repo
                //    {
                //        Book x = (Book)e.Parameter;
                //        Debug.WriteLine("Test1");

                //    }
                //    else if (e.Parameter.GetType() == typeof(Journal))//Jornel to edit / remove from _repo
                //    {
                //        Journal x = (Journal)e.Parameter;
                //        Debug.WriteLine("Test2");

                //    }
                //    else if (e.Parameter.GetType() == typeof(List<LibraryItem>))//book is added
                //    {
                //        Debug.WriteLine("Test3");

                //    }
        }
    }
}
