using finalyearproject.AdminDetails.Allotment;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayTimePage : ContentPage
    {
        public SQLiteConnection conn;
        public DayTimePage()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
        }
        protected override void OnAppearing()
        {
            PopulateDayTimeList();
        }
        public void PopulateDayTimeList()
        {
            list.ItemsSource = null;
            list.ItemsSource = DependencyService.Get<SQLiteInterface>().GetDayTime();
        }
        private void addbtn_Clicked(object sender, EventArgs e)
        {
            DayTime dayTime = new DayTime();
            dayTime.Day = Day.Text;
            dayTime.Time = Time.Text;
            bool res = DependencyService.Get<SQLiteInterface>().AddDayTime(dayTime);
            if (res)
            {
                var message = "Data saved Successfully.";
                DependencyService.Get<SQLiteInterface>().Shorttime(message);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Message", "Data Failed To Save", "OK");
            }
        }
        private async void Delete(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                DayTime details = menu.CommandParameter as DayTime;
                DependencyService.Get<SQLiteInterface>().DeleteDayTime(details.Id);
                PopulateDayTimeList();
            }
        }
    }
}