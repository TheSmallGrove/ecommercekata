using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Entities;

namespace Elite.ECommerceKata.Pricing.Contracts
{
    /// <summary>
    /// Represents the public interface or the <see cref="Elite.ECommerceKata.Pricing.PricingCalculator"/>
    /// Support an eventual IOC Container
    /// </summary>
    public interface IPricingCalculator
    {
        IPricingResult Calculate(IEnumerable<ICartItem> items, params IPromotion[] promos);
    }
}
