namespace ConsoleApp1;

public static class Tasks
{
    public static int Fact(int number)
    {
        if (number == 1)
        {
            return 1;
        }

        return number * Fact(number - 1);
    }


    public static int Fibonacci(int number)
    {
        if (number < 2)
        {
            return number;
        }

        return Fibonacci(number - 1) + Fibonacci(number - 2);
    }

    public static void FibonacciWrite(int number)
    {
        if (number < 2)
        {
            Console.Write(number + " ");
            return;
        }

        int res = (number - 1) + (number - 2);
        Console.Write(res + " ");

        FibonacciWrite(number - 1);
    }

    public static Dictionary<string, int> GetCountWordsDictionary(string line, params string[]? wordsToExclude)
    {
        if (!string.IsNullOrEmpty(line))
        {
            var listOfWords = line.Split(" ").ToList();

            if (wordsToExclude != null && wordsToExclude.Length > 0)
                listOfWords.RemoveAll(e => wordsToExclude.Contains(e));

            var resultDictionary = new Dictionary<string, int>();

            foreach (var word in listOfWords)
            {
                if (resultDictionary.ContainsKey(word))
                {
                    var currentCount = resultDictionary.GetValueOrDefault(word);
                    resultDictionary[word] = ++currentCount;
                }
                else
                {
                    resultDictionary.Add(word, 1);
                }
            }

            return resultDictionary.OrderByDescending(e => e.Value)
                .ToDictionary(z => z.Key, y => y.Value);
        }

        throw new ArgumentException("Input line can not be empty!");
    }
}

