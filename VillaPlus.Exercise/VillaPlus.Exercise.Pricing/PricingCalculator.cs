using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VillaPlus.Exercise.Pricing.Contracts;
using VillaPlus.Exercise.Pricing.Entities;

namespace VillaPlus.Exercise.Pricing
{
    /// <summary>
    /// implements a calculator
    /// </summary>
    class PricingCalculator : IPricingCalculator
    {
        public IPricingResult Calculate(IEnumerable<ICartItem> items, params IPromotion[] promos)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var result = new PricingResult(items);

            // Apply items promotions
            foreach (var sip in promos.OfType<IPerItemPromotion>())
            {
                foreach (var item in result.Detail)
                    sip.Apply(item);
            }

            // Calculate total amount
            result.TotalPrice = Math.Round(result.Detail.Sum(_ => _.ItemPrice), 3);
            result.TotalDiscount = Math.Round(result.Detail.Sum(_ => _.ItemDiscount), 3);
            result.TotalPriceToPay = Math.Round(result.Detail.Sum(_ => _.ItemPriceToPay), 3);

            // Apply total amount promotions
            foreach (var mip in promos.OfType<ITotalAmountPromotion>())
                mip.Apply(result);

            return result;
        }
    }
}
