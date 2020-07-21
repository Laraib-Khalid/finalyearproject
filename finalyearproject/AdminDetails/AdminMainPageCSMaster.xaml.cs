using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPageCSMaster : ContentPage
    {
        private ViewCell lastCell;
        public List<AdminMainPageCSMasterMenuItem> masterpage = new List<AdminMainPageCSMasterMenuItem>
        {
             new AdminMainPageCSMasterMenuItem
                {
                    Title = "Add Teacher",
                    TargetType = typeof(TeacherDetails)
                },
                new AdminMainPageCSMasterMenuItem
                {
                    Title = "Add Subjects",
                    TargetType = typeof(SubjectDetails)
                },
                new AdminMainPageCSMasterMenuItem
                {
                    Title = "Add Classrooms",
                    TargetType = typeof(Classroom.ClassroomDetails)
                },
                new AdminMainPageCSMasterMenuItem
                {
                    Title = "Allotment",
                    TargetType = typeof(Allotment.AllotmentPage)
                },
                new AdminMainPageCSMasterMenuItem
                {
                    Title = "Generate Timetable",
                    TargetType = typeof(GenerateTimetablePage)
                }
        };
        public AdminMainPageCSMaster()
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
            var selecteditem = e.Item as AdminMainPageCSMasterMenuItem;
            foreach (AdminMainPageCSMasterMenuItem item in listView.ItemsSource)
            {
                item.TextColor = selecteditem.Equals(item) ? Color.White : Color.Black;
                item.OnPropertyChanged();
            }
        }
    }
    }