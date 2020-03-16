using System;
using System.Collections.Generic;
using System.Text;
using VillaPlus.Exercise.Pricing.Entities;

namespace VillaPlus.Exercise.Tests
{
    /// <summary>
    /// This class contains static data and generators used for unit testing
    /// </summary>
    static class TestData
    {
        public const string ApplesSku = "A0F9524A-BC23-48C7-8D9A-3AD1DA2D8993";
        public const string OrangesSku = "C2382E44-9DF2-4E27-8969-C96BE3C935FB";
        public const string CoffeeSku = "64B7CD20-935B-4A37-A4B1-2B9B9615C6A6";
        public const string MilkSku = "16F0CE3D-AFE6-4DAE-8ACF-87F813F93DC2";
        public const string UOMKG = "kg";
        public const string UOMUnits = "units";

        public static Cart Cart1 = new Cart
            {
                TestData.Apples(5.5, 1.55M),
                TestData.Oranges(3.25, 1.98M),
                TestData.Coffee(3, 2.5M),
                TestData.Milk(3, 0.77M),
            };

        public static CartItem Apples(double qt, decimal up) => new CartItem { SKU = new Guid(TestData.ApplesSku), Description = "Golden Gala Apples", Quantity = qt, UnitOfMeasure = TestData.UOMKG, UnitPrice = up };
        public static CartItem Oranges(double qt, decimal up) => new CartItem { SKU = new Guid(TestData.OrangesSku), Description = "Sicilian Oranges", Quantity = qt, UnitOfMeasure = TestData.UOMKG, UnitPrice = up };
        public static CartItem Coffee(double qt, decimal up) => new CartItem { SKU = new Guid(TestData.CoffeeSku), Description = "Italian Coffee (500gr)", Quantity = qt, UnitOfMeasure = TestData.UOMUnits, UnitPrice = up };
        public static CartItem Milk(double qt, decimal up) => new CartItem { SKU = new Guid(TestData.MilkSku), Description = "Milk (1lt)", Quantity = qt, UnitOfMeasure = TestData.UOMUnits, UnitPrice = up };
    }
}
