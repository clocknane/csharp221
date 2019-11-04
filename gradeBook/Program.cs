using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
	internal class Program
	{
		private static Dictionary<string, string> gradeBook = new Dictionary<string, string>();

		private static void Main(string[] args)
		{
			studentInput();
			outputGradeBook();
			moreInput();
			Console.Read();
		}

		#region Input

		public static void studentInput()
		{
			//ask for input or quit
			Console.WriteLine("Welcome to Grade Book! Would you like to input data: yes or no?");
			string choice = Console.ReadLine().ToLower();

			while (choice != "no")
			{
				Console.WriteLine("Please enter a student's first and last name: ");
				string studentName = Console.ReadLine();

				Console.WriteLine("Please enter student's grades separated by spaces like so: 100 100 100 100.");
				string studentGrades = Console.ReadLine();
				gradeBook.Add(studentName, studentGrades);

				Console.WriteLine("Do you want to input another student, edit a student, or quit?");
				string secondChoice = Console.ReadLine();

				if (secondChoice == "quit")
				{
					break;
				}
				else if (secondChoice == "edit")
				{
					editGradeBook();
				}
				else
				{
					//loop keeps going
				}
			}
		}

		#endregion Input

		#region Output

		public static void outputGradeBook()
		{
			foreach (KeyValuePair<string, string> kvp in gradeBook)
			{
				//split the values and trim the white space
				string trimmedString = kvp.Value.Trim();
				string[] stringGrades = trimmedString.Split(' ');
				int[] numberGrades = new int[stringGrades.Length];

				//loop to convert strings into integers and store in int[]
				for (int i = 0; i < stringGrades.Length; i++)
				{
					numberGrades[i] = Convert.ToInt32(stringGrades[i]);
				}

				int lowestGrade = numberGrades.Min();
				int highestGrade = numberGrades.Max();
				int sum = 0;

				//loop to get sum of grades
				for (int i = 0; i < numberGrades.Length; i++)
				{
					sum += numberGrades[i];
				}

				float average = (sum / numberGrades.Length);

				Console.WriteLine($"{kvp.Key}:\n Highest Grade is {highestGrade} \nLowest Grade is {lowestGrade} \nAverage is {average}");
			}
		}

		#endregion Output

		#region more input

		public static void moreInput()
		{
			Console.WriteLine("Would you like to close Grade Book, or go back and enter more students: close or enter?");
			string finalChoice = Console.ReadLine().ToLower();

			if (finalChoice == "close")
			{
				Environment.Exit(0);
			}
		}

		#endregion more input

		#region edits

		private static void editGradeBook()
		{
			Console.WriteLine("Please enter first and last name of student you want to edit: ");
			string editStudent = Console.ReadLine();
			Console.WriteLine("Do you want to add or change a grade entry?");
			string editType = Console.ReadLine();

			if (editType == "add")
			{
				Console.WriteLine("Please enter the grade that you would like to add.");
				string addGrade = Console.ReadLine();
				gradeBook[editStudent] = gradeBook[editStudent] + addGrade;
			}
			else
			{
				Console.WriteLine($"The grade entries for {editStudent} are: {gradeBook[editStudent]}");
				Console.WriteLine("What grade entry would you like to change?");
				string changeGrade = Console.ReadLine();
				Console.WriteLine($"What do you want to replace {editStudent}'s {changeGrade} with?");
				string newGrade = Console.ReadLine();

				//turn the students value string into an array
				string[] studGradeArr = gradeBook[editStudent].Split(' ');
				int gradeIndex = Array.IndexOf(studGradeArr, changeGrade);
				studGradeArr[gradeIndex] = newGrade;

				//take edited grade array and turn back into a string value
				gradeBook[editStudent] = string.Join(" ", studGradeArr);

				Console.WriteLine($"{editStudent}'s grade entries are now: {gradeBook[editStudent]}");
				Console.WriteLine("Does that look correct?");
				string affirm = Console.ReadLine();
			}
		}

		#endregion edits
	}
}