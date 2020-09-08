using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Entities;

namespace Elite.ECommerceKata.Pricing.Contracts
{
    /// <summary>
    /// Represents a promotion that apply to a single item. It is applied before <see cref="ITotalAmountPromotion"/>
    /// </summary>
    public interface IPerItemPromotion : IPromotion
    {
        void Apply(IPricingCartItem item);
    }
}
