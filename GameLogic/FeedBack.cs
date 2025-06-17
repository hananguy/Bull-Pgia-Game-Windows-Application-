using System;
using System.Collections.Generic;

namespace GameLogic
{
	public class FeedBack
	{
		public int NumberOfBulls { get; private set; }

		public int NumberOfHits { get; private set; }

		public void Evaluate(SecretCode i_PlayerCode, SecretCode i_ComputerCode)
		{
			Reset();

			char[] computerCodeChars = i_ComputerCode.Code.Replace(" ", "").ToCharArray();
			char[] playerCodeChars = i_PlayerCode.Code.Replace(" ", "").ToCharArray();

			bool[] computerCodeUsedFlags = new bool[computerCodeChars.Length];
			bool[] playerGuessUsedFlags = new bool[playerCodeChars.Length];

			for (int position = 0; position < playerCodeChars.Length; position++)
			{
				if (playerCodeChars[position] == computerCodeChars[position])
				{
					NumberOfBulls++;
					computerCodeUsedFlags[position] = true;
					playerGuessUsedFlags[position] = true;
				}
			}

			for (int playerPosition = 0; playerPosition < playerCodeChars.Length; playerPosition++)
			{
				if (playerGuessUsedFlags[playerPosition])
				{
					continue;
				}

				for (int computerPosition = 0; computerPosition < computerCodeChars.Length; computerPosition++)
				{
					if (computerCodeUsedFlags[computerPosition])
					{
						continue;
					}

					if (playerCodeChars[playerPosition] == computerCodeChars[computerPosition])
					{
						NumberOfHits++;
						playerGuessUsedFlags[playerPosition] = true;
						computerCodeUsedFlags[computerPosition] = true;
						break;
					}
				}
			}
		}

		public string CreateBullsHitsString()
		{
			List<char> feedbackSymbols = new List<char>();
			for (int i = 0; i < NumberOfBulls; i++)
			{
				feedbackSymbols.Add('V');
			}
			for (int i = 0; i < NumberOfHits; i++)
			{
				feedbackSymbols.Add('X');
			}

			return string.Join(" ", feedbackSymbols);
		}

		public bool IsWinningGuess()
		{
			return NumberOfBulls == 4;
		}

		private void Reset()
		{
			NumberOfBulls = 0;
			NumberOfHits = 0;
		}
	}
}
