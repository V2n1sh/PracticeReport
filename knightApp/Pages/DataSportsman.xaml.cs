using iTextSharp.text.pdf;
using iTextSharp.text;
using knightApp.Checks;
using knightApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
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
using static System.Net.Mime.MediaTypeNames;

namespace knightApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для DataSportsman.xaml
    /// </summary>
    public partial class DataSportsman : Page
    {
        private string originalLastname;
        private string originalFirstname;
        private string originalPatronymic;
        private string originalBirthday;
        private string originalMedal;
        private string originalTitle;
        private string originalSortOfSport;
        private string originalTeam;

        private Athletes athlete;


        public DataSportsman()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CBoxMedal.ItemsSource = App.Context.Discharges.Select(s => s.name).ToList();
            CBoxTitle.ItemsSource = App.Context.Titles.Select(s => s.name).ToList();
            CBoxSortOfSport.ItemsSource = App.Context.SortsOfSports.Select(s => s.name).ToList();
            CBoxTeam.ItemsSource = App.Context.Teams.Select(s => s.name).ToList();

            CBoxMedal.SelectedItem = App.Context.Discharges.Find(athlete.discharge_id).name;
            CBoxTitle.SelectedItem = App.Context.Titles.Find(athlete.title_id).name;
            CBoxSortOfSport.SelectedItem = App.Context.SortsOfSports.Find(athlete.sortOfSport_id).name;
            CBoxTeam.SelectedItem = App.Context.Teams.Find(athlete.team_id).name;

            originalLastname = TBoxLastname.Text;
            originalFirstname = TBoxFirstname.Text;
            originalPatronymic = TBoxPatronymic.Text;
            originalBirthday = TBoxBirthday.Text;
            originalMedal = CBoxMedal.SelectedItem.ToString();
            originalTitle = CBoxTitle.SelectedItem.ToString();
            originalSortOfSport = CBoxSortOfSport.SelectedItem.ToString();
            originalTeam = CBoxTeam.SelectedItem.ToString();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateAthlete.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
            {
                if (InputChecksUpdateAthlete.CheckBirthday(TBoxBirthday.Text))
                {
                    if (InputChecksUpdateAthlete.CheckMedalAndTitle(CBoxMedal.Text, CBoxTitle.Text))
                    {
                        if (TBoxLastname.Text != originalLastname || TBoxFirstname.Text != originalFirstname || TBoxPatronymic.Text != originalPatronymic
                        || TBoxBirthday.Text != originalBirthday || CBoxMedal.SelectedItem.ToString() != originalMedal
                        || CBoxTitle.SelectedItem.ToString() != originalTitle || CBoxSortOfSport.SelectedItem.ToString() != originalSortOfSport)
                        {
                            if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                athlete = App.Context.Athletes.Find(int.Parse(TBoxId.Text));
                                athlete.lastname = TBoxLastname.Text;
                                athlete.firstname = TBoxFirstname.Text;
                                athlete.patronymic = TBoxPatronymic.Text;
                                athlete.birthday = DateTime.Parse(TBoxBirthday.Text);
                                athlete.discharge_id = App.Context.Discharges.FirstOrDefault(x => x.name == CBoxMedal.SelectedItem.ToString()).id;
                                athlete.title_id = App.Context.Titles.FirstOrDefault(s => s.name == CBoxTitle.SelectedItem.ToString()).id;
                                athlete.sortOfSport_id = App.Context.SortsOfSports.FirstOrDefault(s => s.name == CBoxSortOfSport.SelectedItem.ToString()).id;
                                imageSportsman.Source = LoadImage(athlete.Users_images.user_image);

                                App.Context.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public DataSportsman(Athletes athlete)
        {
            DateTime date = (DateTime)(athlete.birthday);
            string formatedDate = date.ToString("dd-MM-yyyy");

            InitializeComponent();
            this.athlete = athlete;
            TBoxId.Text = athlete.id.ToString();
            TBoxFirstname.Text = athlete.firstname;
            TBoxLastname.Text = athlete.lastname;
            TBoxPatronymic.Text = athlete.patronymic;
            TBoxBirthday.Text = formatedDate;
            imageSportsman.Source = LoadImage(athlete.Users_images.user_image);

            if (App.currentUser.role_id == 2)
            {
                imageReplace.Visibility = Visibility.Collapsed;

                TBoxLastname.IsReadOnly = true;
                TBoxFirstname.IsReadOnly = true;
                TBoxPatronymic.IsReadOnly = true;
                TBoxBirthday.IsReadOnly = true;
                CBoxMedal.IsEnabled = false;
                CBoxTitle.IsEnabled = false;
                CBoxSortOfSport.IsEnabled = false;
                CBoxTeam.IsEnabled = false;

                ButtonDeleteSportsman.Visibility = Visibility.Collapsed;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InputChecksUpdateAthlete.ChecksAllFields(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text, TBoxBirthday.Text))
            {
                if (InputChecksUpdateAthlete.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
                {
                    if (InputChecksUpdateAthlete.CheckBirthday(TBoxBirthday.Text))
                    {
                        if (InputChecksUpdateAthlete.CheckMedalAndTitle(CBoxMedal.Text, CBoxTitle.Text))
                        {
                            if (NavigationService.CanGoBack)
                            {
                                NavigationService.GoBack();
                            }
                        }
                    }
                }
            }
        }

        private void ButtonDeleteSportsman_Click(object sender, RoutedEventArgs e)
        {
            int athleteId = int.Parse(TBoxId.Text);
            var currentUser = App.Context.Athletes.FirstOrDefault(s => s.id == athleteId);

            if (currentUser != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить этого спортсмена?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.Context.Athletes.Remove(currentUser);
                    App.Context.SaveChanges();
                    NavigationService.Navigate(new Pages.Sportsman());
                    MessageBox.Show("Удалено");
                }
            }
        }

        private void imageReplace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int athleteId = int.Parse(TBoxId.Text);
            var athlete = App.Context.Athletes.FirstOrDefault(a => a.id == athleteId);
            var athleteImage = App.Context.Users_images.FirstOrDefault(ui => ui.id == athlete.image_id);

            if (athleteImage != null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image | *.png; *.jpg; *.jpeg; *.jpg";

                if (dialog.ShowDialog() == true)
                {
                    byte[] imageData = File.ReadAllBytes(dialog.FileName);

                    athleteImage.user_image = imageData;
                    imageSportsman.Source = LoadImage(athlete.Users_images.user_image);
                    App.Context.SaveChanges();
                }
            }
        }

        private void ButtonPDFSportsman_Click(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateAthlete.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
            {
                if (InputChecksUpdateAthlete.CheckBirthday(TBoxBirthday.Text))
                {
                    if (InputChecksUpdateAthlete.CheckMedalAndTitle(CBoxMedal.Text, CBoxTitle.Text))
                    {
                        if (TBoxLastname.Text != originalLastname || TBoxFirstname.Text != originalFirstname || TBoxPatronymic.Text != originalPatronymic
                        || TBoxBirthday.Text != originalBirthday || CBoxMedal.SelectedItem.ToString() != originalMedal
                        || CBoxTitle.SelectedItem.ToString() != originalTitle || CBoxSortOfSport.SelectedItem.ToString() != originalSortOfSport)
                        {
                            if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                athlete = App.Context.Athletes.Find(int.Parse(TBoxId.Text));
                                athlete.lastname = TBoxLastname.Text;
                                athlete.firstname = TBoxFirstname.Text;
                                athlete.patronymic = TBoxPatronymic.Text;
                                athlete.birthday = DateTime.Parse(TBoxBirthday.Text);
                                athlete.discharge_id = App.Context.Discharges.FirstOrDefault(x => x.name == CBoxMedal.SelectedItem.ToString()).id;
                                athlete.title_id = App.Context.Titles.FirstOrDefault(s => s.name == CBoxTitle.SelectedItem.ToString()).id;
                                athlete.sortOfSport_id = App.Context.SortsOfSports.FirstOrDefault(s => s.name == CBoxSortOfSport.SelectedItem.ToString()).id;
                                imageSportsman.Source = LoadImage(athlete.Users_images.user_image);

                                originalLastname = TBoxLastname.Text;
                                originalFirstname = TBoxFirstname.Text;
                                originalPatronymic = TBoxPatronymic.Text;
                                originalBirthday = TBoxBirthday.Text;
                                originalMedal = CBoxMedal.SelectedItem.ToString();
                                originalTitle = CBoxTitle.SelectedItem.ToString();
                                originalSortOfSport = CBoxSortOfSport.SelectedItem.ToString();
                                originalTeam = CBoxTeam.SelectedItem.ToString();

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
                                    DateTime date = (DateTime)(athlete.birthday);
                                    string formatedDate = date.ToString("dd-MM-yyyy");

                                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                    document.Open();

                                    const int COLUMN_COUNT = 2;
                                    PdfPTable table = new PdfPTable(COLUMN_COUNT);

                                    float[] columnWidths = new float[] { 1f, 3f };
                                    table.SetWidths(columnWidths);

                                    table.AddCell(new PdfPCell(new Phrase("ФИО", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(athlete.FIO, fontPdf)));

                                    table.AddCell(new PdfPCell(new Phrase("Дата рождения", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(formatedDate, fontPdf)));

                                    string dischargeName = CBoxMedal.Text;
                                    table.AddCell(new PdfPCell(new Phrase("Разряд", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(App.Context.Discharges.FirstOrDefault(s => s.name == dischargeName).name, fontPdf)));

                                    string titleName = CBoxTitle.Text;
                                    table.AddCell(new PdfPCell(new Phrase("Звание", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(App.Context.Titles.FirstOrDefault(s => s.name == titleName).name, fontPdf)));

                                    string sortOfSportName = CBoxSortOfSport.Text;
                                    table.AddCell(new PdfPCell(new Phrase("Вид спорта", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(App.Context.SortsOfSports.FirstOrDefault(s => s.name == sortOfSportName).name, fontPdf)));

                                    string teamName = CBoxTeam.Text;
                                    table.AddCell(new PdfPCell(new Phrase("Команда", headerFont)));
                                    table.AddCell(new PdfPCell(new Phrase(App.Context.Teams.FirstOrDefault(s => s.name == teamName).name, fontPdf)));


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
                                DateTime date = DateTime.Parse(originalBirthday);
                                string formatedDate = date.ToString("dd-MM-yyyy");

                                iTextSharp.text.Document document = new iTextSharp.text.Document();
                                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                document.Open();

                                const int COLUMN_COUNT = 2;
                                PdfPTable table = new PdfPTable(COLUMN_COUNT);

                                float[] columnWidths = new float[] { 1f, 3f };
                                table.SetWidths(columnWidths);

                                table.AddCell(new PdfPCell(new Phrase("ФИО", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(originalLastname + " " + originalFirstname + " " + originalPatronymic, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Дата рождения", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(formatedDate, fontPdf)));

                                string dischargeName = CBoxMedal.Text;
                                table.AddCell(new PdfPCell(new Phrase("Разряд", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(originalMedal, fontPdf)));

                                string titleName = CBoxTitle.Text;
                                table.AddCell(new PdfPCell(new Phrase("Звание", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(originalTitle, fontPdf)));

                                string sortOfSportName = CBoxSortOfSport.Text;
                                table.AddCell(new PdfPCell(new Phrase("Вид спорта", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(originalSortOfSport, fontPdf)));

                                string teamName = CBoxTeam.Text;
                                table.AddCell(new PdfPCell(new Phrase("Команда", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(originalTeam, fontPdf)));


                                document.Add(table);
                                document.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}

