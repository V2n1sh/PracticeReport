using knightApp.Checks;
using knightApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AddPositions.xaml
    /// </summary>
    public partial class AddPositions : Page
    {
        private int idTypeOfSport;
        private int idPosition;
        public AddPositions()
        {
            InitializeComponent();

            CBoxName.ItemsSource = App.Context.SortsOfSports.Select(s => s.name).ToList();
            CBoxTypeOfSport.ItemsSource = App.Context.TypesOfSports.Select(s => s.name).ToList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void ButtonAddPosition_Click(object sender, RoutedEventArgs e)
        {
            switch (CBoxTypeOfSport.Text)
            {
                case "индивидуальный":
                    idTypeOfSport = 1;
                    break;
                case "командный":
                    idTypeOfSport = 2;
                    break;
                case "единоборство":
                    idTypeOfSport = 3;
                    break;
                case "художественный":
                    idTypeOfSport = 4;
                    break;
            }

            if (InputChecksAddPosition.ChecksAllFields(TBoxName.Text, CBoxTypeOfSport.Text, CBoxName.Text, TBoxSortOfSport.Text))
            {
                if (InputChecksAddPosition.CheckNameAndSortOsSport(TBoxName.Text, TBoxSortOfSport.Text))
                {
                    var newSportName = TBoxSortOfSport.Text.Trim();
                    if (!string.IsNullOrEmpty(newSportName))
                    {
                        var existingSport = App.Context.SortsOfSports.FirstOrDefault(s => s.name == newSportName);
                        if (existingSport == null)
                        {
                            var newSport = new SortsOfSports()
                            {
                                name = newSportName,
                                types_of_sport_id = idTypeOfSport
                            };
                            App.Context.SortsOfSports.Add(newSport);
                            App.Context.SaveChanges();


                            string selectedPosition = TBoxName.Text;
                            Entities.Positions position = App.Context.Positions.FirstOrDefault(s => s.name == selectedPosition);
                            if (position != null)
                            {
                                idPosition = position.id;
                            }
                            else
                            {
                                position = new Entities.Positions
                                {
                                    name = selectedPosition
                                };
                                App.Context.Positions.Add(position);
                                App.Context.SaveChanges();
                                idPosition = position.id;
                            }

                            NavigationService.GoBack();
                            MessageBox.Show("Сохранено");
                        }
                    }
                }
            }
        }
    }
}

