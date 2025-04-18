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

namespace TsaregorodtsevLab2.Pages.UpdatePages
{
    public partial class UpdMenu : Page
    {
        private readonly DataContext _context;

        public UpdMenu(DataContext context)
        {
            _context = context;
            InitializeComponent();
            Loaded += UpdMenu_Loaded;
        }

        private async void UpdMenu_Loaded(object sender, RoutedEventArgs e)
        {
            MenuComboBox.ItemsSource = await _context.Menu
                .Include(m => m.Dish)
                .ToListAsync();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите позицию меню");
                return;
            }

            if (!double.TryParse(PriceTextBox.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            var menuPos = (MenuPosition)MenuComboBox.SelectedItem;
            menuPos.Price = price;

            try
            {
                _context.Menu.Update(menuPos);
                await _context.SaveChangesAsync();
                MessageBox.Show("Позиция меню обновлена");
                MenuComboBox.ItemsSource = await _context.Menu
                    .Include(m => m.Dish)
                    .ToListAsync();
                PriceTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
