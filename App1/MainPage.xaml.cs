using Library.DAL;
using Library.Model;
using Library.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public readonly IRepository<LibraryItem> _db;
        public readonly IRepository<Person> _dbU;
        public MainPage()
        {
           
            this.InitializeComponent();
            _db = new LibraryDB();
            _dbU = new UserDB();
            Browse.IsEnabled = false;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(Menu), null);
            
            

        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            PersonType.Visibility = Visibility.Collapsed;
            Admin.Visibility = Visibility.Visible;
            Pass.PasswordChanged += Pass_PasswordChanged;
        }

        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
             if (Username.Text != string.Empty && Pass.Password != string.Empty)
            {
                Employee temp = (Employee)_dbU.Find(Username.Text);
                if (temp != null)
                    if(temp.Password == Pass.Password)
                    {
                        Browse.IsEnabled = true;
                    } 
            }
             else
            {
                Username.Header = "Invalid Input/s";
                Browse.IsEnabled = false;
            }
        }


        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            PersonType.Visibility = Visibility.Collapsed;
            Customer.Visibility = Visibility.Visible;
            CUsername.TextChanged += CUsername_TextChanged; ;

        }

        private void CUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CUsername.Text != string.Empty)
            {
                if (_dbU.Find(CUsername.Text) == null)
                {
                    Customer guest = new Customer(CUsername.Text);
                    _dbU.Add(guest);
                }
                else
                    Browse.IsEnabled = true;
            }
            else
            {
                Browse.IsEnabled = false;
            }
        }

    }
}
