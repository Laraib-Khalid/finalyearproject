using finalyearproject.AdminDetails;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeacherPage : ContentPage
    {
        Teacher teacherDetails;
        public AddTeacherPage(Teacher details)
        {
            InitializeComponent();
            if (details != null)
            {
                teacherDetails = details;
                PopulateDetails(teacherDetails);
            }
        }
        private void PopulateDetails(Teacher details)
        {
            Name.Text = details.Name;
            FacultyNo.Text = details.FacultyNo;
            Alias.Text = details.Alias;
            ContactNo.Text = details.ContactNo;
            Password.Text = details.Password;
            Password.IsEnabled = false;
            Password.IsVisible = true;
            Password.IsPassword = false;
            Designation.SelectedItem = details.Designation;
            Email.Text = details.Email;
            addbtn.Text = "Update Teacher";
            this.Title = "Edit Teacher";
        }
        private void AddTeacher(object sender, EventArgs e)
        {
            bool isMatched = true; //Regex.IsMatch(Email.Text, emailRegEx);
            if (string.IsNullOrEmpty(Name.Text))
            {
                if (string.IsNullOrEmpty(FacultyNo.Text))
                {
                    if (string.IsNullOrEmpty(Alias.Text))
                    {
                        if (string.IsNullOrEmpty(ContactNo.Text))
                        {
                            if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                            {
                                if(string.IsNullOrEmpty(Email.Text))
                                {
                                    if (string.IsNullOrEmpty(Password.Text))
                                    {
                                        NameError.IsVisible = true;
                                        FacultyError.IsVisible = true;
                                        AliasError.IsVisible = true;
                                        ContactError.IsVisible = true;
                                        DesignationError.IsVisible = true;
                                        EmailError.IsVisible = true;
                                        PasswordError.IsVisible = true;
                                    }
                                    else
                                    {
                                        NameError.IsVisible = true;
                                        FacultyError.IsVisible = true;
                                        AliasError.IsVisible = true;
                                        ContactError.IsVisible = true;
                                        DesignationError.IsVisible = true;
                                        EmailError.IsVisible = true;
                                        PasswordError.IsVisible = false;
                                    }
                                }
                                else
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    EmailError.IsVisible = false;
                                    PasswordError.IsVisible = false;
                                }
                            }
                            else if (string.IsNullOrEmpty(Email.Text))
                            {
                                if(string.IsNullOrEmpty(Password.Text))
                                {

                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = false;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = true;
                                }
                                else
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = false;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = false;
                                }
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                EmailError.IsVisible = false;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                        {
                            if(string.IsNullOrEmpty(Email.Text))
                            {
                                if(string.IsNullOrEmpty(Password.Text))
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    ContactError.IsVisible = false;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = true;
                                }
                                else
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    ContactError.IsVisible = false;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = false;
                                }
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = false;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                            
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(ContactNo.Text))
                    {
                        if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                        {
                            if (string.IsNullOrEmpty(Email.Text))
                            {
                                if(string.IsNullOrEmpty(Password.Text))
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = false;
                                    DesignationError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = true;
                                }
                                else
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = false;
                                    DesignationError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = false;
                                }
                                
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = false;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = false;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            { 
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = false;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {

                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {

                                NameError.IsVisible = true;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if(string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                    
                }
                else if (string.IsNullOrEmpty(Alias.Text))
                {
                    if (string.IsNullOrEmpty(ContactNo.Text))
                    {
                        if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                        {
                            if (string.IsNullOrEmpty(Email.Text))
                            {
                                if(string.IsNullOrEmpty(PasswordError.Text))
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = false;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = true;
                                }
                                else
                                {
                                    NameError.IsVisible = true;
                                    FacultyError.IsVisible = false;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = false;
                                }
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                EmailError.IsVisible = false;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            ContactError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            Email.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                         else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        PasswordError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = true;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(ContactNo.Text))
                {
                    if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if (string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            PasswordError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = true;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                {
                    if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                            
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(Email.Text))
                {
                    if (string.IsNullOrEmpty(Password.Text))
                    {
                        NameError.IsVisible = true;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                }
                else
                {
                    NameError.IsVisible = true;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = false;
                    PasswordError.IsVisible = false;
                }

            }
            else if (string.IsNullOrEmpty(FacultyNo.Text))
            {
                if (string.IsNullOrEmpty(Alias.Text))
                {
                    if (string.IsNullOrEmpty(ContactNo.Text))
                    {
                        if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                        {
                            if (string.IsNullOrEmpty(Email.Text))
                            {
                                if (string.IsNullOrEmpty(Password.Text))
                                {
                                    NameError.IsVisible = false;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = true;
                                }
                                else
                                {
                                    NameError.IsVisible = false;
                                    FacultyError.IsVisible = true;
                                    AliasError.IsVisible = true;
                                    ContactError.IsVisible = true;
                                    DesignationError.IsVisible = true;
                                    EmailError.IsVisible = true;
                                    PasswordError.IsVisible = false;
                                }
                            }
                            else
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                EmailError.IsVisible = false;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty(Email.Text))
                        {
                            if (string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = true;
                            ContactError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if (string.IsNullOrEmpty(Email.Text))
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = false;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = true;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(ContactNo.Text))
                {
                    if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if (string.IsNullOrEmpty(Email.Text))
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = true;
                                AliasError.IsVisible = false;
                                DesignationError.IsVisible = true;
                                ContactError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {

                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = false;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = true;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                {
                    if (string.IsNullOrEmpty(Email.Text))
                    {
                        if (string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                         else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = true;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }    
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(Email.Text))
                {
                    if(string.IsNullOrEmpty(Password.Text))
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = true;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                }
                else
                {
                    NameError.IsVisible = false;
                    FacultyError.IsVisible = true;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = false;
                    PasswordError.IsVisible = false;
                }

            }
            else if (string.IsNullOrEmpty(Alias.Text))
            {
                if (string.IsNullOrEmpty(ContactNo.Text))
                {
                    if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                    {
                        if (string.IsNullOrEmpty(Email.Text))
                        {
                            if(string.IsNullOrEmpty(Password.Text))
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = false;
                                FacultyError.IsVisible = false;
                                AliasError.IsVisible = true;
                                ContactError.IsVisible = true;
                                DesignationError.IsVisible = true;
                                EmailError.IsVisible = true;
                                PasswordError.IsVisible = false;
                            }
                            
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            ContactError.IsVisible = true;
                            DesignationError.IsVisible = true;
                            EmailError.IsVisible = false;
                            PasswordError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(Email.Text))
                    {
                        if(string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            ContactError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            ContactError.IsVisible = true;
                            DesignationError.IsVisible = false;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                        
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = true;
                        ContactError.IsVisible = true;
                        DesignationError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                {
                    if (string.IsNullOrEmpty(Email.Text))
                    {
                        if(string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            Email.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = true;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = false;
                            Email.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                        
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = true;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(Email.Text))
                {
                    if(string.IsNullOrEmpty(Password.Text))
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = true;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = true;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                    
                }
                else
                {
                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = true;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = false;
                    PasswordError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty(ContactNo.Text))
            {
                if (string.IsNullOrEmpty((string)Designation.SelectedItem))
                {
                    if (string.IsNullOrEmpty(Email.Text))
                    {
                        if(string.IsNullOrEmpty(Password.Text))
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            FacultyError.IsVisible = false;
                            AliasError.IsVisible = false;
                            DesignationError.IsVisible = true;
                            ContactError.IsVisible = true;
                            EmailError.IsVisible = true;
                            PasswordError.IsVisible = false;
                        }
                        
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = true;
                        EmailError.IsVisible = false;
                        PasswordError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty(Email.Text))
                {
                    if(string.IsNullOrEmpty(Password.Text))
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = true;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = false;
                        ContactError.IsVisible = true;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                    
                }
                else
                {
                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = true;
                    EmailError.IsVisible = false;
                    PasswordError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty((string)Designation.SelectedItem))
            {
                if (string.IsNullOrEmpty(Email.Text))
                {
                    if(string.IsNullOrEmpty(Password.Text))
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        FacultyError.IsVisible = false;
                        AliasError.IsVisible = false;
                        DesignationError.IsVisible = true;
                        ContactError.IsVisible = false;
                        EmailError.IsVisible = true;
                        PasswordError.IsVisible = false;
                    }
                    
                }
                else
                {
                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = true;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = false;
                    PasswordError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty(Email.Text))
            {
                if(string.IsNullOrEmpty(Password.Text))
                {

                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = true;
                    PasswordError.IsVisible = true;
                }
                else
                {

                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = true;
                    PasswordError.IsVisible = false;
                }
            }
            else if (!isMatched)
            {
                    EmailInvalid.IsVisible = true;
                    NameError.IsVisible = false;
                    FacultyError.IsVisible = false;
                    AliasError.IsVisible = false;
                    DesignationError.IsVisible = false;
                    ContactError.IsVisible = false;
                    EmailError.IsVisible = false;
            }
            else if (addbtn.Text == "Add Teacher")
            {
                Teacher te = new Teacher();
                te.Name = Name.Text;
                te.FacultyNo = FacultyNo.Text;
                te.Alias = Alias.Text;
                te.ContactNo = ContactNo.Text;
                te.Designation = (string)Designation.SelectedItem;
                te.Email = Email.Text;
                bool res = DependencyService.Get<SQLiteInterface>().AddTeacher(te);
                if (res)
                {
                    var message = "Data saved Successfully.";
                    DependencyService.Get<SQLiteInterface>().Shorttime(message);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Save", "OK");
                }
            }
            else
            {
                teacherDetails.Name = Name.Text;
                teacherDetails.FacultyNo = FacultyNo.Text;
                teacherDetails.Alias = Alias.Text;
                teacherDetails.Password = Password.Text;
                teacherDetails.ContactNo = ContactNo.Text;
                teacherDetails.Designation = (string)Designation.SelectedItem;
                teacherDetails.Email = Email.Text;
                bool res = DependencyService.Get<SQLiteInterface>().UpdateTeacher(teacherDetails);
                if (res)
                {
                    var message = "Data update Successfully.";
                    DependencyService.Get<SQLiteInterface>().Shorttime(message);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Message", "Data Failed To Update", "OK");
                }
            }
        }
    }
}