using finalyearproject.AdminDetails;
using finalyearproject.StaffDetails;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffLoginPage : ContentPage
    {
        public SQLiteConnection conn;
        public StaffLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            //var data = conn.Table<Teacher>();
            //var data1 = data.Where(x => x.Name==usr.Text).FirstOrDefault();
            //var data2 = data.Where(x => x.Password == password.Text).FirstOrDefault();
            //if (string.IsNullOrEmpty(usr.Text))
            //{
            //    if (string.IsNullOrEmpty(password.Text))
            //    {
            //        login_UserNameError.IsVisible = true;
            //        login_PasswordError.IsVisible = true;
            //    }
            //    else
            //    {
            //        login_UserNameError.IsVisible = true;
            //        login_PasswordError.IsVisible = false;
            //    }
            //}
            //else if (string.IsNullOrEmpty(password.Text))
            //{
            //    login_PasswordError.IsVisible = true;
            //    login_UserNameError.IsVisible = false;
            //}
            //else if (data1!=null & data2!=null)
            //{
                Navigation.PushAsync(new StaffMasterDetailPage(usr.Text));
                Clear();
            //}
            //else if(data1==null)
            //{
            //   if(data2==null)
            //    {
            //        login_PasswordIncorrect.IsVisible = true;
            //        login_UserNameIncorrect.IsVisible = true;
            //        login_PasswordError.IsVisible = false;
            //        login_UserNameError.IsVisible = false;
            //    }
            //   else
            //    {
            //        login_PasswordIncorrect.IsVisible = false;
            //        login_UserNameIncorrect.IsVisible = true;
            //        login_PasswordError.IsVisible = false;
            //        login_UserNameError.IsVisible = false;
            //    }
            //}
            //else if(data2==null)
            //{
            //    login_PasswordIncorrect.IsVisible = true;
            //    login_UserNameIncorrect.IsVisible = false;
            //    login_PasswordError.IsVisible = false;
            //    login_UserNameError.IsVisible = false;
            //}
        }
        void Clear()
        {
            usr.Text = "";
            password.Text = "";
            login_PasswordIncorrect.IsVisible = false;
            login_UserNameIncorrect.IsVisible = false;
            login_PasswordError.IsVisible = false;
            login_UserNameError.IsVisible = false;
        }
    }
 }
