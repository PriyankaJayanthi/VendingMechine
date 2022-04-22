using System;
using Xunit;
using System.Collections.Generic;
using VendingMachine.Functions;
using VendingMachine.Data;
namespace VendingMachine.Test
{
    public class VendingMachinTest
    {
        [Fact]
        public void Test_Purchaseproduct_inputmoney()
        {
            //Actual
            int expectedMoney = 500;
            int[] listOfMoney;

            //Act
            
             vendingmachinedata objdenom = new vendingmachinedata();
            listOfMoney = objdenom.ValidDenominations();

            //Actual
            Assert.Contains(expectedMoney, listOfMoney);
        }
        [Fact]
        public void Test_Purchaseproduct_wronginput()
        {
            //Actual
            int expectedMoney = 200;
            int[] listOfMoney;

            //Act
            vendingmachinedata objdenom = new vendingmachinedata();
            listOfMoney = objdenom.ValidDenominations();

            //Actual
            Assert.DoesNotContain(expectedMoney, listOfMoney);
        }
        [Fact]
        public void Test_purchaseproduct_InsertMoney()
        {
            //Actual
            int[] expectedMoney = new int[2] { 1, 1000 };
            int Money = 1000;
            int[] isValidMoney;

            //Act
            vendingmachinedata objmoney = new vendingmachinedata();
            isValidMoney = objmoney.InsertMoney(Money);

            //Actual
            Assert.Equal(expectedMoney, isValidMoney);
        }
        [Fact]
        public void Test_purchaseproduct_wrongInsertMoney()
        {
            //Actual
            int[] expectedMoney = new int[2] { 1, 400 };
            int Money = 400;
            int[] isValidMoney;

            //Act
            vendingmachinedata objmoney = new vendingmachinedata();
            isValidMoney = objmoney.InsertMoney(Money);

            //Actual
            Assert.NotEqual(expectedMoney, isValidMoney);
        }
    }
}
