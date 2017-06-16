using System;
using NUnit.Framework;
using CoreCards.Models;

namespace Testing123
{
    [TestFixture]
    public class TestClass
    {
        [TestCase(1, 1, 2)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 5, 105)]
        public void CanAddNumbers(int x, int y, int expected)
        {
            Assert.That(Calculator.Add(x, y), Is.EqualTo(expected));
        }


    }
}
