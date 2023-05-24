using iTextSharp.text.pdf;
using iTextSharp.text;
using knightApp.Checks;
using knightApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DataTournaments.xaml
    /// </summary>
    public partial class DataTournaments : Page
    {
        private string originalName;
        private string originalCity;
        private string originalStreet;
        private string originalHomeNumber;
        private string originalStart;
        private string originalEnd;
        private string originalSortOfSport;

        private Entities.Tournaments tournament;

        public DataTournaments()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CBoxCity.ItemsSource = App.Context.Cities.Select(s => s.name).OrderBy(n => n).ToList();
            CBoxStreet.ItemsSource = App.Context.Streets.Select(s => s.name).OrderBy(n => n).ToList();
            CBoxSortOfSport.ItemsSource = App.Context.SortsOfSports.Select(s => s.name).OrderBy(n => n).ToList();

            originalName = TBoxName.Text;
            originalCity = CBoxCity.SelectedItem.ToString();
            originalStreet = CBoxStreet.SelectedItem.ToString();
            originalHomeNumber = TBoxHomeNumber.Text;
            originalStart = TBoxStart.Text;
            originalEnd = TBoxEnd.Text;
            originalSortOfSport = CBoxSortOfSport.SelectedItem.ToString();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateTournament.ChecksAllFields(TBoxName.Text, TBoxHomeNumber.Text, TBoxStart.Text, TBoxEnd.Text))
            {
                if (InputChecksUpdateTournament.CheckDateTournament(TBoxStart.Text, TBoxEnd.Text))
                {
                    if (originalName != TBoxName.Text || CBoxCity.SelectedItem.ToString() != originalCity || CBoxStreet.SelectedItem.ToString() != originalStreet || TBoxHomeNumber.Text != originalHomeNumber
                    || TBoxStart.Text != originalStart || TBoxEnd.Text != originalEnd || CBoxSortOfSport.SelectedItem.ToString() != originalSortOfSport)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            tournament = App.Context.Tournaments.Find(int.Parse(TBoxId.Text));
                            tournament.name = TBoxName.Text;
                            tournament.city_id = App.Context.Cities.FirstOrDefault(x => x.name == CBoxCity.SelectedItem.ToString()).id;
                            tournament.street_id = App.Context.Streets.FirstOrDefault(x => x.name == CBoxStreet.SelectedItem.ToString()).id;
                            tournament.home_number = int.Parse(TBoxHomeNumber.Text);
                            tournament.tournament_start = DateTime.Parse(TBoxStart.Text);
                            tournament.tournament_end = DateTime.Parse(TBoxEnd.Text);
                            tournament.sort_of_sport_od = App.Context.SortsOfSports.FirstOrDefault(s => s.name == CBoxSortOfSport.SelectedItem.ToString()).id;

                            App.Context.SaveChanges();
                        }
                    }
                }
            }
        }

        public DataTournaments(Entities.Tournaments tournament)
        {
            DateTime firstDate = (DateTime)(tournament.tournament_start);
            string startDate = firstDate.ToString("dd-MM-yyyy");

            DateTime secondDate = (DateTime)(tournament.tournament_end);
            string endDate = secondDate.ToString("dd-MM-yyyy");

            InitializeComponent();
            TBoxId.Text = tournament.id.ToString();
            TBoxName.Text = tournament.name;
            CBoxCity.SelectedItem = tournament.Cities.name;
            CBoxStreet.SelectedItem = tournament.Streets.name;
            TBoxHomeNumber.Text = tournament.home_number.ToString();
            TBoxStart.Text = startDate;
            TBoxEnd.Text = endDate;
            CBoxSortOfSport.SelectedItem = tournament.SortsOfSports.name;

            if (App.currentUser.role_id == 2)
            {
                ButtonDeleteTournament.Visibility = Visibility.Collapsed;

                TBoxName.IsReadOnly = true;
                CBoxCity.IsEnabled = false;
                CBoxStreet.IsEnabled = false;
                TBoxHomeNumber.IsReadOnly = true;
                TBoxStart.IsReadOnly = true;
                TBoxEnd.IsReadOnly = true;
                CBoxSortOfSport.IsEnabled = false;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InputChecksUpdateTournament.ChecksAllFields(TBoxName.Text, TBoxHomeNumber.Text, TBoxStart.Text, TBoxEnd.Text))
            {
                if (InputChecksUpdateTournament.CheckDateTournament(TBoxStart.Text, TBoxEnd.Text))
                {
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                }
            }
        }

        private void ButtonPDFTournament_Click(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateTournament.ChecksAllFields(TBoxName.Text, TBoxHomeNumber.Text, TBoxStart.Text, TBoxEnd.Text))
            {
                if (InputChecksUpdateTournament.CheckDateTournament(TBoxStart.Text, TBoxEnd.Text))
                {
                    if (CBoxCity.SelectedItem.ToString() != originalCity || CBoxStreet.SelectedItem.ToString() != originalStreet || TBoxHomeNumber.Text != originalHomeNumber
                    || TBoxStart.Text != originalStart || TBoxEnd.Text != originalEnd || CBoxSortOfSport.SelectedItem.ToString() != originalSortOfSport)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            tournament = App.Context.Tournaments.Find(int.Parse(TBoxId.Text));
                            tournament.name = TBoxName.Text;
                            tournament.city_id = App.Context.Cities.FirstOrDefault(x => x.name == CBoxCity.SelectedItem.ToString()).id;
                            tournament.street_id = App.Context.Streets.FirstOrDefault(x => x.name == CBoxStreet.SelectedItem.ToString()).id;
                            tournament.home_number = int.Parse(TBoxHomeNumber.Text);
                            tournament.tournament_start = DateTime.Parse(TBoxStart.Text);
                            tournament.tournament_end = DateTime.Parse(TBoxStart.Text);
                            tournament.sort_of_sport_od = App.Context.SortsOfSports.FirstOrDefault(s => s.name == CBoxSortOfSport.SelectedItem.ToString()).id;

                            originalName = TBoxName.Text;
                            originalCity = CBoxCity.SelectedItem.ToString();
                            originalStreet = CBoxStreet.SelectedItem.ToString();
                            originalHomeNumber = TBoxHomeNumber.Text;
                            originalStart = TBoxStart.Text;
                            originalEnd = TBoxEnd.Text;
                            originalSortOfSport = CBoxSortOfSport.SelectedItem.ToString();

                            App.Context.SaveChanges();

                            string font = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");

                            BaseFont headFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            Font headerFont = new Font(headFont, 12f, Font.BOLD);
                            BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            Font fontPdf = new Font(baseFont, 12f, Font.NORMAL);

                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "PDF файл (*.pdf)|*.pdf";
                            saveFileDialog.Title = "Сохранить PDF файл";
                            saveFileDialog.ShowDialog();

                            if (saveFileDialog.FileName != "")
                            {
                                DateTime start = (DateTime)(tournament.tournament_start);
                                string formatedStart = start.ToString("dd-MM-yyyy");

                                DateTime end = (DateTime)(tournament.tournament_end);
                                string formatedEnd = end.ToString("dd-MM-yyyy");

                                iTextSharp.text.Document document = new iTextSharp.text.Document();
                                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                document.Open();

                                const int COLUMN_COUNT = 2;
                                PdfPTable table = new PdfPTable(COLUMN_COUNT);

                                float[] columnWidths = new float[] { 1f, 3f };
                                table.SetWidths(columnWidths);

                                table.AddCell(new PdfPCell(new Phrase("Название", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(tournament.TOUR, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Город", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(App.Context.Cities.FirstOrDefault(s => s.id == tournament.city_id).name, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Улица", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(App.Context.Streets.FirstOrDefault(s => s.id == tournament.street_id).name, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Номер дома", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(tournament.home_number.ToString(), fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Начало", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(formatedStart, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Конец", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(formatedEnd, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Вид спорта", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(App.Context.SortsOfSports.FirstOrDefault(s => s.id == tournament.sort_of_sport_od).name, fontPdf)));


                                document.Add(table);
                                document.Close();
                            }
                        }
                    }
                    else
                    {
                        string font = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");

                        BaseFont headFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        Font headerFont = new Font(headFont, 12f, Font.BOLD);
                        BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        Font fontPdf = new Font(baseFont, 12f, Font.NORMAL);

                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "PDF файл (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Сохранить PDF файл";
                        saveFileDialog.ShowDialog();

                        if (saveFileDialog.FileName != "")
                        {
                            DateTime start = DateTime.Parse(originalStart);
                            string formatedStart = start.ToString("dd-MM-yyyy");

                            DateTime end = DateTime.Parse(originalEnd);
                            string formatedEnd = end.ToString("dd-MM-yyyy");

                            iTextSharp.text.Document document = new iTextSharp.text.Document();
                            PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                            document.Open();

                            const int COLUMN_COUNT = 2;
                            PdfPTable table = new PdfPTable(COLUMN_COUNT);

                            float[] columnWidths = new float[] { 1f, 3f };
                            table.SetWidths(columnWidths);

                            table.AddCell(new PdfPCell(new Phrase("Название", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalName, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Город", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalCity, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Улица", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalStreet, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Номер дома", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalHomeNumber, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Начало", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(formatedStart, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Конец", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(formatedEnd, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Вид спорта", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalSortOfSport, fontPdf)));


                            document.Add(table);
                            document.Close();
                        }
                    }
                }
            }
        }

        private void ButtonDeleteTournament_Click(object sender, RoutedEventArgs e)
        {
            int tourId = int.Parse(TBoxId.Text);
            var currentTour = App.Context.Tournaments.FirstOrDefault(s => s.id == tourId);

            if (currentTour != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить этот турнир?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.Context.Tournaments.Remove(currentTour);
                    App.Context.SaveChanges();
                    NavigationService.Navigate(new Pages.Tournaments());
                    MessageBox.Show("Удалено");
                }
            }
        }
    }
}
