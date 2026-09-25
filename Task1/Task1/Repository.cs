using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Repository
    {
        public static List<Good> InitGoods()
        {
            List<Good> goods = new List<Good>();
            Random rand = new Random(1000);
            for (int i = 1; i <= 20; i++)
            {
                goods.Add(new Good(i, $"Товар номер {i}", rand.Next(1,500)));
            }

            return goods;
        }
        public static void WriteGoods(List<Good> goods)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\textC#\goods.txt"))
            {
                foreach (Good good in goods)
                {
                    writer.WriteLine(good);
                }
            }
        }
        public static List<Good> ReadGoods()
        {
            List < Good > goods = new List<Good>();

            if (File.Exists(@"C:\textC#\goods.txt") == false)
            {
                return goods;
            }
            using(StreamReader reader = new StreamReader(@"C:\textC#\goods.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    goods.Add(new Good(int.Parse(data[0]), data[1], int.Parse(data[2])));
                }
            }
            return goods;
        }
        public static void PrintGoods(List<Good> goods)
        {
            Console.WriteLine("Реестр товаров:");
            foreach (Good good in goods)
            {
                Console.WriteLine($"ID:{good.ID}; Название:{good.Name}; Код:{good.Code}");
            }
        }

        public static List<Client> InitClients()
        {
            List<Client> clients = new List<Client>
            {
            new Client(1, "Иван", "Иванов", "Иванович", new DateTime(2012, 2, 1)),
            new Client(2, "Петр", "Петров", "Петрович", new DateTime(1998, 5, 15)),
            new Client(3, "Анна", "Сидорова", "Алексеевна", new DateTime(2002, 10, 20)),
            new Client(4, "Алексей", "Смирнов", "Сергеевич", new DateTime(1995, 3, 12)),
            new Client(5, "Мария", "Кузнецова", "Ивановна", new DateTime(2014, 8, 7))
            };

            return clients;
        }
        public static void WriteClients(List<Client> clients)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\textC#\clients.txt"))
            {
                foreach (Client client in clients)
                {
                    writer.WriteLine(client);
                }
            }
        }

        public static List<Client> ReadClients()
        {
            List<Client> clients = new List<Client>();

            if (File.Exists(@"C:\textC#\clients.txt") == false)
            {
                return clients;
            }
            using (StreamReader reader = new StreamReader(@"C:\textC#\clients.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    clients.Add(new Client(int.Parse(data[0]),data[1],data[2],data[3],DateTime.Parse(data[4])));
                }
            }
            return clients;
        }
        public static void PrintClients(List<Client> clients)
        {
            Console.WriteLine("Реестр клиентов");

            foreach (Client client in clients)
            {
                Console.WriteLine($"ID: {client.ID}, ФИО: {client.LastName} {client.FirstName} {client.Patronymic}, ");
                Console.WriteLine($"Дата рождения: {client.BirthDay:dd.MM.yyyy}, Возраст: {client.Age}");
            }
        }
        public static List<Shop> InitShops()
        {
            List<Shop> shops = new List<Shop>{new Shop(1, "Пятерочка", 1425),new Shop(2, "Магнит", 7435),new Shop(3, "Перекресток", 2467)};
            return shops;
        }

        public static void WriteShops(List<Shop> shops)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\textC#\shops.txt"))
            {
                foreach (Shop shop in shops)
                {
                    writer.WriteLine(shop);
                }
            }
        }

        public static List<Shop> ReadShops()
        {
            List<Shop> shops = new List<Shop>();

            if (File.Exists(@"C:\textC#\shops.txt") == false)
            {
                return shops;
            }
            using (StreamReader reader = new StreamReader(@"C:\textC#\shops.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    shops.Add(new Shop(int.Parse(data[0]), data[1], int.Parse(data[2])));
                }
            }
            return shops;
        }

        public static void PrintShops(List<Shop> shops)
        {
            Console.WriteLine("Реестр магазинов");

            foreach (Shop shop in shops)
            {
                Console.WriteLine($"ID: {shop.ID}, Название: {shop.Name}, Код: {shop.Code}");
            }
        }
    }
}
