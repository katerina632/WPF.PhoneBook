using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4__Lists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Contact> phoneBook = new ObservableCollection<Contact>();
        public MainWindow()
        {
            InitializeComponent();

            phoneBook = new ObservableCollection<Contact>
            {
            new Contact() {Name = "Kate", Surname="Black", Operator="Kyivstar", PhoneNumber="0671234567" , photoPath=Environment.CurrentDirectory +"\\Resources\\kate.jpg"},
            new Contact() {Name = "Bob", Surname="Drew", Operator="Life", PhoneNumber="0731234567" , photoPath=Environment.CurrentDirectory +"\\Resources\\bob.jpg"}
          
            };

            list.ItemsSource = phoneBook;
            list.DisplayMemberPath = nameof(Contact.FullInfo);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEmpty())
            {
                phoneBook.Add(new Contact(nameTexBox.Text, surnameTexBox.Text, phoneNumberTexBox.Text, operatorTexBox.Text));
            }                
        }


        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(nameTexBox.Text) || string.IsNullOrEmpty(surnameTexBox.Text)
                    || string.IsNullOrEmpty(phoneNumberTexBox.Text) || string.IsNullOrEmpty(operatorTexBox.Text))
            {
                MessageBox.Show("Enter empty fields!", "Error", MessageBoxButton.OK);
                return true;
            }
            else
            {               
                return false;
            }
                
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedIndex != -1)
            {
                var p = list.SelectedItem as Contact;
                if (!IsEmpty())
                {
                    p.Name = nameTexBox.Text;
                    p.Surname = surnameTexBox.Text;
                    p.PhoneNumber = phoneNumberTexBox.Text;
                    p.Operator = operatorTexBox.Text;
                }               
            }
            else MessageBox.Show("Select contact!!", "Error", MessageBoxButton.OK);

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                phoneBook.Remove(list.SelectedItem as Contact);
            }
            else MessageBox.Show("Select contact!!", "Error", MessageBoxButton.OK);
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = list.SelectedItem as Contact;
            if (list.SelectedItem != null)
            {
                nameTexBox.Text = p.Name;
                surnameTexBox.Text = p.Surname;
                phoneNumberTexBox.Text = p.PhoneNumber;
                operatorTexBox.Text = p.Operator;

                Uri filePath = new Uri(p.photoPath);
                photoImage.Source = new BitmapImage(filePath);                
            }
        }

        private void photoImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var p = list.SelectedItem as Contact;
            if (list.SelectedItem != null)
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    Uri filePath = new Uri(openFileDialog.FileName);
                    photoImage.Source = new BitmapImage(filePath);
                    p.photoPath = filePath.ToString();
                }
            }
            else MessageBox.Show("Select contact!!", "Error", MessageBoxButton.OK);
        }
    }
}
