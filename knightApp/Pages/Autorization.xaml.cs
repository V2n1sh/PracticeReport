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

namespace knightApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public static int user;

        public Autorization()
        {
            InitializeComponent();

            try
            {
                App.Context.Database.Connection.Open();
                App.Context.Database.Connection.Close();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Ошибка подключения к БД! Обратитесь к администратору.", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }

            ComboBoxRole.ItemsSource = App.Context.Roles.Select(s => s.name).ToList();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (InputChecksAuto.CheckingAllFields(TBoxLogin.Text, TBoxPass.Password, ComboBoxRole.Text))
            {
                if (InputChecksAuto.ExistenceUser(TBoxLogin.Text))
                {
                    if (InputChecksAuto.ExistencePassword(TBoxLogin.Text, TBoxPass.Password))
                    {
                        if (InputChecksAuto.ExistenceRole(TBoxLogin.Text, TBoxPass.Password, ComboBoxRole.Text))
                        {
                            NavigationService.Navigate(new Pages.AllSections());
                        }
                        else
                        {
                            MessageBox.Show("Пользователя с такой ролью нет!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует!");
                }
            }
        }
    }
}
