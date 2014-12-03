using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Tests;

namespace MyTest
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        private ShoppingCart _target;
        private Dictionary<string, int> _books;
        private double fee;

        [TestInitialize]
        public void TestInitialized()
        {
            this._target = new ShoppingCart();
            this._books = new Dictionary<string, int>();
            this.fee = 0;
        }

        [TestMethod]
        public void Test_第一集買了一本_其他都沒買_價格應為100元()
        {
            this._books.Add("first", 1);
            this.fee = this._target.CalculateFee(this._books);
            var expected = 100;
            Assert.AreEqual(expected, this.fee);
        }

        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this.fee = this._target.CalculateFee(this._books);
            var expected = 190;
            Assert.AreEqual(expected, this.fee);
        }
    }
}