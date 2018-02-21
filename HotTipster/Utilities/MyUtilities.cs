using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTipster.Utilities
{
	public static class MyUtilities
	{
		//Trim any blank or empty chars from beginning or end of strings in an array
		public static string[] TrimArrayStrings(string[] myarr)
		{
			for (int j = 0; j < myarr.Length; j++)
			{
				string b = myarr[j];
				myarr[j] = b.Trim();
			}
			return myarr;
		}

		public static bool ValidFilePath(string filepath)
		{
			if (string.IsNullOrEmpty(filepath))
			{
				throw new ArgumentNullException("Missing filename");
			}
			return File.Exists(filepath);
		}
	}
}
