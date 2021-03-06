﻿using System;
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

        [TestMethod]
        public void Test_一二三集各買了一本_價格應為270()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this.fee = this._target.CalculateFee(this._books);
            var expected = 270;
            Assert.AreEqual(expected, this.fee);
        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為320()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this._books.Add("fourth", 1);
            this.fee = this._target.CalculateFee(this._books);
            var expected = 320;
            Assert.AreEqual(expected, this.fee);
        }

        [TestMethod]
        public void Test_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this._books.Add("fourth", 1);
            this._books.Add("fifth", 1);
            this.fee = this._target.CalculateFee(this._books);
            var expected = 375;
            Assert.AreEqual(expected, this.fee);
        }

        [TestMethod]
        public void Test_一套加孤本_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 2);

            this.fee = this._target.CalculateFee(this._books);
            var expected = 370;
            Assert.AreEqual(expected, this.fee);
        }

        [TestMethod]
        public void Test_兩套加孤本_第一集買了一本_第二三集各買了兩本_價格應為460()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 2);
            this._books.Add("third", 2);

            this.fee = this._target.CalculateFee(this._books);
            var expected = 460;
            Assert.AreEqual(expected, this.fee);
        }
    }
}