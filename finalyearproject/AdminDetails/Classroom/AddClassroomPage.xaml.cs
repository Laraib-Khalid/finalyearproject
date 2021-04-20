using SQLite;
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
        public SQLiteConnection conn;
        public AddClassroomPage(Classrooms details)
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            if (details != null)
            {
                classroomDetails = details;
                PopulateDetails(classroomDetails);
            }
        }

        private void PopulateDetails(Classrooms details)
        {
            Name.Text = details.Name;
            Department.Text = details.Department;
            addbtn.Text = "Update Classroom";
            this.Title = "Edit Classroom";
        }
        private void AddClassroom(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                if(string.IsNullOrEmpty(Department.Text))
                {
                    ClassroomError.IsVisible = true;
                    DepartmentError.IsVisible = true;
                }
                ClassroomError.IsVisible = true;
                DepartmentError.IsVisible = false;
            }
            else if (string.IsNullOrEmpty(Department.Text))
            {
                ClassroomError.IsVisible = false;
                DepartmentError.IsVisible = true;
            }
            else
            { 
                if(addbtn.Text == "Add Classroom")
                {
                    Classrooms classroom = new Classrooms();
                    classroom.Name = Name.Text;
                    classroom.Department = Department.Text;
                    var dup = conn.Query<Classrooms>("Select * from Classrooms where Name = '" + Name.Text + "' and Department ='" + Department.Text + "'");
                    if (dup.Count == 0)
                    {
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
                        DisplayAlert("Message", "Data already exist", "OK");
                    }
                }
                 else
                {
                    classroomDetails.Name = Name.Text;
                    classroomDetails.Department = Department.Text;
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