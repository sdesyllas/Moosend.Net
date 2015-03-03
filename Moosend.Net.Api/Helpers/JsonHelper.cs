using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Moosend.Net.Api.Helpers
{
    public static class JsonHelper
    {
        public static List<string> CustomFieldsToJavascriptArray(JObject customFields)
        {
            /*
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (var property in customFields.Properties())
            {
                sb.AppendFormat("{{\"Name\" : \"{0}\", \"Value\":\"{1}\"}}", property.Name, property.Value);
                //sb.AppendFormat("\"{0} = {1}\"", property.Name, property.Value);
                if (count < property.Count)
                {
                    sb.AppendFormat(",");
                }
                count++;
            }
            
            return string.Format("[{0}]", sb.ToString());
             */
            
            List<string> resultObject = new List<string>();
            foreach (var property in customFields.Properties())
            {
                resultObject.Add(String.Format("{0} = {1}", property.Name, property.Value));
            }
            return resultObject;
            
            
        }
    }
}
