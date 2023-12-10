using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_1.Data
{
    /// <summary>
    /// Component class of a composite structure
    /// </summary>
    public abstract class StudentGroupAbstract
    {
        public StudentGroupAbstract() { }
        public virtual void Add(StudentGroupAbstract studentGroup)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(StudentGroupAbstract studentGroup)
        {
            throw new NotImplementedException();
        }

        public abstract void TakeExam(int indent = 0);
        public abstract void DisplayInfo(int indent = 0);
        public virtual bool IsComposite()
        {
            return true;
        }

    }
}
