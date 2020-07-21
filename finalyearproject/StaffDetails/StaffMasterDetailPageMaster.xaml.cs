using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffMasterDetailPageMaster : ContentPage
    {
        private ViewCell lastCell;
        public List<StaffMasterDetailPageMasterMenuItem> masterpage = new List<StaffMasterDetailPageMasterMenuItem>
        {
             new StaffMasterDetailPageMasterMenuItem
                {
                    Title = "Subject Preferences",
                    TargetType = typeof(SelectSubject)
                },
                new StaffMasterDetailPageMasterMenuItem
                {
                    Title = "Timetable",
                    TargetType = typeof(Timetable)
                }
        };
        public StaffMasterDetailPageMaster()
        {
            InitializeComponent();
            listView.ItemsSource = masterpage;
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminLoginPage());
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewcell = (ViewCell)sender;
            if (viewcell != null)
            {
                viewcell.View.BackgroundColor = Color.DarkGreen;
                lastCell = viewcell;
            }
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = sender as ListView;
            var selecteditem = e.Item as StaffMasterDetailPageMasterMenuItem;
            foreach (StaffMasterDetailPageMasterMenuItem item in listView.ItemsSource)
            {
                item.TextColor = selecteditem.Equals(item) ? Color.White : Color.Black;
                item.OnPropertyChanged();
            }
        }
    }
}