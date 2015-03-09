using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Moosend.Net.Api.Config;
using Moosend.Net.Api.Domain;
using Moosend.Net.Api.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Moosend.Net.Api
{
    public class SubscribersWrapper : MoosendWrapper, ISubscribersWrapper
    {
        private readonly ILog _log = LogManager.GetLogger("Moosend.Net.Api.SubscribersWrapper");

        public dynamic GetSubscriberByEmail(string email, string mailingListId)
        {
            //GET : http://api.moosend.com/v2/subscribers/{MailingListID}/view.{xml|json}
            string webMethodUrl = String.Format("{0}/{1}/{2}/view.json?apikey={3}&Email={4}",
                MoosendConfig.MoosendSettings.ApiVersion,
                MoosendConfig.MoosendSettings.SubscribersRetaliveUri, mailingListId,
                MoosendConfig.MoosendSettings.ApiKey, email);
            using (base.MoosendClient)
            {
                HttpResponseMessage response = MoosendClient.GetAsync(webMethodUrl).Result;
                _log.DebugFormat("Moosend Api call : {0}", response.RequestMessage);
                _log.DebugFormat("Response : {0}", response.StatusCode);
                dynamic subscriber = response.Content.ReadAsAsync<dynamic>().Result;
                _log.DebugFormat("Code:{0}, Error:{1}", subscriber.Code, subscriber.Error);
                return subscriber;
            }
        }

        public dynamic AddSubscriber(string email, string mailingListId = "", string name = "", JObject customFields = null)
        {
            try
            {
                //POST : http://api.moosend.com/v2/subscribers/{MailingListID}/subscribe.{xml|json}
                string webMethodUrl = String.Format("{0}/{1}/{2}/subscribe.json?apikey={3}",
                MoosendConfig.MoosendSettings.ApiVersion,
                MoosendConfig.MoosendSettings.SubscribersRetaliveUri, mailingListId,
                MoosendConfig.MoosendSettings.ApiKey);
                using (base.MoosendClient)
                {
                    //create json to post
                    AddSubscriberJson json = new AddSubscriberJson();
                    json.MailingListID = mailingListId;
                    json.Name = name;
                    json.Email = email;
                    // this work around is needed because moosend needs customfields as a simple string array like
                    // ["IsCustomer=yes","Country=USA"] and not 
                    // [{"IsCustomer" : "yes"}, {"Country"="USA"}]
                    if (customFields != null)
                    {
                        json.CustomFields = JsonHelper.CustomFieldsToJavascriptArray(customFields);
                    }
                    else
                    {
                        json.CustomFields = new List<string>();
                    }
                    HttpResponseMessage response = MoosendClient.PostAsJsonAsync(webMethodUrl, json).Result;
                    _log.DebugFormat("Moosend Api call : {0}", response.RequestMessage);
                    _log.DebugFormat("Response : {0}", response.StatusCode);
                    dynamic subscriber = response.Content.ReadAsAsync<dynamic>().Result;
                    _log.DebugFormat("Code:{0}, Error:{1}", subscriber.Code, subscriber.Error);
                    return subscriber;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        public dynamic Unsubscribe(string email, string mailingListId = "", string campaignId = "")
        {
            try
            {
                //POST : http://api.moosend.com/v2/subscribers/{MailingListID}/{CampaignID}/unsubscribe.{xml|json}
                string webMethodUrl = String.Format("{0}/{1}/{2}/{3}/unsubscribe.json?apikey={4}",
                MoosendConfig.MoosendSettings.ApiVersion,
                MoosendConfig.MoosendSettings.SubscribersRetaliveUri, mailingListId, campaignId,
                MoosendConfig.MoosendSettings.ApiKey);
                using (base.MoosendClient)
                {
                    //create json to post
                    UnsubscribeJson json = new UnsubscribeJson();
                    json.MailingListID = mailingListId;
                    json.CampaignID = campaignId;
                    json.Email = email;

                    HttpResponseMessage response = MoosendClient.PostAsJsonAsync(webMethodUrl, json).Result;
                    _log.DebugFormat("Moosend Api call : {0}", response.RequestMessage);
                    _log.DebugFormat("Response : {0}", response.StatusCode);
                    dynamic subscriber = response.Content.ReadAsAsync<dynamic>().Result;
                    _log.DebugFormat("Code:{0}, Error:{1}", subscriber.Code, subscriber.Error);
                    return subscriber;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }

        public dynamic RemoveSubscriber(string email, string mailingListId = "")
        {
            try
            {
                //POST : http://api.moosend.com/v2/subscribers/{MailingListID}/remove.{xml|json}
                string webMethodUrl = String.Format("{0}/{1}/{2}/remove.json?apikey={3}",
                MoosendConfig.MoosendSettings.ApiVersion,
                MoosendConfig.MoosendSettings.SubscribersRetaliveUri, mailingListId,
                MoosendConfig.MoosendSettings.ApiKey);
                using (base.MoosendClient)
                {
                    //create json to post
                    UnsubscribeJson json = new UnsubscribeJson();
                    json.MailingListID = mailingListId;
                    json.Email = email;

                    HttpResponseMessage response = MoosendClient.PostAsJsonAsync(webMethodUrl, json).Result;
                    _log.DebugFormat("Moosend Api call : {0}", response.RequestMessage);
                    _log.DebugFormat("Response : {0}", response.StatusCode);
                    dynamic subscriber = response.Content.ReadAsAsync<dynamic>().Result;
                    _log.DebugFormat("Code:{0}, Error:{1}", subscriber.Code, subscriber.Error);
                    return subscriber;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }
    }
}
