using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksUpdateTeam
    {
        public static bool ChecksAllFields(string name, string carNumber)
        {
            if (name == "" || carNumber == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }

        public static bool CheckName(string name)
        {
            Regex regexForName = new Regex("^[а-яёА-ЯЁ]+$");
            if (!regexForName.IsMatch(name))
            {
                MessageBox.Show("Название должны содержать только русские буквы!");
                return false;
            }

            var wordsName = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsName)
            {
                if (!char.IsUpper(word[0]))
                {
                    MessageBox.Show("Первая буква в названии должна быть заглавной!");
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
    }
}
