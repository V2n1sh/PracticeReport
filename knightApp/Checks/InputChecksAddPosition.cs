using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksAddPosition
    {
        public static bool ChecksAllFields(string name, string typeOfSport, string sortOfSportCBox, string sortOfSport)
        {
            if (name == "" || typeOfSport == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            if (sortOfSportCBox != "" && sortOfSport != "")
            {
                MessageBox.Show("Необходимо заполнить только одно поле Вида Спорта!\nЛибо выбрать вид спорта в списке, либо ввести свой вариант");
                return false;
            }
            if (sortOfSportCBox == "" && sortOfSport == "")
            {
                MessageBox.Show("Необходимо заполнить хотя бы одно поле Вида Спорта!\nЛибо выбрать вид спорта в списке, либо ввести свой вариант");
                return false;
            }


            return true;
        }

        public static bool CheckNameAndSortOsSport(string name, string sortOfsport)
        {
            Regex regexForName = new Regex("^[а-я]+(\\s+[а-я]+)+$");
            Regex regexForSort = new Regex("[А-Я][а-я]+$");
            if (!regexForName.IsMatch(name))
            {
                MessageBox.Show("Название должности должно содержать только русские буквы и начинаться со строчной буквы!");
                return false;
            }
            if (!regexForSort.IsMatch(sortOfsport))
            {
                MessageBox.Show("Вид спорта должен содержать только русские буквы и начинаться с заглавной буквы!");
            }

            var wordsName = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsSortOfSport = sortOfsport.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsName)
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        MessageBox.Show("Все буквы должны быть строчными!");
                        return false;
                    }
                }
            }

            foreach (var word in wordsSortOfSport)
            {
                if (!char.IsUpper(word[0]))
                {
                    MessageBox.Show("Первая буква в виде спорта должна быть заглавной!");
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
