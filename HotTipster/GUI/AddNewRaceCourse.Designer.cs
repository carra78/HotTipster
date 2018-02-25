namespace HotTipster.GUI
{
	partial class AddNewRaceCourse
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtAddNewRaceCourse = new System.Windows.Forms.TextBox();
			this.btnSaveNewRaceCourse = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnSaveNewRaceCourse);
			this.groupBox1.Controls.Add(this.txtAddNewRaceCourse);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(25, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(343, 270);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(197, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Race Course Name";
			// 
			// txtAddNewRaceCourse
			// 
			this.txtAddNewRaceCourse.Location = new System.Drawing.Point(23, 81);
			this.txtAddNewRaceCourse.Name = "txtAddNewRaceCourse";
			this.txtAddNewRaceCourse.Size = new System.Drawing.Size(288, 37);
			this.txtAddNewRaceCourse.TabIndex = 1;
			// 
			// btnSaveNewRaceCourse
			// 
			this.btnSaveNewRaceCourse.Location = new System.Drawing.Point(23, 154);
			this.btnSaveNewRaceCourse.Name = "btnSaveNewRaceCourse";
			this.btnSaveNewRaceCourse.Size = new System.Drawing.Size(128, 53);
			this.btnSaveNewRaceCourse.TabIndex = 2;
			this.btnSaveNewRaceCourse.Text = "Save";
			this.btnSaveNewRaceCourse.UseVisualStyleBackColor = true;
			this.btnSaveNewRaceCourse.Click += new System.EventHandler(this.btnSaveNewRaceCourse_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(174, 154);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 53);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// AddNewRaceCourse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 345);
			this.Controls.Add(this.groupBox1);
			this.Name = "AddNewRaceCourse";
			this.Text = "AddNewRaceCourse";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtAddNewRaceCourse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSaveNewRaceCourse;
	}
}