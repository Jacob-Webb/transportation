using System;
using NUnit.Framework;
using TransportationAPI.DTOs;
using TransportationAPI.Types;

namespace TransportationAPITests
{
    [TestFixture]
    public class EventTemplateDtoTests
    {
        private EventTemplateDto _eventTemplateDto;
        [SetUp]
        public void Setup()
        {
    
        }

        [Test]
        public void Hour_AssignedNegativeValue_ThrowsArgumentOutOfRangeException()
        {
            //Assert.Throws<ArgumentOutOfRangeException>(() => _timeOfDay.Hour = -1);
        }



    }
}
