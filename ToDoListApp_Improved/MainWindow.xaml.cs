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
using ToDoListApp_Improved.ToDos;

namespace ToDoListApp_Improved
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // объект, который используется для выполнения операций со списком дел
        private readonly IToDoStorage _toDoStorage;

        public MainWindow(IToDoStorage toDoStorage)
        {
            InitializeComponent();
            // инициализация
            _toDoStorage = toDoStorage;
            ViewToDoList();
        }

        // вспомогательная процедура вывода данных из хранилища IToDoStorage
        private void ViewToDoList()
        {
            toDoListBox.Items.Clear();
            foreach (ToDo toDo in _toDoStorage.ListAll())
            {
                toDoListBox.Items.Add($"{toDoListBox.Items.Count+1}. {toDo}");
            }
        }

        // обработчик изменения выбора в списке
        private void toDoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // вывести данные о выбранном элементе в Label
            if (toDoListBox.SelectedIndex != -1)
            {
                string toDoTitle = toDoListBox.SelectedItem as string;
                toDoTitle = toDoTitle.Substring(toDoTitle.IndexOf(".") + 2);
                ToDo toDo = _toDoStorage.GetByTitle(toDoTitle);
                titleLabel.Content = toDo.Title;
                descriptionLabel.Content = toDo.Description;
                deadLineLabel.Content = toDo.DeadLine;
                priorityLabel.Content = toDo.Priority;
            }
            else
            {
                titleLabel.Content = string.Empty;
                descriptionLabel.Content = string.Empty;
                deadLineLabel.Content = string.Empty;
                priorityLabel.Content = string.Empty;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoFormWindow toDoFormWindow = new ToDoFormWindow();
                Hide();
                toDoFormWindow.ShowDialog();
                if (toDoFormWindow.ToDoForm == null)
                {
                    return;
                }
                _toDoStorage.Add(toDoFormWindow.ToDoForm);
                ViewToDoList();
            } catch
            {
                MessageBox.Show("error!"); // TODO: write normal error message
            } finally
            {
                Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(toDoListBox.SelectedIndex != -1)
                {
                    List<ToDo> toDo = _toDoStorage.ListAll();
                    ToDo deleted = _toDoStorage.RemoveByTitle(toDo[toDoListBox.SelectedIndex].Title);
                    MessageBox.Show($"Дело {deleted.Title} удалено из списка.","Удаление",
                                        MessageBoxButton.OK,MessageBoxImage.Information); 
                }
                ViewToDoList();
            }
            catch
            {
                MessageBox.Show("error!"); // TODO: write normal error message
            }
            finally
            {
                Show();
            }
        }

        private void redactButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (toDoListBox.SelectedIndex != -1)
                {
                    List<ToDo> toDo = _toDoStorage.ListAll();
                    ToDo slectedToDo = toDo[toDoListBox.SelectedIndex];
                    ToDoFormWindow toDoFormWindow = new ToDoFormWindow(slectedToDo.Title, slectedToDo.Description, 
                                                                        slectedToDo.DeadLine, slectedToDo.Priority.ToString());
                    Hide();
                    toDoFormWindow.ShowDialog();
                    if (toDoFormWindow.ToDoForm == null)
                    {
                        return;
                    }
                    ToDo update = _toDoStorage.UpdateByTitle(toDoFormWindow.ToDoForm.Title, toDoFormWindow.ToDoForm);
                    MessageBox.Show($"Дело {update.Title} Изменено.", "Редактирование",
                                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ViewToDoList();
            }
            catch
            {
                MessageBox.Show("error!"); // TODO: write normal error message
            }
            finally
            {
                Show();
            }
        }
    }
}
