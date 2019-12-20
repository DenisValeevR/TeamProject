using System;
using System.Collections.Generic;
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
using Task_Killer;

namespace Task_Killer_Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User User { get; set; }
        public static Program Program { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Program = new Program();
            if (Directory.Exists(Program._folderPath))
                Program.RestoreDataJSON();
            Navigator.Initialize(page => _mainFrame.Navigate(page));
            Navigator.Default.Navigate(new Login());
        }
    }
}
