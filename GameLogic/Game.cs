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
		private Board m_Board;
		private InputValidator m_Validator;
		private int m_CurrentUserTurn = 0;
		private const int k_NumberOfPinsToGuess = 4;
		private int m_MaxNumberOfGuesses;
		private int m_NumberOfGuessesChoosenByUser;
		readonly int k_MinNumberOfChances = 4;
		readonly int k_MaxNumberOfChances = 10;
		private const int k_SecretCodeLength = 4;
		private readonly char[] m_AllowedLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

		public Game()
		{

		}
		public int NumberOfGuessesChoosenByUser
		{
			get { return m_NumberOfGuessesChoosenByUser; }
			set { m_NumberOfGuessesChoosenByUser = value; }
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

		private void InitializeGame(int i_NumberOfGuesses)
		{
			m_MaxNumberOfGuesses = i_NumberOfGuesses;
			m_Computer = new Computer();
			m_Board = new Board(k_SecretCodeLength, m_MaxNumberOfGuesses);
			m_Validator = new InputValidator(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' }, k_SecretCodeLength);
			m_Player = new Player();

			m_Computer.CreateSecretCode(m_AllowedLetters, k_SecretCodeLength);

		}
		
	}
}
