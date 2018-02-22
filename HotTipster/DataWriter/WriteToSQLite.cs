using HotTipster.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Data.Sqlite;


namespace HotTipster.DataWriter
{
	class WriteToSQLite : IDataWriter
	{
		private static string databaseName = "HotTipsterDataBase";
		SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + databaseName +";Version=3;New=True;Compression=True;");
		

		public void WriteData()
		{

		}

		public bool CheckDatabaseExists()
		{

			return MyUtilities.ValidFilePath(Directory.GetCurrentDirectory() + Path.PathSeparator + databaseName + ".sqlite");
		}

		public void CreateDatabase()
		{

		}

	}
}
