﻿using System;

namespace Exercise_6
{
    class Program
    {
        static double FirstNum = 1;
        static double SecondNum = 2;
        static double ThirdNum = 3;
        static double[] MasNums;
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 6:");
            Console.WriteLine("Построить N элементов последовательности  а_{к} = (а_{к–1} + 1) / (а_{к-2} + 2) * а_{к–3}.");
            while (true)
            {
                int count;

                Console.WriteLine("Введите a_{1}:");
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out FirstNum))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные. Повторите ввод:");
                    }
                }

                Console.WriteLine("Введите a_{2}:");
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out SecondNum))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные. Повторите ввод:");
                    }
                }

                Console.WriteLine("Введите a_{3}:");
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out ThirdNum))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные. Повторите ввод:");
                    }
                }

                Console.WriteLine("Введите N:");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out count) && count > 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные (N > 3). Повторите ввод:");
                    }
                }

                MasNums = new double[count];
                GetSequence(count);
                Console.WriteLine("Полученная последовательность:");
                foreach (double num in MasNums)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();

                bool IsIncreasing = true;
                bool IsNondecreasing = true;
                for (int i = 0; i < MasNums.Length - 1; i++)
                {
                    if (MasNums[i] <= MasNums[i + 1])
                    {
                        IsIncreasing = false;
                    }

                    if (MasNums[i] < MasNums[i + 1])
                    {
                        IsNondecreasing = false;
                    }
                }

                if (IsIncreasing)
                {
                    Console.WriteLine("Последовательность строго возрастающая.");
                }
                else if (IsNondecreasing)
                {
                    Console.WriteLine("Последовательность монотонно неубывающая.");
                }
                else if (!(IsIncreasing && IsNondecreasing))
                {
                    Console.WriteLine("Последовательность не является возрастающей и не является неубывающей.");
                }

                Console.ReadLine();
            }
        }

        static double GetSequence(int n)
        {
            double outNum;
            if (n == 1)
            {
                outNum = FirstNum;
            }
            else if (n == 2)
            {
                outNum = SecondNum;
            }
            else if (n == 3)
            {
                outNum = ThirdNum;
            }
            else
            {
                outNum = (GetSequence(n - 1) + 1) / (GetSequence(n - 2) + 2) * GetSequence(n - 3);
            }

            MasNums[n - 1] = outNum;
            return outNum;
        }
    }
}
