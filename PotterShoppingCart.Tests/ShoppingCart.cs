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

            var maxBooksCount = books.Max(x => x.Value);
            var unCheckedOutBooks = books.ToDictionary(x => x.Key, y => y.Value);

            double fee = 0;

            //檢查是否成套，每結帳一套（依據該套書本數的折扣），結帳過的集數書本數就扣1
            for (int i = maxBooksCount; i > 0; i--)
            {
                var groupOfEditionMoreThanOneBook = unCheckedOutBooks.Where(x => x.Value > 0).ToList();
                var groupCount = groupOfEditionMoreThanOneBook.Count;

                // 只剩下某一集有書，直接把剩下的書x單價，加上原本的fee，即為總價
                if (groupCount == 1)
                {
                    fee += groupOfEditionMoreThanOneBook.First().Value * unitBookPrice;
                    break;
                }

                var discountRatio = this.discountRatio[groupCount];

                fee += groupCount * unitBookPrice * discountRatio;

                foreach (var group in groupOfEditionMoreThanOneBook)
                {
                    unCheckedOutBooks[group.Key]--;
                }
            }

            return fee;
        }
    }
}
