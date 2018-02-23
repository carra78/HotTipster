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
	public class WriteToSQLite : IDataWriter
	{
		private static string databaseName = "HotTipster.db";
		SqliteConnection dbConnection = new SqliteConnection(string.Format("Filename={0}", databaseName));
		

		public void WriteData()
		{

		}

		public bool CheckDatabaseExists()
		{

			return MyUtilities.ValidFilePath(Directory.GetCurrentDirectory() + Path.PathSeparator + databaseName);
		}

		public void CreateDatabase()
		{
			using (dbConnection)
			{
				string tablecommand = "CREATE TABLE IF NOT EXISTS Horses" +
					"(HorseID INTEGER PRIMARY KEY AUTOINCREMENT, " +
					"HorseName NVARCHAR(150) NOT NULL)";
				SqliteCommand createTable = new SqliteCommand(tablecommand, dbConnection);
				try
				{
					dbConnection.Open();
					createTable.ExecuteNonQuery();
				}
				catch (Exception)
				{

					throw;
				}
			}
		}

	}
}
