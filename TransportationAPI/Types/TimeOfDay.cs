using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Types
{
    /// <summary>
    /// Represents the time of day using a 24-hour period.
    /// </summary>
    public struct TimeOfDay
    {
        private int? _hour;
        private int? _minutes;

        /// <summary>
        /// Represents the hour value of the time of day. Values should range from 0 - 23.
        /// </summary>
        public int? Hour
        {
            get { return _hour; }
            set { _hour = CheckArgumentRange(nameof(value), value, 0, 23); }
        }
        /// <summary>
        /// Represents the minutes value of the time of day. Values should range from 0 - 59.
        /// </summary>
        public int? Minutes
        {
            get { return _minutes; }
            set { _minutes = CheckArgumentRange(nameof(value), value, 0, 59); }
        }

        internal static int? CheckArgumentRange(
        string paramName, int? value, int minInclusive, int maxInclusive)
        {
            if (value < minInclusive || value > maxInclusive)
            {
                throw new ArgumentOutOfRangeException(paramName, value,
                    $"Value should be in range [{minInclusive}-{maxInclusive}]");
            }
            return value;
        }
    }
}
