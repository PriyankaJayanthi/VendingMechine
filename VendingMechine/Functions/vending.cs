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
        //public int[] Purchaseproduct();

        // Insert Money to buy product
        public int[] InsertMoney(int insertmoney);

        //public double EndOfTrancation(int user_input_money, int number_of_product);
    }
}
