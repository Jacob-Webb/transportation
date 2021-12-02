using System;
using NUnit.Framework;
using TransportationAPI.DTOs;

namespace TransportationAPITests
{
    [TestFixture]
    public class TimeSpanDtoTests
    {
        private TimeSpanDto _timeSpanDto;
        [SetUp]
        public void Setup()
        {
            _timeSpanDto = new TimeSpanDto();
        }

        [Test]
        public void Hour_AssignedNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeSpanDto.Hour = -1);
        }

        [Test]
        public void Hour_AssignedValueGreaterThan23_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeSpanDto.Hour = 24);
        }

        [Test]
        public void Hour_AssignedValueIsValid_ReturnsHourValue()
        {
            _timeSpanDto.Hour = 1;
            Assert.AreEqual(1, _timeSpanDto.Hour);
        }

        [Test]
        public void Minutes_AssignedNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeSpanDto.Minutes = -1);
        }

        [Test]
        public void Minutes_AssignedValueGreaterThan59_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _timeSpanDto.Minutes = 60);
        }

        [Test]
        public void Minutes_AssignedValueIsValid_ReturnsMinutesValue()
        {
            _timeSpanDto.Minutes = 1;
            Assert.AreEqual(1, _timeSpanDto.Minutes);
        }

    }
}
