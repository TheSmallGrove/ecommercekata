using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VillaPlus.Exercise.Pricing.Contracts;

namespace VillaPlus.Exercise.Pricing.Entities
{
    /// <summary>
    /// Represents ths Cart as a collection of <seealso cref="ICartItem"/>
    /// </summary>
    public class Cart : Collection<ICartItem>
    { }
}
