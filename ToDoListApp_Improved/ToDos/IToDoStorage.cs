using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.ToDos
{
    // IToDoStorage - интерфейс хранилища списка дел
    public interface IToDoStorage
    {
        // Add - добавление нового дела в список дел
        // вход: объект дела
        // выход: -
        void Add(ToDo toDo);

        // ListAll - метод получения всех дел
        // вход: -
        // выход: объекты дел в виде списка
        List<ToDo> ListAll();

        // GetByTitle - получить дело по заголовку
        ToDo GetByTitle(string title);

        // RemoveByTitle - удаления дела из списка по заголвоку
        // вход: заголовок
        // выход: удаленное из списка дело
        ToDo RemoveByTitle(string title);

        // UpdateByTitle - редактирование списка дел
        // вход: объект дела с установленным полем title и новыми значениями полей
        // выход: обновленный объект title
        ToDo UpdateByTitle(string titile, ToDo toDo);
    }
}
