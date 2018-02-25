using HotTipster.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HotTipster.GUI
{
	public partial class HotTipsterMenu : Form
	{
		public HotTipsterMenu()
		{
			InitializeComponent();
			ReadWriteToSQLite sqldb = new ReadWriteToSQLite();
			HistoricDataReader reader = new HistoricDataReader(@"C:\Users\carra\Documents\HotTipster\HotTipsHistoricData.txt"); //Replace with directory ref?
			if (!File.Exists(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "HotTipster.db"))
			{
				sqldb.CreateDatabase();
				sqldb.InsertExistingRaceCoursesIntoDB();
				sqldb.InsertListOfBets(reader.ListOfHistoricHorseBetsOriginal());
			}
		}

		private void btnAddBetInfo_Click(object sender, EventArgs e)
		{
			AddBetInformation add = new AddBetInformation();
			add.Show();
		}

		private void btnReports_Click(object sender, EventArgs e)
		{
			Reports r = new Reports();
			r.Show();
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
