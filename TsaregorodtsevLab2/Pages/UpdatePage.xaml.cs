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
using TsaregorodtsevLab2.Data.Entities;
using TsaregorodtsevLab2.Pages.UpdatePages;

namespace TsaregorodtsevLab2.Pages
{
    public partial class UpdatePage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        private Dish currentDish;

        public DishType SeletedMenuPos { get; set; }
        public Dish SeletedDish { get; set; }
        public DishType SeletedDishType { get; set; }
        public UpdatePage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();

            UpdateMenuFrame.Content = new UpdMenu(_context);
            UpdateDishFrame.Content = new UpdDish(_context);
            UpdateDishTypeFrame.Content = new UpdDishType(_context);
        }
    }
}
