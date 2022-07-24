﻿using Library.DAL;
using Library.Model;
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
    public sealed partial class AddBook : Page
    {
        public readonly IRepository<LibraryItem> _db;
        public bool DatePickChanged = false;
        public AddBook()
        {
            this.InitializeComponent();
            _db = new LibraryDB();
            this.Loaded += Info_Loaded;
            this.Unloaded += AddBook_Unloaded;
            DatePick.DateChanged += DatePick_DateChanged;

            //foreach (var x in ISBN.Countries)
            //{
            //    ComboBoxItem b = new ComboBoxItem();
            //    b.Content = x.Key;
            //    Country.Items.Add(b);
            //}
            Country.ItemsSource = ISBN.Countries.Keys;
            Publisher.ItemsSource = Enum.GetNames(typeof(JournalFrequency));
                //ISBN.Publishers.Keys;




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
            //if (e.Parameter.GetType() == typeof(List<LibraryItem>))
            //    tempRepo = (List<LibraryItem>)e.Parameter;
            //else if ((e.Parameter.GetType()).BaseType == typeof(LibraryItem))
            //{
            //    tempItem = (LibraryItem)e.Parameter;
            //    DisplayInfo();
            //}

        }

        //public void DisplayInfo()// Edit func
        //{
        //    if (tempItem != null)
        //    {
        //        if (tempItem.GetType() == (typeof(Book)))
        //        {
        //            Book book = (Book)tempItem;
        //            Title.Text = book.Title;
        //            Auther.Text = book.Publisher;
        //            Date.Text = book.PublishDate.ToString();
        //            DatePick.Date = book.PublishDate;
        //            Country.Header = book.Isbn.Country;

        //            Synapsis.Text = book.Synopsis;
        //        }

        //    }

        //}

        private void EditOrAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (!checkWrongFieleds())//check if any field are wrong , returns true if so.\\\
            {
               Book tempItem = new Book(Title.Text, DatePick.Date.DateTime, 200, Country.SelectionBoxItem.ToString());
                tempItem.Publisher = Publisher.SelectedItem.ToString();// need to make sure is valid
                tempItem.Price = int.Parse(Price.Text);// need to make sure is valid
                _db.Add(tempItem);
                this.Frame.Navigate(typeof(Menu));
            }

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

            if (!DatePickChanged)
            {
                DatePick.Header = "Invalid input , select Valid Date ";
                haveWrongField = true;
            }
            else
            {
                DatePick.Header = string.Empty;
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

            return haveWrongField;
        }

    }
}
