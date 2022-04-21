using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace VendingMachine.Functions
{
    // Interface
   public interface Ivending
    {
        // To display list of all products
       public List<product> ShowAll();

        // To purchase product 
        public int Purchaseproduct(int productNumber);

        // Insert Money to buy product
        public int[] InsertMoney(int insertmoney);

        // End Transactions and return if any money left in pool
        public double EndTransaction(int userInputMoney, int totalProductCost);
    }
}
