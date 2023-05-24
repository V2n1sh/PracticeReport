using knightApp.Checks;
using knightApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    /// Логика взаимодействия для AddTournament.xaml
    /// </summary>
    public partial class AddTournament : Page
    {
        int idCity = 0;
        int idStreet = 0;
        int idSortOfSport = 0;

        public AddTournament()
        {
            InitializeComponent();

            CBoxCity.ItemsSource = App.Context.Cities.Select(s => s.name).OrderBy(n => n).ToList();
            CBoxStreet.ItemsSource = App.Context.Streets.Select(s => s.name).OrderBy(n => n).ToList();
            CBoxSortOfSport.ItemsSource = App.Context.SortsOfSports.Select(s => s.name).OrderBy(n => n).ToList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private bool CheckAddTournament()
        {
            if (InputChecksUpdateTournament.ChecksAllFields(TBoxName.Text, TBoxHomeNumber.Text, TBoxStart.Text, TBoxEnd.Text))
            {
                if (InputChecksUpdateTournament.CheckDateTournament(TBoxStart.Text, TBoxEnd.Text))
                {
                    return true;
                }
            }
            return false;
        }

        private void ButtonAddTournament_Click(object sender, RoutedEventArgs e)
        {
            switch (CBoxCity.Text)
            {
                case "Вологда":
                    idCity = 1;
                    break;
                case "Великий Устюг":
                    idCity = 2;
                    break;
                case "Череповец":
                    idCity = 3;
                    break;
                case "Санкт-Петербург":
                    idCity = 4;
                    break;
            }

            switch (CBoxStreet.Text)
            {
                case "Гагарина":
                    idStreet = 1;
                    break;
                case "Лечебная":
                    idStreet = 2;
                    break;
                case "Молодежная":
                    idStreet = 3;
                    break;
                case "Железнодорожная":
                    idStreet = 4;
                    break;
                case "Краснодонцев":
                    idStreet = 5;
                    break;
                case "Лесково":
                    idStreet = 6;
                    break;
                case "Владимирский проспект":
                    idStreet = 7;
                    break;
                case "Кирова":
                    idStreet = 8;
                    break;
            }


            if (CheckAddTournament())
            {
                string selectedSortOfSport = CBoxSortOfSport.Text;
                Entities.SortsOfSports sortOfSport = App.Context.SortsOfSports.FirstOrDefault(s => s.name == selectedSortOfSport);

                if (sortOfSport != null)
                {
                    idSortOfSport = sortOfSport.id;
                }

                var tournament = new Entities.Tournaments
                {
                    name = TBoxName.Text,
                    city_id = idCity,
                    street_id = idStreet,
                    home_number = int.Parse(TBoxHomeNumber.Text),
                    tournament_start = DateTime.Parse(TBoxStart.Text),
                    tournament_end = DateTime.Parse(TBoxEnd.Text),
                    sort_of_sport_od = idSortOfSport
                };
                App.Context.Tournaments.Add(tournament);
                App.Context.SaveChanges();
                NavigationService.GoBack();
                MessageBox.Show("Сохранено");
            }

        }
    }
}
