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
    /// Логика взаимодействия для DataTeams.xaml
    /// </summary>
    public partial class DataTeams : Page
    {
        private string originalName;
        private string originalCarNumber;

        private Entities.Teams team;

        public DataTeams()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CBoxTransferNumber.ItemsSource = App.Context.Transfers.Select(s => s.car_number).ToList();
            originalName = TBoxName.Text;
            originalCarNumber = CBoxTransferNumber.SelectedItem.ToString();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateTeam.ChecksAllFields(TBoxName.Text, CBoxTransferNumber.Text))
            {
                if (InputChecksUpdateTeam.CheckName(TBoxName.Text))
                {
                    if (originalName != TBoxName.Text || originalCarNumber != CBoxTransferNumber.Text)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            team = App.Context.Teams.Find(int.Parse(TBoxId.Text));
                            team.name = TBoxName.Text;
                            team.transfer_id = App.Context.Transfers.FirstOrDefault(x => x.car_number == CBoxTransferNumber.Text).car_number; ;

                            App.Context.SaveChanges();
                        }
                    }
                }    
            }
        }

        public DataTeams(Entities.Teams team)
        {
            InitializeComponent();
            TBoxId.Text = team.id.ToString();
            TBoxName.Text = team.name;
            CBoxTransferNumber.SelectedItem = team.Transfers.car_number;
            int teamId = int.Parse(TBoxId.Text);
            ListAthletesInTeam.ItemsSource = App.Context.Athletes.Where(s => s.team_id == teamId).Select(s => s.lastname + " " + s.firstname + " " + s.patronymic).ToList();

            if (App.currentUser.role_id == 2)
            {
                TBoxName.IsReadOnly = true;
                CBoxTransferNumber.IsEnabled = false;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InputChecksUpdateTeam.ChecksAllFields(TBoxName.Text, CBoxTransferNumber.Text))
            {
                if (InputChecksUpdateTeam.CheckName(TBoxName.Text))
                {
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                }
            }
        }

        private void ButtonPDFTeam_Click(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateTeam.ChecksAllFields(TBoxName.Text, CBoxTransferNumber.Text))
            {
                if (InputChecksUpdateTeam.CheckName(TBoxName.Text))
                {
                    if (originalName != TBoxName.Text || originalCarNumber != CBoxTransferNumber.Text)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            team = App.Context.Teams.Find(int.Parse(TBoxId.Text));
                            team.name = TBoxName.Text;
                            team.transfer_id = App.Context.Transfers.FirstOrDefault(x => x.car_number == CBoxTransferNumber.Text).car_number; ;

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
                                iTextSharp.text.Document document = new iTextSharp.text.Document();
                                PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                document.Open();

                                const int COLUMN_COUNT = 2;
                                PdfPTable table = new PdfPTable(COLUMN_COUNT);

                                float[] columnWidths = new float[] { 1f, 3f };
                                table.SetWidths(columnWidths);

                                table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(team.id.ToString(), fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Наименование", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(team.name, fontPdf)));



                                table.AddCell(new PdfPCell(new Phrase("Номер трансфера", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(App.Context.Transfers.FirstOrDefault(s => s.car_number == team.transfer_id).car_number, fontPdf)));

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
                            iTextSharp.text.Document document = new iTextSharp.text.Document();
                            PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                            document.Open();

                            const int COLUMN_COUNT = 2;
                            PdfPTable table = new PdfPTable(COLUMN_COUNT);

                            float[] columnWidths = new float[] { 1f, 3f };
                            table.SetWidths(columnWidths);

                            table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(TBoxId.Text, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Наименование", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalName, fontPdf)));

                            string athletesString = "";
                            foreach (var athlete in ListAthletesInTeam.Items)
                            {
                                athletesString += athlete.ToString();
                                athletesString += "\n";
                            }

                            table.AddCell(new PdfPCell(new Phrase("Состав команды", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(athletesString, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Номер трансфера", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalCarNumber, fontPdf)));

                            document.Add(table);
                            document.Close();
                        }
                    }
                }
            }
        }
    }
}
