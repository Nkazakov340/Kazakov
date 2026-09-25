using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("goods.txt", "");
            GoodDaoFileRepository repository = new GoodDaoFileRepository();

            GoodDao good1 = new GoodDao
            {
                Id = 1,
                Name = "Телефон",
                Code = 123
            };
            GoodDao good2 = new GoodDao
            {
                Id = 2,
                Name = "Клавиатура",
                Code = 133
            };
            repository.Create(good1);
            repository.Create(good2);
            Console.WriteLine("Товары добавлены");

            GoodDao foundGood = repository.Read(1);
            Console.WriteLine($"Найден: {foundGood.Name}, код товара: {foundGood.Code}");

            good1.Name = "Аэрогриль";
            good1.Code = 200;
            repository.Update(good1);
            Console.WriteLine("Товар обновлён");

            List<GoodDao> goods = repository.ReadAll();

            Console.WriteLine("Все товары:");
            foreach (GoodDao item in goods)
            {
                Console.WriteLine($"ID:{item.Id}, Название:{item.Name}, Код: {item.Code}");
            }

            repository.Delete(1);
            Console.WriteLine("Товар удалён");
            goods = repository.ReadAll();
            foreach (GoodDao item in goods)
            {
                Console.WriteLine($"ID:{item.Id}, Название:{item.Name}, Код: {item.Code}");
            }
        }
    }
}
