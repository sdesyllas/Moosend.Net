using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Moosend.Net.Api.Domain
{
    public class AddSubscriberJson : BasicSubscriberJson
    {
        public string Name { get; set; }
        public List<string> CustomFields { get; set; }
    }
}
