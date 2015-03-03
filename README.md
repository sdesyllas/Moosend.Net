# Moosend.Net
.Net API wrapper for Moosend mailing service

# config file
```
<configSections>
    <sectionGroup name="mooSendConfigurationGroup">
      <section
        name="mooSendBasicConfiguration"
        type="Moosend.Net.Api.Config.MoosendConfig, Moosend.Net.Api.Config"
        allowLocation="true"
        allowDefinition="Everywhere"
      />
    </sectionGroup>
</configSections>

<!-- Configuration section settings area. -->
<mooSendConfigurationGroup>
  <mooSendBasicConfiguration 
    baseUrl="http://api.moosend.com/" 
    apiVersion="v2" 
    apiKey="xxxxxxxxxxxxxxxxxxxxxxxxxxxx" 
    subscribersRetaliveUri="subscribers" />
</mooSendConfigurationGroup>
```

# api call in code
```
JObject customFields = new JObject();
customFields["IsCustomer"] = true;
customFields["Country"] = "Greece";
using (ISubscribersWrapper subscribersWrapper = new SubscribersWrapper())
{
    Task<dynamic> subscriber = subscribersWrapper.AddSubscriber(email, mailistListId, name, customFields);
    var responseEmail = subscriber.Result.Context.Email.ToString();
    var responseCode = subscriber.Result.Code.ToString();
    //if response code is 0 everything is OK!
}
```

