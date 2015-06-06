using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Neudesic.AgileDefender.Services.Processors;
using Neudesic.AgileDefender.Services.DataObjects;

namespace Neudesic.AgileDefender.ServiceTests
{
    [TestClass]
    public class AzureESBQueueTests
    {
        [TestMethod]
        public void CanPublishToUserLocationQueue()
        {
            UserLocationProcessorESB processor = new UserLocationProcessorESB();
            processor.CreateUserLocation(new UserLocation { Latitude = 1.0, Longitude = 2.0, UserId = Guid.NewGuid() });
        }
    }
}
