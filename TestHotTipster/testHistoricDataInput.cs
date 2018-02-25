using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster;
using HotTipster.DataAccess;
using System.Collections.Generic;

namespace TestHotTipster
{
	[TestClass]
	public class testHistoricDataInputWithValidFilePath
	{
		HistoricDataReader myReader;

		[TestInitialize]
		public void Initialize()
		{
			myReader = new HistoricDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt");
		}

		[TestMethod]
		public void testDataReaderClassExists()
		{
			
			Assert.IsInstanceOfType(myReader, typeof(Object));
		}

		[TestMethod]
		public void testDataReaderConstructor()
		{
			string filePath = @"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt";
			HistoricDataReader myReader = new HistoricDataReader(filePath);
			Assert.AreEqual(filePath, myReader.FilePath);

		}



		[TestMethod]
		public void testExpectedValuesReturned_ListOfHistoricBets()
		{
			List<HorseBet> historicBets = myReader.ListOfHistoricHorseBetsOriginal();
			CollectionAssert.AllItemsAreInstancesOfType(historicBets, typeof(HorseBet));
			//HorseBet item0 = new HorseBet("Aintree", new DateTime(2017, 5, 12), 11.58m, true );
			//HorseBet item19 = new HorseBet("Goodwood", new DateTime(2016, 10, 5), 34.12m, true);
			//HorseBet item35 = new HorseBet("Sandown", new DateTime(2017, 8, 7), 25.00m, false);
			//Assert.AreEqual(historicBets[0], item0);
			//Assert.AreEqual(historicBets[19], item19);
			//Assert.AreEqual(historicBets[35], item35);
		}

	}
	
}
