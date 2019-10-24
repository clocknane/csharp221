using System;

internal class Program
{
	public static char playerSignature = ' ';

	private static int turns = 0; // Counts each turn. Once == 10 then the game is a draw

	private static char[] ArrBoard =
	{
			'1', '2', '3','4', '5', '6','7', '8', '9'
		}; // Global char array variable that stores players input

	public static char[] ArrBoard1 { get => ArrBoard; set => ArrBoard = value; }

	public static void BoardReset() // If called, resets game
	{
		char[] ArrBoardInitialize =
		{
				'1', '2', '3','4', '5', '6','7', '8', '9'
			};

		ArrBoard = ArrBoardInitialize;
		DrawBoard();
		turns = 0;
	}

	public static void DrawBoard()
	{
		Console.Clear();
		Console.WriteLine("  -------------------------");
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[0], ArrBoard[1], ArrBoard[2]);
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  -------------------------");
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[3], ArrBoard[4], ArrBoard[5]);
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  -------------------------");
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[6], ArrBoard[7], ArrBoard[8]);
		Console.WriteLine("  |       |       |       |");
		Console.WriteLine("  -------------------------");
	} // Prints player board to console

	public static void Introduction()
	{ }

	private static void Main(string[] args)
	{
		int player = 2; // Player 1 Starts
		int input = 0;
		bool inputCorrect = true;

		Introduction();

		do // Do loop to alternate turns
		{
			if (player == 2)
			{
				player = 1;
				XorO(player, input);
			}
			else if (player == 1)
			{
				player = 2;
				XorO(player, input);
			}

			DrawBoard();
			turns++;

			// Check Game Status
			HorizontalWin();
			VerticalWin();
			DiagonalWin();

			if (turns == 10)
			{
				Draw();
			}

			do
			{
				Console.WriteLine("\nReady Player {0}: It's your turn!", player);
				try
				{
					input = Convert.ToInt32(Console.ReadLine());
				}
				catch
				{
					Console.WriteLine("Please enter a number!");
				}

				if ((input == 1) && (ArrBoard[0] == '1'))
					inputCorrect = true;
				else if ((input == 2) && (ArrBoard[1] == '2'))
					inputCorrect = true;
				else if ((input == 3) && (ArrBoard[2] == '3'))
					inputCorrect = true;
				else if ((input == 4) && (ArrBoard[3] == '4'))
					inputCorrect = true;
				else if ((input == 5) && (ArrBoard[4] == '5'))
					inputCorrect = true;
				else if ((input == 6) && (ArrBoard[5] == '6'))
					inputCorrect = true;
				else if ((input == 7) && (ArrBoard[6] == '7'))
					inputCorrect = true;
				else if ((input == 8) && (ArrBoard[7] == '8'))
					inputCorrect = true;
				else if ((input == 9) && (ArrBoard[8] == '9'))
					inputCorrect = true;
				else
				{
					Console.WriteLine("Please try again...");
					inputCorrect = false;
				}
			} while (!inputCorrect);
		} while (true);
	} // Gameplay loop that controls player turns & overrides the array with player input

	private static void Draw()
	{
		{
			Console.WriteLine("Draw! Play again to determine winner" +
							  "\nPlease press any key to reset the game and try again!");
			Console.ReadKey();
			BoardReset();
		}
	} // Method is called to check if the game is a draw

	private static void DiagonalWin()
	{
		char[] playerSignatures = { 'X', 'O' };

		foreach (char playerSignatue in playerSignatures)
		{
			if (((ArrBoard[0] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[8] == playerSignatue))
				|| ((ArrBoard[6] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[2] == playerSignatue)))
			{
				Console.Clear();
				if (playerSignatue == 'X')
				{
					Console.WriteLine("WOW!, player 1 that's a diagonal win! Excellently Played");
				}
				else
				{
					Console.WriteLine("WOW!, player 2 that's a diagonal win! Excellently Played");
				}

				Console.WriteLine("Please press any key to reset the game");
				Console.ReadKey();
				BoardReset();

				break;
			}
		}
	} // Method is called to check for a diagonal win

	private static void VerticalWin()
	{
		char[] playerSignatures = { 'X', 'O' };

		foreach (char playerSignatue in playerSignatures)
		{
			if (((ArrBoard[0] == playerSignatue) && (ArrBoard[3] == playerSignatue) && (ArrBoard[6] == playerSignatue))
				|| ((ArrBoard[1] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[7] == playerSignatue))
				|| ((ArrBoard[2] == playerSignatue) && (ArrBoard[5] == playerSignatue) && (ArrBoard[8] == playerSignatue)))
			{
				System.Console.Clear();
				if (playerSignatue == 'X')
				{
					Console.WriteLine("Player 1, A vertical win! Congratulations");
				}
				else
				{
					Console.WriteLine("Player 2, A vertical win! Well Done!");
				}

				Console.WriteLine("Please press any key to reset the game");
				Console.ReadKey();
				BoardReset();

				break;
			}
		}
	} // Method is called to check for a vertical win

	private static void HorizontalWin()
	{
		char[] playerSignatures = { 'X', 'O' };

		foreach (char playerSignatue in playerSignatures)
		{
			if (((ArrBoard[0] == playerSignatue) && (ArrBoard[1] == playerSignatue) && (ArrBoard[2] == playerSignatue))
				|| ((ArrBoard[3] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[5] == playerSignatue))
				|| ((ArrBoard[6] == playerSignatue) && (ArrBoard[7] == playerSignatue) && (ArrBoard[8] == playerSignatue)))
			{
				Console.Clear();
				if (playerSignatue == 'X')
				{
					Console.WriteLine("Congratulations Player 1.You have a achieved a horizontal win! ");
				}
				else if (playerSignatue == 'O')
				{
					Console.WriteLine("Congratulations Player 2.You have a achieved a horizontal win! ");
				}

				Console.WriteLine("Please press any key to reset the game");
				Console.ReadKey();
				BoardReset();

				break;
			}
		}
	} // Method is called to check for a horizontal win

	private static void XorO(int player, int input)
	{
		if (player == 1) playerSignature = 'X';
		else if (player == 2) playerSignature = 'O';

		switch (input)
		{
			case 1: ArrBoard[0] = playerSignature; break;
			case 2: ArrBoard[1] = playerSignature; break;
			case 3: ArrBoard[2] = playerSignature; break;
			case 4: ArrBoard[3] = playerSignature; break;
			case 5: ArrBoard[4] = playerSignature; break;
			case 6: ArrBoard[5] = playerSignature; break;
			case 7: ArrBoard[6] = playerSignature; break;
			case 8: ArrBoard[7] = playerSignature; break;
			case 9: ArrBoard[8] = playerSignature; break;
		}
	} // Controls if the player is X or O
}