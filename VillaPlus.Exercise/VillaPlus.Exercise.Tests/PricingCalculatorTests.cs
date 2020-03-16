using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VillaPlus.Exercise.Pricing;
using VillaPlus.Exercise.Pricing.Contracts;
using VillaPlus.Exercise.Pricing.Entities;
using VillaPlus.Exercise.Pricing.Promotions;
using Xunit;

namespace VillaPlus.Exercise.Tests
{
    public class PricingCalculatorTests
    {
        [Fact]
        public void PricingCalculator_Calculate_Args_Null_Items()
        {
            // ARRANGE
            var calculator = new PricingCalculator();

            // ACT
            Exception ex = Assert.Throws<ArgumentNullException>(
                () => calculator.Calculate(null));

            // ASSERT
            Assert.Equal("Value cannot be null. (Parameter 'items')", ex.Message);
        }

        [Fact]
        public void CalculatePricing_When_No_Promotions()
        {
            // ARRANGE
            var cart = TestData.Cart1;
            var calculator = new PricingCalculator();

            // ACT
            var result = calculator.Calculate(cart);

            // ASSERT
            Assert.Equal(24.77M, result.TotalPrice);
            Assert.Equal(0M, result.TotalDiscount);
            Assert.Equal(result.TotalPrice, result.TotalPriceToPay);
        }

        [Fact]
        public void CalculatePricing_With_Buy3GetOneFree_Promotion()
        {
            // ARRANGE
            var cart = TestData.Cart1;

            var calculator = new PricingCalculator();

            // ACT
            var result = calculator.Calculate(
                cart,
                new BuyManyGetSomeFreePromotion(3, 1, "kg", new Guid(TestData.ApplesSku)) // get 1kg of apples free for each 3kg (buy 3 get 1 free)
                );

            // ASSERT
            Assert.Equal(24.77M, result.TotalPrice);
            Assert.Equal(1.55M, result.TotalDiscount);
            Assert.Equal(result.TotalPriceToPay, result.TotalPrice - result.TotalDiscount);
        }

        [Fact]
        public void CalculatePricing_With_BuyALotGetADiscount_Promotion()
        {
            // ARRANGE
            var cart = TestData.Cart1;

            var calculator = new PricingCalculator();

            // ACT
            var result = calculator.Calculate(
                cart,
                new BuyALotGetADiscountPromotion(3, 2) // buy at least 3 items and get 2% of discount
                );

            // ASSERT
            Assert.Equal(24.77M, result.TotalPrice);
            Assert.Equal(0.4954M, result.TotalDiscount);
            Assert.Equal(result.TotalPriceToPay, result.TotalPrice - result.TotalDiscount);
        }

        [Fact]
        public void CalculatePricing_With_Two_Promotions()
        {
            // ARRANGE
            var cart = TestData.Cart1;

            var calculator = new PricingCalculator();

            // ACT
            var result = calculator.Calculate(
                cart,
                new BuyManyGetSomeFreePromotion(3, 1, "kg", new Guid(TestData.ApplesSku)), // get 1kg of apples free for each 3kg (buy 3 get 1 free)
                new BuyALotGetADiscountPromotion(3, 2) // buy at least 3 items and get 2% of discount
                );

            // ASSERT
            Assert.Equal(24.77M, result.TotalPrice);
            Assert.Equal(2.0454M, result.TotalDiscount);
            Assert.Equal(result.TotalPriceToPay, result.TotalPrice - result.TotalDiscount);
        }
    }
}
