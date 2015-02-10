ServiceNOW
==========

This is a C# wrapper for some of the functions available through the ServiceNOW wsdl interfaces.

You will need to copy the system.ServiceModel section of the app.config into either your web.config for a website or app.config for an application.

Add the following code to your app/web.config files immediately before your endpoint declarations.

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name="ServiceNowSoap">
          <security mode="Transport">
            <transport clientCredentialType="Basic" proxyCredentialType="Basic"
                realm="">
              <extendedProtectionPolicy policyEnforcement="Never" />
            </transport>
            <message clientCredentialType="UserName" algorithmSuite="Default" />
          </security>
        </binding>
        <binding name="ServiceNowSoap1" />
      </basicHttpBinding>
    </bindings>
```
Please see the Demo app's app.config for example usage.

https://github.com/jeffpatton1971/mod-ServiceNOW/blob/master/Demo/App.config
