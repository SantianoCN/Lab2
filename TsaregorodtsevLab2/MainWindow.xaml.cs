using Microsoft.EntityFrameworkCore;
using System.IO;
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
using TsaregorodtsevLab2.Data;
using TsaregorodtsevLab2.Pages;

namespace TsaregorodtsevLab2
{
    public partial class MainWindow : Window
    {
        private readonly DataContext dataContext = new DataContext();
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("last_login.txt"))
            {
                var login = File.ReadAllText("last_login.txt");
                if (dataContext.Users.Any(u => u.Login == login))
                {
                    MainFrame.Content = new MenuPage(dataContext, this);
                } else
                {
                    MainFrame.Content = new RegPage(dataContext, this);
                }
            } else
            {
                MainFrame.Content = new RegPage(dataContext, this);
            }
        }
    }
}