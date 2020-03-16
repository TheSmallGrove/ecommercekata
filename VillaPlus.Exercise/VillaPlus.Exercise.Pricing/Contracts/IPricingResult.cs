using System;
using System.Collections.Generic;
using System.Text;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Represents the result of calculation
    /// </summary>
    public interface IPricingResult
    {
        decimal TotalPrice { get; set; }
        decimal TotalDiscount { get; set; }
        decimal TotalPriceToPay { get; set; }
        IEnumerable<IPricingCartItem> Detail { get; }
    }
}
