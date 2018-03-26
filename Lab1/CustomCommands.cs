using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab1
{
    class CustomCommands
    {
        // Создание команды AddCustomProgrammer
        private static RoutedUICommand add_custom_programmer;

        static CustomCommands()
        {
            // Инициализация команды
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
            //requery = new RoutedUICommand("Requery", "Requery", typeof(CustomCommands), inputs);
            add_custom_programmer = new RoutedUICommand("AddCustomProgrammer", "AddCustomProgrammer", typeof(CustomCommands));
        }

        public static RoutedUICommand AddCustomProgrammer
        {
            get { return add_custom_programmer; }
        }
    }
}
