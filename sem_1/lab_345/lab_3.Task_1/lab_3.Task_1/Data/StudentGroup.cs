using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_3.Task_1.Data
{
    /// <summary>
    /// Composite component of a composite structure
    /// </summary>
    public class StudentGroup : StudentGroupAbstract
    {
        public string Group { get; set; }
        public StudentGroup(string group)
        {
            Group = group;
        }

        protected List<StudentGroupAbstract> _students = new List<StudentGroupAbstract>();

        public override void Add(StudentGroupAbstract studentGroup)
        {
            this._students.Add(studentGroup);
        }

        public override void Remove(StudentGroupAbstract studentGroup)
        {
            this._students.Remove(studentGroup);
        }

        public override void DisplayInfo(int indent = 0)
        {
            if (_students.Count != 0)
                Console.WriteLine(Utils.Indent(indent) + "Group {0} has students:", Group);
            else
            {
                Console.WriteLine(Utils.Indent(indent) + "Group {0} has no students", Group);
                return;
            }

            foreach (StudentGroupAbstract studentGroup in _students)
            {
                studentGroup.DisplayInfo(indent + 4);
            }
        }

        public override void TakeExam(int indent = 0)
        {
            if (_students.Count != 0)
                Console.WriteLine(Utils.Indent(indent) + "Students from group {0} take exam ", Group);
            else
            {
                Console.WriteLine(Utils.Indent(indent) + "Group {0} has no students", Group);
                return;
            }

            foreach (StudentGroupAbstract studentGroup in _students)
            {
                studentGroup.TakeExam(indent + 4);
            }
        }

        public override bool IsComposite()
        {
            return true;
        }
    }
}
