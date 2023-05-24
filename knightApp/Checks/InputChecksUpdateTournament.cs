using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksUpdateTournament
    {
        public static bool ChecksAllFields(string name, string homeNumber, string start, string end)
        {
            Regex regexForNumberHome = new Regex("^\\d+$");
            Regex regexForNameTour = new Regex(@"^([А-Яа-я0-9""'\-.]+\s*)+$");

            if (name == "" || homeNumber == "" || start == "" || end == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            if (!regexForNumberHome.IsMatch(homeNumber))
            {
                MessageBox.Show("Введите правильный номер дома!");
                return false;
            }

            if (!regexForNameTour.IsMatch(name))
            {
                MessageBox.Show("Введите корректное название турнира!");
                return false;
            }

            return true;
        }

        public static bool CheckDateTournament(string start, string end)
        {
            Regex regexForDate = new Regex(@"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(19|20)\d{2}$");

            if (start == "" || end == "")
            {
                MessageBox.Show("Введите время проведения турнира!");
                return false;
            }

            if (!regexForDate.IsMatch(start) || !regexForDate.IsMatch(end))
            {
                MessageBox.Show("Неверный формат даты!\nПример верной даты - 01-01-1990");
                return false;
            }

            return true;
        }
    }
}
