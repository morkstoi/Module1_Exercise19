using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeOfComputers
{
    class Computer
    {
        public string Code { get; set; }
        public string BrandName { get; set; }
        public string Processor { get; set; }
        public double ProcessorFrequency { get; set; }
        public int RAM { get; set; }
        public int HardDrive { get; set; }
        public int GraphicsMemory { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>
            {
                new Computer () {Code ="001", BrandName = "HP", Processor = "Intel Core i5", ProcessorFrequency = 2.4, RAM = 16, HardDrive = 512, GraphicsMemory = 4,  Price = 500, Quantity =40},
                new Computer () {Code ="002", BrandName = "Dell", Processor = "AMD Ryzen 3", ProcessorFrequency = 3.8, RAM = 12, HardDrive = 1024, GraphicsMemory = 8,  Price = 720, Quantity =26},
                new Computer () {Code ="003", BrandName = "HP", Processor = "Intel Core i7", ProcessorFrequency = 4.0, RAM = 16, HardDrive = 2048, GraphicsMemory = 8,  Price = 1060, Quantity =20},
                new Computer () {Code ="004", BrandName = "Apple", Processor = "Intel Core i7", ProcessorFrequency = 3.6, RAM = 16, HardDrive = 1024, GraphicsMemory = 6,  Price = 1400, Quantity =8},
                new Computer () {Code ="005", BrandName = "Asus", Processor = "Intel Core i9", ProcessorFrequency = 4.4, RAM = 32, HardDrive = 1024, GraphicsMemory = 12,  Price = 1600, Quantity =14},
                new Computer () {Code ="006", BrandName = "Acer", Processor = "AMD Ryzen 5", ProcessorFrequency = 3.2, RAM = 8, HardDrive = 512, GraphicsMemory = 8,  Price = 860, Quantity =19},
                new Computer () {Code ="007", BrandName = "Lenovo", Processor = "Intel Core i3", ProcessorFrequency = 2.8, RAM = 8, HardDrive = 512, GraphicsMemory = 4,  Price = 360, Quantity =75},
                new Computer () {Code ="008", BrandName = "Alienware", Processor = "Intel Core i9", ProcessorFrequency = 5.4, RAM = 32, HardDrive = 1024, GraphicsMemory = 24,  Price = 2500, Quantity =14},
            };

            Console.WriteLine("Введите название процессора:");
            string processor = Console.ReadLine();
            List<Computer> computersProcessor = computers.Where(x => x.Processor == processor).ToList();
            Print(computersProcessor);

            Console.WriteLine("Введите минимальное количество ОЗУ:");
            int ramSearch = Convert.ToInt32(Console.ReadLine());
            List<Computer> computersWithRam = computers.Where(x => x.RAM > ramSearch).ToList();
            Print(computersWithRam);

            List<Computer> computersSortedByPrice = computers.OrderBy(x => x.Price).ToList();
            Print(computersSortedByPrice);

            IEnumerable<IGrouping<string, Computer>> processorType = computers.GroupBy(x => x.Processor);
            foreach (IGrouping<string, Computer> gr in processorType)
            {
                Console.WriteLine("Процессор:" + gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine(c.BrandName +"-"+c.Price);
                }

            }

            Computer mostExpensiveComputer = computers.OrderByDescending(x => x.Price).First();
            Console.WriteLine("Самый дорогой компьютер: " + mostExpensiveComputer.BrandName + " - " + mostExpensiveComputer.Price);

            Computer cheapestComputer = computers.OrderBy(x => x.Price).First();
            Console.WriteLine("Самый дешевый компьютер: " + cheapestComputer.BrandName + " - " + cheapestComputer.Price);

            Console.WriteLine(computers.Any (x=>x.Quantity>=30));
            Console.ReadKey();
        }
        private static void Print(List<Computer> computers)
        {
            foreach (var c in computers)
            {
                Console.WriteLine("Код: " + c.Code);
                Console.WriteLine("Марка: " + c.BrandName);
                Console.WriteLine("Тип процессора: " + c.Processor);
                Console.WriteLine("Частота процессора: " + c.ProcessorFrequency + " ГГц");
                Console.WriteLine("Объем ОЗУ: " + c.RAM + " ГБ");
                Console.WriteLine("Объем жесткого диска: " + c.HardDrive + " ГБ");
                Console.WriteLine("Объем памяти видеокарты: " + c.GraphicsMemory + " ГБ");
                Console.WriteLine("Цена: " + c.Price);
                Console.WriteLine("Количество экземпляров: " + c.Quantity);
            }
            Console.WriteLine();
        }
    }

    
}
