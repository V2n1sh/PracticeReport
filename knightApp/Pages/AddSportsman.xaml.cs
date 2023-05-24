using knightApp.Checks;
using knightApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddSportsman.xaml
    /// </summary>
    public partial class AddSportsman : Page
    {
        int idTitle = 0;
        int idDischarge = 0;
        int idTeam = 0;
        int idSortOfSport = 0;
        private byte[] _mainImageData;

        public AddSportsman()
        {
            InitializeComponent();

            ComboBoxTitle.ItemsSource = App.Context.Titles.Select(s => s.name).ToList();
            ComboBoxDischarge.ItemsSource = App.Context.Discharges.Select(s => s.name).ToList();
            ComboBoxTeam.ItemsSource = App.Context.Teams.Select(s => s.name).ToList();
            ComboBoxSort.ItemsSource = App.Context.SortsOfSports.Select(s => s.name).ToList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private bool CheckAddSportsman()
        {
            if (InputChecksUpdateAthlete.ChecksAllFields(TBoxLastname.Text, TBoxName.Text, TBoxPatronymic.Text, TBoxBirthbay.Text))
            {
                if (InputChecksUpdateAthlete.ChecksAllComboBox(ComboBoxDischarge.Text, ComboBoxTitle.Text, ComboBoxSort.Text, ComboBoxTeam.Text))
                {
                    if (InputChecksUpdateAthlete.CheckFIO(TBoxLastname.Text, TBoxName.Text, TBoxPatronymic.Text))
                    {
                        if (InputChecksUpdateAthlete.CheckBirthday(TBoxBirthbay.Text))
                        {
                            if (InputChecksUpdateAthlete.CheckMedalAndTitle(ComboBoxDischarge.Text, ComboBoxTitle.Text))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void ButtonAddSportsman_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBoxTitle.Text)
            {
                case "гроссмейстер России":
                    idTitle = 1;
                    break;
                case "мастер спорта России":
                    idTitle = 2;
                    break;
                case "мастер спорта России международного класса":
                    idTitle = 3;
                    break;
                case "отсутствует":
                    idTitle = 4;
                    break;
            }

            switch (ComboBoxSort.Text)
            {
                case "Баскетбол":
                    idSortOfSport = 1;
                    break;
                case "Волейбол":
                    idSortOfSport = 2;
                    break;
                case "Бокс":
                    idSortOfSport = 3;
                    break;
                case "Плавание":
                    idSortOfSport = 4;
                    break;
                case "Легкая атлетика":
                    idSortOfSport = 5;
                    break;
                case "Хоккей":
                    idSortOfSport = 8;
                    break;
                case "Теннис":
                    idSortOfSport = 11;
                    break;
                case "Тяжелая атлетика":
                    idSortOfSport = 12;
                    break;
                case "Лыжный спорт":
                    idSortOfSport = 13;
                    break;
            }

            switch (ComboBoxDischarge.Text)
            {
                case "третий юношеский спортивный":
                    idDischarge = 1;
                    break;
                case "второй юношеский спортивный":
                    idDischarge = 2;
                    break;
                case "первый юношеский спортивный":
                    idDischarge = 3;
                    break;
                case "третий спортивный":
                    idDischarge = 4;
                    break;
                case "второй спортивный":
                    idDischarge = 5;
                    break;
                case "первый спортивный":
                    idDischarge = 6;
                    break;
                case "кандитат в мастера спорта":
                    idDischarge = 7;
                    break;
                case "отсутствует":
                    idDischarge = 8;
                    break;
            }  

            switch (ComboBoxTeam.Text)
            {
                case "СШОР Витязь":
                    idTeam = 1;
                    break;
                case "Чемпион":
                    idTeam = 2;
                    break;
                case "Ястребы":
                    idTeam = 3;
                    break;
                case "Молния":
                    idTeam = 4;
                    break;
                case "Витязь":
                    idTeam = 5;
                    break;
                case "Медведи":
                    idTeam = 6;
                    break;
                case "Отсутствует":
                    idTeam = 8;
                    break;
            }


            if (ImageSportsman.Source == null)
            {
                MessageBox.Show("Выберите изображение");
            }
            else
            {
                if (CheckAddSportsman())
                {
                    var sportsman = new Entities.Athletes
                    {
                        firstname = TBoxName.Text,
                        lastname = TBoxLastname.Text,
                        patronymic = TBoxPatronymic.Text,
                        birthday = DateTime.Parse(TBoxBirthbay.Text),
                        title_id = idTitle,
                        discharge_id = idDischarge,
                        sortOfSport_id = idSortOfSport,
                        team_id = idTeam,
                        Users_images = new Users_images()
                        {
                            user_image = _mainImageData
                        }
                    };
                    App.Context.Athletes.Add(sportsman);
                    App.Context.SaveChanges();
                    NavigationService.GoBack();
                    MessageBox.Show("Сохранено");
                }
            } 
        }

        private void ImageAddSportsman_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image | *.png; *.jpg; *.jpeg; *.jpg";
            if (openFile.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(openFile.FileName);
                ImageSportsman.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
            }
        }
    }
}
