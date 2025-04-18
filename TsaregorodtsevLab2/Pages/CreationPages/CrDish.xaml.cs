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
    public partial class CrDish : Page
    {
        private readonly DataContext _context;
        private readonly MainWindow _mainWindow;

        public CrDish(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();
            Loaded += CrDish_Loaded;
        }

        private async void CrDish_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDishTypes();
        }

        private async Task LoadDishTypes()
        {
            DishTypeComboBox.ItemsSource = await _context.DishTypes.ToListAsync();
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs())
                return;

            var dish = new Dish
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                DishTypeId = ((DishType)DishTypeComboBox.SelectedItem).Id,
                Сalories = double.Parse(CaloriesTextBox.Text),
                Type = (DishType)DishTypeComboBox.SelectedItem
            };

            try
            {
                _context.Dishes.Add(dish);
                await _context.SaveChangesAsync();
                MessageBox.Show("Блюдо успешно создано");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании блюда: {ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название блюда");
                return false;
            }

            if (DishTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип блюда");
                return false;
            }

            if (!double.TryParse(CaloriesTextBox.Text, out _) || double.Parse(CaloriesTextBox.Text) <= 0)
            {
                MessageBox.Show("Введите корректное значение калорий");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            NameTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            DishTypeComboBox.SelectedIndex = -1;
            CaloriesTextBox.Text = string.Empty;
        }
    }
}
