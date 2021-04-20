using finalyearproject.AdminDetails;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminLoginPage : ContentPage
    {
        public AdminLoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            usr.Text = "Admin"; password.Text = "admin";
        }
        private void Login_Clicked(object sender, EventArgs e)
        {
            if (usr.Text == "Admin" && password.Text == "admin")
            {

                Navigation.PushAsync(new AdminMainPageCS(usr.Text));
            }
            else if (string.IsNullOrEmpty(usr.Text))
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
            else if (usr.Text != "Admin")
            {
                if (password.Text != "admin")
                {
                    login_UserNameIncorrect.IsVisible = true;
                    login_PasswordIncorrect.IsVisible = true;
                }
                else
                {
                    login_UserNameIncorrect.IsVisible = true;
                }
                login_PasswordError.IsVisible = false;
                login_UserNameError.IsVisible = false;
            }
            else if (password.Text != "Admin")
            {
                login_PasswordIncorrect.IsVisible = true;
                login_PasswordError.IsVisible = false;
                login_UserNameError.IsVisible = false;
            }
        }
    }
}
    