using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp_Improved.ToDos
{
    // ToDo - класс, описывающий дело.
    public class ToDo : ICloneable
    {
        public string Title { get; set; }       // заголовок
        public string Description { get; set; } // описание дела
        public DateTime DeadLine { get; set; }  // дедлайн
        public int Priority { get; set; }       // приоритет - неотрицательное число, приоритет == 0 считается наивысшим.

        // конструктор по умолчанию
        public ToDo() { }

        public override string ToString()
        {
            return $"{Title}";
        }

        public object Clone()
        {
            return new ToDo()
            {
                Title = Title,
                Description = Description,
                DeadLine = DeadLine,
                Priority = Priority
            };
        }
    }
}
