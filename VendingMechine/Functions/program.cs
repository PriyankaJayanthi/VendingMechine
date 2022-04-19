using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using VendingMachine.Functions;
using VendingMachine.Data;


namespace VendingMechine.Model
{
    class program
    {
        static void Main(string[] args)
        {
            // Initialize
            bool isContinue = false;
            string addMoney = "N";

            do
            {

                // List all products using ShowAll

                // Display headers
                Console.WriteLine("************** Welcome to the Vending Machine *******************");
                Console.WriteLine("Products available for Purchase\n");
                string header = String.Format("{0,-12}{1,8}\n",
                                          "Product", "Price (SEK)");

                vendingmachinedata machineObject = new vendingmachinedata();
                List<product> listOfProducts = new List<product>();
                listOfProducts = machineObject.ShowAll();
                Console.WriteLine(header);
                foreach (var s in listOfProducts)
                {
                    Console.WriteLine(s.ProductName());
                }

                // Purchase products


                // Insert Money to the pool
                int[] moneyList = machineObject.ValidDenominations();

                do
                {
                    // Request user to enter money
                    Console.WriteLine("Please inset your money in a fixed denominations 1kr, 5kr,10kr,20kr,50kr,100kr, 500kr, 1000kr");
                    int userMoney = int.Parse(Console.ReadLine());
                    //Check if entered money is valid
                    int []isValidMoney_poolMoney= machineObject.InsertMoney(userMoney);
                    if(isValidMoney_poolMoney[0] == 1)
                    {
                        Console.WriteLine("Money Added Successfully. Total Money available for purchase : {0}", isValidMoney_poolMoney[1]);
                    }
                    else
                    {
                        Console.WriteLine("In valid denomination. Money was not added. Total Money available for purchase : {0}", isValidMoney_poolMoney[1]);
                    }
                    Console.WriteLine("Would you like to enter more money. Press Y to add more money");
                    addMoney = Console.ReadLine().ToUpper();

                } while (addMoney == "Y");
                


                // End Transaction 

            } while (isContinue);

        }
    }
}
