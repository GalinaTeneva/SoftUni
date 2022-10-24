using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StoreBoxes
{
    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal BoxPrice
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }

        }
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (inputLine[0] != "end")
            {
                Box box = new Box
                {
                    SerialNumber = inputLine[0],
                    Item = new Item
                    {
                        Name = inputLine[1],
                        Price = decimal.Parse(inputLine[3]),
                    },
                    ItemQuantity = int.Parse(inputLine[2]),
                };

                boxes.Add(box);
                inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            List<Box> orderedBoxes = boxes.OrderByDescending(box => box.BoxPrice).ToList();
           
            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}\n" +
                    $"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}\n" +
                    $"-- ${box.BoxPrice:F2}");
            }
        }
    }
}

