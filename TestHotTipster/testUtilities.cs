using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.Utilities;

namespace TestHotTipster
{
	[TestClass]
	public class testUtilities
	{
		[TestMethod]
		public void testTrimArrayStrings()
		{
			string[] testArray = { "  remove blank spaces at beginning and end of string   " };
			string expected = "remove blank spaces at beginning and end of string";
			string[] resultArray = MyUtilities.TrimArrayStrings(testArray);
			Assert.AreEqual(resultArray[0], expected);
		}

		[TestMethod]
		public void testFileExistsValidFilePath()
		{
			string filepath = @"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt";
			bool result = MyUtilities.ValidFilePath(filepath);
			Assert.IsTrue(result);
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void testValidFilePathNullorEmptyPath()
		{
			MyUtilities.ValidFilePath("");
		}

		[TestMethod]
		public void testFileExistsInvalidPath()
		{
			string filepath = @"c:\test\test.txt";
			bool result = MyUtilities.ValidFilePath(filepath);
			Assert.IsFalse(result);
		}

	}
}
