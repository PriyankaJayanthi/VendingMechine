
using System;
using Xunit;
using VendingMachine.Functions;
using VendingMachine.Data;
namespace VendingMachine.Test
{
    public class ChocolateTest
    {
        [Fact]
        public void Test_Dairymilk_product()
        {
            //Arrange
            string expected = "Dairymilk                 20";
            //Act
            var choco = new chocolates("Dairymilk", 20);
            //Assert
            Assert.Equal(expected, choco.ProductName());
        }
        [Fact]
        public void Test_Snickers_product()
        {
            //Arrange
            string expected = "Snickers";
            //Act
            var choco = new chocolates("Snickers", 40);
            //Assert
            Assert.Contains(expected, choco.ProductName());
        }
        [Fact]
        public void Test_Marabou_product()
        {
            //Arrange
            string expected = "100";
            //Act
            var choco = new chocolates("Marabou", 100);
            //Assert
            Assert.Contains(expected, choco.ProductName());
        }



    }
}
