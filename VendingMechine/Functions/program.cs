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
            string SelectProduct = "N";
            int totalProducts = 0;
            int totalProductsCost = 0;
            int[] isValidMoney_poolMoney;

            do
            {

                // List all products using ShowAll

                // Display headers
                Console.WriteLine("************** Welcome to the Vending Machine *******************");
                Console.WriteLine("Products available for Purchase\n");
                string header = String.Format("{0,-20}{1,8}\n",
                                          "Product", "Price (SEK)");

                vendingmachinedata machineObject = new vendingmachinedata();
                List<product> listOfProducts = new List<product>();
                listOfProducts = machineObject.ShowAll();
                Console.WriteLine(header);
                foreach (var s in listOfProducts)
                {
                    Console.WriteLine(s.ProductName());
                    totalProducts += 1;
                }

                // Purchase products from the list
                do
                {
                    // Select product number to buy 
                    Console.WriteLine("Please select product by choosing product number");
                    int productNumber = int.Parse(Console.ReadLine());
                    if(1 <= productNumber && productNumber <= totalProducts)
                    {
                        var s = listOfProducts[productNumber - 1];
                        Console.WriteLine("Selected Product successfully: {0}", s.ProductName().Substring(0, 20));
                        int pno = machineObject.Purchaseproduct(productNumber);
                        totalProductsCost += pno;
                    }
                    else
                    {
                        Console.WriteLine("Selected Product Number is Invalid. No Product has been selected");
                    }
                    Console.WriteLine("Would you like to select more products. Press Y to continue buying");

                    SelectProduct = Console.ReadLine().ToUpper();

                } while(SelectProduct == "Y");


                // Insert Money to the pool
                int[] moneyList = machineObject.ValidDenominations();
                do
                {
                    // Request user to enter money
                    Console.WriteLine("Please inset your money in a fixed denominations 1kr, 5kr,10kr,20kr,50kr,100kr, 500kr, 1000kr");
                    int userMoney = int.Parse(Console.ReadLine());
                    //Check if entered money is valid
                    isValidMoney_poolMoney= machineObject.InsertMoney(userMoney);
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
                    if (addMoney != "Y")
                    {
                        if (totalProductsCost > isValidMoney_poolMoney[1])
                        {
                            Console.WriteLine("Insufficient Money to buy products");
                            addMoney = "Y";
                        }

                    }
                } while (addMoney == "Y");

                // End Transaction
                double change = machineObject.EndTransaction(isValidMoney_poolMoney[1], totalProductsCost);
                Console.WriteLine(change);

            } while (isContinue);

        }
    }
}
