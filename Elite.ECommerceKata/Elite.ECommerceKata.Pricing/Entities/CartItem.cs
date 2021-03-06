﻿using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Contracts;

namespace Elite.ECommerceKata.Pricing.Entities
{
    /// <summary>
    /// Represents an item in a Cart
    /// </summary>
    public class CartItem : ICartItem
    {
        public Guid SKU { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
