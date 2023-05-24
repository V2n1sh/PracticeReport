using iTextSharp.text.pdf;
using iTextSharp.text;
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
    /// Логика взаимодействия для SortsOfSport.xaml
    /// </summary>
    public partial class SortsOfSport : Page
    {
        public SortsOfSport()
        {
            InitializeComponent();
            ListViewSport.ItemsSource = App.Context.SortsOfSports.OrderBy(s => s.name).ToList();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void ButtonPDFSortOfSport_Click(object sender, RoutedEventArgs e)
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

                List<Entities.SortsOfSports> data = new List<Entities.SortsOfSports>();
                foreach (var item in ListViewSport.Items)
                {
                    SortsOfSports sort = item as SortsOfSports;
                    if (sort != null)
                    {
                        data.Add(sort);
                    }
                }

                const int COLUMN_COUNT = 2;
                PdfPTable table = new PdfPTable(COLUMN_COUNT);

                float[] columnWidths = new float[] { 1f, 3f };
                table.SetWidths(columnWidths);

                table.AddCell(new PdfPCell(new Phrase("№", headerFont)));
                table.AddCell(new PdfPCell(new Phrase("Название", headerFont)));

                foreach (var item in data)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.id.ToString(), fontPdf)));
                    table.AddCell(new PdfPCell(new Phrase(item.name, fontPdf)));
                }

                document.Add(table);
                document.Close();
            }
        }
    }
}
