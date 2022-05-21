namespace LibraryClass.Attributes
{
    public enum Measure
    {
        Minutes, Seconds, Hours, Infinity
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CacheableAttribute : Attribute
    {
        public long TimeoutSeconds { get; set; }

        public Measure Measure { get; set; }

        public CacheableAttribute(long timeout, Measure measure)
        {
            Measure = measure;
            switch (measure)
            {
                case Measure.Hours:
                    TimeoutSeconds = timeout * 3600;
                    break;

                case Measure.Minutes:
                    TimeoutSeconds = timeout * 60;
                    break;

                case Measure.Seconds:
                    TimeoutSeconds = timeout;
                    break;

                case Measure.Infinity:
                    TimeoutSeconds = timeout;
                    break;
            }
        }
    }
}
