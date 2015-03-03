using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moosend.Net.Api.Config
{
    public class MoosendConfig : ConfigurationSection
    {
        /// <summary>
        /// This static property return the Settings class object from loading the configuration
        /// </summary>
        public static MoosendConfig MoosendSettings
        {
            get
            {
                return
                    (MoosendConfig)
                        ConfigurationManager.GetSection("mooSendConfigurationGroup/mooSendBasicConfiguration");
            }
        }


        // Create a "baseUrl" attribute.
        [ConfigurationProperty("baseUrl", DefaultValue = "http://api.moosend.com/", IsRequired = true)]
        public string BaseUrl
        {
            get
            {
                return (string)this["baseUrl"];
            }
            set
            {
                this["baseUrl"] = value;
            }
        }

        // Create a "apiVersion" attribute.
        [ConfigurationProperty("apiVersion", DefaultValue = "v2", IsRequired = true)]
        public string ApiVersion
        {
            get
            {
                return (string)this["apiVersion"];
            }
            set
            {
                this["apiVersion"] = value;
            }
        }

        // Create a "apiKey" attribute.
        [ConfigurationProperty("apiKey", DefaultValue = "xxxxxx", IsRequired = true)]
        public string ApiKey
        {
            get
            {
                return (string)this["apiKey"];
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        // Create a "apiVersion" attribute.
        [ConfigurationProperty("subscribersRetaliveUri", DefaultValue = "subscribers", IsRequired = true)]
        public string SubscribersRetaliveUri
        {
            get
            {
                return (string)this["subscribersRetaliveUri"];
            }
            set
            {
                this["subscribersRetaliveUri"] = value;
            }
        }


    }
}
