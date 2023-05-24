using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksUpdateAthlete
    {
        public static bool ChecksAllFields(string lastname, string firstname, string patronymic, string birthday)
        {
            if (lastname == "" || firstname == "" || patronymic == "" || birthday == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }

        public static bool ChecksAllComboBox(string discharge, string title, string sortOfSport, string team)
        {
            if (discharge == "" || title == "" || sortOfSport == "" || team == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }

        public static bool CheckFIO(string lastname, string firstname, string patronymic)
        {
            Regex regexForName = new Regex("^[а-яёА-ЯЁ]+$");
            if (!regexForName.IsMatch(lastname) || !regexForName.IsMatch(firstname) || !regexForName.IsMatch(patronymic))
            {
                MessageBox.Show("ФИО должны содержать только русские буквы!");
                return false;
            }

            var wordsLastname = lastname.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsFirstname = firstname.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsPatronymic = patronymic.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsLastname)
            {
                if (!char.IsUpper(word[0]))
                {
                    MessageBox.Show("Первая буква в ФИО должна быть заглавной!");
                    return false; 
                }

                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        MessageBox.Show("Все буквы кроме первой должны быть строчными!");
                        return false;
                    }
                }
            }

            foreach (var word in wordsFirstname)
            {
                if (!char.IsUpper(word[0]))
                {
                    MessageBox.Show("Первая буква в ФИО должна быть заглавной!");
                    return false;
                }

                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        MessageBox.Show("Все буквы кроме первой должны быть строчными!");
                        return false;
                    }
                }
            }

            foreach (var word in wordsPatronymic)
            {
                if (!char.IsUpper(word[0]))
                {
                    MessageBox.Show("Первая буква в ФИО должна быть заглавной!");
                    return false;
                }

                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        MessageBox.Show("Все буквы кроме первой должны быть строчными!");
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool CheckBirthday(string date)
        {
            Regex regexForBirthday = new Regex(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(19|20)\d{2}$");

            if (date == "")
            {
                MessageBox.Show("Введите дату рождения!");
                return false;
            }

            if (!regexForBirthday.IsMatch(date))
            {
                MessageBox.Show("Неверный формат даты!\nПример верной даты - 01-01-1990");
                return false;
            }

            return true;
        }

        public static bool CheckMedalAndTitle(string medal, string title)
        {
            if (medal != "отсутствует" && title != "отсутствует")
            {
                MessageBox.Show("У спортсмена не может быть и разряда и звания!");
                return false;
            }

            return true;
        }
    }
}
