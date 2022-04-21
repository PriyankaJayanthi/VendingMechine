using System;
using Xunit;
using VendingMachine.Functions;
using VendingMachine.Data;

namespace VendingMachine.Test
{
    public class DrinksTest
    {
        [Fact]
        public void Test_cola_product()
        {
            //Arrange
            string expected = "Cola                      20";
            //Act
            var mydrink = new Drinks("Cola", 20);
            //Assert
            Assert.Equal(expected,mydrink.ProductName());
        }
        [Fact]
        public void Test_sprite_product()
        {
            // Arrange
            string expected = "Sprite";
            // Act
            var mydrink = new Drinks("Sprite", 40);
            //Assert
            Assert.Contains(expected, mydrink.ProductName());
        }
        [Fact]
        public void Test_Maza_product()
        {
            // Arrange
            string expected = "100";
            // Act
            var mydrink = new Drinks("Maza", 100);
            //Assert
            Assert.Contains(expected, mydrink.ProductName());
        }


    }

}
