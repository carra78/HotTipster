using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.DataAccess;
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
			HistoricDataReader myReader = new HistoricDataReader(@"c:\fakefilepath");
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void testExpectedValuesNotReturned_ListOfHorseBets()
		{
			HistoricDataReader myReader = new HistoricDataReader(@"C:\Users\carra\Documents\HotTipster\BadDataTestFile.txt");
			List<HorseBet> mybets = myReader.ListOfHistoricHorseBetsOriginal();
				
		}
	}
}
