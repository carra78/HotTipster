using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace HotTipster.BusinessLogic
{
	class HashCode
	{

		//method to return string of hashed data
		public string HashData(string password)
		{
			//encryption algorithm class
			SHA1 sha = SHA1.Create();

			//byte array to hold individual characters of result
			byte[] result = sha.ComputeHash(Encoding.Default.GetBytes(password));

			//create string to return the result
			StringBuilder returnValue = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				//each item in the byte array is converted to a string and added to returnValue
				returnValue.Append(result[i]).ToString();
			}
			return returnValue.ToString(); //convert stringbuilder object to a string to return it
		}
	}
}
