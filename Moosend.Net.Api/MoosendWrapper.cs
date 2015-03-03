using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Moosend.Net.Api.Config;
using Moosend.Net.Api;

namespace Moosend.Net.Api
{
    public class MoosendWrapper : IDisposable
    {
        private HttpClient _moosendClient = null;

        public HttpClient MoosendClient
        {
            get
            {
                if (_moosendClient == null)
                {
                    _moosendClient = new HttpClient();
                    _moosendClient.BaseAddress =
                        new Uri(String.Format("{0}", MoosendConfig.MoosendSettings.BaseUrl));
                    _moosendClient.DefaultRequestHeaders.Accept.Clear();
                    _moosendClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _moosendClient;
            }
        }

        
        public void Dispose()
        {
            if (_moosendClient != null)
            {
                _moosendClient.Dispose();
            }
        }
    }
}
