using System;
using VendingMachine.Functions;

namespace VendingMachine.Functions
{
    public class Drinks : product
    {
            public string Name { get; set; }
            public int Price { get; set; }
            public Drinks(string name, int price)
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
