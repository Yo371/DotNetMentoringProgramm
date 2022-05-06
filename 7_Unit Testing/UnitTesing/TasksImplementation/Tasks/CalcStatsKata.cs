namespace TasksImplementation.Tasks
{
    public class CalcStatsKata
    {
        public static double GetStats(List<int> numbers, TypeValue typeValue)
        {
            if (numbers == null) throw new ArgumentNullException();

            return typeValue switch
            {
                TypeValue.Minimum => numbers.Min(),
                TypeValue.Maximum => numbers.Max(),
                TypeValue.NumberOfElements => numbers.Count,
                TypeValue.Average => Math.Round(numbers.Average(), 3),
                _ => throw new ArgumentException()
            };
        }

        public enum TypeValue
        {
            Minimum = 1,
            Maximum,
            NumberOfElements,
            Average
        }
    }
}
