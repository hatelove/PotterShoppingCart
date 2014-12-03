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
                {4,0.8},
                {5,0.75}
            };
        }

        internal double CalculateFee(Dictionary<string, int> books)
        {
            var bookCount = books.Sum(x => x.Value);
            if (bookCount == 0)
            {
                return 0;
            }

            //同一集超過一本的書，有幾集
            var groupOfEditionMoreThanOneBook = books.Where(x => x.Value > 0);
            var groupCount = groupOfEditionMoreThanOneBook.Count();

            //成群的折扣
            var discountRatio = this.discountRatio[groupCount];

            var excludeSetBooksCount = bookCount - groupCount;

            //成群的書錢
            var setPrice = groupCount * unitBookPrice * discountRatio;

            //孤本的書錢
            var nonSetPrice = excludeSetBooksCount * unitBookPrice;

            return setPrice + nonSetPrice;
        }
    }
}
