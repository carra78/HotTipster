using System;
using HotTipster;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHotTipster
{
	[TestClass]
	public class testHorseBet
	{
		[TestMethod]
		public void TestMethod1()
		{
		}
		[TestMethod]
		public void testHorseBetClassExists()
		{
			HorseBet testBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true);
			Assert.IsInstanceOfType(testBet, typeof(Object));
		}

		[TestMethod]
		public void testHorseBetConstructor()
		{
			HorseBet testHorseBet = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true);
			object actualtype = testHorseBet.GetType();
			object expectedtype = typeof(HorseBet);
			Assert.AreEqual(actualtype, expectedtype);
		}
	}
}
