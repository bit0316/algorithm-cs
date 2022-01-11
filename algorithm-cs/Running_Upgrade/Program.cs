using System;
using System.Threading;

namespace Running_Upgrade
{

    internal class Program
    {
        const string LINE = "-------------------------------";
        const int LENGTH = 30;
        static bool goal = false;
        static int[] run = new int[4] { 0, 0, 0, 0 };

        static void ClearScreen()
        {
            Thread.Sleep(100);
            Console.Clear();
        }

        static void Process(ref Random rand)
        {
            for (int i = 0; i < 4; i++)
            {
                run[i] += rand.Next(1, 3);  // 0.1초 달린 거리
                for (int j = 0; j < run[i]; j++) // 달린 거리
                    Console.Write(" ");
                Console.Write(i + 1);  // 선수 위치
                for (int k = LENGTH - run[i] - 1; k > 0; k--)  // 남은 거리
                    Console.Write(" ");
                Console.WriteLine("|");  // 결승선

                if (run[i] >= LENGTH)  // 도착 검사
                    goal = true;
            }

        }

        static void UpdateScreen()
        {
            for (int i = 0; i < 4; i++)
                if (run[i] >= LENGTH)
                    Console.WriteLine("Winner : " + (i + 1));
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            while (!goal)
            {
                ClearScreen();

                Console.WriteLine(LINE);
                Process(ref rand);
                Console.WriteLine(LINE);
            }
            UpdateScreen();
        }
    }

}   
