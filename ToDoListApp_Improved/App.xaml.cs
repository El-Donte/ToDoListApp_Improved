using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ToDoListApp_Improved.ToDos;

namespace ToDoListApp_Improved
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            IToDoStorage toDoStorage = new InMemoryToDoStorage();
            // добавим несколько дел
            for (int i = 1; i <= 3; i++)
            {
                toDoStorage.Add(new ToDo()
                {
                    Title = $"test#{i}",
                    Description = $"test#{i}",
                    DeadLine = DateTime.UtcNow.AddDays(i),
                    Priority = 10
                });
            }
            MainWindow mainWindow = new MainWindow(toDoStorage);
            mainWindow.Show();
        }
    }
}
