namespace HotTipster.GUI
{
	partial class Reports
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnReportByYear = new System.Windows.Forms.Button();
			this.btnReportFavRaceCourse = new System.Windows.Forms.Button();
			this.btnReportAllByDate = new System.Windows.Forms.Button();
			this.btnReportMaxWinLose = new System.Windows.Forms.Button();
			this.btnReportSuccessRate = new System.Windows.Forms.Button();
			this.dgvReports = new System.Windows.Forms.DataGridView();
			this.btnQuit = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnQuit);
			this.groupBox1.Controls.Add(this.dgvReports);
			this.groupBox1.Controls.Add(this.btnReportSuccessRate);
			this.groupBox1.Controls.Add(this.btnReportMaxWinLose);
			this.groupBox1.Controls.Add(this.btnReportAllByDate);
			this.groupBox1.Controls.Add(this.btnReportFavRaceCourse);
			this.groupBox1.Controls.Add(this.btnReportByYear);
			this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(29, 23);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(834, 545);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnReportByYear
			// 
			this.btnReportByYear.Location = new System.Drawing.Point(20, 37);
			this.btnReportByYear.Name = "btnReportByYear";
			this.btnReportByYear.Size = new System.Drawing.Size(138, 83);
			this.btnReportByYear.TabIndex = 0;
			this.btnReportByYear.Text = "Results by Year";
			this.btnReportByYear.UseVisualStyleBackColor = true;
			this.btnReportByYear.Click += new System.EventHandler(this.btnReportByYear_Click);
			// 
			// btnReportFavRaceCourse
			// 
			this.btnReportFavRaceCourse.Location = new System.Drawing.Point(164, 37);
			this.btnReportFavRaceCourse.Name = "btnReportFavRaceCourse";
			this.btnReportFavRaceCourse.Size = new System.Drawing.Size(151, 83);
			this.btnReportFavRaceCourse.TabIndex = 1;
			this.btnReportFavRaceCourse.Text = "Favourite RaceCourse";
			this.btnReportFavRaceCourse.UseVisualStyleBackColor = true;
			this.btnReportFavRaceCourse.Click += new System.EventHandler(this.btnReportFavRaceCourse_Click);
			// 
			// btnReportAllByDate
			// 
			this.btnReportAllByDate.Location = new System.Drawing.Point(321, 37);
			this.btnReportAllByDate.Name = "btnReportAllByDate";
			this.btnReportAllByDate.Size = new System.Drawing.Size(176, 83);
			this.btnReportAllByDate.TabIndex = 2;
			this.btnReportAllByDate.Text = "Show All - Chronologically";
			this.btnReportAllByDate.UseVisualStyleBackColor = true;
			this.btnReportAllByDate.Click += new System.EventHandler(this.btnReportAllByDate_Click);
			// 
			// btnReportMaxWinLose
			// 
			this.btnReportMaxWinLose.Location = new System.Drawing.Point(503, 37);
			this.btnReportMaxWinLose.Name = "btnReportMaxWinLose";
			this.btnReportMaxWinLose.Size = new System.Drawing.Size(151, 83);
			this.btnReportMaxWinLose.TabIndex = 3;
			this.btnReportMaxWinLose.Text = "Max Won / Lost";
			this.btnReportMaxWinLose.UseVisualStyleBackColor = true;
			this.btnReportMaxWinLose.Click += new System.EventHandler(this.btnReportMaxWinLose_Click);
			// 
			// btnReportSuccessRate
			// 
			this.btnReportSuccessRate.Location = new System.Drawing.Point(660, 37);
			this.btnReportSuccessRate.Name = "btnReportSuccessRate";
			this.btnReportSuccessRate.Size = new System.Drawing.Size(151, 83);
			this.btnReportSuccessRate.TabIndex = 4;
			this.btnReportSuccessRate.Text = "Success Rate";
			this.btnReportSuccessRate.UseVisualStyleBackColor = true;
			this.btnReportSuccessRate.Click += new System.EventHandler(this.btnReportSuccessRate_Click);
			// 
			// dgvReports
			// 
			this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReports.Location = new System.Drawing.Point(20, 147);
			this.dgvReports.Name = "dgvReports";
			this.dgvReports.RowTemplate.Height = 28;
			this.dgvReports.Size = new System.Drawing.Size(791, 289);
			this.dgvReports.TabIndex = 5;
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(272, 464);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(194, 56);
			this.btnQuit.TabIndex = 6;
			this.btnQuit.Text = "Quit Reports";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// Reports
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 589);
			this.Controls.Add(this.groupBox1);
			this.Name = "Reports";
			this.Text = "Reports";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnReportMaxWinLose;
		private System.Windows.Forms.Button btnReportAllByDate;
		private System.Windows.Forms.Button btnReportFavRaceCourse;
		private System.Windows.Forms.Button btnReportByYear;
		private System.Windows.Forms.Button btnReportSuccessRate;
		private System.Windows.Forms.DataGridView dgvReports;
		private System.Windows.Forms.Button btnQuit;
	}
}