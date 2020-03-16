using System;
using System.Collections.Generic;
using System.Text;
using VillaPlus.Exercise.Pricing;
using VillaPlus.Exercise.Pricing.Promotions;
using Xunit;

namespace VillaPlus.Exercise.Tests
{
    public class BuyALotGetADiscountPromotionTests
    {
        [Theory]
        [InlineData(10, 5)]
        [InlineData(20, 10)]
        [InlineData(25, 15)]
        public void BuyALotGetADiscount_Theory_When_Not_Exceed_The_Limit(int minItemsInCart, double percentDiscount)
        {
            // ARRANGE
            var promo = new BuyALotGetADiscountPromotion(minItemsInCart, percentDiscount);
            var result = new PricingResult(TestData.Cart1) { TotalPrice = 100, TotalPriceToPay = 0, TotalDiscount = 0 };

            // ACT
            promo.Apply(result);

            // ASSERT
            Assert.Equal(100, result.TotalPrice);
            Assert.Equal(0, result.TotalPriceToPay);
            Assert.Equal(0, result.TotalDiscount);
        }

        [Theory]
        [InlineData(4, 10)]
        [InlineData(3, 5)]
        [InlineData(2, 1)]
        public void BuyALotGetADiscount_Theory_When_Exceed_The_Limit(int minItemsInCart, double percentDiscount)
        {
            // ARRANGE
            var promo = new BuyALotGetADiscountPromotion(minItemsInCart, percentDiscount);
            var result = new PricingResult(TestData.Cart1) { TotalPrice = 100, TotalPriceToPay = 0, TotalDiscount = 0 };

            // ACT
            promo.Apply(result);

            // ASSERT
            Assert.Equal(100, result.TotalPrice);
            Assert.Equal(100 - (decimal)percentDiscount, result.TotalPriceToPay, 3);
            Assert.Equal((decimal)percentDiscount, result.TotalDiscount);
        }
    }
}
