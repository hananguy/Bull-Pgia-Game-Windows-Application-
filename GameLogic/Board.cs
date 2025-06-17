using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class Board
	{
		private List<SecretCode> m_SecretCodes;
		private List<FeedBack> m_FeedBacks;
		private readonly int r_CodeLength;
		private readonly int r_MaxGuesses;

		public Board(int i_CodeLength, int i_MaxGuesses)
		{
			r_CodeLength = i_CodeLength;
			r_MaxGuesses = i_MaxGuesses;
			m_SecretCodes = new List<SecretCode>();
			m_FeedBacks = new List<FeedBack>();
		}

		public IReadOnlyList<SecretCode> SecretCodes
		{
			get { return m_SecretCodes.AsReadOnly(); }
		}

		public IReadOnlyList<FeedBack> FeedBacks
		{
			get { return m_FeedBacks.AsReadOnly(); }
		}

		public int CodeLength
		{
			get { return r_CodeLength; }
		}

		public int MaxGuesses
		{
			get { return r_MaxGuesses; }
		}

		public string GetBoardAsString()
		{
			int guessColWidth = 2 * r_CodeLength - 1;
			int resultColWidth = 2 * r_CodeLength - 1;

			string header = $"| {"Pins:".PadRight(guessColWidth)} | {"Result:".PadRight(resultColWidth)} |";
			string separator = $"|{new string('=', guessColWidth + 2)}|{new string('=', resultColWidth + 2)}|";

			StringBuilder boardString = new StringBuilder();
			boardString.AppendLine("Current board status:");
			boardString.AppendLine(header);
			boardString.AppendLine(separator);

			string hidden = string.Join(" ", Enumerable.Repeat("#", r_CodeLength));
			boardString.AppendLine($"| {hidden.PadRight(guessColWidth)} | {"".PadRight(resultColWidth)} |");
			boardString.AppendLine(separator);

			for (int line = 0; line < r_MaxGuesses; line++)
			{
				string guess = line < m_SecretCodes.Count ? string.Join(" ", m_SecretCodes[line].Code.Replace(" ", "").ToCharArray()) : "";
				string result = line < m_FeedBacks.Count ? string.Join(" ", m_FeedBacks[line].CreateBullsHitsString()) : "";

				boardString.AppendLine($"| {guess.PadRight(guessColWidth)} | {result.PadRight(resultColWidth)} |");
				boardString.AppendLine(separator);
			}

			return boardString.ToString();
		}
		public void UpdateBoard(SecretCode i_Guess, FeedBack i_Feedback)
		{
			m_SecretCodes.Add(i_Guess);
			m_FeedBacks.Add(i_Feedback);
		}
	}
}

internal class Board
	{
	}
}
