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
    public partial class UpdDishType : Page
    {
        private readonly DataContext _context;

        public UpdDishType(DataContext context)
        {
            _context = context;
            InitializeComponent();
            LoadDishTypes();
        }

        private async void LoadDishTypes()
        {
            DishTypesComboBox.ItemsSource = await _context.DishTypes.ToListAsync();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DishTypesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип блюда");
                return;
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите новое название");
                return;
            }

            var dishType = (DishType)DishTypesComboBox.SelectedItem;
            dishType.Name = NameTextBox.Text;

            try
            {
                _context.DishTypes.Update(dishType);
                await _context.SaveChangesAsync();
                MessageBox.Show("Тип блюда обновлен");
                LoadDishTypes();
                NameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
