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
    public partial class SubjectDetails : ContentPage
    {
        private ViewCell lastCell;
        public SubjectDetails()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            PopulateSubjectList();
        }
        public void PopulateSubjectList()
        {
            SubjectList.ItemsSource = null;
            SubjectList.ItemsSource = DependencyService.Get<SQLiteInterface>().GetSubject();
        }

        private void AddSubject(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Subject.AddSubjectPage(null));
        }
        private void UpdateSubject(object sender, ItemTappedEventArgs e)
        {
            Subjects details = e.Item as Subjects;
            if (details != null)
            {
                Navigation.PushAsync(new Subject.AddSubjectPage(details));
            }
        }
        private async void DeleteSubject(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Message", "Do you want to delete Subject?", "Ok", "Cancel");
            if (res)
            {
                var menu = sender as MenuItem;
                Subjects details = menu.CommandParameter as Subjects;
                DependencyService.Get<SQLiteInterface>().DeleteSubject(details.Id);
                PopulateSubjectList();
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