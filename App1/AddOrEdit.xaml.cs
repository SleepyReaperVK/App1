using Library.DAL;
using Library.Model;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    /// <summary>
    ///  AddBook page is used to Add new Item to the DataBase 
    ///  AddBook page is used to Edit existing Items 
    /// </summary>
    public sealed partial class AddOrEdit : Page
    {
        public readonly IRepository<LibraryItem> _db;
        public bool DatePickChanged = false;
        private LibraryItem tempItem;
        private bool isEdit;

        public AddOrEdit()
        {
            this.InitializeComponent();
            _db = new LibraryDB();
            this.Loaded += Info_Loaded;
            this.Unloaded += AddBook_Unloaded;
            DatePick.DateChanged += DatePick_DateChanged;
            Country.ItemsSource = ISBN.Countries.Keys;
            Publisher.ItemsSource = ISBN.Publishers.Keys;
            isEdit = false;




        }

        private void DatePick_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DatePickChanged = true;
        }

        private void AddBook_Unloaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void Info_Loaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Info_BackRequested;

        }

        private void Info_BackRequested(object sender, BackRequestedEventArgs e)/// why go back with LibraryItem
        {
            this.Frame.Navigate(typeof(Menu)); // Parametar should be with UIElement
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) // e.paremeter is .... // create new book and add to LibraryItems is _db//
        {
            if(e.Parameter != null)// is Edit
             if ((e.Parameter.GetType()).BaseType == typeof(LibraryItem))
            {
                isEdit = true;
                tempItem = (LibraryItem)e.Parameter;
                DisplayInfo();
            }
            if(e.Parameter == null)// is Add
            {

            }

        }

        public void DisplayInfo()// Edit func
        {
            if (tempItem != null)
            {

                if (tempItem.GetType() == (typeof(Book)))
                {
                    LeftS.Visibility = Visibility.Visible;
                    Synapsis.Visibility = Visibility.Visible;
                    EditOrAddBook.Visibility = Visibility.Visible;
                    BookInput.Visibility = Visibility.Visible;
                    ChooseCanvas.Visibility = Visibility.Collapsed;
                    EditOrAddBook.Content = "update";

                    Book book = (Book)tempItem;
                    Title.Text = book.Title;
                    Auther.Text = ListTools.MakeStringFromList(book.Authors);
                    Genres.PlaceholderText = ListTools.MakeStringFromList(book.Genres);
                    DatePick.Date = book.PublishDate;
                    Country.PlaceholderText = book.Isbn.Country;
                    Publisher.PlaceholderText = book.Publisher;
                    Synapsis.Text = book.Synopsis;
                    Price.Text = book.Price+string.Empty;
                }
                else if (tempItem.GetType() == (typeof(Journal)))
                {

                    LeftS.Visibility = Visibility.Visible;
                    JournalInput.Visibility = Visibility.Visible;
                    ChooseCanvas.Visibility = Visibility.Collapsed;

                    Journal journal = (Journal)tempItem;
                    TitleJ.Text = journal.Title;
                    AutherJ.Text = ListTools.MakeStringFromList(journal.Editors);
                    GenresJ.Header = ListTools.MakeStringFromList(journal.Ganres);
                    GenresJ.PlaceholderText = "Add Genres";
                    DatePickJ.Date = journal.PublishDate;
                    CountryJ.PlaceholderText = "Frequncy"; 
                    CountryJ.ItemsSource = Enum.GetNames(typeof(JournalFrequency));
                    PriceJ.Text = journal.Price + string.Empty;

                }

            }

        }

        private void EditOrAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (!checkWrongFieleds())//check if any field are wrong , returns true if so.\\\
            {
                if (isEdit)//if editing
                    if (tempItem.GetType() == (typeof(Book)))
                    {
                        BookInput.Visibility = Visibility.Visible;
                        Book tempItem = new Book(Title.Text, DatePick.Date.DateTime, 0, Country.SelectionBoxItem.ToString());
                        tempItem.Authors.Clear();
                        tempItem.Authors.Add(Auther.Text);
                        tempItem.Genres.Add(Genres.Text);
                        tempItem.Price =int.Parse(Price.Text);
                        
                        _db.Update(tempItem);
                    }
                else if (tempItem.GetType() == (typeof(Journal)))
                    {
                        tempItem = new Journal(Title.Text, DatePick.Date.DateTime);
                        _db.Update(tempItem);
                    }
                //if Adding new Item

                if (tempItem.GetType() == (typeof(Book)))
                {
                    _db.Add(tempItem);
                }
                else if (tempItem.GetType() == (typeof(Journal)))
                {
                    _db.Add(tempItem);
                }



                this.Frame.Navigate(typeof(Menu));
            }
            //Book tempItem = new Book(Title.Text, DatePick.Date.DateTime, 200, Country.SelectionBoxItem.ToString());
            //tempItem.Publisher = Publisher.SelectedItem.ToString();// need to make sure is valid
            //tempItem.Price = int.Parse(Price.Text);// need to make sure is valid
            //tempItem.Synopsis = Synapsis.Text;
            //_db.Add(tempItem);
        }

        private bool checkWrongFieleds()
        {
            bool haveWrongField = false;



            if (Title.Text == "" && Title.Text.Trim().Length < 7)//cand add !haveWrongField to other ifs to check faster
            {
                Title.Header = "Invalid Input";
                haveWrongField = true;
            }
            else
            {
                Title.Header = string.Empty;
            }

            if (Auther.Text == string.Empty && !Book.KnownAuthors.Contains(Auther.Text))
            {
                Auther.Header = "Invalid Input, select a Valid Auter";
                haveWrongField = true;
            }
            else
            {
                Auther.Header = string.Empty;
            }

            if (Country.SelectionBoxItem == null)
            {
                Country.Header = "Invalid Country , select Valid Country";
                haveWrongField = true;
            }
            else
            {
                if (!ISBN.Countries.ContainsKey(Country.SelectionBoxItem.ToString()))
                {
                    Country.Header = "Invalid Country , select Valid Country";
                    haveWrongField = true;
                }
                else
                {
                    Country.Header = string.Empty;
                }
            }

            if (Publisher.SelectedItem == null)
            {
                Publisher.Header = "Invalid input , select Valid Publisher ";
                haveWrongField = true;
            }
            else
            {
                Publisher.Header = string.Empty;
            }

            if (Synapsis.Text == string.Empty)
            {
                Synapsis.Header = "Please add Synapsis";
                haveWrongField = true;
            }
            else
            {
                Synapsis.Header = "Synapsis:";
            }

            if(!DatePickChanged)
            {
                DatePick.Header = "Please add Synapsis";
                haveWrongField = true;
            }
            else
            {
                DatePick.Header = string.Empty;
            }

            return haveWrongField;
        }

        private void ChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ChooseToAdd.SelectedIndex == 1)
            {
                LeftS.Visibility = Visibility.Visible;
                Synapsis.Visibility = Visibility.Visible;
                EditOrAddBook.Visibility = Visibility.Visible;
                BookInput.Visibility = Visibility.Visible;
                ChooseCanvas.Visibility = Visibility.Collapsed;
            }
            else if(ChooseToAdd.SelectedIndex == 2)
            {
                LeftS.Visibility = Visibility.Visible;
                JournalInput.Visibility = Visibility.Visible;
                ChooseCanvas.Visibility = Visibility.Collapsed;
            }

        }
    }
}
