using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotTipster.Utilities;
using HotTipster;
using System.Collections.Generic;

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

		[TestMethod]
		public void testAddItemToList()
		{
			List<String> stringList = new List<string>();
			string testString = "This is a test";
			MyUtilities.AddItemToList(testString, stringList);
			string expected = "This is a test";
			Assert.AreEqual(stringList[0], expected);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidCastException))]
		public void testAddItemToListMismatchTypes()
		{
			List<int> intList = new List<int>();
			string testString = "This is a test";
			MyUtilities.AddItemToList(testString, intList);
		}


	}
}
