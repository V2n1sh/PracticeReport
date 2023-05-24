using knightApp.Checks;
using knightApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    /// Логика взаимодействия для AddStaffer.xaml
    /// </summary>
    public partial class AddStaffer : Page
    {
        int idPosition = 0;
        private byte[] _mainImageData;

        public AddStaffer()
        {  
            InitializeComponent();
            ComboBoxPosition.ItemsSource = App.Context.Positions.Select(s => s.name).ToList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private bool CheckAddStaffer()
        {
            if (InputChecksUpdateStaff.ChecksAllFields(TBoxLastname.Text, TBoxName.Text, TBoxPatronymic.Text, TBoxPhoneNumber.Text))
            {
                if (InputChecksUpdateStaff.CheckFIO(TBoxLastname.Text, TBoxName.Text, TBoxPatronymic.Text))
                {
                    if (InputChecksUpdateStaff.CheckPhoneNumber(TBoxPhoneNumber.Text))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ImageAddSportsman_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image | *.png; *.jpg; *.jpeg; *.jpg";
            if (openFile.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(openFile.FileName);
                ImageStaffer.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
            }
        }

        private void ButtonAddStaffer_Click(object sender, RoutedEventArgs e)
        {
            switch (ComboBoxPosition.Text)
            {
                case "администратор комплекса":
                    idPosition = 1; 
                    break;
                case "уборщица":
                    idPosition = 2;
                    break;
                case "тренер по боксу":
                    idPosition = 3;
                    break;
                case "тренер по плаванию":
                    idPosition = 4;
                    break;
                case "тренер по легкой атлетике":
                    idPosition = 5;
                    break;
                case "тренер по волейболу":
                    idPosition = 6;
                    break;
                case "тренер по баскетболу":
                    idPosition = 7;
                    break;
                case "администратор БД":
                    idPosition = 8;
                    break;
                case "тренер по теннису":
                    idPosition = 10;
                    break;
                case "тренер по тяжелой атлетике":
                    idPosition = 11;
                    break;
                case "тренер по лыжному спорту":
                    idPosition = 12;
                    break;
                case "тренер по самбо":
                    idPosition = 13;
                    break;
            }


            if (ImageStaffer.Source == null)
            {
                MessageBox.Show("Выберите изображение");
            }
            else
            {
                if (CheckAddStaffer())
                {
                    var staffer = new Entities.Staff
                    {
                        firstname = TBoxName.Text,
                        lastname = TBoxLastname.Text,
                        patronymic = TBoxPatronymic.Text,
                        phone_number = TBoxPhoneNumber.Text,
                        position_id = idPosition,
                        Users_images = new Users_images()
                        {
                            user_image = _mainImageData
                        }
                    };
                    App.Context.Staff.Add(staffer);
                    App.Context.SaveChanges();
                    NavigationService.GoBack();
                    MessageBox.Show("Сохранено");
                }
            }
        }

        private void ImageAddStaffer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image | *.png; *.jpg; *.jpeg; *.jpg";
            if (openFile.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(openFile.FileName);
                ImageStaffer.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
            }
        }
    }
}
