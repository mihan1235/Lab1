using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace library
{
    [Serializable]
    public class Programmer : Person, IDeepCopy, IEnumerable, IComparable<IAverageTimeFrame>, IComparer<IAverageTimeFrame>, IAverageTimeFrame
    {
        private List<Project> projects;


        public Programmer(string _firstName = "Alex", string _lastName = "Brown", DateTime _birthday = new DateTime()) :
        base(_firstName, _lastName, _birthday.Day, _birthday.Month, _birthday.Year)
        {
            projects = new List<Project>();
        }

        public Programmer(Person _lecturer, double _experience) :
        base(_lecturer.Name, _lecturer.Surname, _lecturer.Birthday.Day, _lecturer.Birthday.Month, _lecturer.Birthday.Year)
        {
            projects = new List<Project>();
        }

        public List<Project> ProjectsList
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
            }
        }

        public double AverageTimeFrame
        {
            get
            {
                double average_time = 0;
                for (int i = 0; i < ProjectsList.Count; i++)
                {
                    if (projects[i].TimeFrame == TimeFrame.Long)
                    {
                        average_time++;
                    }
                }
                return average_time / ProjectsList.Count;
            }
        }

        public void AddProjects(params Project[] list)
        {
            if (list != null)
            {
                projects.AddRange(list);
            }
        }

        public string Subject
        {
            get
            {
                string str = ""; ;
                foreach (var project in projects)
                {
                    str += project.Theme + ", ";
                }
                return str;
            }
        }

        object IDeepCopy.DeepCopy()
        {
            Programmer DCopy = new Programmer(this.Name, this.Surname, this.Birthday);

            foreach (var project in projects)
            {
                DCopy.projects.Add(project.DeepCopy() as Project);
            }
            return DCopy;
        }

        public new Programmer DeepCopy()
        {
            Programmer DCopy = new Programmer(this.Name, this.Surname, this.Birthday);

            foreach (var project in projects)
            {
                DCopy.projects.Add(project.DeepCopy() as Project);
            }
            return DCopy;
        }

        public IEnumerator GetEnumerator()
        {
            return new IteratorProgrammer(this);
        }

        public override string ToString()
        {
            string output = "Programmer is ";
            output = output + base.ToString();

            for (int i = 0; i < ProjectsList.Count; i++)
            {
                output = output + ' ' + ProjectsList[i].ToString();
            }
            return output;
        }

        public override string ToShortString()
        {
            string output = "Programmer is ";
            output = output + base.ToString();
            return output;
        }
        public int CompareTo(IAverageTimeFrame obj)
        {
            if (this.AverageTimeFrame < obj.AverageTimeFrame)
            {
                return -1;
            }
            if (this.AverageTimeFrame > obj.AverageTimeFrame)
            {
                return 1;
            }
            return 0;
        }

        public int Compare(IAverageTimeFrame obj1, IAverageTimeFrame obj2)
        {
            return obj1.CompareTo(obj2);
        }
    }

    public class IteratorProgrammer : IEnumerator
    {
        Programmer obj;
        int index = -1;
        public IteratorProgrammer(Programmer obj)
        {
            this.obj = obj;
        }

        public bool MoveNext()
        {
            while (index < obj.ProjectsList.Count - 1)
            {
                index++;
                Project rd = obj.ProjectsList[index] as Project;
                if (rd.Count != 1)
                {
                    this.MoveNext();
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return obj.ProjectsList[index];
            }
        }
    }
}