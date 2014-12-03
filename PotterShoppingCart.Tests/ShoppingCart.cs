using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    class ShoppingCart
    {
        private const double unitBookPrice = 100;
        internal double CalculateFee(Dictionary<string, int> dictionary)
        {
            var bookCount = dictionary.Sum(x => x.Value);
            if (bookCount == 1)
            {
                return unitBookPrice * bookCount;
            }
            else if (bookCount == 2)
            {
                return unitBookPrice * bookCount * 0.95;
            }
            else
            {
                return 0;
            }
        }
    }
}
