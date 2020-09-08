using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Elite.ECommerceKata.Pricing.Contracts;

namespace Elite.ECommerceKata.Pricing.Entities
{
    /// <summary>
    /// Represents ths Cart as a collection of <seealso cref="ICartItem"/>
    /// </summary>
    public class Cart : Collection<ICartItem>
    { }
}
