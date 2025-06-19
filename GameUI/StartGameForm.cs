using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameUI
{
	public class StartGameForm : Form
	{
		int m_CurrentNumberOfChances;
		public readonly int k_MinNumberOfChances;
		public readonly int k_MaxNumberOfChances;
		private Label m_NumberOfChances;
		private Button m_Start;
		Game m_GameLogic;
		public StartGameForm()
		{
			m_GameLogic = new Game();
			k_MinNumberOfChances = m_GameLogic.MinNumberOfChances;
			k_MaxNumberOfChances = m_GameLogic.MaxNumberOfChances;
			m_CurrentNumberOfChances = k_MinNumberOfChances;
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.m_NumberOfChances = new Label();
			this.m_Start = new Button();
			this.SuspendLayout();
			// 
			// m_NumberOfChances
			// 
			this.m_NumberOfChances.AutoSize = true;
			this.m_NumberOfChances.BorderStyle = BorderStyle.Fixed3D;
			this.m_NumberOfChances.Location = new Point(72, 9);
			this.m_NumberOfChances.Name = "m_NumberOfChances";
			this.m_NumberOfChances.Size = new Size(129, 18);
			this.m_NumberOfChances.TabIndex = 0;
			this.m_NumberOfChances.Text = "Number Of Chances: " + m_CurrentNumberOfChances.ToString();
			this.m_NumberOfChances.Click += new EventHandler(this.m_NumberOfChances_Click);
			// 
			// m_Start
			// 
			this.m_Start.FlatStyle = FlatStyle.Flat;
			this.m_Start.Location = new Point(210, 102);
			this.m_Start.Name = "m_Start";
			this.m_Start.Size = new Size(75, 23);
			this.m_Start.TabIndex = 1;
			this.m_Start.Text = "Start";
			this.m_Start.UseVisualStyleBackColor = false;
			m_Start.Click += m_Start_Click;
			// 
			// StartGameForm
			// 
			this.BackColor = SystemColors.Info;
			this.ClientSize = new Size(287, 131);
			this.Controls.Add(this.m_NumberOfChances);
			this.Controls.Add(this.m_Start);
			this.Name = "StartGameForm";
			this.Text = "Bull Pgia";
			this.ResumeLayout(false);
			this.PerformLayout();
			this.StartPosition = FormStartPosition.CenterScreen;
		}
		public void m_Start_Click(object sender, EventArgs e)
		{
			this.Hide();
			GameForm gameForm = new GameForm(NumberOfGuesses);
			gameForm.ShowDialog();	
		}
		public int NumberOfGuesses
		{
			get { return m_CurrentNumberOfChances; }
		}
		public void m_NumberOfChances_Click(object sender, EventArgs e)
		{
			m_CurrentNumberOfChances++;
			
			if (m_CurrentNumberOfChances > k_MaxNumberOfChances)
			{
				m_CurrentNumberOfChances = k_MinNumberOfChances;
			}

			this.m_NumberOfChances.Text = string.Format("Number Of Chances: {0}", m_CurrentNumberOfChances);
			
		}
	}
}
