using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace knightApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly static Entities.KnightDBEntities Context = new Entities.KnightDBEntities();

        public static Entities.Users currentUser = null;
    }

}
