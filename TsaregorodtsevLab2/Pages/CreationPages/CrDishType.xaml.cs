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

namespace TsaregorodtsevLab2.Pages
{
    public partial class CrDishType : Page
    {
        private readonly DataContext _context;

        public CrDishType(DataContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название типа блюда");
                return;
            }

            var dishType = new DishType
            {
                Name = NameTextBox.Text
            };

            try
            {
                _context.DishTypes.Add(dishType);
                await _context.SaveChangesAsync();
                MessageBox.Show("Тип блюда успешно создан");
                NameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании: {ex.Message}");
            }
        }
    }
}
