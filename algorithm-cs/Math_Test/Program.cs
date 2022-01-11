using System;

namespace Math_Test
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            const int COUNT = 5;
            int numA, numB, numSign, result = 0, score = 0;
            char[] sign = new char[5] {'+', '-', '*', '/', '%'};

            for(int i = 0; i < COUNT; i++)
            {
                numA = rand.Next(1, 10);
                numB = rand.Next(1, 10);
                numSign = rand.Next(0, 4);

                Console.Write(" {0} {1} {2} = ", numA, sign[numSign], numB);
                switch (numSign)
                {
                    case 0: result = numA + numB;   break;
                    case 1: result = numA - numB;   break;
                    case 2: result = numA * numB;   break;
                    case 3: result = numA / numB;   break;
                    case 4: result = numA % numB;   break;
                }
               
                if (result == int.Parse(Console.ReadLine()))
                {
                    Console.WriteLine(" Correct!! \n");
                    score++;
                }
                else
                    Console.WriteLine(" Wrong!! Answer is {0} \n", result);

            }

            Console.WriteLine(" < Score : {0} >", score);
        }
    }

}