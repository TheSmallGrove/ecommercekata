using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Contracts;

namespace Elite.ECommerceKata.Pricing
{
    public class Extensions
    {
        /// <summary>
        /// Supports addition of calculator to an external IOC container <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="collection">Instance ot the IOC builder</param>
        public void AddPricing(IServiceCollection collection)
        {
            collection.AddTransient<IPricingCalculator, PricingCalculator>();
        }
    }
}
