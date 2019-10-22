using System;

namespace RPS
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string inputPlayer;
			int randomInt;

			bool playAgain = true;

			while (playAgain)
			{
				int scorePlayer = 0;
				int scoreCPU = 0;

				while (scorePlayer < 3 && scoreCPU < 3)
				{
					Console.Write("Choose between Rock, Paper and Scissors: ");
					inputPlayer = Console.ReadLine();
					inputPlayer = inputPlayer.ToUpper();

					Random generator = new Random();

					randomInt = generator.Next(1, 4);

					switch (randomInt)
					{
						case 1:
							Console.WriteLine("Computer chose ROCK");
							if (inputPlayer == "ROCK")
							{
								Console.WriteLine("DRAW!!\n\n");
							}
							else if (inputPlayer == "PAPER")
							{
								Console.WriteLine("PLAYER WINS!!\n\n");
								scorePlayer++;
							}
							else if (inputPlayer == "SCISSORS")
							{
								Console.WriteLine("CPU WINS!!\n\n");
								scoreCPU++;
							}
							break;

						case 2:
							Console.WriteLine("Computer chose PAPER");
							if (inputPlayer == "PAPER")
							{
								Console.WriteLine("DRAW!!\n\n");
							}
							else if (inputPlayer == "ROCK")
							{
								Console.WriteLine("CPU WINS!!\n\n");
								scoreCPU++;
							}
							else if (inputPlayer == "SCISSORS")
							{
								Console.WriteLine("PLAYER WINS!!\n\n");
								scorePlayer++;
							}
							break;

						case 3:
							Console.WriteLine("Computer chose SCISSORS");
							if (inputPlayer == "SCISSORS")
							{
								Console.WriteLine("DRAW!!\n\n");
							}
							else if (inputPlayer == "ROCK")
							{
								Console.WriteLine("PLAYER WINS!!\n\n");
								scorePlayer++;
							}
							else if (inputPlayer == "PAPER")
							{
								Console.WriteLine("CPU WINS!!\n\n");
								scoreCPU++;
							}
							break;

						default:
							Console.WriteLine("Invalid entry, please make a valid selection!");
							break;
					}

					Console.WriteLine("\n\nSCORES:\tPLAYER:\t{0}\tCPU:\t{1}", scorePlayer, scoreCPU);
				}

				if (scorePlayer == 3)
				{
					Console.WriteLine("Player WON!");
				}
				else if (scoreCPU == 3)
				{
					Console.WriteLine("CPU WON!");
				}
				else
				{
				}

				Console.WriteLine("Do you want to play again?(y/n)");
				string loop = Console.ReadLine();
				if (loop == "y")
				{
					playAgain = true;
					Console.Clear();
				}
				else if (loop == "n")
				{
					playAgain = false;
				}
				else
				{
				}
			}
		}
	}
}