using System;
using System.Collections.Generic;
using System.Linq;
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
using TsaregorodtsevLab2.Data.Entities;
using TsaregorodtsevLab2.Data;
using Microsoft.EntityFrameworkCore;

namespace TsaregorodtsevLab2.Pages
{
    public partial class RegPage : Page
    {
        private readonly DataContext _context;
        private MainWindow _mainWindow;
        public RegPage(DataContext context, MainWindow window)
        {
            _context = context;
            _mainWindow = window;
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ClearValidationErrors();

            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                ShowValidationError(LoginTextBox, "Логин не может быть пустым");
                return;
            }

            if (LoginTextBox.Text.Length < 4)
            {
                ShowValidationError(LoginTextBox, "Логин должен содержать минимум 4 символа");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                ShowValidationError(PasswordBox, "Пароль не может быть пустым");
                return;
            }

            if (PasswordBox.Password.Length < 6)
            {
                ShowValidationError(PasswordBox, "Пароль должен содержать минимум 6 символов");
                return;
            }

            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                ShowValidationError(ConfirmPasswordBox, "Пароли не совпадают");
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                ShowValidationError(EmailTextBox, "Email не может быть пустым");
                return;
            }

            if (!IsValidEmail(EmailTextBox.Text))
            {
                ShowValidationError(EmailTextBox, "Некорректный формат email");
                return;
            }

            if (!AgreementCheckBox.IsChecked ?? false)
            {
                ShowValidationError(AgreementCheckBox, "Необходимо согласиться с условиями");
                return;
            }

            try
            {
                bool loginExists = await CheckIfLoginExists(LoginTextBox.Text);
                if (loginExists)
                {
                    ShowValidationError(LoginTextBox, "Этот логин уже занят");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке логина: {ex.Message}");
                return;
            }

            try
            {
                await RegisterUser(
                    LoginTextBox.Text,
                    PasswordBox.Password,
                    EmailTextBox.Text);

                MessageBox.Show("Регистрация прошла успешно!");
                _mainWindow.MainFrame.Content = new AuthPage(_context, _mainWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
            }
        }

        private void ClearValidationErrors()
        {
            LoginTextBox.ToolTip = null;
            LoginTextBox.BorderBrush = Brushes.Gray;

            PasswordBox.ToolTip = null;
            PasswordBox.BorderBrush = Brushes.Gray;

            ConfirmPasswordBox.ToolTip = null;
            ConfirmPasswordBox.BorderBrush = Brushes.Gray;

            EmailTextBox.ToolTip = null;
            EmailTextBox.BorderBrush = Brushes.Gray;

            AgreementCheckBox.ToolTip = null;
            AgreementCheckBox.BorderBrush = Brushes.Gray;
        }

        private void ShowValidationError(FrameworkElement element, string message)
        {
            element.ToolTip = message;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CheckIfLoginExists(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        private async Task RegisterUser(string login, string password, string email)
        {
            var hashParams = HashPassword(password);

            var user = new User
            {
                Login = login,
                Password = hashParams.hash,
                Salt = hashParams.salt,
                Email = email,
                RegistrationDate = DateTime.UtcNow,
                LastEntry = DateTime.UtcNow,
                Remember = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        private (string hash, string salt) HashPassword(string password)
        {
            string hashedPassword = "";
            byte[] salt = new byte[32];
            new Random().NextBytes(salt);
            using (var sha = SHA512.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt));
                byte[] hash = sha.ComputeHash(buffer);
                hashedPassword = Convert.ToBase64String(hash);
            }
            return (hashedPassword, Convert.ToBase64String(salt));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.MainFrame.Content = new AuthPage(_context, _mainWindow);
        }
    }
}
