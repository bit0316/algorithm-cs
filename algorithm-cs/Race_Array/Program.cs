using System;
using System.Threading;

namespace Race_Array
{
    internal class Program
    {
        const int ARRAY_X = 7; // 선수 5명 + 외벽 2줄
        const int ARRAY_Y = 50; // 거리 50칸
        const int DELAY = 100; // 갱신 시간 0.1초
        const int MIN_SPEED = 1; // 최소 속도
        const int MAX_SPEED = 3; // 최대 속도
        static char[,] array = new char[ARRAY_X, ARRAY_Y + MAX_SPEED];
        static char[] tile = new char[ARRAY_X] { ' ', 'A', 'B', 'C', 'D', 'E', '|' };
        static int round = 0;
        static int rank = 1;
        static int[] ranking = new int[ARRAY_X];

        static bool Question()
        {
            Console.Write("{0}번째 경기를 시작하시겠습니까? (Y/N) : ", round);

            while (true)
            {
                string check = Console.ReadLine();

                if (check == "Y" || check == "y")
                    return true;
                else if (check == "N" || check == "n")
                    return false;
                else
                    Console.Write("다시 입력하세요! (Y/N) : ");
            }
        }

        static void StageReset()
        {
            for (int i = 0; i < ARRAY_X; i++)
            {
                rank = 1; // 순위 초기화
                for (int j = 0; j < ARRAY_Y + 2; j++)
                {
                    if (i == 0 || i == ARRAY_X - 1) // 외벽 2줄
                        array[i, j] = '-';

                    else if (j == ARRAY_Y - 1) // 결승선
                        array[i, j] = tile[6];

                    else if (j == 0) // 선수 출발선 대기
                        array[i, j] = tile[i];

                    else // 빈공간
                        array[i, j] = tile[0];
                }
            }
        }

        static void RaceReady()
        {
            Thread.Sleep(1000);
            for (int time = 3; time > 0; time--)
            {
                Console.Write("{0}... ", time);
                Thread.Sleep(1000);
            }
        }

        static void RaceStart()
        {
            Random rnd = new Random();

            for (int i = 1; i < ARRAY_X - 1; i++)
            {
                int run = rnd.Next(MIN_SPEED, MAX_SPEED); // 선수마다 달린 거리 갱신
                for (int j = 0; j < ARRAY_Y + MAX_SPEED; j++)
                {
                    // 결승선을 지나지 않은 선수
                    if (array[i, j] == tile[i] && array[i, ARRAY_Y] != tile[i])
                    {
                        if (j < ARRAY_Y - 1)
                        {
                            array[i, j] = tile[0]; // 이전 위치 삭제
                            array[i, j + run] = tile[i]; // 현재 위치 갱신
                        }

                        if (j + run >= ARRAY_Y - 1)
                        {
                            array[i, j + run] = tile[0]; // 현재 위치 삭제
                            array[i, ARRAY_Y - 1] = tile[i]; // 결승선 위로 이동
                        }
                        break;
                    }
                }

            }
        }

        static void RankingChecker()
        {
            int count = 0; // 결승에 도착한 선수

            for (int i = 1; i < ARRAY_X - 1; i++)
            {
                if (array[i, ARRAY_Y - 1] == tile[i])
                {
                    count++;
                    ranking[i] = rank;
                    Console.WriteLine("{0}위 : {1}", ranking[i], tile[i]);

                    // 순위 갱신 후 선수 1칸 전진
                    array[i, ARRAY_Y - 1] = tile[6];
                    array[i, ARRAY_Y] = tile[i];
                }
            }

            rank += count;
        }

        static void PrintRace()
        {
            Thread.Sleep(DELAY);
            Console.Clear();
            Console.WriteLine("\t<{0}번째 경기>", round);

            // 경기장 + 선수 위치 출력
            for (int i = 0; i < ARRAY_X; i++)
            {
                for (int j = 0; j < ARRAY_Y + MAX_SPEED; j++)
                    Console.Write(array[i, j]);
                Console.WriteLine();
            }

            // 순위 출력
            for (int i = 1; i < ARRAY_X - 1; i++)
                for (int j = 1; j < ARRAY_X - 1; j++)
                    if (i == ranking[j] && array[j, ARRAY_Y] == tile[j])
                        Console.WriteLine("{0}위 : {1}", ranking[j], tile[j]);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                round++; // 진행한 경기 횟수 측정
                if (!Question()) // 경기 시작 질문
                    return;

                StageReset();
                PrintRace();
                RaceReady();

                while (rank < ARRAY_X - 1)
                {
                    RaceStart();
                    PrintRace();
                    RankingChecker();
                }
                PrintRace();
                Console.WriteLine();
            }
        }
    }
}
