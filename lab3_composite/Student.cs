using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab3_composite
{
    class Student : Entity
    {

        private List<int> list_of_marks;

        public Student(string student_name) :
            base(student_name)
        {
            this.list_of_marks = new List<int>();
        }

        public void PrintStudentInfo()
        {
            Write($"Student name: {this.name}. Marks: ");
            for (int i = 0; i < this.list_of_marks.Count; i++)
            {
                Write($"{this.list_of_marks[i]}; ");
            }

            double sum = this.CountStudentMarks();
            Write($"Average mark: {sum}. ");
            WriteLine();
        }
        public void Add(int mark)
        {
            list_of_marks.Add(mark);
        }

        public void Remove(int mark)
        {
            list_of_marks.Remove(mark);
        }

        public double CountStudentMarks()
        {
            double sum = 0;

            foreach (int m in this.list_of_marks)
            {
                sum += m;
            }

            return sum / this.list_of_marks.Count;

        }

    }
}
