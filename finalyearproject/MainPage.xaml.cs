using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace finalyearproject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Admin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminLoginPage());
        }

        private void Staff_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StaffLoginPage());
        }
    }
}
