using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12_User_GC
{
    public class PeopleStorage<T> :IDisposable
    {
        public event Action RemoveUserEvent;
        public event Action AddUserEvent;
        private List<T> list;
        public PeopleStorage()
        {
            this.list = new List<T>();
        }


        public void AddUser(T item)
        {
            list.Add(item);
            AddUserEvent?.Invoke();
        }

        public void RemoveUser(T item)
        {
            list.Remove(item);
            RemoveUserEvent?.Invoke();
        }

        //public void RemoveUserMessage()
        //{
        //    Console.WriteLine("Person has been deleted");
        //}

        //public void AddUserMessage()
        //{
        //    Console.WriteLine("Person has been added");
        //}
        public void ShowAll()
        {
            foreach (T item in this.list)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(this));
        }
    }
}
