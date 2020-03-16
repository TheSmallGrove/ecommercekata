using System;
using System.Collections.Generic;
using System.Text;
using VillaPlus.Exercise.Pricing.Entities;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Represents the public interface or the <see cref="VillaPlus.Exercise.Pricing.PricingCalculator"/>
    /// Support an eventual IOC Container
    /// </summary>
    public interface IPricingCalculator
    {
        IPricingResult Calculate(IEnumerable<ICartItem> items, params IPromotion[] promos);
    }
}
