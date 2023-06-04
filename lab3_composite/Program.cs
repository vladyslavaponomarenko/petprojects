using System;
using System.Collections.Generic;
using static System.Console;

namespace lab3_composite
{
    abstract class Entity
    {
        protected string name; 

        public Entity(string name)
        {
            this.name = name; 
        }
        public virtual void Add (Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove (Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsCompsite()
        {
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Helen");

            s.Add(10);
            //s.Remove(10);
            s.Add(1);
            s.Add(5);
            s.Add(9);

            s.PrintStudentInfo();
            s.CountStudentMarks();
            WriteLine();

            
            Student s2 = new Student("Harry");

            s2.Add(2);
            s2.Add(3);
            s2.Add(5);
            s2.Add(10);

            Student s3 = new Student("Alen");

            s3.Add(6);
            s3.Add(3);

            Student s4 = new Student("April");

            s4.Add(10);
            s4.Add(7);

            //s2.PrintStudentInfo();
            //s2.CountStudentMarks();

            
            Group g1 = new Group("KP-33");

            g1.Add(s);

            g1.Add(s2);
            //g1.Remove(s);


            Group g2 = new Group("KP-32");

            g2.Add(s3);

            Group g3 = new Group("KM-31");

            g3.Add(s4);

            g1.PrintGroupInfo();
            //g2.PrintGroupInfo();
            //g3.PrintGroupInfo();

            Flow f1 = new Flow("KP-3x");
            Flow f2 = new Flow("KM-3x");

            f1.Add(g1);
            f1.Add(g2);
            f2.Add(g3);

            f1.PrintFlowInfo();
            //f2.PrintFlowInfo();

            Course c1 = new Course("3x");

            c1.Add(f1);
            c1.Add(f2);

            c1.PrintCourseInfo();

            Faculty f = new Faculty("FAM");
            f.Add(c1);
            f.PrintFacultyInfo();
            
        }
    }
}
