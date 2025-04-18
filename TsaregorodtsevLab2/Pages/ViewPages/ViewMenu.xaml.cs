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
    public partial class ViewMenu : Page
    {
        private readonly DataContext _context;

        public ViewMenu(DataContext context)
        {
            _context = context;
            InitializeComponent();
            LoadMenu();
        }

        public async void LoadMenu()
        {
            MenuDataGrid.ItemsSource = await _context.Menu
                .Include(m => m.Dish)
                .ThenInclude(d => d.Type)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
