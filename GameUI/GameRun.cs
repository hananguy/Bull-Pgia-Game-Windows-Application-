using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUI
{
	public class GameRun
	{
	

		public void Run()
		{
			StartGameForm startGame = new StartGameForm(4,10);
			startGame.ShowDialog();
			GameForm gameForm = new GameForm(startGame.NumberOfGuesses);
			gameForm.ShowDialog();	

		}
	}
}
