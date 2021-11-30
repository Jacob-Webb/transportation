using System;
using NUnit.Framework;
using TransportationAPI.Types;

namespace TransportationAPITests
{
    [TestFixture]
    public class TimeOfDayTests
    {
        public TimeOfDay _timeOfDay;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Hour_AssignedNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeOfDay.Hour = -1);
        }

        [Test]
        public void Hour_AssignedValueGreaterThan23_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeOfDay.Hour = 24);
        }

        [Test]
        public void Hour_AssignedValueIsValid_ReturnsHourValue()
        {
            _timeOfDay.Hour = 1;
            Assert.AreEqual(1, _timeOfDay.Hour);
        }

        [Test]
        public void Minutes_AssignedNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeOfDay.Minutes = -1);
        }

        [Test]
        public void Minutes_AssignedValueGreaterThan59_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeOfDay.Minutes = 60);
        }

        [Test]
        public void Minutes_AssignedValueIsValid_ReturnsMinutesValue()
        {
            _timeOfDay.Minutes = 1;
            Assert.AreEqual(1, _timeOfDay.Minutes);
        }

    }
}
