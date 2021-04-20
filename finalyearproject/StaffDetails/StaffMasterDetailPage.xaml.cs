using finalyearproject.AdminDetails;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffMasterDetailPage : MasterDetailPage
    {
        StaffMasterDetailPageMaster masterPage;
        public Teacher teacher;
        public StaffMasterDetailPage(Teacher teacher)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.teacher = teacher;
            MasterBehavior = MasterBehavior.Popover;
            masterPage = new StaffMasterDetailPageMaster();
            Master = masterPage;
            SelectSubject.teacher = teacher;
            Timetable.teacherId = teacher.ID;
            Detail = new NavigationPage(new SelectSubject())
            {
                BarBackgroundColor = Color.DarkGreen,
                BarTextColor = Color.White
            };
            masterPage.listView.ItemSelected += OnItemSelected;
            void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                var item = e.SelectedItem as StaffMasterDetailPageMasterMenuItem;
                if (item != null)
                {
                   
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType))
                    { BarBackgroundColor = Color.DarkGreen, BarTextColor = Color.White };
                    masterPage.listView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}