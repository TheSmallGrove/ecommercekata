using System;
using System.Collections.Generic;
using System.Text;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Represents a Decorator the add calculated properties for the cart calculation
    /// </summary>
    public interface IPricingCartItem : ICartItem
    {
        decimal ItemPrice { get; set; }
        decimal ItemDiscount { get; set; }
        decimal ItemPriceToPay { get; set; }
    }
}
