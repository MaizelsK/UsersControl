using System;
using System.Windows;

namespace UsersControl
{
    /// <summary>
    /// Логика взаимодействия для Create_User.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private MainWindow Window { get; set; }

        public CreateUser(MainWindow mainWindow)
        {
            InitializeComponent();
            Window = mainWindow;
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LoginText.Text) ||
                String.IsNullOrWhiteSpace(PasswordText.Text))
            {
                MessageBox.Show("Поля \"Логин\" и \"Пароль\" обязательны к заполнению!");
                return;
            }
            else
            {
                DbHelper helper = new DbHelper();

                User user = helper.FindUserByLogin(LoginText.Text);

                if (user.Login != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    return;
                }

                helper.CreateUser(new User()
                {
                    Id = Guid.NewGuid(),
                    Login = LoginText.Text,
                    Password = PasswordText.Text.GetHashCode(),
                    Address = AddressText.Text,
                    Phone = PhoneText.Text,
                    IsAdmin = IsAdminCheckBox.IsChecked.Value
                });

                Window.UpdateList();
                Close();
            }
        }
    }
}
