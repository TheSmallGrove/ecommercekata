using System;
using System.Collections.Generic;
using System.Text;

namespace VillaPlus.Exercise.Pricing.Contracts
{
    /// <summary>
    /// Represents a promotion that apply to the whole cart. It is applied after the <see cref="IPerItemPromotion"/>
    /// </summary>
    public interface ITotalAmountPromotion : IPromotion
    {
        void Apply(IPricingResult result);
    }
}
