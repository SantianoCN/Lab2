using Microsoft.EntityFrameworkCore;
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
    public partial class ViewDishesType : Page
    {
        private readonly DataContext _context;

        public ViewDishesType(DataContext context)
        {
            _context = context;
            InitializeComponent();
            LoadDishTypes();
        }

        public async void LoadDishTypes()
        {
            DishTypesDataGrid.ItemsSource = await _context.DishTypes
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
