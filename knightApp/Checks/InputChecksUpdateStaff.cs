using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksUpdateStaff
    {
        public static bool ChecksAllFields(string lastname, string firstname, string patronymic, string number)
        {
            if (lastname == "" || firstname == "" || patronymic == "" || number == "")
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

        public static bool CheckPhoneNumber(string number)
        {
            Regex regexForNumber = new Regex(@"^8-\d{3}-\d{3}-\d{2}-\d{2}$");

            if (!regexForNumber.IsMatch(number))
            {
                MessageBox.Show("Неверный формат номера телефона!\nПример верного номера - 8-900-123-12-12");
                return false;
            }

            return true;
        }
    }
}
