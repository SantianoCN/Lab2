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

namespace TsaregorodtsevLab2.Pages
{
    public partial class ViewPage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        public ViewPage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();


            ViewDishFrame.Content = new ViewDish(_context, _mainWindow);
            ViewDishTypeFrame.Content = new ViewDishesType(_context);
            ViewMenuFrame.Content = new ViewMenu(_context);
        }

        private void UpdateMenu(object sender, MouseButtonEventArgs e)
        {
            var menu = ViewDishFrame.Content as ViewMenu;

            if (menu != null)
            {
                menu.LoadMenu();
            }
        }

        private void UpdateDish(object sender, MouseButtonEventArgs e)
        {
            var dishes = ViewDishFrame.Content as ViewDish;

            if (dishes != null)
            {
                dishes.LoadDishes();
            }
        }

        private void UpdateDishesType(object sender, MouseButtonEventArgs e)
        {
            var dishesTypes = ViewDishTypeFrame.Content as ViewDishesType;

            if (dishesTypes != null)
            {
                dishesTypes.LoadDishTypes();
            }
        }
    }
}
