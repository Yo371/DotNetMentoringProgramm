using System;

namespace ConcatenationLibrary
{
    public class ConcatenationLogic
    {
        public static string GetGreetingLineWithDate(string name)
        {
            return $"Hello {name}! ({DateTime.Now.Date})";
        }
    }
}
