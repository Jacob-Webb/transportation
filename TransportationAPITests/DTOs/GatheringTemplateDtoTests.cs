using System;
using NUnit.Framework;
using TransportationAPI.DTOs;

namespace TransportationAPITests
{
    [TestFixture]
    public class GatheringTemplateDtoTests
    {
        private GatheringTemplateDto _GatheringTemplateDto;
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
