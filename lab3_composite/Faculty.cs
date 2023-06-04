using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab3_composite
{
    class Faculty : Entity
    {
        private List<Course> list_of_courses;

        public Faculty(string faculty_name) :
            base(faculty_name)
        {
            this.list_of_courses = new List<Course>();
        }

        public void PrintFacultyInfo()
        {
            WriteLine($"Faculty name: {this.name}. Average mark on faculty: {this.CountFacultyMarks()}. Courses: ");
            foreach (Course c in list_of_courses)
            {
                c.PrintCourseInfo();
                //WriteLine();
            }
            WriteLine();
        }
        public double CountFacultyMarks()
        {
            double sum = 0;

            foreach (Course c in this.list_of_courses)
            {
                sum += c.CountCourseMarks();
            }

            return sum / this.list_of_courses.Count;
        }

        public override void Remove(Entity entity)
        {
            list_of_courses.Remove((Course)entity);
        }
        public override void Add(Entity entity)
        {
            list_of_courses.Add((Course)entity);
        }
    }
}
