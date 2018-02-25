using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotTipster.DataAccess;

namespace HotTipster.GUI
{
	public partial class AddNewRaceCourse : Form
	{
		public AddNewRaceCourse()
		{
			InitializeComponent();
		}

		private void btnSaveNewRaceCourse_Click(object sender, EventArgs e)
		{
			string name = txtAddNewRaceCourse.Text;
			ReadWriteToSQLite writer = new ReadWriteToSQLite();
			writer.InsertNewRaceCourse(name);
			AddBetInformation bet = new AddBetInformation();
			bet.Show();
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			AddBetInformation bet = new AddBetInformation();
			bet.Show();
			this.Close();
		}
	}
}
