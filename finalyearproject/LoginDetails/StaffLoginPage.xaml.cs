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
           
            var restult = conn.Query<Teacher>("select * from Teacher where Name='"+usr.Text+ "' and Password='" + password.Text+"'").FirstOrDefault();
            var UserName = conn.Query<Teacher>("select Name from Teacher where Name='" + usr.Text + "'").FirstOrDefault();
            var UserPassword = conn.Query<Teacher>("select Password from Teacher where  Password='" + password.Text + "'").FirstOrDefault();
            if (string.IsNullOrEmpty(usr.Text))
            {
                if (string.IsNullOrEmpty(password.Text))
                {
                    login_UserNameError.IsVisible = true;
                    login_PasswordError.IsVisible = true;
                }
                else
                {
                    login_UserNameError.IsVisible = true;
                    login_PasswordError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                login_PasswordError.IsVisible = true;
                login_UserNameError.IsVisible = false;
            }
            else if (UserName == null)
            {
                if (UserPassword == null)
                {
                    login_PasswordIncorrect.IsVisible = true;
                    login_UserNameIncorrect.IsVisible = true;
                    login_PasswordError.IsVisible = false;
                    login_UserNameError.IsVisible = false;
                }
                else
                {
                    login_PasswordIncorrect.IsVisible = false;
                    login_UserNameIncorrect.IsVisible = true;
                    login_PasswordError.IsVisible = false;
                    login_UserNameError.IsVisible = false;
                }
            }
            else if (UserPassword == null)
            {
                login_PasswordIncorrect.IsVisible = true;
                login_UserNameIncorrect.IsVisible = false;
                login_PasswordError.IsVisible = false;
                login_UserNameError.IsVisible = false;
            }
            else if (UserName!=null)
            {
                Navigation.PushAsync(new StaffMasterDetailPage(restult));
                Clear();
            }
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
