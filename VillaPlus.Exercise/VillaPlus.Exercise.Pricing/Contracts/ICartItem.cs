using System;
using System.Collections.Generic;
using System.Text;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Interfact that require minumum properties for a <see cref="VillaPlus.Exercise.Pricing.Entities.CartItem"/>
    /// It has been used to let the developer implement a much more detailed CartItem that can be calculated
    /// </summary>
    public interface ICartItem
    {
        Guid SKU { get; }
        string Description { get; }
        double Quantity { get; }
        decimal UnitPrice { get; }
        string UnitOfMeasure { get; }
    }
}
