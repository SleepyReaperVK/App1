using Library.DAL;
using Library.Model;
using Library.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Info : Page
    {
        public readonly IRepository<LibraryItem> _db;
        private LibraryItem temp { get; set; }
        private ListViewItem NavItem;
        public Info()
        {
            this.InitializeComponent();
            _db = new LibraryDB();
            this.Loaded += Info_Loaded;
        }



        private void Info_Loaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Info_BackRequested;
            
        }

        private void Info_BackRequested(object sender, BackRequestedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            this.Frame.Navigate(typeof(Menu));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter.GetType() == typeof(ListViewItem))
                {

                NavItem = (ListViewItem)e.Parameter;
                LibraryItem item = _db.Find(NavItem.Name);
                
                if (item.GetType() == typeof(Book))
                {
                    Book x = (Book)item;
                    temp = x;
                    UpdateInfo(x);
                }
                else if (item.GetType() == typeof(Journal))
                {
                    Journal x = (Journal)item;
                    temp = x;
                    UpdateInfo(x);
                }


            }
            else
            {
                throw new Exception("Navigated Error");

            }
        }

        /// <summary>
        /// Updates the Framwork with the {x}
        /// </summary>
        public void UpdateInfo(Book x)
        {
            Title.Text = x.Title;
            Auther.Text = ListTools.MakeStringFromList(x.Authors);
            Date.Text = $"{x.PublishDate:d}";
            ISBN.Text = x.Isbn.ToString();
            Country.Text = x.Isbn.Country;
            Synapsis.Text = x.Synopsis.ToString();
        }

       
        
        public void UpdateInfo(Journal x)
        {
            Title.Text = x.Title;
            Auther.Text = x.Editors.ToArray().ToString() ;
            Date.Text = $"{x.PublishDate:d}";
            ISBN.Text = x.Contributers.ToArray().ToString() ;
            Synapsis.Text = x.Id.ToString();

        }

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Menu), temp);
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddBook), temp);
        }
    }
}
