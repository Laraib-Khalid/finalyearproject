using finalyearproject.AdminDetails;
using SQLite;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateTimetablePage : ContentPage
    {
        public SQLiteConnection conn;

        public GenerateTimetablePage()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            setTeacher();
            setClassRooms();
        }
        private void setTeacher()
        {
            var getTeacher = conn.Query<Teacher>("SELECT Id,Name FROM Teacher");
            TeacherPicker.ItemsSource = getTeacher;
        }
        public void setClassRooms()
        {
            var getClassrooms = conn.Query<Classrooms>("SELECT Id,Name FROM Classrooms");
            ClassroomPicker.ItemsSource = getClassrooms;
        }

        private void gteacherbtn_Clicked(object sender, EventArgs e)
        {
            _ = TeacherActionAsync();
        }
        private async Task TeacherActionAsync()
        {
            if (TeacherPicker.SelectedIndex != -1)
            {
                var selectedTeacher = (Teacher)TeacherPicker.SelectedItem;
                int teacherID = selectedTeacher.Id;
                var slist= DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                list.ItemsSource = null;
                list.ItemsSource = slist;
            }
            else
            {
                await DisplayAlert("Title", "Please select any Teacher","","Yes");
            }
        }

        private void gsubjectbtn_Clicked(object sender, EventArgs e)
        {
            _ = classroomActionAsync();
        }
        private async Task classroomActionAsync()
        {
            if (ClassroomPicker.SelectedIndex != -1)
            {
                var selectedClassroom = (Classrooms)ClassroomPicker.SelectedItem;
                int classroomID = selectedClassroom.Id;
                var slist = DependencyService.Get<SQLiteInterface>().GetClassroomAllotments(classroomID);
                list.ItemsSource = null;
                list.ItemsSource = slist;
            }
            else
            {
                await DisplayAlert("Title", "Please select any Classroom", "", "Yes");
            }
        }
    }
}