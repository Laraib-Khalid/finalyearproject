using SQLite;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
