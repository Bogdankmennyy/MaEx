using System.Windows;
using System.Windows.Controls;

namespace MaEx
{
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка входа пользователя
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Добавьте здесь логику для проверки логина и пароля.
            // Например, сверьтесь с данными из базы данных или другого источника.

            if (username == "ваш_логин" && password == "ваш_пароль")
            {
                MessageBox.Show("Вход выполнен успешно!");
                // Здесь вы можете перейти на другое окно или выполнить другие действия.
            }
            else
            {
                MessageBox.Show("Ошибка входа. Пожалуйста, проверьте введенные данные.");
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Очистить текстовое поле при получении фокуса, если оно содержит начальный текст
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "Username" || textBox.Text == "Password")
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Восстановить начальный текст, если поле осталось пустым при потере фокуса
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "UsernameTextBox")
                {
                    textBox.Text = "Username";
                }
                else if (textBox.Name == "PasswordTextBox")
                {
                    textBox.Text = "Password";
                }
            }
        }

        private void LoginButton_Click1(object sender, RoutedEventArgs e)
        {
            // Создайте экземпляр контекста базы данных
            using (var context = new MarketExchangeDBEntities())
            {
                // Создайте нового пользователя
                Users newUsers = new Users
                {
                    Username = UsernameTextBox.Text,
                    PasswordHash = PasswordTextBox.Text // Обратите внимание на безопасное хранение пароля
                                                    
                };

                // Добавьте пользователя в контекст и сохраните изменения
                context.Users.Add(newUsers);
                context.SaveChanges();
            }

            // После добавления пользователя перейдите на MainWindow.xaml
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close(); // Закроет текущее окно (registration.xaml)
        }


    }
}

