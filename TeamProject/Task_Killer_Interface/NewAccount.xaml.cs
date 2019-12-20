using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task_Killer;

namespace Task_Killer_Interface
{
    /// <summary>
    /// Логика взаимодействия для NewAccount.xaml
    /// </summary>
    public partial class NewAccount : Page
    {
        public NewAccount()
        {
            InitializeComponent();

        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new Login());
        }

        private void OnCreateClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrEmpty(ageTextBox.Text) 
                && !string.IsNullOrEmpty(loginTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text))
            {
                int number;
                bool success = Int32.TryParse(ageTextBox.Text, out number);
                if (!success)
                {
                    MessageBox.Show("Age must be inputted as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (MainWindow.Program.Users.Any(u => u.Login == loginTextBox.Text))
                {
                    MessageBox.Show("Account with this phone number already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    User user = new User(nameTextBox.Text, surnameTextBox.Text, Convert.ToInt32(ageTextBox.Text), loginTextBox.Text, passwordTextBox.Text);
                    MainWindow.Program.Users.Add(user);
                    MainWindow.User = user;
                    MainWindow.Program.SaveDataJSON();
                    Navigator.Default.Navigate(new MainPage());
                }
            }
            else
            {
                MessageBox.Show("All the fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
