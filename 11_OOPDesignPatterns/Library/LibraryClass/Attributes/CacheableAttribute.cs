using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Attributes
{
    public enum Measure
    {
        Minutes, Seconds, Hours, Infinity
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CacheableAttribute : Attribute
    {
        public TimeSpan TimeSpan { get; set; }
        public long TimeoutSeconds { get; set; }

        public Measure Measure { get; set; }

        public CacheableAttribute(TimeSpan timeSpan)
        {
            this.TimeSpan = timeSpan;
        }

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
