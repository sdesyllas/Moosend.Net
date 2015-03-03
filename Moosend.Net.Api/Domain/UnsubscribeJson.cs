using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moosend.Net.Api.Domain
{
    public class UnsubscribeJson : BasicSubscriberJson
    {
        public string CampaignID { get; set; }
    }
}
