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
    public partial class UpdDish : Page
    {
        private readonly DataContext _context;

        public UpdDish(DataContext context)
        {
            _context = context;
            InitializeComponent();
            Loaded += UpdDish_Loaded;
        }

        private async void UpdDish_Loaded(object sender, RoutedEventArgs e)
        {
            DishesComboBox.ItemsSource = await _context.Dishes.ToListAsync();
            DishTypeComboBox.ItemsSource = await _context.DishTypes.ToListAsync();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите блюдо");
                return;
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название");
                return;
            }

            if (DishTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип");
                return;
            }

            var dish = (Dish)DishesComboBox.SelectedItem;
            dish.Name = NameTextBox.Text;
            dish.Description = DescriptionTextBox.Text;
            dish.DishTypeId = ((DishType)DishTypeComboBox.SelectedItem).Id;
            dish.Type = (DishType)DishTypeComboBox.SelectedItem;

            try
            {
                _context.Dishes.Update(dish);
                await _context.SaveChangesAsync();
                MessageBox.Show("Блюдо обновлено");
                DishesComboBox.ItemsSource = await _context.Dishes.ToListAsync();
                NameTextBox.Clear();
                DescriptionTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
