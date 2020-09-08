using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing;
using Elite.ECommerceKata.Pricing.Entities;
using Elite.ECommerceKata.Pricing.Promotions;
using Xunit;

namespace Elite.ECommerceKata.Tests
{
    public class BuyManyGetSomeFreeTests
    {
        [Theory]
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 4, 1.55, 3, 1, 6.2, 4.65)] // buy 3 get 1 free
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 8, 2.55, 4, 2, 20.4, 10.2)] // buy 4 get 2 free
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 12, 3.45, 6, 1, 41.4, 34.5)] // buy 6 get 1 free
        public void BuyManyGetSomeFree_Theory_When_Exceed_The_Limit(string promoSku, string promoUnit, int buyQuantity, decimal unitPrice, int promoQuantity, int promoFree, decimal itemPrice, decimal itemPriceToPay)
        {
            // ARRANGE
            var item = TestData.Apples(buyQuantity, unitPrice);
            var promo = new BuyManyGetSomeFreePromotion(promoQuantity, promoFree, promoUnit, new Guid(promoSku));
            var pricingItem = new PricingCartItem(item);

            // ACT
            promo.Apply(pricingItem);

            // ASSERT
            Assert.Equal(unitPrice * (decimal)pricingItem.Quantity, pricingItem.ItemPrice);
            Assert.Equal(itemPrice, pricingItem.ItemPrice);
            Assert.Equal(itemPriceToPay, pricingItem.ItemPriceToPay);
            Assert.Equal(pricingItem.ItemPrice - pricingItem.ItemPriceToPay, pricingItem.ItemDiscount);
        }

        [Theory]
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 2, 1.55, 3, 1, 3.1, 3.1)] // buy 3 get 1 free
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 3, 2.55, 4, 2, 7.65, 7.65)] // buy 4 get 2 free
        [InlineData(TestData.ApplesSku, TestData.UOMKG, 5, 3.45, 6, 1, 17.25, 17.25)] // buy 6 get 1 free
        public void BuyManyGetSomeFree_Theory_When_Not_Exceed_The_Limit(string promoSku, string promoUnit, int buyQuantity, decimal unitPrice, int promoQuantity, int promoFree, decimal itemPrice, decimal itemPriceToPay)
        {
            // ARRANGE
            var item = TestData.Apples(buyQuantity, unitPrice);
            var promo = new BuyManyGetSomeFreePromotion(promoQuantity, promoFree, promoUnit, new Guid(promoSku));
            var pricingItem = new PricingCartItem(item);

            // ACT
            promo.Apply(pricingItem);

            // ASSERT
            Assert.Equal(unitPrice * (decimal)pricingItem.Quantity, pricingItem.ItemPrice);
            Assert.Equal(itemPrice, pricingItem.ItemPrice);
            Assert.Equal(itemPriceToPay, pricingItem.ItemPriceToPay);
            Assert.Equal(pricingItem.ItemPrice - pricingItem.ItemPriceToPay, pricingItem.ItemDiscount);
            Assert.Equal(0, pricingItem.ItemDiscount);
        }

        [Theory]
        [InlineData(TestData.OrangesSku, TestData.UOMKG, 2, 1.55, 3, 1, 3.1, 3.1)] // buy 3 get 1 free
        [InlineData(TestData.OrangesSku, TestData.UOMKG, 5, 3.45, 6, 1, 17.25, 17.25)] // buy 6 get 1 free
        public void BuyManyGetSomeFree_Theory_When_Not_Applicable(string promoSku, string promoUnit, int buyQuantity, decimal unitPrice, int promoQuantity, int promoFree, decimal itemPrice, decimal itemPriceToPay)
        {
            // ARRANGE
            var item = TestData.Apples(buyQuantity, unitPrice);
            var promo = new BuyManyGetSomeFreePromotion(promoQuantity, promoFree, promoUnit, new Guid(promoSku));
            var pricingItem = new PricingCartItem(item);

            // ACT
            promo.Apply(pricingItem);

            // ASSERT
            Assert.Equal(unitPrice * (decimal)pricingItem.Quantity, pricingItem.ItemPrice);
            Assert.Equal(itemPrice, pricingItem.ItemPrice);
            Assert.Equal(itemPriceToPay, pricingItem.ItemPriceToPay);
            Assert.Equal(pricingItem.ItemPrice - pricingItem.ItemPriceToPay, pricingItem.ItemDiscount);
            Assert.Equal(0, pricingItem.ItemDiscount);
        }

        [Theory]
        [InlineData(TestData.ApplesSku, TestData.UOMUnits, 2, 1.55, 3, 1, 3.1, 3.1)] // buy 3 get 1 free but wrong unit
        public void BuyManyGetSomeFree_Theory_When_Not_Same_Unit(string promoSku, string promoUnit, int buyQuantity, decimal unitPrice, int promoQuantity, int promoFree, decimal itemPrice, decimal itemPriceToPay)
        {
            // ARRANGE
            var item = TestData.Apples(buyQuantity, unitPrice);
            var promo = new BuyManyGetSomeFreePromotion(promoQuantity, promoFree, promoUnit, new Guid(promoSku));
            var pricingItem = new PricingCartItem(item);

            // ACT

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => promo.Apply(pricingItem));

            // ASSERT
            Assert.Equal($"UnitOfMeasure (Parameter 'Unit of measure '{promoUnit}' is not compatible with '{item.UnitOfMeasure}'')", ex.Message);
        }
    }
}

// ARRANGE

// ACT

// ASSERT