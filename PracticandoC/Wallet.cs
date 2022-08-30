using System;
namespace PracticandoC
{
	public class Wallet 
	{
		int hundred = 0;


		private int[] bills = new int[4];

		public int getBills
		{
			get;
			set;
		}

		Dictionary<int, string> MiDict = new Dictionary<int, string>()
		{
			{1, "uno" },
			{2,"dos" }
		};

		public Wallet()
		{
			bills[0] = 50;
            bills[1] = 20;
            bills[2] = 10;
            bills[3] = 5;



        }

        public void exchange(int cash)
		{
			int cashCopy = cash;
			int result;

			if(cashCopy >= 100)
			{
				hundred = cashCopy /100;
				
				result = cashCopy %= 100;
                Console.WriteLine($"100:  {hundred}");


                foreach (int bill in bills)
				{
                    if (result >= bill)
					{
						int amount = result / bill;
						result %= bill;
						Console.WriteLine($"{bill}:  {amount}");


					}



                }

				}


			}
		}

	
	
}

