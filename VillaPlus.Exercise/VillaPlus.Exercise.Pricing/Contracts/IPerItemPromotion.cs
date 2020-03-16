using System;
using System.Collections.Generic;
using System.Text;
using VillaPlus.Exercise.Pricing.Entities;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Represents a promotion that apply to a single item. It is applied before <see cref="ITotalAmountPromotion"/>
    /// </summary>
    public interface IPerItemPromotion : IPromotion
    {
        void Apply(IPricingCartItem item);
    }
}
