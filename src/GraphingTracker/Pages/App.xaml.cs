﻿//****************************************************
//ITU project 2021 - Graphing Tracker

//@authors - Tadeas Kachyna, xkachy00@fit.vutbr.cz
//@date - 5.12.2021
//****************************************************

using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GraphingTracker
{
    public partial class App : Application
    {
        private static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db6.db3"));
                    database.InitializeDatabaseData();
                }

                return database;
            }
        }    

        public App()
        {
           
            MainPage = new NavigationPage(new MainPage());
        }

   
    }
}
