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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
        
        void save_DOCollection()
        {
            SaveFileDialog save_diag = new SaveFileDialog();
            if (save_diag.ShowDialog() == true)
            {
                try
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    using (Stream fStream = new FileStream(save_diag.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var DO = (DepartmentObservable)this.FindResource("key_department");
                        binFormat.Serialize(fStream, DO);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void new_make_DOCollection(object sender, RoutedEventArgs e)
        {
            var DO = (DepartmentObservable)this.FindResource("key_department");
            if (DO.CollectionIsChanged)
            {
                MessageBoxResult result = MessageBox.Show("Collection is changed! Do you want to save it?", "Warning",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    save_DOCollection();
                }
            }
            Application.Current.Resources["key_department"] = new DepartmentObservable();
        }

        private void open_DOCollection(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_diag = new OpenFileDialog();
            if (open_diag.ShowDialog() == true)
            {
                try
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    Stream fStream = File.OpenRead(open_diag.FileName);
                    DepartmentObservable DO = (DepartmentObservable)binFormat.Deserialize(fStream);
                    Application.Current.Resources["key_department"] = DO;
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.ToString(),"Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void save_DOCollection(object sender, RoutedEventArgs e)
        {
            save_DOCollection();
            var DO = (DepartmentObservable)this.FindResource("key_department");
            DO.CollectionIsChanged = false;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var DO = (DepartmentObservable)this.FindResource("key_department");
            if (DO.CollectionIsChanged)
            {
                MessageBoxResult result = MessageBox.Show("Collection is changed! Do you want to save it?", "Warning",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    save_DOCollection();
                }
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
