using System;
namespace PracticandoC
{
	public class RobotFactory
	{
		public RobotFactory()
		{
		}

        static void Main() // Voy ha ecesitar mas info sobre este metodo...
        {
            Console.WriteLine("Crating a new robot for you");

            Console.WriteLine("Creating new robot...");
            NumericBot myRobot = new NumericBot("Анна");
            Wallet myWalet = new Wallet();



            bool isRunning = true;
            string userInput;

            
            while (isRunning)
            {
                Console.WriteLine($" 1 - Number Converter \n 2 - Biger number \n 3 - Coin exchanger \n 4 - Type searcher \n 5 - Chain destructuring \n 6 - For scape");
                Console.WriteLine("Select operation number: ");

               userInput = Console.ReadLine();

                if (userInput == "6")
                {
                    Console.WriteLine("Power off...");
                    isRunning = false;


                }

                if(userInput == "1")
                {
                    try
                    {
                    Console.WriteLine("Number Converter selected, please input your number: ");
                   string numerToInvertInut = Console.ReadLine();
                    myRobot.numberComberter(Int32.Parse(numerToInvertInut));
                    Console.WriteLine("Reloading...");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }

                if(userInput =="2")
                {

                    try
                    {
                    Console.WriteLine("Bigger number catcher sellected: ");
                    Console.WriteLine("Enter numbers separated by coma like so: 1,2,3,4, ");

                    string userInputNumbers = Console.ReadLine();
                    var parsedNumbersString = userInputNumbers.Split(",");
                    int[] parsedNumbers = new int[parsedNumbersString.Length];
                    int counter = 0;

                    foreach (var stristringedNumber in parsedNumbersString)
                    {
                        parsedNumbers[counter] = Int32.Parse(stristringedNumber);
                        counter++;

                    }

                    myRobot.selectTheBigestNumber(parsedNumbers);



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);

                    }
                }

                if(userInput == "3")
                {

                    try
                    {

                    Console.WriteLine("Coin exchanger selected ");
                    Console.WriteLine("Please enter the amount of money to exchange: ");

                    string stringedCoins = Console.ReadLine();
                    int coins = Int32.Parse(stringedCoins);

                    myWalet.exchange(coins);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);  

                    }


                }

                if(userInput == "4")
                {
                    try
                    {
                        Console.WriteLine("Type checker ");
                        Console.WriteLine("input one carcter");
                        char[] charToAnalize =  Console.ReadLine().ToCharArray();

                        myRobot.typeSearcher(charToAnalize[0]);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                if(userInput == "5")
                {
                    try
                    {
                        Console.WriteLine("String dstructuring sellected");
                        Console.WriteLine("Please enter an string to destructure: ");
                        string chainForDestructuring =  Console.ReadLine();
                        myRobot.chainDestructuring(chainForDestructuring);
                    }
                    catch (Exception ex)
                    {

                    }
                }


            }


        }
    }
}

