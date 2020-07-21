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
    public partial class AdminMainPageCS : MasterDetailPage
    {
        AdminMainPageCSMaster masterPage;
        public AdminMainPageCS(string usr)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            MasterBehavior = MasterBehavior.Popover;
            masterPage = new AdminMainPageCSMaster();
            Master = masterPage;
            Detail = new NavigationPage(new TeacherDetails())
            {
                BarBackgroundColor = Color.DarkGreen, BarTextColor = Color.White };
            masterPage.listView.ItemSelected += OnItemSelected;
            void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                var item = e.SelectedItem as AdminMainPageCSMasterMenuItem;
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

    
