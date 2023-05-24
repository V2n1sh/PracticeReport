using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using System.Diagnostics.Eventing.Reader;
using knightApp.Entities;
using System.Text.RegularExpressions;

namespace knightApp
{
    internal class InputChecksAuto
    {
        public static bool CheckingAllFields(string login, string password, string role)
        {

            if (login == "" || password == "" || role == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }

        public static bool ExistenceUser(string login)
        {
            var currentUser = App.Context.Users.FirstOrDefault(s => s.user_login == login);

            if (currentUser == null)
            {
                return false;
            }
            if (currentUser.user_login.Length < 3 && currentUser.user_login.Length > 20)
            {
                MessageBox.Show("Длина логина должна быть от 3 до 20 символов!");
                return false;
            }
            if (currentUser.user_login != login)
            {
                return false;
            }
            else
            {
                App.currentUser = currentUser;
                return true;
            }
        }

        public static bool ExistencePassword(string login, string password) 
        {
            var currentPassword = App.Context.Users.FirstOrDefault(s => s.user_login == login && s.user_password == password);

            if (currentPassword == null)
            {
                return false;
            }
            if (currentPassword.user_password != password)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ExistenceRole(string login, string password, string role)
        {
            var roleId = App.Context.Roles.FirstOrDefault(s => s.name == role)?.id;
            var currentRole = App.Context.Users.FirstOrDefault(s => s.user_login == login && s.user_password == password && s.role_id == roleId);

            if (currentRole != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
