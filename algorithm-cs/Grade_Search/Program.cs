using System;

namespace Grade_Search
{
    internal class Program
    {

        const int STUDENTS = 3;
        static int[] ID = new int[STUDENTS];
        static int[] kor = new int[STUDENTS];
        static int[] math = new int[STUDENTS];
        static int[] eng = new int[STUDENTS];

        static void InputID(int[] ID, int index)
        {
            Console.Write("학생 ID를 입력하세요? ");
            ID[index] = int.Parse(Console.ReadLine());
        }

        static void InputKor(int[] kor, int index)
        {
            Console.Write("국어 점수를 입력하세요? ");
            kor[index] = int.Parse(Console.ReadLine());
        }

        static void InputMath(int[] math, int index)
        {
            Console.Write("수학 점수를 입력하세요? ");
            math[index] = int.Parse(Console.ReadLine());
        }

        static void InputEng(int[] eng, int index)
        {
            Console.Write("영어 점수를 입력하세요? ");
            eng[index] = int.Parse(Console.ReadLine());
        }

        static void PrintID(int max, int[] ID)
        {
            foreach(int i in ID)
                Console.WriteLine("학생 ID: " + i);
        }

        static void CheckID(int id, int max, int[] ID)
        {
            int i;

            for(i = 0; i < max; i++)
            {
                if (ID[i] == id)
                {
                    int total = kor[i] + math[i] + eng[i];
                    float average = total / 3;

                    Console.WriteLine("국어 점수: " + kor[i]);
                    Console.WriteLine("수학 점수: " + math[i]);
                    Console.WriteLine("영어 점수: " + eng[i]);
                    Console.WriteLine("총점: " + total);
                    Console.WriteLine("평균: " + average);
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("학생 아이디가 없어요. 다시 입력하세요.");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int search = 1;

            for (int i = 0; i < STUDENTS; i++)
            {
                InputID(ID, i);
                InputKor(kor, i);
                InputMath(math, i);
                InputEng(eng, i);
                Console.WriteLine();
            }
            
            while(search != 0)
            {
                Console.Write("학생 아이디를 입력하세요? (0)나가기 ");
                search = int.Parse(Console.ReadLine());

                if (search == 0)
                    return;

                CheckID(search, STUDENTS, ID);
                PrintID(STUDENTS, ID);
            }
        }
    }

}
