using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OOP_2
{
    public class Person
    {
        public int age;
        public double height;
        public int number;
        public int address;
        public int weight;
        public Person()
        {
            age = 0;
            height = 0;
            number = 0;
            address = 0;
            weight = 0;
        }
        public Person(int Age, double Height, int Number, int Address, int Weight)
        {
            age = Age;
            height = Height;
            number = Number;
            address = Address;
            weight = Weight;
        }

        static Random random = new Random(1000);
        public static Person[] GenPerson(int count)
        {
            Person[] Mass = new Person[count];
            for (int i = 0; i < count; i++)
            {
                int age = random.Next(1, 90);
                double height = 100 + random.NextDouble() * 50;
                int number = random.Next(1, 500);
                int address = random.Next(10, 200);
                int weight = random.Next(50, 120);
                Mass[i] = new Person(age, height, number, address, weight);
            }
            return Mass;
        }
    }

    class Program
    {
        const string TextPath = @"C:\textC#\C#0.1";
        const string BinPath = @"C:\textC#\C#0.2";
        static void WriteFileText(int count)
        {
            using (StreamWriter sw = new StreamWriter(TextPath))
            {
                int part = 1000000;

                for (int start = 0; start < count; start += part)
                {
                    int partSize = Math.Min(part, count - start);
                    Person[] persons = Person.GenPerson(partSize);

                    for (int i = 0; i < persons.Length; i++)
                    {
                        sw.WriteLine($"{persons[i].age};{persons[i].height};{persons[i].number};{persons[i].address};{persons[i].weight}");
                    }
                }
            }
        }

        static void WriteFileBinary(int count)
        {
            using (FileStream fs = new FileStream(BinPath, FileMode.Create))
            using (BinaryWriter sw = new BinaryWriter(fs, Encoding.UTF8))
            {
                int part = 1000000;

                for (int start = 0; start < count; start += part)
                {
                    int partSize = Math.Min(part, count - start);
                    Person[] persons = Person.GenPerson(partSize);

                    for (int i = 0; i < persons.Length; i++)
                    {
                        sw.Write(persons[i].age);
                        sw.Write(persons[i].height);
                        sw.Write(persons[i].number);
                        sw.Write(persons[i].address);
                        sw.Write(persons[i].weight);
                    }
                }
            }
        }

        static void ReadFileText()
        {
            using (StreamReader sr = new StreamReader(TextPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] personData = line.Split(';');
                    Person person = new Person(int.Parse(personData[0]),double.Parse(personData[1]),int.Parse(personData[2]),int.Parse(personData[3]),int.Parse(personData[4]));
                }
            }
        }

        static void ReadFileBinary()
        {
            using (FileStream stream = new FileStream(BinPath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int age = reader.ReadInt32();
                    double height = reader.ReadDouble();
                    int number = reader.ReadInt32();
                    int address = reader.ReadInt32();
                    int weight = reader.ReadInt32();
                    Person person = new Person(age, height, number, address, weight);
                }
            }


        }

        static void Main(string[] args)
        {
            int[] personCount = { 10, 1000, 100000, 1000000, 10000000, 100000000 };
            double TextWriteTime, TextReadTime, BinaryWriteTime, BinaryReadTime;
            foreach (int n in personCount)
            {
                Stopwatch time = new Stopwatch();
                time.Start();
                WriteFileText(n);
                time.Stop();
                TextWriteTime = time.Elapsed.TotalSeconds;


                time.Restart();
                ReadFileText();
                time.Stop();
                TextReadTime = time.Elapsed.TotalSeconds;

                time.Restart();
                WriteFileBinary(n);
                time.Stop();
                BinaryWriteTime = time.Elapsed.TotalSeconds;

                time.Restart();
                ReadFileBinary();
                time.Stop();
                BinaryReadTime = time.Elapsed.TotalSeconds;

                Console.WriteLine($"Данные для {n} элементов:");
                Console.WriteLine($"Текстовый файл:\nВремя записи: {TextWriteTime}\tВремя считывания: {TextReadTime}");
                Console.WriteLine($"Бинарный файл:\nВремя записи: {BinaryWriteTime}\tВремя считывания: {BinaryReadTime}\n");

                File.Delete(TextPath);
                File.Delete(BinPath);
            }
        }
    }
}
