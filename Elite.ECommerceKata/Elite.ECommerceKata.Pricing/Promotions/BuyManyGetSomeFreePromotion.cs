using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Contracts;

namespace Elite.ECommerceKata.Pricing.Promotions
{
    /// <summary>
    /// Represents a generic promotion that apply a discount when a numebr of the same item have bougth
    /// It is implemented as a requirement for the test to create "buy 3 and get 1 free" (buy 3 and pay 2)
    /// </summary>
    public class BuyManyGetSomeFreePromotion : IPerItemPromotion
    {
        public double QuantityToBuy { get; }
        public double QuantityFree { get; }
        public string UnitOfMeasure { get; }
        public Guid ApplicableSku { get; }

        public BuyManyGetSomeFreePromotion(double quantityToBuy, double quantityFree, string unitOfMeasure, Guid applicableSku)
        {
            if (quantityToBuy < 1)
                throw new ArgumentOutOfRangeException("quantityToBuy must be greather than 0", nameof(quantityToBuy));
            if (quantityFree > quantityToBuy)
                throw new ArgumentOutOfRangeException("quantityFree must be less or equal to quantityToBuy", nameof(quantityFree));
            if (string.IsNullOrEmpty(unitOfMeasure))
                throw new ArgumentOutOfRangeException("unitOfMeasure must have a value", nameof(unitOfMeasure));
            if (applicableSku == Guid.Empty)
                throw new ArgumentOutOfRangeException("applicableSku must not be empty", nameof(applicableSku));

            this.QuantityToBuy = quantityToBuy;
            this.QuantityFree = quantityFree;
            this.UnitOfMeasure = unitOfMeasure;
            this.ApplicableSku = applicableSku;
        }

        public void Apply(IPricingCartItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.SKU == this.ApplicableSku)
            {
                if (this.UnitOfMeasure != item.UnitOfMeasure)
                    throw new ArgumentOutOfRangeException($"Unit of measure '{this.UnitOfMeasure}' is not compatible with '{item.UnitOfMeasure}'", nameof(item.UnitOfMeasure));

                var groups = (int)(item.Quantity / this.QuantityToBuy);
                var itemsFree = groups * this.QuantityFree;
                item.ItemPriceToPay = Math.Round((decimal)(item.Quantity - itemsFree) * item.UnitPrice, 3);
                item.ItemDiscount = Math.Round(item.ItemPrice - item.ItemPriceToPay, 3);
            }
        }
    }
}
