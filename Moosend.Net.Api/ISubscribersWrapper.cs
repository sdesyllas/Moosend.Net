using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Moosend.Net.Api
{
    public interface ISubscribersWrapper : IDisposable
    {
        /// <summary>
        /// Searches for a subscriber with the specified email address in the specified mailing list and returns detailed information such as id, 
        /// name, date created, date unsubscribed, status and custom fields
        /// </summary>
        /// <param name="email">(REQUIRED) The email address of the member</param>
        /// <param name="mailingListId">(REQUIRED) The ID of the mailing list to add the new member</param>
        /// <returns></returns>
        Task<dynamic> GetSubscriberByEmail(string email, string mailingListId);


        /// <summary>
        /// Adds a new subscriber to the specified mailing list. If there is already a subscriber with the specified email address in the list, an update will be performed instead.
        /// </summary>
        /// <param name="email">(REQUIRED) The email address of the member</param>
        /// <param name="mailingListId">(OPTIONAL) The ID of the mailing list to add the new member</param>
        /// <param name="name">(OPTIONAL) The name of the member</param>
        /// <param name="customFields"> (OPTIONAL) A list of name-value pairs that match the member's custom fields defined in the mailing list.</param>
        /// <returns>true if response was ok</returns>
        Task<dynamic> AddSubscriber(string email, string mailingListId = "", string name = "", JObject customFields = null);

        /// <summary>
        /// Unsubscribes a subscriber from the specified mailing list and the specified campaign. The subscriber is not deleted, but moved to the supression list. 
        /// This call will take into account the setting you have in "Supression list and unsubscribe settings" and will remove the subscriber from all other mailing lists or not accordingly.
        /// </summary>
        /// <param name="email">(REQUIRED) The email address of the subscriber to be supressed.</param>
        /// <param name="mailingListId">(OPTIONAL) The ID of the mailing list to unsubscribe the subscriber from. If also omitted, the email address of the subscriber will be unsubscribed from all mailing lists.</param>
        /// <param name="campaignId">(OPTIONAL) The ID of the campaign from which the subscriber unsubscribed. It can be omitted if no such information is available.</param>
        /// <returns></returns>
        Task<dynamic> Unsubscribe(string email, string mailingListId = "", string campaignId = "");

        /// <summary>
        /// Removes a subscriber from the specified mailing list permanently (without moving to the supression list).
        /// </summary>
        /// <param name="email">(REQUIRED) The email address of the subscriber being searched.</param>
        /// <param name="mailingListId">(REQUIRED) The ID of the mailing list to search the subscriber in.</param>
        /// <returns></returns>
        Task<dynamic> RemoveSubscriber(string email, string mailingListId = "");
    }
}
