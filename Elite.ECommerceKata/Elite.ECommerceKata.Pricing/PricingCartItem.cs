using System;
using System.Collections.Generic;
using System.Text;
using Elite.ECommerceKata.Pricing.Contracts;
using Elite.ECommerceKata.Pricing.Entities;

namespace Elite.ECommerceKata.Pricing
{
    [System.Diagnostics.DebuggerDisplay("ItemPrice={ItemPrice} | ItemDiscount={ItemDiscount} | ItemPriceToPay={ItemPriceToPay} | {Description} | {Quantity} | {UnitPrice}")]
    class PricingCartItem : IPricingCartItem
    {
        private ICartItem Item { get; }

        public decimal ItemPrice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal ItemPriceToPay { get; set; }

        public Guid SKU => this.Item.SKU;
        public string Description => this.Item.Description;
        public double Quantity => this.Item.Quantity;
        public decimal UnitPrice => this.Item.UnitPrice;
        public string UnitOfMeasure => this.Item.UnitOfMeasure;

        public PricingCartItem(ICartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            this.Item = item;
            this.ItemPrice = (decimal)this.Quantity * this.UnitPrice;
            this.ItemPriceToPay = this.ItemPrice;
        }
    }
}
