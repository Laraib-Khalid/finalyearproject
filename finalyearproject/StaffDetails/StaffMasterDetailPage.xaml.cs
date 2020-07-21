using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffMasterDetailPage : MasterDetailPage
    {
        StaffMasterDetailPageMaster masterPage;
        public StaffMasterDetailPage(string usr)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            MasterBehavior = MasterBehavior.Popover;
            masterPage = new StaffMasterDetailPageMaster();
            Master = masterPage;
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