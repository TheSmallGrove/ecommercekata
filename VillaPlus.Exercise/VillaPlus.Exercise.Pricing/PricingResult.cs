using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VillaPlus.Exercise.Pricing.Contracts;

namespace VillaPlus.Exercise.Pricing
{
    [System.Diagnostics.DebuggerDisplay("TotalPrice={TotalPrice}, TotalDiscount={TotalDiscount}, TotalPriceToPay={TotalPriceToPay}")]
    class PricingResult : IPricingResult
    {
        public PricingResult(IEnumerable<ICartItem> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            this.Detail = (from item in items
                           select new PricingCartItem(item)).ToArray();
        }

        public decimal TotalPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPriceToPay { get; set; }
        public IEnumerable<IPricingCartItem> Detail { get; }
    }
}
