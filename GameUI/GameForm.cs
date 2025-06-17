using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
	public class GameForm : Form
	{
		private Button button1;
		private int m_NumberOfChances;
		public GameForm(int i_NumberOfchances)
		{
			m_NumberOfChances = i_NumberOfchances;
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.IndianRed;
			this.button1.Location = new System.Drawing.Point(379, 70);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(156, 89);
			this.button1.TabIndex = 0;
			this.button1.Text = "Hey";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// GameForm
			// 
			this.ClientSize = new System.Drawing.Size(893, 586);
			this.Controls.Add(this.button1);
			this.Name = "GameForm";
			this.ResumeLayout(false);

		}
	}
}
