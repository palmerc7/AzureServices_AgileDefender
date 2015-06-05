using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace Neudesic.AgileDefender.ServiceTests
{
    [TestClass]
    public class UserServiceTests
    {
        private string baseUrl = "https://agiledefenderservices.azure-mobile.net/api";
        private HttpClient client = new HttpClient();

        [TestMethod]
        public void UserServiceCanValidate()
        {
            Console.WriteLine("Start");

            var task = new Task(() =>
            {
                var result = ValidateUserService().Wait(1000);
                Assert.AreNotEqual(string.Empty, result);
                Console.WriteLine(result);
            });

            Console.WriteLine("End");
        }

        private async Task<string> ValidateUserService()
        {
            try
            {
                var url = string.Format("{0}/v1/user/validate", baseUrl);
                var result = await client.GetStringAsync(url);
                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

    }
}
