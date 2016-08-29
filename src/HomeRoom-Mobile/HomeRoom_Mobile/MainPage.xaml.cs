using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Models;
using Xamarin.Forms;

namespace HomeRoom_Mobile
{
    public partial class MainPage : ContentPage
    {
        public static List<Course> Courses { get; set; } 
        public MainPage()
        {
            Courses = new List<Course>
            {
                new Course
                {
                    Name = "Math 101",
                    Subject = "Math",
                    Teacher = "Mrs. Smith"
                },
                new Course
                {
                    Name = "English 101",
                    Subject = "English",
                    Teacher = "Mr. Joe"
                },
                new Course
                {
                    Name = "History 101",
                    Subject = "History",
                    Teacher = "Mrs. Price"
                }
            };
            InitializeComponent();
        }
    }
}
