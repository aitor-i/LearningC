using System;
namespace PracticandoC
{
	public class NumericBot
	{
		string Name;

		public NumericBot(string name) // Que es este metodo y porque no esta typado? Constructor?
		{
			Console.WriteLine("Sarting numeric Robot");
			Console.WriteLine($"Robot: Hello Human, My name is {name}! How can I serve to you?");
			this.Name = name;
		}

		public int numberComberter(int numberToConvert)
		{
			Console.WriteLine($"Converting {numberToConvert}");
			int lenght = numberToConvert.ToString().Length;
			string[] invertedNumbers = new string[lenght];
			char[] chartsToInvert = numberToConvert.ToString().ToCharArray();

			Console.WriteLine(chartsToInvert[0]);	

			for (int i = 0; i < lenght; i++)
			{
				int index = (lenght -1 )- i;
				invertedNumbers[i] = chartsToInvert[index].ToString();
			}

			string invertedNumberString = string.Join("",invertedNumbers).ToString();
			int invertedNumber = Int32.Parse(invertedNumberString);

			Console.WriteLine($"{this.Name}: Number {numberToConvert} inverted, output: {invertedNumber}");
			return invertedNumber;
		}

		public int selectTheBigestNumber(int[] numbers)
		{
			Console.WriteLine($"{this.Name}: Selecting the bigger number...");
			int theBigerNumber = 0;

			foreach (int number in numbers)
			{
				if (number > theBigerNumber) theBigerNumber = number;
			}

			Console.WriteLine($"{this.Name}: The bigger number is: {theBigerNumber}");
			return theBigerNumber;
		}

		public void typeSearcher(char charToAnalize)
		{

			if (char.IsNumber(charToAnalize))
			{
				Console.WriteLine($"{this.Name}: {charToAnalize} is a number");
				return;
			}

			char[] vocals = new char[5] { 'a', 'e', 'i','o','u' };
				if (vocals.Contains(charToAnalize))
				{
					Console.WriteLine($"{this.Name}: {charToAnalize} is a vowel");
				}
				else
				{
					Console.WriteLine($"{this.Name}: {charToAnalize} is a consonat");
				}


		}

		public void chainDestructuring(string stringForDestructuring )
		{
			char[] characters = stringForDestructuring.ToCharArray();

			foreach (var character in characters)
			{
				Console.WriteLine(character);
			}
		}

		public string coinExchanger(int change)
		{
			
			return "";
		}
	}



	public class App
	{
		
	}
}

