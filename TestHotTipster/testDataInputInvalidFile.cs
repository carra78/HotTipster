using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.HistoricData;
using HotTipster;
using System.Collections.Generic;

namespace TestHotTipster
{
	[TestClass]
	public class testDataInputInvalidFile
	{
		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void testDataReaderNotCreatedIfInvalidFilePath()
		{
			HorseBetDataReader myReader = new HorseBetDataReader(@"c:\fakefilepath");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void testExpectedValuesNotReturned_ListOfHorseBets()
		{
			HorseBetDataReader myReader = new HorseBetDataReader(@"C:\Users\carra\Documents\HotTipster\BadDataTestFile.txt");
			List<HorseBet> mybets = myReader.ListOfHistoricHorseBets();
				
		}
	}
}
