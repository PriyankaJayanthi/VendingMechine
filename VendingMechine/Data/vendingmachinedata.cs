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

        public List<product> ShowAll()
        {
            List<product> listOfItems = new List<product>();

            Drinks cola = new Drinks("cola",15);
            Drinks sprite = new Drinks("Sprite",20);
            Drinks pepsi = new Drinks("Pepsi", 25);
            chocolates kex = new chocolates("Kex", 100);
            chocolates Bounty = new chocolates("Bounty", 200);
            chocolates mars = new chocolates("Mars", 50);
            Snacks chilenötter = new Snacks("ChileNötter", 500);
            Snacks chips = new Snacks("Chips", 150);
            Snacks wasasandwich = new Snacks("Sandwich", 80);
            
            listOfItems.Add(cola);
            listOfItems.Add(sprite);
            listOfItems.Add(pepsi);
            listOfItems.Add(kex);
            listOfItems.Add(Bounty);
            listOfItems.Add(mars);
            listOfItems.Add(chilenötter);
            listOfItems.Add(chips);
            listOfItems.Add(wasasandwich);

            return listOfItems;
        }

        //Implimentation of show all denominations to purchase product
        public int[] ValidDenominations()
        {
            return moneyDenominations;
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
    }
}
