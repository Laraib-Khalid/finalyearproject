using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherDetails : ContentPage
    {
        private ViewCell lastCell; 
        public TeacherDetails()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateTeacherList();
        }
        public void PopulateTeacherList()
        {
            TeacherList.ItemsSource = null;
            TeacherList.ItemsSource = DependencyService.Get<SQLiteInterface>().GetTeacher();
        }

        private void AddTeacher(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTeacherPage(null));
        }
        private void UpdateTeacher(object sender, ItemTappedEventArgs e)
        {
            Teacher details = e.Item as Teacher;
            if (details != null)
            {
                Navigation.PushAsync(new AddTeacherPage(details));
            }
        }
        private async void DeleteTeacher(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete Teacher?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Teacher details = menu.CommandParameter as Teacher;
                DependencyService.Get<SQLiteInterface>().DeleteTeacher(details.ID);
                PopulateTeacherList();
            }
        }
        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewcell = (ViewCell)sender;
            if (viewcell != null)
            {
                viewcell.View.BackgroundColor = Color.LightGray;
                lastCell = viewcell;
            }
        }
    }
}