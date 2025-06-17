using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;
namespace GameUI
{
	public class Program
	{
		static void Main()
		{
			Game game = new Game();
			StartGameForm startGameForm = new StartGameForm(game.MinNumberOfChances,game.MaxNumberOfChances);
			startGameForm.ShowDialog();	
		}
	}
}
