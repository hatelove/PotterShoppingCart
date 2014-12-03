using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    class ShoppingCart
    {
        private const double unitBookPrice = 100;

        private Dictionary<int, double> discountRatio;

        public ShoppingCart()
        {
            this.discountRatio = new Dictionary<int, double>() 
            {
                {1,1},
                {2,0.95},
                {3,0.9},
                {4,0.8}
            };
        }

        internal double CalculateFee(Dictionary<string, int> dictionary)
        {
            var bookCount = dictionary.Sum(x => x.Value);

            if (this.discountRatio.ContainsKey(bookCount))
            {
                var ratio = this.discountRatio[bookCount];
                return unitBookPrice * bookCount * ratio;
            }
            else
            {
                return 0;
            }
        }
    }
}
