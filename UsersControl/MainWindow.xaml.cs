using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace UsersControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DbHelper Helper { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Helper = new DbHelper();

            UpdateList();
        }

        public void UpdateList()
        {
            List<User> users = Helper.GetUsers(IsAdminCheckBox.IsChecked.Value);

            UserList.ItemsSource = new ObservableCollection<User>(users);
        }

        private void CreateUserButtonClick(object sender, RoutedEventArgs e)
        {
            Window createUser = new CreateUser(this);
            createUser.Show();
        }

        private void IsAdminChecked(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }
    }
}
