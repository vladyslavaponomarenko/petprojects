using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab3_composite
{
    class Flow : Entity
    {
        private List<Group> list_of_groups;

        public Flow(string flow_name) :
            base(flow_name)
        {
            this.list_of_groups = new List<Group>();
        }

        public void PrintFlowInfo()
        {
            double av_mark;
            WriteLine($"Flow name: {this.name}. Average mark: {av_mark = this.CountFlowMarks()}. Groups: ");
            foreach (Group g in list_of_groups)
            {
                g.PrintGroupInfo();
                //WriteLine();
            }
            WriteLine();
        }

        public override void Remove(Entity entity)
        {
            list_of_groups.Remove((Group)entity);
        }
        public override void Add(Entity entity)
        {
            list_of_groups.Add((Group)entity);
        }
        public double CountFlowMarks()
        {
            double sum = 0;

            foreach (Group g in this.list_of_groups)
            {
                sum += g.CountGroupMarks();
            }

            return sum / this.list_of_groups.Count;
        }
    }
}
