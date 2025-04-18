using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace TsaregorodtsevLab2.Pages
{
    
    public partial class AuthPage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        public AuthPage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;


            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                MessageBox.Show("Укажите логин");
                return;
            }

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Укажите пароль");
                return;
            }
            var login = LoginTextBox.Text;
            var password = PasswordBox.Password;

            if (await _context.Users.AnyAsync(u => u.Login == login))
            {
                var user = _context.Users.FirstOrDefault(u => u.Login == login);

                if(await IsCorrectPassword(user.Password, password, user.Salt))
                {
                    user.LastEntry = DateTime.UtcNow;
                    if ((bool)RememberCheckBox.IsChecked!)
                    {
                        File.WriteAllText("last_login.txt", login);
                    }

                    _context.Users.Update(user);
                    _context.SaveChanges();

                    _mainWindow.MainFrame.Content = new MenuPage(_context, _mainWindow);
                } else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            } else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private async Task<bool> IsCorrectPassword(string hash, string passToShceck, string salt)
        {
            string hashedPassword;
            using (var sha = SHA512.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(passToShceck + salt);
                byte[] hashBytes = sha.ComputeHash(buffer);
                hashedPassword = Convert.ToBase64String(hashBytes);
            }

            if (hashedPassword == hash)
            {
                return true;
            }
            return false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.GoBack();
        }
    }
}
