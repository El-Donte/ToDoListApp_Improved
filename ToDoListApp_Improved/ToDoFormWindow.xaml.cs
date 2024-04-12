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
using ToDoListApp_Improved.ToDos;

namespace ToDoListApp_Improved
{
    /// <summary>
    /// Логика взаимодействия для ToDoFormWindow.xaml
    /// </summary>
    public partial class ToDoFormWindow : Window
    {
        private ToDo toDoForm; 

        public ToDo ToDoForm {  get { return toDoForm; } }

        // ToDoFormWindow - окно формы заполнения дела
        public ToDoFormWindow()
        {
            InitializeComponent();
            toDoForm = null;
            deadlineDatePicker.SelectedDate = DateTime.Now;
        }
        
        public ToDoFormWindow(string title, string desc, DateTime date, string priority)
        {
            InitializeComponent();
            toDoForm = null;
            titleTextBox.Text = title;
            descriptionTextBox.Text = desc;
            deadlineDatePicker.SelectedDate = date;
            priorityComboBox.Text = priority;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            toDoForm = new ToDo()
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                DeadLine = (DateTime)deadlineDatePicker.SelectedDate,
                Priority = Convert.ToInt32(priorityComboBox.Text)
            };
            Close(); // закрыть форму
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
