using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp.Checks
{
    internal class InputChecksUpdateTransfer
    {
        public static bool ChecksAllFields(string brand, string typeOfCar, string carNumber)
        {
            if (brand == "" || typeOfCar == "" || carNumber == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }
    }
}
