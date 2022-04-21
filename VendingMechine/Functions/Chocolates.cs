using System;

namespace VendingMachine.Functions
{
    public class chocolates : product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public chocolates(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ProductName()
        {
            return string.Format("{0,-20}{1,8:N0}", Name, Price);
        }

    }
}
