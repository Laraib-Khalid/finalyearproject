using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails.Classroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassroomDetails : ContentPage
    {
        private ViewCell lastCell;
        public ClassroomDetails()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateClassroomList();
        }
        public void PopulateClassroomList()
        {
            ClassroomList.ItemsSource = null;
            ClassroomList.ItemsSource = DependencyService.Get<SQLiteInterface>().GetClassrooms();
        }

        private void AddClassroom(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddClassroomPage(null));
        }
        private void UpdateClassroom(object sender, ItemTappedEventArgs e)
        { 
            Classrooms details = e.Item as Classrooms;
            if(details!=null)
            {
                Navigation.PushAsync(new AddClassroomPage(details));
            }
        }
        private async void DeleteClassroom(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete Classroom?", "Ok","Cancel");
            if(res)
            {
                var menu = sender as MenuItem;
                Classrooms details = menu.CommandParameter as Classrooms;
                DependencyService.Get<SQLiteInterface>().DeleteClassroom(details.Id);
                PopulateClassroomList();
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