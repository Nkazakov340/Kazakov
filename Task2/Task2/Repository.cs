using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    public interface IRepository<T>
    {
        void Create(T item);
        T Read(int id);
        List<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }

    public abstract class FileRepository<T> : IRepository<T>
    {
        protected string FileName;

        protected FileRepository(string fileName)
        {
            FileName = fileName;

            if (File.Exists(FileName) == false)
                File.Create(FileName).Close();
        }

        protected abstract int GetId(T item);
        protected abstract T FromString(string line);
        protected abstract string ToString(T item);

        public void Create(T item)
        {
            List<T> items = ReadAll();

            foreach (T existingItem in items)
            {
                if (GetId(existingItem) == GetId(item))
                {
                    throw new Exception("Объект с таким ID уже существует");
                }
            }

            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(ToString(item));
            }
        }

        public T Read(int id)
        {
            List<T> items = ReadAll();
            foreach (T item in items)
            {
                if (GetId(item) == id)
                {
                    return item;
                }
            }
            return default(T);
        }

        public List<T> ReadAll()
        {
            List<T> items = new List<T>();
            string[] lines = File.ReadAllLines(FileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    items.Add(FromString(line));
                }
            }
            return items;
        }

        protected int FindIndex(List<T> items, int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (GetId(items[i]) == id)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Update(T item)
        {
            List<T> items = ReadAll();
            int index = FindIndex(items, GetId(item));
            if (index == -1)
            {
                throw new Exception("Объект не найден");
            }
            items[index] = item;
            using (StreamWriter writer = new StreamWriter(FileName, false))
            {
                foreach (T UpdateItems in items)
                {
                    writer.WriteLine(ToString(UpdateItems));
                }
            }
        }

        public void Delete(int id)
        {
            List<T> items = ReadAll();
            int index = FindIndex(items, id);
            if (index == -1)
            {
                throw new Exception("Объект не найден");
            }
            items.RemoveAt(index);
            using (StreamWriter writer = new StreamWriter(FileName, false))
            {
                foreach (T UpdateItems in items)
                {
                    writer.WriteLine(ToString(UpdateItems));
                }
            }
        }
    }

    public class ShopDaoFileRepository : FileRepository<ShopDao>
    {
        public ShopDaoFileRepository()
            : base("shops.txt")
        {
        }

        protected override int GetId(ShopDao item)
        {
            return item.Id;
        }

        protected override ShopDao FromString(string line)
        {
            string[] data = line.Split(';');

            return new ShopDao
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Code = int.Parse(data[2])
            };
        }

        protected override string ToString(ShopDao item)
        {
            return $"{item.Id};{item.Name};{item.Code}";
        }
    }

    public class ClientDaoFileRepository : FileRepository<ClientDao>
    {
        public ClientDaoFileRepository() : base("clients.txt") { }

        protected override int GetId(ClientDao item)
        {
            return item.Id;
        }

        protected override ClientDao FromString(string line)
        {
            string[] data = line.Split(';');

            return new ClientDao
            {
                Id = int.Parse(data[0]),
                FirstName = data[1],
                LastName = data[2],
                Patronymic = data[3],
                BirthDate = DateTime.Parse(data[4])
            };
        }

        protected override string ToString(ClientDao item)
        {
            return $"{item.Id};{item.FirstName};{item.LastName};{item.Patronymic};{item.BirthDate:yyyy-MM-dd}";
        }
    }
    public class GoodDaoFileRepository : FileRepository<GoodDao>
    {
        public GoodDaoFileRepository()
            : base("goods.txt")
        {
        }

        protected override int GetId(GoodDao item)
        {
            return item.Id;
        }

        protected override GoodDao FromString(string line)
        {
            string[] data = line.Split(';');

            return new GoodDao
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Code = int.Parse(data[2])
            };
        }

        protected override string ToString(GoodDao item)
        {
            return $"{item.Id};{item.Name};{item.Code}";
        }
    }
}
