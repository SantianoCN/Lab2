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
    public partial class CreationPage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        public CreationPage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();

            CreateDishFrame.Content = new CrDish(_context, _mainWindow);
            CreateDishTypeFrame.Content = new CrDishType(_context);
            CreateMenuFrame.Content = new CrMenu(_context);
        }
    }
}
