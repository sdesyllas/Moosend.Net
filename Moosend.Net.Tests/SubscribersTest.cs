using System;
using System.Threading.Tasks;
using Moosend.Net.Api;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Moosend.Net.Tests
{
    [TestFixture]
    public class SubscribersTest
    {
        [TestCase("test@tset.com", "6dc7684b-7a20-4fdd-8654-9e5dac00a5fc")]
        public void GetSubscriberByEmail(string email, string listId)
        {
            using (ISubscribersWrapper subscribersWrapper = new SubscribersWrapper())
            {
                Task<dynamic> subscriber = subscribersWrapper.GetSubscriberByEmail(email, listId);
                var responseEmail = subscriber.Result.Context.Email.ToString();
                var responseCode = subscriber.Result.Code.ToString();
                Assert.AreEqual("0", responseCode);
                Assert.AreEqual(email, responseEmail);
                Console.WriteLine(subscriber.Result);
            }
        }

        [TestCase("user1@moosend.com", "6dc7684b-7a20-4fdd-8654-9e5dac00a5fc", "Moosend test User 1")]
        public void AddSubscriber(string email, string mailistListId, string name)
        {
            JObject customFields = new JObject();
            customFields["IsCustomer"] = true;
            customFields["Country"] = "Greece";
            using (ISubscribersWrapper subscribersWrapper = new SubscribersWrapper())
            {
                Task<dynamic> subscriber = subscribersWrapper.AddSubscriber(email, mailistListId, name, customFields);
                var responseEmail = subscriber.Result.Context.Email.ToString();
                var responseCode = subscriber.Result.Code.ToString();
                Assert.AreEqual("0", responseCode);
                Assert.AreEqual(email, responseEmail);
                Console.WriteLine(subscriber.Result);
            }
        }

        [TestCase("user1@moosend.com", "6dc7684b-7a20-4fdd-8654-9e5dac00a5fc")]
        public void Unsubscribe(string email, string mailistListId)
        {
            using (ISubscribersWrapper subscribersWrapper = new SubscribersWrapper())
            {
                Task<dynamic> subscriber = subscribersWrapper.Unsubscribe(email, mailistListId);
                Assert.IsNotNull(subscriber);
                var responseCode = subscriber.Result.Code.ToString();
                Assert.AreEqual("0", responseCode);
                Console.WriteLine(subscriber.Result);
            }
        }

        [TestCase("user1@moosend.com", "6dc7684b-7a20-4fdd-8654-9e5dac00a5fc")]
        public void Remove(string email, string mailistListId)
        {
            using (ISubscribersWrapper subscribersWrapper = new SubscribersWrapper())
            {
                Task<dynamic> subscriber = subscribersWrapper.RemoveSubscriber(email, mailistListId);
                Assert.IsNotNull(subscriber);
                var responseCode = subscriber.Result.Code.ToString();
                Assert.AreEqual("0", responseCode);
                Console.WriteLine(subscriber.Result);
            }
        }
    }
}
