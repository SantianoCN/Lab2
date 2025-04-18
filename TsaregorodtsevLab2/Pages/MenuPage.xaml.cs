using System;
using System.Collections.Generic;
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
using TsaregorodtsevLab2.Data;

namespace TsaregorodtsevLab2.Pages
{
    public partial class MenuPage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        public MenuPage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();

            CreateFrame.Content = new CreationPage(_context, _mainWindow);
            ViewFrame.Content = new ViewPage(_context, _mainWindow);
            EditFrame.Content = new UpdatePage(_context, _mainWindow);
            DeleteFrame.Content = new DeletePage(_context, _mainWindow);
        }
    }
}
