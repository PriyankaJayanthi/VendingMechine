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
            bool isContinue = true;
            string addMoney = "N";
            string SelectProduct = "N";
            int totalProducts = 0;
            int totalProductsCost = 0;
            int[] isValidMoney_poolMoney;
            List<int> allProductsSelected = new List<int>();
            int productNumber;
            do
            {

                // List all products using ShowAll

                // Display headers
                Console.WriteLine("************** Welcome to the Vending Machine *******************");
                Console.WriteLine("Products available for Purchase\n");
                string header = String.Format("{0,-4}{1,-20}{2,8}\n",
                                         "No#", "Product", "Price (SEK)");

                vendingmachinedata machineObject = new vendingmachinedata();
                List<product> listOfProducts = new List<product>();
                listOfProducts = machineObject.ShowAll();
                Console.WriteLine(header);
                foreach (var s in listOfProducts)
                {
                    totalProducts += 1;
                    string data = String.Format("{0,-4}{1,-28}",
                                         totalProducts, s.ProductName());
                    Console.WriteLine(data);
                    
                }

                // Purchase products from the list
                do
                {
                    // Select product number to buy 
                    Console.WriteLine("Please select product by choosing product number");
                    productNumber = int.Parse(Console.ReadLine());
                    if(1 <= productNumber && productNumber <= totalProducts)
                    {
                        var s = listOfProducts[productNumber - 1];
                        Console.WriteLine("Selected Product successfully: {0}", s.ProductName().Substring(0, 20));
                        int productCost = machineObject.Purchaseproduct(productNumber);
                        totalProductsCost += productCost;
                        allProductsSelected.Add(productNumber - 1);
                    }
                    else
                    {
                        Console.WriteLine("******>>>> Invalid Product Number");
                    }
                    Console.WriteLine("******>>>> Press Y to continue buying");

                    SelectProduct = Console.ReadLine().ToUpper();

                } while(SelectProduct == "Y");

                // Total amount required to buy
                Console.WriteLine("Total Amount Required to buy products {0}", totalProductsCost);

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
                        Console.WriteLine("******>>>> In valid denomination. Total Money available for purchase : {0}", isValidMoney_poolMoney[1]);
                    }
                    Console.WriteLine("******>>>> Press Y to add more money");
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
                Console.Clear();
                string Bheader = String.Format("{0,-20}{1,-20}{2,-30}",
                                               "Products Purchased", "Price (SEK)", "Product Description");
                Console.WriteLine("*****************************************");
                Console.WriteLine("************ Thank you ******************");
                Console.WriteLine(Bheader);
                foreach (int s in allProductsSelected)
                {
                    var p = listOfProducts[s];
                    string productMsg = machineObject.ProductMsg(s);
                    string Bdata = String.Format("{0,-28}{1,30}",
                                                 p.ProductName(),productMsg);
                    Console.WriteLine(Bdata);
                }
                Console.WriteLine("*********>>>>>>>>");
                Console.WriteLine("Total Cost of the products : {0} SEk", totalProductsCost);
                Console.WriteLine("Money to Return to User : {0} SEK", change);
                Console.WriteLine("would you like to continue or exit. Enter Any Key - Continue or N - Exit");
                var key = Console.ReadLine().ToUpper();
                if (key == "N")
                {
                    isContinue = false;
                    Console.WriteLine("Thanks for shopping");
                    Console.ReadKey();
                }


            } while (isContinue);

        }
    }
}
