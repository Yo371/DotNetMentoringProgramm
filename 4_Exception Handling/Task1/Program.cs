using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                PrintFirstLetter(Console.ReadLine());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void PrintFirstLetter(string line)
        {
            Console.WriteLine(line[0]);
        }
    }
}