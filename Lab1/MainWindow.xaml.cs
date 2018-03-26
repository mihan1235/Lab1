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

        private void DO_add_def_researcher(object sender, RoutedEventArgs e)
        {
            var obj = (DepartmentObservable)this.FindResource("key_department");
            obj.AddDefaultResearcher();
        }

        //private void make_custom_programmer()
        //{
        //    DialogCustomProgrammer dialog = new DialogCustomProgrammer();
        //    if (dialog.ShowDialog() == true)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        //private void add_custom_programmer(object sender, RoutedEventArgs e)
        //{
        //    make_custom_programmer();
        //}

        //private void context_menu_custom_pr(object sender, RoutedEventArgs e)
        //{
        //    make_custom_programmer();
        //}

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

        private void DO_add_def_programmer(object sender, RoutedEventArgs e)
        {
            var obj = (DepartmentObservable)this.FindResource("key_department");
            obj.Add(new Programmer());
        }

        private void add_custom_programmer(object sender, ExecutedRoutedEventArgs e)
        {
            DialogCustomProgrammer dialog = new DialogCustomProgrammer();
            if (dialog.ShowDialog() == true)
            {

            }
            else
            {

            }
        }
    }
}
