using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using library;
using Microsoft.Win32;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void FilterByResearcher(object sender, FilterEventArgs e)
        {
            if (e.Item is Researcher)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
         
        }

        private void FilterByProgrammer(object sender, FilterEventArgs e)
        {
            if (e.Item is Programmer)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void DO_add_def_person(object sender, RoutedEventArgs e)
        {
            var obj = (DepartmentObservable) this.FindResource("key_department");
            obj.AddDefaultPerson();
        }

        //private float count_persentage_of_researchers()
        //{
            
        //    return ListBoxRes.Items.Count / ListBoxP.Items.Count;
        //}

        private void DO_add_def_researcher(object sender, RoutedEventArgs e)
        {
            var obj = (DepartmentObservable)this.FindResource("key_department");
            obj.AddDefaultResearcher();
        }        

        private void new_make_DOCollection(object sender, RoutedEventArgs e)
        {

        }

        private void open_DOCollection(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_diag = new OpenFileDialog();
            if (open_diag.ShowDialog() == true)
            {

            }
        }

        private void save_DOCollection(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save_diag = new SaveFileDialog();
            if (save_diag.ShowDialog() == true)
            {

            }
        }

        private void add_custom_programmer(object sender, ExecutedRoutedEventArgs e)
        {
            DialogCustomProgrammer dialog = new DialogCustomProgrammer();
            if (dialog.ShowDialog() == true)
            {
                var obj = (DepartmentObservable)this.FindResource("key_department");
                obj.Add(dialog.GetCustomProgrammer());
            }
            else
            {
                
            }
        }

        private void ListBoxRes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Researcher res = (Researcher) ListBoxRes.SelectedItem;
            
        }

        private void add_def_programmer(object sender, ExecutedRoutedEventArgs e)
        {
            var obj = (DepartmentObservable)this.FindResource("key_department");
            obj.Add(new Programmer());
        }

        private void P_remove_programmer(object sender, RoutedEventArgs e)
        {
            int index = ListBoxP.SelectedIndex;
            var DO = (DepartmentObservable)this.FindResource("key_department");
            if (index != -1)
            {
                var prog = (Programmer) ListBoxP.Items.GetItemAt(index);
                DO.Remove(prog);
                //DO.RemoveAt(index);
            }
            MessageBox.Show(index.ToString());
        }

        private void DO_remove_obj(object sender, RoutedEventArgs e)
        {
            int index = ListboxDO.SelectedIndex;
            var DO = (DepartmentObservable)this.FindResource("key_department");
            if (index != -1)
            {
                DO.RemoveAt(index);
            }
            //MessageBox.Show(e.OriginalSource.ToString());
        }

        private void NoDateTemplate_Checked(object sender, RoutedEventArgs e)
        {
            ListboxDO.ItemTemplate = null;
            ListBoxP.ItemTemplate = null;
            ListBoxRes.ItemTemplate = null; ;
        }

        private void DateTemplate_Checked(object sender, RoutedEventArgs e)
        {
            DataTemplate template = (DataTemplate)this.FindResource("key_Item_DataTemplate");
            if (template != null)
            {
                ListboxDO.ItemTemplate = template;
                ListBoxP.ItemTemplate = template;
                ListBoxRes.ItemTemplate = template;
            }
        }
    }

        //private void remove_object(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var obj = (ListBox)e.Source;
        //    int index = obj.SelectedIndex;
        //    var DO = (DepartmentObservable)this.FindResource("key_department");
        //    if (index != -1)
        //    {
        //        DO.RemoveAt(index);
        //    }
        //}
    //}
}
