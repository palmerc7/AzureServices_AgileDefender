using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Neudesic.AgileDefender.ServiceTests
{
    [TestClass]
    public class UserServiceTests
    {
        private HttpClient client;
        private string baseUrl = "https://agiledefenderservices.azure-mobile.net/api";
        private string validateApiUrl;
        private string getUserApiUrl;
        private int numberOfThreads = 100;

        [TestInitialize]
        public void Setup()
        {
            validateApiUrl = string.Format("{0}/v1/user/validate", baseUrl);
            getUserApiUrl = string.Format("{0}/v1/user/getUserByEmail/?emailAddress={1}", baseUrl, "chris.palmer@neudesic.com");
            client = new HttpClient();

            InitiateUserServiceCanValidate();
            InitiateUserServiceCanGetUserByEmail();
        }

        private void InitiateUserServiceCanValidate()
        {
            Console.WriteLine("UserServiceCanValidate Started with " + numberOfThreads.ToString() + " threads");
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(UserServiceCanValidate);
                threads[i].Name = string.Format("UserServiceCanValidate Thread: {0}", i);
                Console.WriteLine("Starting thread (" + i.ToString() + ")");
                threads[i].Start();
            }

            while (ThreadsStillRunning(threads))
            {
            }

            Console.WriteLine("UserServiceCanValidate End");
        }

        private void InitiateUserServiceCanGetUserByEmail()
        {
            Console.WriteLine("UserServiceCanGetUserByEmail Started with " + numberOfThreads.ToString() + " threads");
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(UserServiceCanGetUserByEmail);
                threads[i].Name = string.Format("UserServiceCanGetUserByEmail Thread: {0}", i);
                Console.WriteLine("Starting thread (" + i.ToString() + ")");
                threads[i].Start();
            }

            while (ThreadsStillRunning(threads))
            {
            }

            Console.WriteLine("UserServiceCanGetUserByEmail End");
        }

        private bool ThreadsStillRunning(Thread[] threads)
        {
            var result = false;
            if (threads.Length != 0)
                for (int i = 0; i < threads.Length; i++)
                    if (threads[i].IsAlive)
                        result = true;

            return result;
        }

        [TestMethod]
        public void UserServiceCanValidate()
        {
            var task = Task.Run(async () =>
            {
                var result = await ValidateUserService();
                Assert.AreNotEqual(string.Empty, result);
                Assert.IsTrue(result.ToLower().Contains("success"));
            });

            task.Wait();
        }

        [TestMethod]
        public void UserServiceCanGetUserByEmail()
        {
            var task = Task.Run(async () =>
            {
                var result = await GetUserByEmailService();
                Assert.AreNotEqual(null, result);
                Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            });

            task.Wait();
        }

        private async Task<string> ValidateUserService()
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    result = await client.GetStringAsync(validateApiUrl);
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ValidateUserService ERROR: {0}"), ex.Message);
                return result;
            }
        }

        private async Task<HttpResponseMessage> GetUserByEmailService()
        {
            HttpResponseMessage result = null;
            try
            {
                using (var client = new HttpClient())
                {
                    result = await client.GetAsync(getUserApiUrl);
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("GetUserByEmailService ERROR: {0}"), ex.Message);
                return result;
            }
        }

    }
}
