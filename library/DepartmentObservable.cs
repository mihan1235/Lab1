using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace library
{
    public class DepartmentObservable : ObservableCollection<Person>
    {
        bool collection_changed;
        public bool DOCollectionChanged
        {
            get
            {
                return collection_changed;
            }
            set
            {
                collection_changed = value;
            }
        }
        public bool PercentageOfResearchers
        {
            get;
            set;
        }

        List<Paper> PapersSet;

        public DepartmentObservable()
        {
            //CollectionChanged += detect_collection_changed();
            AddDefaultPerson();
            AddDefaultPerson();
            AddDefaultPerson();
        }

        private void detect_collection_changed()
        {

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
