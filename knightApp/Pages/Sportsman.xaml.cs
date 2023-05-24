using knightApp.Entities;
using Microsoft.Win32;
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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Shapes;
using System.IO;

namespace knightApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Sportsman.xaml
    /// </summary>
    public partial class Sportsman : Page
    {
        public Sportsman()
        {
            InitializeComponent();

            if (App.currentUser.role_id == 2)
            {
                ButtonAddSporsman.Visibility = Visibility.Collapsed;
            }
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewSportsman.ItemsSource = App.Context.Athletes.OrderBy(n => n.lastname).ToList();
            ListViewSportsman.SelectedItem = null;
        }

        private void ListViewSportsman_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItem != null)
                NavigationService.Navigate(new Pages.DataSportsman((sender as ListView).SelectedItem as Athletes));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.AllSections());
        }

        private void ButtonAddSporsman_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddSportsman());
        }

        private void ButtonPDFSportsman_Click(object sender, RoutedEventArgs e)
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

                List<Athletes> data = new List<Athletes>();
                foreach (var item in ListViewSportsman.Items)
                {
                    Athletes sportsman = item as Entities.Athletes;
                    if (sportsman != null)
                    {
                        data.Add(sportsman);
                    }
                }

                const int COLUMN_COUNT = 2;
                PdfPTable table = new PdfPTable(COLUMN_COUNT);

                float[] columnWidths = new float[] { 1f, 3f };
                table.SetWidths(columnWidths);

                table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("ФИО", headerFont)));

                foreach (var item in data)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.id.ToString(), fontPdf)));
                    table.AddCell(new PdfPCell(new Phrase(item.FIO, fontPdf)));
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
