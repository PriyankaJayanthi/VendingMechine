using System;
using Xunit;
using VendingMachine.Functions;
using VendingMachine.Data;

namespace VendingMachine.Test
{
    public class SnacksTest
    {

        [Fact]
        public void Test_Cashew_product()
        {
            //Arrange
            string expected = "Cashew";
            //Act
            var Mysnacks = new Snacks("Cashew", 80);
            //Assert
            Assert.Contains(expected, Mysnacks.ProductName());
        }
        [Fact]
        public void Test_mixednuts_product()
        {
            //Arrange
            string expected = "mixednuts";
            //Act
            var Mysnacks = new Snacks("mixednuts", 100);
            //Assert
            Assert.Contains(expected, Mysnacks.ProductName());
        }
        [Fact]
        public void Test_breadsticks_product()
        {
            //Arrange
            string expected = "58";
            //Act
            var mysnacks = new Snacks("breadsticks", 58);
            //Assert
            Assert.Contains(expected, mysnacks.ProductName());
        }

    }
}
