using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Good> goods = Repository.InitGoods();
            Repository.WriteGoods(goods);
            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);

            Console.WriteLine();

            List<Client> clients = Repository.InitClients();
            Repository.WriteClients(clients);
            clients = Repository.ReadClients();
            Repository.PrintClients(clients);

            Console.WriteLine();

            List<Shop> shops = Repository.InitShops();
            Repository.WriteShops(shops);
            shops = Repository.ReadShops();
            Repository.PrintShops(shops);

            Console.WriteLine();

            List<Good> newGoods = new List<Good>();

            Random rand = new Random(1000);
            for (int i = 21; i <= 30; i++)
            {
                newGoods.Add(new Good(i, $"Новый товар номер {i}", rand.Next(1,500)));
            }

            goods.AddRange(newGoods);
            Repository.WriteGoods(goods);

            Console.WriteLine($"В goods.txt записано товаров: {goods.Count}");

            Console.WriteLine();

            clients.Add(new Client(
                6,
                "Дарья",
                "Трифонова",
                "Алексеевна",
                new DateTime(2007, 9, 13)
            ));

            clients.Add(new Client(
                7,
                "Ольга",
                "Морозова",
                "Дмитриевна",
                new DateTime(2013, 7, 25)
            ));

            clients.Add(new Client(
                8,
                "Олег",
                "Муркаев",
                "Васильевич",
                new DateTime(1997, 12, 3)
            ));

            Repository.WriteClients(clients);

            Console.WriteLine($"В clients.txt записано клиентов: {clients.Count}");

            Console.WriteLine();

            shops.Add(new Shop(4, "Лента", 5667));
            shops.Add(new Shop(5, "Ашан", 4252));

            Repository.WriteShops(shops);

            Console.WriteLine($"В shops.txt записано магазинов: {shops.Count}");

            Console.WriteLine();

            Console.WriteLine("Обновленные реестры:");

            goods = Repository.ReadGoods();
            Repository.PrintGoods(goods);

            Console.WriteLine();

            clients = Repository.ReadClients();
            Repository.PrintClients(clients);

            Console.WriteLine();

            shops = Repository.ReadShops();
            Repository.PrintShops(shops);

        }
    }
}
