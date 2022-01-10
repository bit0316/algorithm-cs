using System;
using System.Threading;

namespace Running
{

    internal class Program
    {
        static void Main(string[] args)
        {
            const string LINE = "--------------------------------";
            const int LENGTH = 30;
            bool goal = false;
            Random random = new Random();
            int[] run = new int[4] { 0, 0, 0, 0 };

            while (!goal)
            {
                Thread.Sleep(100);
                Console.Clear();

                Console.WriteLine(LINE);
                for (int i = 0; i < 4; i++)
                {
                    run[i] += random.Next(1, 3);  // 0.1초 달린 거리
                    for (int j = 0; j < run[i]; j++) // 달린 거리
                        Console.Write(" ");
                    Console.Write(i + 1);  // 선수 위치
                    for (int k = LENGTH - run[i]; k > 0; k--)  // 남은 거리
                        Console.Write(" ");
                    Console.WriteLine("|");  // 결승선

                    if (run[i] >= LENGTH)  // 도착 검사
                        goal = true;
                }
                Console.WriteLine(LINE);
            }

            for (int i = 0; i < 4; i++)
                if (run[i] >= LENGTH)
                    Console.WriteLine("Winner : " + (i + 1));
        }
    }

}
