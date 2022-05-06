using System.Text;

namespace TasksImplementation.Tasks
{
    public class OddEvenKata
    {
        public static string GetPrintedNumbers(int from, int to)
        {
            if (from <= 0 || to <= 0 || from >= to)
                throw new ArgumentException("Value does not fall within the expected range.");

            return CheckOddEvenPrimeOfNumbersInRange(from, to);
        }

        private static string CheckOddEvenPrimeOfNumbersInRange(int from, int to)
        {
            var resultBuilder = new StringBuilder();

            for (int number = from; number <= to; number++)
            {
                var numString = GetStringOfNumberOddEvenPrime(number);
                resultBuilder.Append(numString + " ");
            }

            return resultBuilder.ToString().Trim();
        }

        private static string GetStringOfNumberOddEvenPrime(int number)
        {
            var result = string.Empty;
            if (IsPrime(number))
            {
                result = Convert.ToString(number);
            }
            
            else if (IsOdd(number))
            {
                result = "Odd";
            }
            else if (IsEven(number))
            {
                result = "Even";
            }
            return result;
        }

        private static bool IsEven(int number) => number >= 2 && number % 2 == 0;
        

        private static bool IsOdd(int number) => number % 2 != 0;
        

        private static bool IsPrime(int number)
        {
            if (number < 2 || IsEven(number)) return false;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
