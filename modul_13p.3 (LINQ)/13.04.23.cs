using static modul_13p._3__LINQ_.Program;
using System;

namespace modul_13p._3__LINQ_
{
    /*Задание 1:
    Создайте пользовательский тип Телефон. 
    Необходимо хранить такую информацию:
      Название телефона
      Производитель
      Цена
      Дата выпуска
    Для массива телефонов выполните следующие задания, используя агрегатные операции из LINQ:
      Посчитайте количество телефонов
      Посчитайте количество телефонов с ценой больше 100
      Посчитайте количество телефонов с ценой в диапазоне от 400 до 700
      Посчитайте количество телефонов конкретного производителя
      Найдите телефон с минимальной ценой
      Найдите телефон с максимальной ценой
      Отобразите информацию о самом старом телефоне
      Отобразите информацию о самом свежем телефоне
      Найдите среднюю цену телефона*/
    internal class Program
    {
        public class Phone
        {
            public string Name { get; set; }          // Название телефона
            public string Manufacturer { get; set; }  // Производитель
            public decimal Price { get; set; }        // Цена
            public DateTime ReleaseDate { get; set; } // Дата выпуска
        }    
        static void Main(string[] args)
        {
            Phone[] phones =
            {
            new Phone { Name = "iPhone 12", Manufacturer = "Apple", Price = 999, ReleaseDate = new DateTime(2020, 10, 23) },
            new Phone { Name = "Galaxy S21", Manufacturer = "Samsung", Price = 799, ReleaseDate = new DateTime(2021, 1, 14) },
            new Phone { Name = "iPhone 10", Manufacturer = "Apple", Price = 969, ReleaseDate = new DateTime(2021, 3, 23) },
            new Phone { Name = "Pixel 5", Manufacturer = "Google", Price = 699, ReleaseDate = new DateTime(2020, 10, 15) },
            new Phone { Name = "Mi 11 ", Manufacturer = "Xiaomi", Price = 749, ReleaseDate = new DateTime(2021, 2, 8) }
            };
            Console.WriteLine("Все телефоны: \n");
            foreach (Phone phone in phones)
            {
                Console.WriteLine($"Название: {phone.Name}\tПроизводитель: {phone.Manufacturer}\tЦена: {phone.Price}\tДата выпуска: {phone.ReleaseDate}");
            }
            // количество телефонов
            int CountPhones = phones.Count();
            Console.WriteLine($"\nОбщее количество телефонов: {CountPhones} шт.\n");

            // количество телефонов с ценой больше 100
            int result = phones.Count(p => p.Price > 100);
            Console.WriteLine($"Телефоны с ценой больше $100: {result} шт.\n");

            // количество телефонов с ценой в диапазоне от 400 до 700
            result = phones.Count(p => p.Price >= 400 && p.Price <= 700);
            Console.WriteLine($"Телефоны с ценой от $400 до $700: {result} шт.\n");

            // количество телефонов конкретного производителя
            string manufacturer = "Apple";
            int applePhones = phones.Count(p => p.Manufacturer == manufacturer);
            Console.WriteLine($"{manufacturer} телефоны: {applePhones} шт.\n");

            // телефон с минимальной ценой
            var min = phones.OrderBy(p => p.Price).Take(1);
            foreach (Phone phone in min)
                Console.WriteLine($"Телефон с минимальной ценой: {phone.Name}, ${phone.Price} \n");

            // телефон с максимальной ценой
            var max = phones.OrderByDescending(p => p.Price).Take(1);
            foreach (Phone phone in max)
                Console.WriteLine($"Телефон с максимальной ценой: {phone.Name}, ${phone.Price} \n");

            // информация о самом старом телефоне
            var old = phones.OrderBy(p => p.ReleaseDate).Take(1);
            foreach (Phone phone in old)
                Console.WriteLine($"Самый старый телефон: {phone.Name}, выпущенный {phone.ReleaseDate} \n");

            // информация о самом свежем телефоне
            var new1 = phones.OrderByDescending(p => p.ReleaseDate).Take(1);
            foreach (Phone phone in new1)
                Console.WriteLine($"Самый новый телефон: {phone.Name} , выпущенный  {phone.ReleaseDate} \n");

            // средняя цена телефона
            decimal averagePrice = phones.Average(p => p.Price);
            Console.WriteLine($"Средняя цена телефона: ${averagePrice} \n");

            /*Задание 2:
            Добавьте к первому заданию новую функциональность:
             Отобразите пять самых дорогих телефонов
             Отобразите пять самых дешевых телефонов
             Отобразите три самых старых телефона
            Отобразите три самых новых телефона
            Для реализации задания используйте семейство методов Skip, Take*/

            // Отобразите пять самых дорогих телефонов
            var max5 = phones.OrderByDescending(p => p.Price).Take(5);
            Console.WriteLine("Пять самых дорогих телефонов:");
            foreach (var phone in max5)
            {
                Console.WriteLine(" {0} - цена: {1}$", phone.Name, phone.Price);
            }

            // Отобразите пять самых дешевых
            var min5 = phones.OrderBy(p => p.Price).Take(5);
            Console.WriteLine("Пять самых дешевых телефонов:");
            foreach (var phone in min5)
            {
                Console.WriteLine(" {0} - цена: {1}$", phone.Name, phone.Price);
            }
            Console.WriteLine();

            // Отобразите три самых старых телефона
            var old3 = phones.OrderBy(p => p.ReleaseDate).Take(3);
            Console.WriteLine("Три самые старые телефоны:");
            foreach (var phone in old3)
            {
                Console.WriteLine(" {0} - выпущен {1}", phone.Name, phone.ReleaseDate);
            }
            Console.WriteLine();

            // Отобразите три самых новых телефона
            var new3 = phones.OrderByDescending(p => p.ReleaseDate).Take(3);
            Console.WriteLine("Три самые новые телефоны:");
            foreach (var phone in new3)
            {
                Console.WriteLine(" {0} - выпущен {1}", phone.Name, phone.ReleaseDate);
            }
            Console.WriteLine();

            /*Задание 3:
            Добавьте к первому заданию новую функциональность:
             Отобразите статистику по количеству телефонов каждого производителя. 
            Например: Sony – 3, Samsung – 4, Apple – 5 и т. д.
             Отобразите статистику по количеству моделей телефонов.
            Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8 
             Отобразите статистику телефонов по годам. 
            Например: 2021 – 10, 2022 – 5, 2019 – 3 */

            //Статистика по количеству телефонов каждого производителя:
            var phonesByManufacturer = phones.GroupBy(p => p.Manufacturer).Select(g => new { Manufacturer = g.Key, Count = g.Count() });
            Console.WriteLine("Статистика по количеству телефонов каждого производителя:");
            foreach (var phone in phonesByManufacturer)
                Console.WriteLine($"{phone.Manufacturer} - {phone.Count}");

            //Статистика по количеству моделей телефонов:
            var phonesByName = phones.GroupBy(p => p.Name).Select(g => new { Name = g.Key, Count = g.Count() });
            Console.WriteLine("\nСтатистика по количеству моделей телефонов:");
            foreach (var phone in phonesByName)
                Console.WriteLine($"{phone.Name} - {phone.Count}"); 

            //Статистика телефонов по годам:
            var phonesByYear = phones.GroupBy(p => p.ReleaseDate.Year).Select(g => new { Year = g.Key, Count = g.Count() });
            Console.WriteLine("\nСтатистика телефонов по годам:");
            foreach (var phone in phonesByYear) 
                Console.WriteLine($"{phone.Year} - {phone.Count}");
        }

    }
}