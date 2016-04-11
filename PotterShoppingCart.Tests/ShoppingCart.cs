﻿using System.Collections.Generic;
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

            var bookCountsOfSuites = GetBooksCountOfEachSuite(books);

            double total = GetTotalOfSuites(bookCountsOfSuites);

            return total;
        }

        private static List<int> GetBookCountMoreThanZero(Dictionary<string, int> books)
        {
            return books.Where(x => x.Value > 0)
                .Select(x => x.Value).ToList();
        }

        private double GetTotalOfSuites(IEnumerable<int> bookCountsOfSuites)
        {
            var total = bookCountsOfSuites.Sum(x =>
            {
                return x * unitBookPrice * this.discountRatio[x];
            });

            return total;
        }

        private static IEnumerable<int> GetBooksCountOfEachSuite(Dictionary<string, int> books)
        {
            List<int> bookCountMoreThanZero = GetBookCountMoreThanZero(books);

            var maxBookCount = books.Max(x => x.Value);

            for (int i = 0; i < maxBookCount; i++)
            {
                var bookCountOfSuite = bookCountMoreThanZero.Count(x => x > 0);

                yield return bookCountOfSuite;

                for (int index = 0; index < bookCountMoreThanZero.Count; index++)
                {
                    bookCountMoreThanZero[index] -= 1;
                }
            }
        }
    }
}