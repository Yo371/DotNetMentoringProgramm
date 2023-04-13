// See https://aka.ms/new-console-template for more information

using ConcatenationLibrary;
using ConsoleApp1;

Console.WriteLine($"Hello, {args[0]}!");

Console.WriteLine(ConcatenationLogic.GetGreetingLineWithDate(args[0]));


int number = 4;


int result = 1;

for (int i = 1; i <= number; i++)
{
    result *= i;
}


Console.WriteLine(result);


Console.WriteLine(Tasks.Fact(4));



//bubble sort
int[] array = new[] { 1, 5, 6, 2, 7, 9, 5, 1, 0 };

for (int i = 0; i < array.Length; i++)
{
    for (int j = i; j < array.Length - 1; j++)
    {
        if (array[i] > array[j + 1])
        {
            var tmp = array[i];
            array[i] = array[j + 1];
            array[j + 1] = tmp;
        }
    }
}


//factorial
int prev = 1;
int next = 1;
int current = 0;

Console.WriteLine("\n+++ " + prev + " " + next + " ");

for (int i = 0; i < 10; i++)
{
    current = prev + next;
    Console.Write(current + " ");

    prev = next;
    next = current;
}


Console.WriteLine();

int result2 = Tasks.Fibonacci(10);


Console.WriteLine(result2);

Tasks.FibonacciWrite(10);


/*var testString = "the quick brown fox jumps over the lazy dog and the brown fox runs away";

var countWordsDictionary = Tasks.GetCountWordsDictionary(testString, "the", "a", "and", "or", "but");

foreach (var keyValuePair in countWordsDictionary)
{
    Console.WriteLine(keyValuePair.Key + ": " + keyValuePair.Value);
}*/


var inputString = Console.ReadLine();
var wordsToExclude = Console.ReadLine()?.Split(" ");


var countWordsDictionary = Tasks.GetCountWordsDictionary(inputString, wordsToExclude);

foreach (var keyValuePair in countWordsDictionary)
{
    Console.WriteLine(keyValuePair.Key + ": " + keyValuePair.Value);
}


