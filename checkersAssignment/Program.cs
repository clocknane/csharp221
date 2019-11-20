using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//Allows game to use the unicode characters
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			//Instantiate a game
			//Call the start method
			Game game = new Game();
			game.Start();
			Console.Read();
		}
	}

	//Create team colors
	public enum Color { White, Black }

	//Create coordinates struct for checker pieces
	public struct Position
	{
		public int Row { get; private set; }
		public int Column { get; private set; }

		public Position(int row, int col)
		{
			this.Row = row;
			this.Column = col;
		}
	}

	#region Checker

	public class Checker
	{
		public string Symbol { get; private set; }
		public Color Team { get; private set; }
		public Position Position { get; set; }

		//create checker piece with color and position and unicode symbol
		public Checker(Color team, int row, int col)
		{
			if (team == Color.Black)
			{
				int symbol = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
				Symbol = char.ConvertFromUtf32(symbol);
				Team = Color.Black;
			}
			else
			{
				int symbol = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
				Symbol = char.ConvertFromUtf32(symbol);
				Team = Color.White;
			}
			Position = new Position(row, col);
		}
	}

	#endregion Checker

	#region Board

	public class Board
	{
		//creates list to hold checker objects
		public List<Checker> checkers { get; private set; }

		public Board()
		{
			checkers = new List<Checker>();
			//for top 3 rows off board create/add white checkers, in offset spaces to list
			for (int r = 0; r < 3; r++)
			{
				for (int i = 0; i < 8; i += 2)
				{
					Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
					checkers.Add(c);

					Checker c2 = new Checker(Color.Black, (5 + r), r % 2 + i);
					checkers.Add(c2);
				}
			}
		}

		public Checker GetChecker(Position source)
		{
			//takes source parameter from user input, finds checker in list, returns that checker
			foreach (Checker c in checkers)
			{
				if (c.Position.Row == source.Row && c.Position.Column == source.Column)
				{
					return c;
				}
			}

			return null;
		}

		public void MoveChecker(Checker checker, Position destination)
		{
			//accepts a given checker object and a position from user input to move to
			//creates a copy of the given checker but with the new position
			//adds copy to the list, calls remove function for original object
			Checker c = new Checker(checker.Team, destination.Row, destination.Column);
			checkers.Add(c);
			RemoveChecker(checker);
		}

		public void RemoveChecker(Checker checker)
		{
			//if checker exists remove it from list
			if (checker != null)
			{
				checkers.Remove(checker);
			}
		}
	}

	#endregion Board

	#region Game

	public class Game
	{
		private Board board;

		public Game()
		{
			this.board = new Board();
		}

		private bool CheckForWin()
		{
			return (board.checkers.All(x => x.Team == Color.White) || board.checkers.All(x => x.Team == Color.Black));
		}

		//Methods

		#region Start

		public void Start()
		{
			drawBoard();
			while (!CheckForWin())
			{
				ProcessInput();
				drawBoard();
			}

			Console.WriteLine("You Won!!!");
			Console.WriteLine("Press any key to end...");
			Console.ReadKey();
		}

		#endregion Start

		#region Legal Move?

		public bool IsLegalMove(Position source, Position destination)
		{
			//Make sure that source and destination points are on NOT outside the game board
			if (source.Row < 0 || source.Row > 7 || source.Column < 0 || source.Column > 7
				|| destination.Row < 0 || destination.Row > 7 || destination.Column < 0 || destination.Column > 7)
			{
				return false;
			}

			//Get difference between the specified rows and columns
			//check if the absolute values of the distances yield a slope
			// of 1
			int rowDistance = Math.Abs(destination.Row - source.Row);
			int colDistance = Math.Abs(destination.Column - source.Column);

			if (colDistance == 0 || rowDistance == 0) return false;
			if (rowDistance / colDistance != 1) return false;

			//check if distance to destination is greater than 2
			//don't need to check col because previous line already
			//tells us if the two are equivalent
			if (rowDistance > 2) return false;

			//if checker is in destination already then false
			Checker c = board.GetChecker(destination);
			if (c != null) return false;

			if (rowDistance == 2)
			{
				if (IsCapture(source, destination))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				//It is a valid move 1 space diagonally
				return true;
			}
		}

		#endregion Legal Move?

		#region IsCapture

		public bool IsCapture(Position source, Position destination)
		{
			int rowDistance = Math.Abs(destination.Row - source.Row);
			int colDistance = Math.Abs(destination.Column - source.Column);

			if (rowDistance == 2 && colDistance == 2)
			{
				int row_mid = (destination.Row + source.Row) / 2;
				int col_mid = (destination.Column + source.Column) / 2;
				Position p = new Position(row_mid, col_mid);
				Checker c = board.GetChecker(p);
				Checker player = board.GetChecker(source);
				//if mid point is empty then can't move two spaces
				if (c == null)
				{
					Console.WriteLine("Player is null");
					return false;
				}
				else
				{
					if (c.Team == player.Team)
					{
						return false;
					}
					else
					{
						return true;
					}
				}
			}
			else
			{
				return false;
			}
		}

		#endregion IsCapture

		#region Return Captured Checker

		public Checker GetCaptureChecker(Position source, Position destination)
		{
			if (IsCapture(source, destination))
			{
				int row_mid = (source.Row + destination.Row) / 2;
				int col_mid = (source.Column + destination.Column) / 2;
				Position p = new Position(row_mid, col_mid);
				Checker c = board.GetChecker(p);
				return c;
			}
			else
			{
				return null;
			}
		}

		#endregion Return Captured Checker

		#region Validation

		public bool userValidation(string src, string dest)
		{
			//Check if either input was empty
			if (String.IsNullOrEmpty(src) || String.IsNullOrEmpty(dest))
			{
				return false;
			}

			string[] source = src.Split(',');
			string[] destination = dest.Split(',');

			//Check for too many numbers
			if (source.Length > 2 || destination.Length > 2)
			{
				return false;
			}

			//Check if only partial input is valid
			for (int i = 0; i < 2; i++)
			{
				if (String.IsNullOrEmpty(source[i]) || String.IsNullOrEmpty(destination[i]))
				{
					return false;
				}
			}

			return true;
		}

		#endregion Validation

		#region Process Input

		public void ProcessInput()
		{
			Console.WriteLine("Select Checker to move in the form of row, column");
			string from = Console.ReadLine().Trim();
			Console.WriteLine("Select a space to move to in the form of row, column");
			string to = Console.ReadLine().Trim();

			if (!userValidation(from, to))
			{
				Console.WriteLine();
				Console.WriteLine("***You missed an input or have inputted too many numbers. Please try again.***");
			}
			else
			{
				string[] src = from.Split(',');
				string[] dest = to.Split(',');
				Position source = new Position(int.Parse(src[0]), int.Parse(src[1]));
				Position destination = new Position(int.Parse(dest[0]), int.Parse(dest[1]));
				Checker c = board.GetChecker(source);

				if (c == null)
				{
					Console.WriteLine();
					Console.WriteLine("***There is no checker in the source location");
				}
				else
				{
					//Checking if move is legal and if it's a capture
					if (IsLegalMove(source, destination))
					{
						//check if legal move was a capture move
						//if so, then move the source checker and remove the checker that was "captured"
						if (GetCaptureChecker(source, destination) != null)
						{
							board.RemoveChecker(GetCaptureChecker(source, destination));
							board.MoveChecker(c, destination);
						}
						else
						{
							//Move is legal so move the copy and remove the original
							board.MoveChecker(c, destination);
						}
					}
					else
					{
						Console.WriteLine("This is not a legal move. Please try again");
					}
				}
			}
		}

		#endregion Process Input

		#region Draw Board

		public void drawBoard()
		{
			String[][] grid = new String[8][];
			for (int r = 0; r < 8; r++)
			{
				grid[r] = new string[8];
				for (int c = 0; c < 8; c++)
				{
					grid[r][c] = " ";
				}
			}
			foreach (Checker c in board.checkers)
			{
				grid[c.Position.Row][c.Position.Column] = c.Symbol;
			}

			Console.WriteLine();
			Console.WriteLine("   0   1   2   3   4   5   6   7");
			Console.Write("  ");
			for (int i = 0; i < 32; i++)
			{
				Console.Write("\u2501");
			}

			Console.WriteLine();

			for (int r = 0; r < 8; r++)
			{
				Console.Write($"{r} ");

				for (int c = 0; c < 8; c++)
				{
					Console.Write($" {grid[r][c]} \u2503");
				}

				Console.WriteLine();
				Console.Write("  ");

				for (int i = 0; i < 32; i++)
				{
					Console.Write("\u2501");
				}
				Console.WriteLine();
			}
		}

		#endregion Draw Board
	}

	#endregion Game
}