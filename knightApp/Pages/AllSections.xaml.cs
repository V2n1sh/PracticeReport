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
    /// Логика взаимодействия для AllSections.xaml
    /// </summary>
    public partial class AllSections : Page
    {
        public AllSections()
        {
            InitializeComponent();
           
        }

        private void TextBlockSportsmen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.Sportsman());
        }

        private void TextBlockTraining_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new Pages.Training());
        }

        private void TextBlockStaff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.Employee());
        }

        private void TextBlockTournament_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.Tournaments());
        }

        private void StackPanelPosition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.Positions());
        }

        private void StackPanelSortsOfSport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.SortsOfSport());
        }

        private void StackPanelTeams_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.Teams());
        }
    }
}
