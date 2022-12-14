using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace library
{
    [Serializable]
    public class DepartmentObservable : ObservableCollection<Person>, INotifyPropertyChanged,IDeserializationCallback
    {
        [NonSerialized]
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
                OnPropertyChanged(new PropertyChangedEventArgs("CollectionIsChanged"));
            }
        }

        double percentage_of_researchers = 0;
        public double PercentageOfResearchers
        {
            get
            {
                return percentage_of_researchers;
            }
            set
            {
                percentage_of_researchers = value;
            }


        }

        List<Paper> papers_set = new List<Paper>();

        public List<Paper> PapersSet
        {
            get
            {
                return papers_set;
            }
        }

        List<Project> projects_set = new List<Project>();

        public List<Project> ProjectSet
        {
            get
            {
                return projects_set;
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

            projects_set.Add(new Project("Microsoft Azure",0,TimeFrame.Long));
            projects_set.Add(new Project("Project Spiral", 0, TimeFrame.TwoYears));
            projects_set.Add(new Project("Skylon",0,TimeFrame.Long));
            projects_set.Add(new Project("Tesla Autopilot", 0, TimeFrame.Long));

            CollectionChanged += detect_collection_changed;
        }

        private double count_persentage_of_researchers()
        {
            var res_list = from obj in Items
                           where obj is Researcher
                           select obj;
            return (double)res_list.Count()/(double) Items.Count();
        }

        private void detect_collection_changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionIsChanged = true;
            percentage_of_researchers = count_persentage_of_researchers();
            OnPropertyChanged(new PropertyChangedEventArgs("PercentageOfResearchers"));
        }

        public void AddDefaultPerson()
        {
            Add(new Person());
        }

        Random rnd = new Random();
        char generate_rnd_char()
        {
            return (char)rnd.Next(0x0061, 0x007A);
        }

        string generate_rnd_string(int length = 6)
        {
            string name = "";
            for (int i = 0; i < length; i++)
            {
                name = name + generate_rnd_char();
            }
            return name;
        }

        public void AddDefaultResearcher()
        {
            var obj = new Researcher(generate_rnd_string(), generate_rnd_string());
            obj.PapersList.Add(new Paper());
            //((Paper)papers_set.ElementAt(2)).PublicationAuthorAmount++;
            obj.ProjectsList.Add(new Project());
            Add(obj);
            //percentage_of_researchers = count_persentage_of_researchers();
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

        public void OnDeserialization(object sender)
        {
            //percentage_of_researchers = 0;
            collection_is_changed = false;
            CollectionChanged += detect_collection_changed;
        }
    }
}
