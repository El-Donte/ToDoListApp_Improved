using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.ToDos
{
    // InMemoryToDoStorage - имплементация IToDoStorage, которая хранит все данные в RAM
    public class InMemoryToDoStorage : IToDoStorage
    {
        // дела хранятся в ОЗУ
        private List<ToDo> toDos = new List<ToDo>();

        public void Add(ToDo toDo)
        {
            toDos.Add(toDo.Clone() as ToDo);
        }

        public ToDo GetByTitle(string title)
        {
            return toDos.First(toDo => toDo.Title == title).Clone() as ToDo;
        }

        public List<ToDo> ListAll()
        {
            return toDos.Select(toDo => toDo.Clone() as ToDo).ToList();
        }

        public ToDo RemoveByTitle(string title)
        {
            ToDo removed = GetByTitle(title);   // 1. получить дело
            toDos.RemoveAll(todo => todo.Title == title);              // 2. удалить дело
            return removed;
        }

        public ToDo UpdateByTitle(string title, ToDo toDo)
        {
            ToDo updated = toDos.First(td => td.Title == title);   // 1. получить дело (не клона)
            updated.Description = toDo.Description;
            updated.DeadLine = toDo.DeadLine;
            updated.Priority = toDo.Priority;
            return updated;
        }
    }
}
