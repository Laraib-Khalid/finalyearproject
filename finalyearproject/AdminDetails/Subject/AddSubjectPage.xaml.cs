using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace finalyearproject.AdminDetails.Subject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSubjectPage : ContentPage
    {
        public SQLiteConnection conn;
        Subjects subjectDetails;
        public AddSubjectPage(Subjects details)
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteInterface>().GetConnectionwithCreateDatabase();
            setDepartment();
            if (details != null)
            {
                subjectDetails = details;
                PopulateDetails(subjectDetails);
            }
        }
        private void setDepartment()
        {
            var getDepartment = conn.Query<Classrooms>("SELECT DISTINCT Department FROM Classrooms");
            Department.ItemsSource = getDepartment;
        }

        private void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            var department = (Classrooms)Department.SelectedItem;
            var getClass = conn.Query<Classrooms>("SELECT DISTINCT Id,Name FROM Classrooms where Department = '" + department.Department + "'");
            Classroom.ItemsSource = getClass;
        }
        private void PopulateDetails(Subjects details)
        {
            Name.Text = details.Name;
            Code.Text = details.Code;
            CourseType.SelectedItem = details.CourseType;
            Classroom.SelectedItem = details.ClassRoom;
            Department.SelectedItem = details.Department;
            addbtn.Text = "Update Subject";
            this.Title = "Edit Subject";
        }
        private void AddSubject(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                if (string.IsNullOrEmpty(Code.Text))
                {
                    if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
                    {
                        if ((Classrooms)Classroom.SelectedItem==null)
                        {
                            if ((Classrooms)Department.SelectedItem==null)
                            {
                                NameError.IsVisible = true;
                                CodeError.IsVisible = true;
                                ClassroomError.IsVisible = true;
                                CourseError.IsVisible = true;
                                DepartmentError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                CodeError.IsVisible = true;
                                ClassroomError.IsVisible = true;
                                CourseError.IsVisible = true;
                                DepartmentError.IsVisible = false;
                            }
                        }
                        else if ((Classrooms)Department.SelectedItem == null)
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = false;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = false;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if ((Classrooms)Classroom.SelectedItem == null)
                    {
                        if ((Classrooms)Department.SelectedItem == null)
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = false;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = false;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
                {
                    if ((Classrooms)Classroom.SelectedItem == null)
                    {
                        if ((Classrooms)Department.SelectedItem == null)
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = false;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = false;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if ((Classrooms)Classroom.SelectedItem == null)
                {
                    if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if ((Classrooms)Department.SelectedItem == null)
                {
                    NameError.IsVisible = true;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = true;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty(Code.Text))
            {
                if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
                {
                    if ((Classrooms)Classroom.SelectedItem == null)
                    {
                        if ((Classrooms)Department.SelectedItem == null)
                        {
                            NameError.IsVisible = false;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            CodeError.IsVisible = true;
                            ClassroomError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if ((Classrooms)Classroom.SelectedItem == null)
                {
                    if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if ((Classrooms)Department.SelectedItem == null)
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = true;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = true;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            
            else if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
            {
                if ((Classrooms)Classroom.SelectedItem == null)
                {
                    if ((Classrooms)Department.SelectedItem == null)
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = false;
                        ClassroomError.IsVisible = true;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if ((Classrooms)Department.SelectedItem == null)
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = true;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = false;
                    CourseError.IsVisible = true;
                    DepartmentError.IsVisible = false;
                }
            }
            else if ((Classrooms)Classroom.SelectedItem == null)
            {
                if ((Classrooms)Department.SelectedItem == null)
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = true;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    ClassroomError.IsVisible = true;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            else if ((Classrooms)Department.SelectedItem == null)
            {
                NameError.IsVisible = false;
                CodeError.IsVisible = false;
                ClassroomError.IsVisible = false;
                CourseError.IsVisible = false;
                DepartmentError.IsVisible = true;
            }
            else if (addbtn.Text == "Add Subject")
            {

                var SelectedDepartment = (Classrooms)Department.SelectedItem;
                var SelectedClassroom = (Classrooms)Classroom.SelectedItem;
                Subjects sub = new Subjects();
                sub.Name = Name.Text;
                sub.Code = Code.Text;
                sub.CourseType = (string)CourseType.SelectedItem;
                sub.ClassRoom = SelectedClassroom.Name;
                sub.Department = SelectedDepartment.Department;
                var chkDuplication = conn.Query<Subjects>("SELECT * FROM Subjects where Name='" + Name.Text + "' and Code='" + Code.Text + "' and CourseType='"+CourseType.SelectedItem+"'and ClassRoom='"+SelectedClassroom.Name+"'and Department='"+SelectedDepartment.Department+"'");
                if (chkDuplication.Count == 0)
                {
                    bool res = DependencyService.Get<SQLiteInterface>().AddSubject(sub);
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
                    DisplayAlert("Warning", "Data already exist", "", "Yes");
                }
            }
            else
            {
                var SelectedDepartment = (Classrooms)Department.SelectedItem;
                var SelectedClassroom = (Classrooms)Classroom.SelectedItem;
                subjectDetails.Name = Name.Text;
                subjectDetails.Code = Code.Text;
                subjectDetails.CourseType = (string)CourseType.SelectedItem;
                subjectDetails.ClassRoom = SelectedClassroom.Name;
                subjectDetails.Department = SelectedDepartment.Department;
                var chkDuplication = conn.Query<Subjects>("SELECT * FROM Subjects where Name='" + Name.Text + "' and Code='" + Code.Text + "' and CourseType='" + CourseType.SelectedItem + "'and ClassRoom='" + SelectedClassroom.Name + "'and Department='" + SelectedDepartment.Department + "'");
                if (chkDuplication.Count == 0)
                {
                    bool res = DependencyService.Get<SQLiteInterface>().UpdateSubject(subjectDetails);
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
                else
                {
                    DisplayAlert("Warning", "Data already exist", "", "Yes");
                }
            }
        }

    } }