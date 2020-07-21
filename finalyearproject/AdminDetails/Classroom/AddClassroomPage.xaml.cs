using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails.Classroom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClassroomPage : ContentPage
    {
        Classrooms classroomDetails;
        public AddClassroomPage(Classrooms details)
        {
            InitializeComponent();
            if (details != null)
            {
                classroomDetails = details;
                PopulateDetails(classroomDetails);
            }
        }
        private void PopulateDetails(Classrooms details)
        {
            Name.Text = details.Name;
            addbtn.Text = "Update Classroom";
            this.Title = "Edit Classroom";
        }
        private void AddClassroom(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                ClassroomError.IsVisible = true;
            }
            else
            { 
                if(addbtn.Text == "Add Classroom")
                {
                    Classrooms classroom = new Classrooms();
                    classroom.Name = Name.Text;
                    bool res = DependencyService.Get<SQLiteInterface>().AddClassroom(classroom);
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
                    classroomDetails.Name = Name.Text;
                    bool res = DependencyService.Get<SQLiteInterface>().UpdateClassroom(classroomDetails);
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
}