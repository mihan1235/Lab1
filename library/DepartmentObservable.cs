using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace library
{
    public class DepartmentObservable : ObservableCollection<Person>
    {
        bool collection_is_changed;
        public bool CollectionIsChanged
        {
            get
            {
                return collection_is_changed;
            }
            set
            {
                collection_is_changed = value;
            }
        }
        public bool PercentageOfResearchers
        {
            get;
            set;
        }

        List<Paper> papers_set = new List<Paper>();

        public List<Paper> PapersSet
        {
            get
            {
                return papers_set;
            }
        }

        public DepartmentObservable()
        {
            
            //AddDefaultPerson();
            //AddDefaultPerson();
            //AddDefaultPerson();
            papers_set.Add(new Paper("How not to do bad things",0,new DateTime(1995,05,31)));
            papers_set.Add(new Paper("Why doese nobody need functional analysis",0, new DateTime(2002, 12, 01)));
            papers_set.Add(new Paper("Why everybody love C language!?", 0, new DateTime(2017, 01, 13)));
            papers_set.Add(new Paper("Do we need to learn Fortran in 2017",0,new DateTime(2017,02,16)));
            CollectionChanged += detect_collection_changed;
        }

        private void detect_collection_changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionIsChanged = true;
        }

        public void AddDefaultPerson()
        {
            Add(new Person());
        }

        public void AddDefaultResearcher()
        {
            Add(new Researcher());
        }

        public void AddDefaultProgrammer()
        {
            Add(new Programmer());
        }

        public void AddProgrammer(Programmer pr)
        {
            Add(pr);
        }

        public override string ToString()
        {
            string str = "";
            foreach(var item in Items)
            {
                str += item.ToString();
            }
            return str;
        }
    }
}
