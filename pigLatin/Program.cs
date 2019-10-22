using System;

namespace PigLatin
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("please enter a word: ");
			string word = Console.ReadLine();
			string word2 = word.ToLower();
			char[] splitword2 = new char[word.Length];
			splitword2 = word2.ToCharArray();
			char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
			for (int i = 0; i < vowel.Length; i++)
			{
				if (splitword2[0].Equals(vowel[i]))
				{
					string final = word2 + "yay";
					Console.WriteLine("The result is {0}", final);
					break;
				}
				else if (splitword2[0].Equals('q') && splitword2[1].Equals('u'))
				{
					string final = word2.Substring(2, word2.Length - 2) + "ay";
					Console.WriteLine("The result is {0}", final);
					break;
				}
				else
				{
					for (int j = 0; j < splitword2.Length; j++)
					{
						if (vowel[i].Equals(splitword2[j]) && ((i = j) != 0))
						{
							string final = word2.Substring(i - 1, word2.Length - i + 1) + word2.Substring(0, i - 1) + "ay";
							Console.WriteLine("The result is {0}", final);
							break;
						}
					}
				}
			}
			Console.ReadLine();
		}
	}
}