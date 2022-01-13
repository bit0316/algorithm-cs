using System;

namespace Plus_Numbers
{
    internal class Program
    {

        static int InputNumber(int count)
        {
            return int.Parse(Console.ReadLine());
        }

        static void PrintResult(int a, int b)
        {
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        }

        static bool CheckEnd()
        {
            while (true)
            {
            int key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 0:
                        return false;
                    case 1:
                        Console.WriteLine();
                        return true;
                    default:
                        Console.Write("0이나 1을 입력해주세요 ");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            const int INDEX = 10;
            int[] numA = new int[INDEX];
            int[] numB = new int[INDEX];

            for (int i = 0; i < INDEX; i++)
            {
                Console.Write("첫번째 수를 입력 해 주세요? ");
                numA[i] = InputNumber(i);

                Console.Write("두번째 수를 입력 해 주세요? ");
                numB[i] = InputNumber(i);

                PrintResult(numA[i], numB[i]);
                Console.WriteLine();

                Console.Write("추가로 계산할까요(1: OK, 0: NO, 단 총 10번까지 가능) ");
                if (!CheckEnd())
                {
                    for (int j = 0; j <= i; j++)
                        PrintResult(numA[j], numB[j]);
                    return;
                }
            }

            Console.WriteLine();
        }
    }

}
