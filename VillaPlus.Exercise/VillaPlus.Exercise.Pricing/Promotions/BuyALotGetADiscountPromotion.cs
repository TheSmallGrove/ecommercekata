using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VillaPlus.Exercise.Pricing.Contracts;

namespace VillaPlus.Exercise.Pricing.Promotions
{
    /// <summary>
    /// Generic implementation of a promotion that apply a discount when the cart contains more than a numer of items
    /// It may be expanded applying slices of princing with increasing discounts
    /// </summary>
    public class BuyALotGetADiscountPromotion : ITotalAmountPromotion
    {
        public double MinItemsInCart { get; }
        public double PercentDiscount { get; }

        public BuyALotGetADiscountPromotion(int minItemsInCart, double percentDiscount)
        {
            if (minItemsInCart < 1)
                throw new ArgumentOutOfRangeException("minItemsInCart must be greather than 0", nameof(minItemsInCart));
            if (percentDiscount < 0 || percentDiscount > 100)
                throw new ArgumentOutOfRangeException("percentDiscount must be between 0 and 100", nameof(percentDiscount));

            this.MinItemsInCart = minItemsInCart;
            this.PercentDiscount = percentDiscount;
        }

        public void Apply(IPricingResult result)
        {
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            if (result.Detail == null)
                throw new ArgumentNullException(nameof(result.Detail));

            if (result.Detail.Count() >= this.MinItemsInCart)
            {
                result.TotalDiscount += result.TotalPrice / 100M * (decimal)this.PercentDiscount;
                result.TotalPriceToPay = result.TotalPrice - result.TotalDiscount;
            }
        }
    }
}
