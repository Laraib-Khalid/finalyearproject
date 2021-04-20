using finalyearproject.AdminDetails;
using finalyearproject.AdminDetails.Allotment;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.StaffDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectSubject : ContentPage
    {
        public SQLiteConnection conn;
        public static Teacher teacher;
        public SelectSubject()
        {
            InitializeComponent();

            //  this.teacher = teacher;
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            txtStaffName.Text = teacher.Name.ToString();
            setDepartment();
            Display();
        }

        private void setDepartment()
        {
            var getDepartment = conn.Query<Subjects>("SELECT DISTINCT Department from Subjects");
            DepartmentPicker.ItemsSource = getDepartment;
        }
        private void DepartmentPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var department = (Subjects)DepartmentPicker.SelectedItem;
            var getSubject = conn.Query<Subjects>("SELECT Id,Name FROM Subjects where Department = '" + department.Department + "'");
            SubjectPicker.ItemsSource = getSubject;
        }
        private void SubjectPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subjects = (Subjects)SubjectPicker.SelectedItem;
            var getClass = conn.Query<Subjects>("SELECT ClassRoom from Subjects where Id = '"+subjects.Id+"'");
            ClassPicker.ItemsSource = getClass;
        }
        private void addbtn_Clicked(object sender, EventArgs e)
        {
            TeacherAndSubjectTable tesub = new TeacherAndSubjectTable();
            var SelectedSubject = (Subjects)SubjectPicker.SelectedItem;
            var SelectedDepartment = (Subjects)DepartmentPicker.SelectedItem;
            var SelectedClass = (Subjects)ClassPicker.SelectedItem;
            if (SelectedSubject == null || SelectedClass == null || SelectedDepartment == null ||txtExperience == null)
            {
                DisplayAlert("Message", "Please fill all data", "OK");
            }
            else
            {

                tesub.SubjectID = SelectedSubject.Id;
                tesub.TeacherID = teacher.ID;
                tesub.Department = SelectedDepartment.Department;
                tesub.ClassRoom = SelectedClass.ClassRoom;
                tesub.Experience = Convert.ToInt32(txtExperience.Text);
                var chkDuplication = conn.Query<TeacherAndSubjectTable>("SELECT * FROM TeacherAndSubjectTable where TeacherID='" + teacher.ID + "' and SubjectID='" + SelectedSubject.Id + "' and ClassRoom = '"+SelectedClass.ClassRoom+"'");
                if (chkDuplication.Count == 0)
                {
                    bool res = DependencyService.Get<SQLiteInterface>().TeacherPreferences(tesub);
                    if (res)
                    {
                        var message = "Data saved Successfully.";
                        DependencyService.Get<SQLiteInterface>().Shorttime(message);
                        Clear();
                        Display();
                    }
                    else
                    {
                        DisplayAlert("Message", "Data Failed To Save", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Warning", "Data already exist", "", "Yes");
                }
            }

        }

        private void Display()
        {
            var Display = conn.Query<TeacherAndSubjectTable>("SELECT t.Name as TeacherName,s.Name as SubjectName,s.ClassRoom as ClassRoom,s.Department as Department ,tt.Experience as Experience from TeacherandSubjectTable tt inner join Teacher t on tt.TeacherID=t.Id inner join Subjects s on tt.SubjectID=s.Id where t.Id='" + teacher.ID + "'");
            listView.ItemsSource = Display;
        }
        void Clear()
        {
            SubjectPicker.SelectedItem = "";
            DepartmentPicker.SelectedItem = "";
            ClassPicker.SelectedItem = "";
            txtExperience.Text = "";
        }

    }
}

