using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VendingMachine.Functions;

namespace VendingMachine.Data
{
    public class vendingmachinedata : Ivending
    {
        readonly int[] moneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        int[] isValid_PoolMoney = new int[2] {0, 0};
        List<product> listOfDetails = new List<product>();

        //List of all products in Vending machine
        List<items> listOfProducts = new List<items>()
        {
            new items() { Name = "Cola", Price = 20, Message = "Enjoy the drink" },
            new items() { Name = "Sprit", Price = 25, Message = "Enjoy the drink" },
            new items() { Name = "Pepsi", Price = 30, Message = "Enjoy the drink" },
            new items() { Name = "Kex", Price = 100, Message = "Enjoy the chocolate" },
            new items() { Name = "Bounty", Price = 200, Message = "Enjoy the chocolate" },
            new items() { Name = "Mars", Price = 50, Message = "Enjoy the chocolate" },
            new items() { Name = "Chile Nötter", Price = 500, Message = "Enjoy the snacks" },
            new items() { Name = "Chips", Price = 150, Message = "Enjoy the snacks" },
            new items() { Name = "Sandwich", Price = 80, Message = "Enjoy the snacks" },
        };


        public List<product> ShowAll()
        { 

            Drinks cola = new Drinks(listOfProducts[0].Name, listOfProducts[0].Price);
            Drinks sprite = new Drinks(listOfProducts[1].Name, listOfProducts[1].Price);
            Drinks pepsi = new Drinks(listOfProducts[2].Name, listOfProducts[2].Price);
            chocolates kex = new chocolates(listOfProducts[3].Name, listOfProducts[3].Price);
            chocolates Bounty = new chocolates(listOfProducts[4].Name, listOfProducts[4].Price);
            chocolates mars = new chocolates(listOfProducts[5].Name, listOfProducts[5].Price);
            Snacks chilenötter = new Snacks(listOfProducts[6].Name, listOfProducts[6].Price);
            Snacks chips = new Snacks(listOfProducts[7].Name, listOfProducts[7].Price);
            Snacks wasasandwich = new Snacks(listOfProducts[8].Name, listOfProducts[8].Price);

            listOfDetails.Add(cola);
            listOfDetails.Add(sprite);
            listOfDetails.Add(pepsi);
            listOfDetails.Add(kex);
            listOfDetails.Add(Bounty);
            listOfDetails.Add(mars);
            listOfDetails.Add(chilenötter);
            listOfDetails.Add(chips);
            listOfDetails.Add(wasasandwich);

            return listOfDetails;
        }

        //Implimentation of show all denominations to purchase product
        public int[] ValidDenominations()
        {
            return moneyDenominations;
        }

        public int Purchaseproduct(int productNumber)
        {
            var itemCost = listOfProducts[productNumber-1].Price;
            return itemCost;
        }

        //Implimentation of InserMoney function
        public int[] InsertMoney(int insertMoney)
        {
            if (moneyDenominations.Contains(insertMoney))
            {  
                isValid_PoolMoney[0] = 1;
                isValid_PoolMoney[1] += insertMoney;
            }
            return isValid_PoolMoney;
        }

        //Implimentation of EndTransaction functiom
        public double EndTransaction(int userInputMoney, int totalProductCost)
        {
            double remainingbalance = 0.0;
            remainingbalance = userInputMoney - totalProductCost;
            return remainingbalance;
        }

        // Product Message
        public string ProductMsg(int productNumber)
        {
            var itemMessage = listOfProducts[productNumber].Message;
            return itemMessage;
        }

        public class items
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Message { get; set; }
        }

    }
}
