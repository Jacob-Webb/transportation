using System;

namespace TransportationAPI.DTOs
{
    /// <summary>
    /// Represents the time of day using a 24-hour period.
    /// </summary>
    public class TimeSpanDto
    {
        private int _hours;
        private int _minutes;

        public TimeSpanDto(int hours = 0, int minutes = 0)
        {
            _hours = hours;
            _minutes = minutes;
        }

        /// <summary>
        /// Gets or sets the hour value of the time of day. Values should range from 0 - 23.
        /// </summary>
        public int Hours
        {
            get { return _hours; }
            set { _hours = CheckArgumentRange(nameof(value), value, 0, 23); }
        }

        /// <summary>
        /// Gets or sets the minutes value of the time of day. Values should range from 0 - 59.
        /// </summary>
        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = CheckArgumentRange(nameof(value), value, 0, 59); }
        }

        /// <summary>
        /// Ensures that range of arguments must be within a given range.
        /// </summary>
        /// <param name="paramName">The name of the parameter for which we are checking the values.</param>
        /// <param name="value">The numerical value to check between ranges.</param>
        /// <param name="minInclusive">The minimum value (inclusive) for the range.</param>
        /// <param name="maxInclusive">The maximum value (inclusive) for the range.</param>
        /// <returns>The value of <paramref name="value"/>.</returns>
        internal static int CheckArgumentRange(
        string paramName, int value, int minInclusive, int maxInclusive)
        {
            if (value < minInclusive || value > maxInclusive)
            {
                throw new ArgumentOutOfRangeException(
                    paramName,
                    value,
                    $"Value should be in range [{minInclusive}-{maxInclusive}]");
            }

            return value;
        }
    }
}
