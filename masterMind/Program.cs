using System;

namespace masterMind
{
	internal class Program
	{
		private static string[] hidden = new string[2];
		private static string[] colorArray = new string[] { "red", "yellow", "blue" };
		private static bool endGame = false;

		private static void Main(string[] args)
		{
			createhidden();
			userGuess();
			Console.Read();
		}

		//Generate Random Hidden Values
		public static void createhidden()
		{
			for (int i = 0; i < 2; i++)
			{
				Random num = new Random();
				int ranNum = num.Next(0, 3);
				hidden[i] = colorArray[ranNum];
			}
		}

		//Get Guess from User and Compare to Hidden
		public static void userGuess()
		{
			Console.WriteLine("To play, please guess two colors in the format color color");
			while (endGame == false)
			{
				Console.WriteLine("Please Enter your guess: ");
				string[] guess = Console.ReadLine().Split(' ');
				string guess0 = guess[0].ToLower();
				string guess1 = guess[1].ToLower();

				if (guess.Length > 2)
				{
					Console.WriteLine("Whoa, easy there, choose only two colors please. \nTry again: ");
					guess = Console.ReadLine().Split(' ');
				}

				//Check if Guess is Correct
				if (hidden[0] == guess0 && hidden[1] == guess1)
				{
					Console.WriteLine("Hey, that is absolute right, You Won!");
					endGame = true;
				}
				else
				{
					int colorHintCount = 0;
					int slotHintCount = 0;

					//Checkf If Any Colors Match
					for (int i = 0; i < 2; i++)
					{
						for (int j = 0; j < 2; j++)
						{
							if (hidden[i] == guess[j].ToLower())
							{
								colorHintCount++;
							}
						}
					}

					//Check If Any slots Match
					for (int i = 0; i < 2; i++)
					{
						if (hidden[i] == guess[i].ToLower())
						{
							slotHintCount++;
						}
					}

					Console.WriteLine(colorHintCount + "-" + slotHintCount);
				}
			}
		}
	}
}