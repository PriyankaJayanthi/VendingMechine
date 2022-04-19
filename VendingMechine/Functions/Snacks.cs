using System;

namespace VendingMachine.Functions
{
    public class Snacks : product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Snacks(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ProductName()
        {
            return string.Format("{0,-12}{1,8:N0}", Name, Price);
        }
    }
}
