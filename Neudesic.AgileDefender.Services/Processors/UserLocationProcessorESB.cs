using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ServiceBus.Messaging;

using Neudesic.AgileDefender.Services.DataObjects;
using Microsoft.ApplicationInsights;
using Neudesic.AgileDefender.Services.Helpers;

namespace Neudesic.AgileDefender.Services.Processors
{
    public class UserLocationProcessorESB
    {
        private TelemetryClient telemetryClient;

        public UserLocationProcessorESB()
        {
            telemetryClient = new TelemetryClient();
        }

        public UserLocation CreateUserLocation(UserLocation userLocation)
        {
            telemetryClient.TrackEvent("UserLocationProcessor.CreateUserLocation");
            userLocation.IsSuccess = false;
            userLocation.ErrorMessage = string.Empty;
            try
            {
                // Setup a message factory with a connection string
                MessagingFactory factory = MessagingFactory.CreateFromConnectionString(AzureEsbStrings.ConnectionString);

                // Setup a sender for the appropriate queue
                MessageSender sender = factory.CreateMessageSender(AzureEsbStrings.UserLocationQueue);

                // Author the message with appropriate properties
                var message = new BrokeredMessage
                {
                    MessageId = Guid.NewGuid().ToString(),
                    Properties =
                    {
                        {"UserId", userLocation.UserId},
                        {"Latitude", userLocation.Latitude},
                        {"Longitude", userLocation.Longitude},
                        {"CreateDateTime", DateTime.Now}
                    }
                };

                // Send message to queue via async
                sender.SendAsync(message);
            }
            catch
            {
                throw;
            }

            return userLocation;
        }
    }
}