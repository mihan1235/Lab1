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
using System.Windows.Shapes;
using library;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для DialogCustomProgrammer.xaml
    /// </summary>
    public partial class DialogCustomProgrammer : Window
    {
        public DialogCustomProgrammer()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
        }

        public Programmer GetCustomProgrammer()
        {
            Programmer obj = new Programmer();
            if (CustomProgrammerName.Text.Length != 0)
            {
                obj.Name = CustomProgrammerName.Text;
            }
            if (CustomProgrammerSurname.Text.Length != 0)
            { 
                obj.Surname = CustomProgrammerSurname.Text;
            }
            
            if(CustomProgrammerBirth.SelectedDate != null)
            {
                obj.Birthday = (DateTime)CustomProgrammerBirth.SelectedDate;
            }
            foreach(var item in ProjectList.SelectedItems)
            {
                obj.ProjectsList.Add((Project) item);
            }
            return obj;
        }

        private void NotAccept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
