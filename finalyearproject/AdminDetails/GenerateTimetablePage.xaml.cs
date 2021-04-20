using finalyearproject.AdminDetails;
using SQLite;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
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
                int teacherID = selectedTeacher.ID;
                var teacherName = selectedTeacher.Name.ToString();
                var mlist= DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                var tlist = DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                var wlist = DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                var thlist = DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                var flist = DependencyService.Get<SQLiteInterface>().GetTeacherAllotments(teacherID);
                list.ItemsSource = null;
                list.ItemsSource = flist;
                list.IsVisible = true;
                txtteacher.Text = teacherName;
                txtteacher.IsVisible = true;
                txtclass.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Title", "Please select any Teacher","","Yes");
            }
        }

        private void gclassroombtn_Clicked(object sender, EventArgs e)
        {
            _ = classroomActionAsync();
        }
        private async Task classroomActionAsync()
        {
            if (ClassroomPicker.SelectedIndex != -1)
            {
                var selectedClassroom = (Classrooms)ClassroomPicker.SelectedItem;
                int classroomID = selectedClassroom.Id;
                var classroomName = selectedClassroom.Name.ToString();
                var slist = DependencyService.Get<SQLiteInterface>().GetClassroomAllotments(classroomID);
                list.ItemsSource = null;
                list.ItemsSource = slist;
                list.IsVisible = true;
                txtclass.Text = classroomName;
                txtclass.IsVisible = true;
                txtteacher.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Title", "Please select any Classroom", "", "Yes");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
        }
    }
}