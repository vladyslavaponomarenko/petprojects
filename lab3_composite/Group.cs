using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab3_composite
{
    class Group : Entity
    {
        private List<Student> list_of_students;

        public Group(string group_name) : base(group_name)
        {
            this.list_of_students = new List<Student>();
        }

        public override void Remove(Entity entity)
        {
            list_of_students.Remove((Student)entity);
        }
        public override void Add(Entity entity)
        {
            list_of_students.Add((Student)entity);
        }
        public void PrintGroupInfo()
        {
            double av_mark;
            WriteLine($"Group name: {this.name}. Average group mark: {av_mark = this.CountGroupMarks()}. Students: ");
            foreach (Student s in list_of_students)
            {
                s.PrintStudentInfo();
                //WriteLine();
            }
            WriteLine();
        }

        public double CountGroupMarks()
        {
            double sum = 0;

            foreach (Student s in this.list_of_students)
            {
                sum += s.CountStudentMarks();
            }

            return sum / this.list_of_students.Count;
        }
    }
}

