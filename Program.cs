using System;

namespace Lesson12_User_GC
{
    class Program
    {
        static void Main(string[] args)
        {
            var start1 = DateTime.Now;

            Console.WriteLine(" Реализовать бенчмарк на создание \n 10 000 000 объектов User (ФИО и возраст).\n ");

            // Смотрим размер памяти в байтах которую занимают обьекты в управляемоц куче
            Console.WriteLine(" Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));

            // Свойство MaxGeneration - возвращает макс. колл. поколений (отсчет с нуля поэтому + 1)
            Console.WriteLine(" Система поддерживает {0} поколения \n ", (GC.MaxGeneration + 1));

            // Создаем новый лбьект в динамической памяти (куче)
            PeopleStorage<User> peopleStorage = new PeopleStorage<User>();
           
            peopleStorage.AddUser(new User(" First name 1 ", " Last name 1 ", " MiddlName 1", 18));

            peopleStorage.ShowAll();

            // Метод GetGeneration() возвращает поколение к которому относится данный обьект
            Console.WriteLine("\n Обьект peopleStorage относится к {0} поколению \n", GC.GetGeneration(peopleStorage));
            Console.WriteLine(" Размер памяти в байтах в управляемой куче: {0}\n", GC.GetTotalMemory(false));

            ShowGCStart();
            var start2 = DateTime.Now;

            int count = 10000;
            //int count = 10000000;
            for (int i = 0; i < count; i++)
            {
                //Console.Write($" {i} \n");
                peopleStorage.AddUser(new User());
            }
           
            peopleStorage.ShowAll();
            var start3 = DateTime.Now;

            Console.WriteLine("\n Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));
            // peopleStorage = null;
            Console.WriteLine("\n Массив построен запускаем GC \n");

            ShowGCStart();

            // Метод Collect() дает указание сборщику мусора проверять обьекты определенного 
            // поколения ( в данном случае - 2 )
            GC.Collect();

            var start4 = DateTime.Now;

           
            Console.WriteLine("\n Размер памяти в байтах в управляемой куче: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("\n Обьект peopleStorage относится к {0} поколению ", GC.GetGeneration(peopleStorage));

            Console.WriteLine("\n С начала программы: отработал " + start1.Minute + " секунд ");
            Console.WriteLine("\n Начало создания обьектов: отработал " + start2.Minute + " секунд ");
            Console.WriteLine("\n Обьекты созданны отработал " + start3.Minute + " секунд ");
            Console.WriteLine("\n Начало удаления обьектов отработал " + start4.Minute + " секунд ");
            Console.WriteLine("\n Разница времени старта ПО и завершения " + (start4 - start1).TotalMilliseconds + " миллисекунд ");
            Console.WriteLine("\n Разница времени старта ПО и завершения " + (start4 - start1).ToString() + " секунд \n");

            ShowGCStart();

            Console.Read();
        }
        private static void ShowGCStart()
        {
            Console.WriteLine("\n Поколение 0 проверялось {0} раз: ", GC.CollectionCount(0));
            Console.WriteLine("\n Поколение 1 проверялось {0} раз: ", GC.CollectionCount(1));
            Console.WriteLine("\n Поколение 2 проверялось {0} раз: ", GC.CollectionCount(2));

        }
    }

}
