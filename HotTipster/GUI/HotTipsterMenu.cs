using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotTipster.GUI
{
	public partial class HotTipsterMenu : Form
	{
		public HotTipsterMenu()
		{
			InitializeComponent();
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
