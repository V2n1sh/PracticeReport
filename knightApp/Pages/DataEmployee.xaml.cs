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
    /// Логика взаимодействия для DataEmployee.xaml
    /// </summary>
    public partial class DataEmployee : Page
    {
        private string originalLastname;
        private string originalFirstname;
        private string originalPatronymic;
        private string originalNumber;
        private string originalPosition;

        private Staff staffer;

        public DataEmployee()
        {
            InitializeComponent();
        }     

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CBoxPosition.ItemsSource = App.Context.Positions.OrderBy(s => s.name).Select(s => s.name).ToList();

            originalLastname = TBoxLastname.Text;
            originalFirstname = TBoxFirstname.Text;
            originalPatronymic = TBoxPatronymic.Text;
            originalNumber = TBoxPhoneNumber.Text;
            originalPosition = CBoxPosition.SelectedItem.ToString();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateStaff.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
            {
                if (InputChecksUpdateStaff.CheckPhoneNumber(TBoxPhoneNumber.Text))
                {
                    if (TBoxLastname.Text != originalLastname || TBoxFirstname.Text != originalFirstname || TBoxPatronymic.Text != originalPatronymic
                    || TBoxPhoneNumber.Text != originalNumber || CBoxPosition.Text != originalPosition)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            staffer = App.Context.Staff.Find(int.Parse(TBoxId.Text));
                            staffer.lastname = TBoxLastname.Text;
                            staffer.firstname = TBoxFirstname.Text;
                            staffer.patronymic = TBoxPatronymic.Text;
                            staffer.phone_number = TBoxPhoneNumber.Text;
                            staffer.position_id = App.Context.Positions.FirstOrDefault(x => x.name == CBoxPosition.SelectedItem.ToString()).id;
                            imageStaffer.Source = LoadImage(staffer.Users_images.user_image);

                            App.Context.SaveChanges();
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

        public DataEmployee(Staff staff)
        {
            InitializeComponent();
            TBoxId.Text = staff.id.ToString();
            TBoxFirstname.Text = staff.firstname;
            TBoxLastname.Text = staff.lastname;
            TBoxPatronymic.Text = staff.patronymic;
            TBoxPhoneNumber.Text = staff.phone_number;
            CBoxPosition.SelectedItem = App.Context.Positions.FirstOrDefault(s => s.id == staff.position_id).name;
            imageStaffer.Source = LoadImage(staff.Users_images.user_image);

            if (App.currentUser.role_id == 2)
            {
                imageReplace.Visibility = Visibility.Collapsed;

                TBoxLastname.IsReadOnly = true;
                TBoxFirstname.IsReadOnly = true;
                TBoxPatronymic.IsReadOnly = true;
                TBoxPhoneNumber.IsReadOnly = true;
                CBoxPosition.IsEnabled = false;

                ButtonDeleteEmployee.Visibility = Visibility.Collapsed;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (InputChecksUpdateStaff.ChecksAllFields(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text, TBoxPhoneNumber.Text))
            {
                if (InputChecksUpdateStaff.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
                {
                    if (InputChecksUpdateStaff.CheckPhoneNumber(TBoxPhoneNumber.Text))
                    {
                        if (NavigationService.CanGoBack)
                        {
                                NavigationService.GoBack();
                        }
                    }
                }
            }
        }

        private void ButtonDeleteStaffer_Click(object sender, RoutedEventArgs e)
        {
            int stafferId = int.Parse(TBoxId.Text);
            var currentUser = App.Context.Staff.FirstOrDefault(s => s.id == stafferId);

            if (currentUser != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить этого сотрудника?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.Context.Staff.Remove(currentUser);
                    App.Context.SaveChanges();
                    MessageBox.Show("Удалено");
                }
            }
        }

        private void imageReplace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int stafferId = int.Parse(TBoxId.Text);
            var staffer = App.Context.Staff.FirstOrDefault(a => a.id == stafferId);

            if (staffer != null)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image | *.png; *.jpg; *.jpeg; *.jpg";

                if (dialog.ShowDialog() == true)
                {
                    byte[] imageData = File.ReadAllBytes(dialog.FileName);

                    staffer.Users_images.user_image = imageData;
                    App.Context.SaveChanges();
                    MessageBox.Show("Новое изображение сохранено");
                }
            }
        }

        private void ButtonPDFEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (InputChecksUpdateStaff.CheckFIO(TBoxLastname.Text, TBoxFirstname.Text, TBoxPatronymic.Text))
            {
                if (InputChecksUpdateStaff.CheckPhoneNumber(TBoxPhoneNumber.Text))
                {
                    if (TBoxLastname.Text != originalLastname || TBoxFirstname.Text != originalFirstname || TBoxPatronymic.Text != originalPatronymic
                    || TBoxPhoneNumber.Text != originalNumber || CBoxPosition.Text != originalPosition)
                    {
                        if (MessageBox.Show("Сохранить изменения?", "Редактирование", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            staffer = App.Context.Staff.Find(int.Parse(TBoxId.Text));
                            staffer.lastname = TBoxLastname.Text;
                            staffer.firstname = TBoxFirstname.Text;
                            staffer.patronymic = TBoxPatronymic.Text;
                            staffer.phone_number = TBoxPhoneNumber.Text;
                            staffer.position_id = App.Context.Positions.FirstOrDefault(x => x.name == CBoxPosition.SelectedItem.ToString()).id;
                            imageStaffer.Source = LoadImage(staffer.Users_images.user_image);

                            originalLastname = TBoxLastname.Text;
                            originalFirstname = TBoxFirstname.Text;
                            originalPatronymic = TBoxPatronymic.Text;
                            originalNumber = TBoxPhoneNumber.Text;
                            originalPosition = CBoxPosition.SelectedItem.ToString();

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
                                table.AddCell(new PdfPCell(new Phrase(staffer.id.ToString(), fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("ФИО сотрудника", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(staffer.STAFF, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Номер телефона", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(staffer.phone_number, fontPdf)));

                                table.AddCell(new PdfPCell(new Phrase("Должность", headerFont)));
                                table.AddCell(new PdfPCell(new Phrase(App.Context.Positions.FirstOrDefault(s => s.id == staffer.position_id).name, fontPdf)));

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

                            table.AddCell(new PdfPCell(new Phrase("ФИО сотрудника", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalLastname + " " + originalFirstname + " " + originalPatronymic, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Номер телефона", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalNumber, fontPdf)));

                            table.AddCell(new PdfPCell(new Phrase("Должность", headerFont)));
                            table.AddCell(new PdfPCell(new Phrase(originalPosition, fontPdf)));

                            document.Add(table);
                            document.Close();
                        }
                    }
                }
            }
        }
    }
}
