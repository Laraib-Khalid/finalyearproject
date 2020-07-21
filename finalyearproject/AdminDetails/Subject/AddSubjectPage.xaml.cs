using System;
using System.Collections.Generic;
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
        Subjects subjectDetails;
        public AddSubjectPage(Subjects details)
        {
            InitializeComponent();
            if (details != null)
            {
                subjectDetails = details;
                PopulateDetails(subjectDetails);
            }
        }
        private void PopulateDetails(Subjects details)
        {
            Name.Text = details.Name;
            Code.Text = details.Code;
            CourseType.SelectedItem = details.CourseType;
            Semester.SelectedItem = details.Semester;
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
                        if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                        {
                            if (string.IsNullOrEmpty((string)Department.SelectedItem))
                            {
                                NameError.IsVisible = true;
                                CodeError.IsVisible = true;
                                SemesterError.IsVisible = true;
                                CourseError.IsVisible = true;
                                DepartmentError.IsVisible = true;
                            }
                            else
                            {
                                NameError.IsVisible = true;
                                CodeError.IsVisible = true;
                                SemesterError.IsVisible = true;
                                CourseError.IsVisible = true;
                                DepartmentError.IsVisible = false;
                            }
                        }
                        else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = false;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = false;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                    {
                        if (string.IsNullOrEmpty((string)Department.SelectedItem))
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = false;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = false;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
                {
                    if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                    {
                        if (string.IsNullOrEmpty((string)Department.SelectedItem))
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = false;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = true;
                            CodeError.IsVisible = false;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                {
                    if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = true;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                {
                    NameError.IsVisible = true;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = true;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty(Code.Text))
            {
                if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
                {
                    if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                    {
                        if (string.IsNullOrEmpty((string)Department.SelectedItem))
                        {
                            NameError.IsVisible = false;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = true;
                        }
                        else
                        {
                            NameError.IsVisible = false;
                            CodeError.IsVisible = true;
                            SemesterError.IsVisible = true;
                            CourseError.IsVisible = true;
                            DepartmentError.IsVisible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = false;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                {
                    if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = true;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = false;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = true;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = true;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            
            else if (string.IsNullOrEmpty((string)CourseType.SelectedItem))
            {
                if (string.IsNullOrEmpty((string)Semester.SelectedItem))
                {
                    if (string.IsNullOrEmpty((string)Department.SelectedItem))
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = true;
                    }
                    else
                    {
                        NameError.IsVisible = false;
                        CodeError.IsVisible = false;
                        SemesterError.IsVisible = true;
                        CourseError.IsVisible = true;
                        DepartmentError.IsVisible = false;
                    }
                }
                else if (string.IsNullOrEmpty((string)Department.SelectedItem))
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = true;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = false;
                    CourseError.IsVisible = true;
                    DepartmentError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty((string)Semester.SelectedItem))
            {
                if (string.IsNullOrEmpty((string)Department.SelectedItem))
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = true;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = true;
                }
                else
                {
                    NameError.IsVisible = false;
                    CodeError.IsVisible = false;
                    SemesterError.IsVisible = true;
                    CourseError.IsVisible = false;
                    DepartmentError.IsVisible = false;
                }
            }
            else if (string.IsNullOrEmpty((string)Department.SelectedItem))
            {
                NameError.IsVisible = false;
                CodeError.IsVisible = false;
                SemesterError.IsVisible = false;
                CourseError.IsVisible = false;
                DepartmentError.IsVisible = true;
            }
            else if (addbtn.Text == "Add Subject")
            {
                Subjects sub = new Subjects();
                sub.Name = Name.Text;
                sub.Code = Code.Text;
                sub.CourseType = (string)CourseType.SelectedItem;
                sub.Semester = (string)Semester.SelectedItem;
                sub.Department = (string)Department.SelectedItem;
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
                subjectDetails.Name = Name.Text;
                subjectDetails.Code = Code.Text;
                subjectDetails.CourseType = (string)CourseType.SelectedItem;
                subjectDetails.Semester = (string)Semester.SelectedItem;
                subjectDetails.Department = (string)Department.SelectedItem;
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
        }
    } }