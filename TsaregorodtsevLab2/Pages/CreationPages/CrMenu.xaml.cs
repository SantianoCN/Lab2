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
using TsaregorodtsevLab2.Data.Entities;
using TsaregorodtsevLab2.Data;
using Microsoft.EntityFrameworkCore;

namespace TsaregorodtsevLab2.Pages
{
    public partial class CrMenu : Page
    {
        private readonly DataContext _context;

        public CrMenu(DataContext context)
        {
            _context = context;
            InitializeComponent();
            Loaded += CrMenu_Loaded;
        }

        private async void CrMenu_Loaded(object sender, RoutedEventArgs e)
        {
            DishesComboBox.ItemsSource = await _context.Dishes.ToListAsync();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите блюдо");
                return;
            }

            if (!double.TryParse(PriceTextBox.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            var menuPosition = new MenuPosition
            {
                DishId = ((Dish)DishesComboBox.SelectedItem).Id,
                Dish = (Dish)DishesComboBox.SelectedItem,
                Price = price,
                CreationDate = DateTime.UtcNow
            };

            try
            {
                _context.Menu.Add(menuPosition);
                await _context.SaveChangesAsync();
                MessageBox.Show("Блюдо успешно добавлено в меню");
                PriceTextBox.Clear();
                DishesComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
            }
        }
    }
}
