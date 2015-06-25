using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neudesic.AgileDefender.ServiceTests
{
    [TestClass]
    public class FaceOffersTests
    {
        private string baseUrl = "https://api.faceoffers.com/api";
        private string authApiUrl;
        private string getUserApiUrl;

        [TestInitialize]
        public void Setup()
        {
            authApiUrl = string.Format("{0}/Apps/Authenticate", baseUrl);
            //getUserApiUrl = string.Format("{0}/Users/ByUsername/?username={1}", baseUrl, "palmerc7");
            getUserApiUrl = string.Format("{0}/Users/ByUsername/{1}", baseUrl, "palmerc7");
        }

        [TestMethod]
        public void CanPostToGetAuthToken()
        {
            var task = Task.Run(async () =>
            {
                var result = await GetAuthToken();
                Assert.AreNotEqual(string.Empty, result);
                //Assert.IsTrue(result.ToLower().Contains("success"));
            });

            task.Wait();
        }

        [Ignore]
        [TestMethod]
        public void CanGetUserByName()
        {
            var task = Task.Run(async () =>
            {
                var result = await GetUserService();
                Assert.AreNotEqual(string.Empty, result);
                //Assert.IsTrue(result.ToLower().Contains("success"));
            });

            task.Wait();
        }

        private async Task<string> GetAuthToken()
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    //HttpContent content = new StringContent("{ 'ApiKey': 'Mb7j6YSg84Bon2N9KtZe35Xms2P4Ryp8L3CrQi76Tfz9H5Wda5ADq6k7G2ExFw94' }");
                    
                    var postData = new List<KeyValuePair<string, string>>();
                    postData.Add(new KeyValuePair<string, string>("ApiKey", "Mb7j6YSg84Bon2N9KtZe35Xms2P4Ryp8L3CrQi76Tfz9H5Wda5ADq6k7G2ExFw94"));
                    HttpContent content = new FormUrlEncodedContent(postData);

                    //client.PostAsync(authApiUrl, content).ContinueWith(
                    //(postTask) =>
                    //{
                        //postTask.Result.EnsureSuccessStatusCode();
                    //});

                    string xmlString =
                        "<AppCredential xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                        "xmlns=\"http://schemas.datacontract.org/2004/07/FaceOffers.Api.Models\">" +
                        "<ApiKey>Mb7j6YSg84Bon2N9KtZe35Xms2P4Ryp8L3CrQi76Tfz9H5Wda5ADq6k7G2ExFw94</ApiKey>" +
                        "</AppCredential>";

                    var xmlContent = new StringContent(xmlString, Encoding.UTF8, "application/xml");

                    HttpResponseMessage response = await client.PostAsync(authApiUrl, xmlContent);
                    var rr = response;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ValidateUserService ERROR: {0}"), ex.Message);
                return result;
            }
        }

        private async Task<string> GetUserService()
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    result = await client.GetStringAsync(getUserApiUrl);
                    var rr = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ValidateUserService ERROR: {0}"), ex.Message);
                return result;
            }
        }

    }
}
