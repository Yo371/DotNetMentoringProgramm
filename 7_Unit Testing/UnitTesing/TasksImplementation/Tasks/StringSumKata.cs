using System.Numerics;

namespace TasksImplementation.Tasks
{
    public class StringSumKata
    {
        public static string Sum(string str1, string str2)
        {
            /*str1 = string.IsNullOrEmpty(str1) ? "0" : str1;
            str2 = string.IsNullOrEmpty(str2) ? "0" : str2;*/

            return (GetNaturalNumberByString(str1) + GetNaturalNumberByString(str2)).ToString();
        }


        private static double GetNaturalNumberByString(string str)
        {
            if (double.TryParse(str, out var number))
            {
                return number > 0? number : 0;
            }
            return number;
        }
    }
}
