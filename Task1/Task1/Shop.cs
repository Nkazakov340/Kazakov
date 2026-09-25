using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Shop : IPrimary
    {
        public int ID { get; }
        public string Name { get; }
        public int Code { get; }
        public Shop(int id, string name, int code)
        {
            ID = id;
            Name = name;
            Code = code;
        }
        public override string ToString()
        {
            return $"{ID};{Name};{Code}";
        }
    }
}
