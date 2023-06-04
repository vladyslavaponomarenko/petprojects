using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab3_composite
{
    class Course : Entity
    {
        private List<Flow> list_of_flows;

        public Course(string course_name) :
            base(course_name)
        {
            this.list_of_flows = new List<Flow>();
        }

        public void PrintCourseInfo()
        {
            WriteLine($"Course name: {this.name}. Average mark on course: {this.CountCourseMarks()}.Flows: ");
            foreach (Flow f in list_of_flows)
            {
                f.PrintFlowInfo();
                //WriteLine();
            }
            WriteLine();
        }

        public override void Remove(Entity entity)
        {
            list_of_flows.Remove((Flow)entity);
        }
        public override void Add(Entity entity)
        {
            list_of_flows.Add((Flow)entity);
        }
        public double CountCourseMarks()
        {
            double sum = 0;

            foreach (Flow f in this.list_of_flows)
            {
                sum += f.CountFlowMarks();
            }

            return sum / this.list_of_flows.Count;
        }
    }
}
