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
    public partial class DeletePage : Page
    {
        private readonly DataContext _context;
        private readonly MainWindow _mainWindow;

        public DeletePage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();
            Loaded += DeletePage_Loaded;
        }

        private async void DeletePage_Loaded(object sender, RoutedEventArgs e)
        {
            var menuItems = await _context.Menu
                .Include(m => m.Dish)
                .Select(m => new { Name = m.Dish.Name, Entity = m, Type = "(меню)" })
                .ToListAsync();

            var dishes = await _context.Dishes
                .Select(d => new { Name = d.Name, Entity = d, Type = "(блюдо)" })
                .ToListAsync();

            var dishTypes = await _context.DishTypes
                .Select(dt => new { Name = dt.Name, Entity = dt, Type = "(тип блюда)" })
                .ToListAsync();

            var allItems = new List<dynamic>();
            allItems.AddRange(menuItems.Select(x => new
            {
                DisplayText = $"{x.Name} {x.Type}",
                Entity = x.Entity,
                Type = x.Type
            }));
            allItems.AddRange(dishes.Select(x => new
            {
                DisplayText = $"{x.Name} {x.Type}",
                Entity = x.Entity,
                Type = x.Type
            }));
            allItems.AddRange(dishTypes.Select(x => new
            {
                DisplayText = $"{x.Name} {x.Type}",
                Entity = x.Entity,
                Type = x.Type
            }));

            DeleteChoice.ItemsSource = allItems;
            DeleteChoice.DisplayMemberPath = "DisplayText";
        }

        private string GetDisplayName(object entity)
        {
            return entity switch
            {
                MenuPosition m => m.Dish.Name,
                Dish d => d.Name,
                DishType dt => dt.Name,
                _ => string.Empty
            };
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteChoice.SelectedItem == null)
            {
                MessageBox.Show("Выберите сущность для удаления");
                return;
            }

            dynamic selected = DeleteChoice.SelectedItem;
            object entity = selected.Entity;
            string type = selected.Type;

            try
            {
                if (type == "(блюдо)" && await _context.Menu.AnyAsync(m => m.DishId == ((Dish)entity).Id))
                {
                    MessageBox.Show("Нельзя удалить блюдо, которое есть в меню");
                    return;
                }

                if (type == "(тип блюда)" && await _context.Dishes.AnyAsync(d => d.DishTypeId == ((DishType)entity).Id))
                {
                    MessageBox.Show("Нельзя удалить тип блюда, который используется в блюдах");
                    return;
                }

                _context.Remove(entity);
                await _context.SaveChangesAsync();
                MessageBox.Show("Удаление выполнено успешно");
                DeletePage_Loaded(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
    }
}
