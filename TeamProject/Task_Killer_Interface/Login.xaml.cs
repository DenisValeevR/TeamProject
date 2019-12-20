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

namespace Task_Killer_Interface
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTextBox.Text) && (!string.IsNullOrEmpty(passwordTextBox.Text)))
            {
                if (MainWindow.Program.Users.Any(u => u.Login == loginTextBox.Text && u.Pass == passwordTextBox.Text))
                {
                    MainWindow.User = MainWindow.Program.Users.Find(u => u.Login == loginTextBox.Text);
                    Navigator.Default.Navigate(new MainPage());
                }
                else
                {
                    MessageBox.Show("Incorrect input. Try again or create an account.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("All the fields are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void OnCreateAnAccountClick(object sender, RoutedEventArgs e)
        {
            Navigator.Default.Navigate(new NewAccount());
        }
    }
}
