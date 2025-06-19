using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
	public class Game
	{
		private Computer m_Computer;
		private Player m_Player;
		private int m_CurrentUserTurn = 0;
		private const int k_NumberOfPinsToGuess = 4;
		private readonly int r_NumberOfGuessesChoosenByUser;
		readonly int k_MinNumberOfChances = 4;
		readonly int k_MaxNumberOfChances = 10;
		private const int k_SecretCodeLength = 4;
		private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
		public Game(int i_NumberOfGuesses)
		{
			r_NumberOfGuessesChoosenByUser = i_NumberOfGuesses;
			m_Computer = new Computer();
			m_Player = new Player();
		}
		public Game()
		{
		}
		public int NumberOfGuessesChoosenByUser
		{
			get { return r_NumberOfGuessesChoosenByUser; }
		}
		public Computer ComputerPlayer
		{
			get { return m_Computer; }
		}
		public Player HumanPlayer
		{
			get { return m_Player; }
		}
		public int NumberOfPinsToGuess
		{
			get { return k_NumberOfPinsToGuess; }
		}
		public int CurrentUserTurn
		{
			get { return m_CurrentUserTurn; }
			set { m_CurrentUserTurn = value; }
		}
		public int MinNumberOfChances
		{
			get { return k_MinNumberOfChances; }
		}
		public int MaxNumberOfChances
		{
			get { return k_MaxNumberOfChances; }
		}
		public char[] AvailableLetters
		{
			get { return m_AllowedLetters; }
		}
		
	}
}
