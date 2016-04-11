using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart.Tests
{
    internal class ShoppingCart
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
            var bookMoreThanZero = books.Where(x => x.Value > 0)
                .Select(x => x.Value).ToList();

            var maxBookCount = books.Max(x => x.Value);
            var groups = new List<int>();
            for (int i = 0; i < maxBookCount; i++)
            {
                var booksOfSuite = bookMoreThanZero.Count(x => x > 0);
                groups.Add(booksOfSuite);

                for (int index = 0; index < bookMoreThanZero.Count; index++)
                {
                    bookMoreThanZero[index] -= 1;
                }
            }

            double total = 0;
            foreach (var item in groups)
            {
                var discountRatio = this.discountRatio[item];
                total += item * unitBookPrice * discountRatio;
            }

            return total;
        }
    }
}