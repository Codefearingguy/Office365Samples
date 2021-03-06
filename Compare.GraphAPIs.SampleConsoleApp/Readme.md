For a long time I have been a big lazy developer. I was quite happy in my world of on-premise computing and writing add-ins for my on-premise SharePoint unaware of what's happening in the cloud. Then suddenly we decided to migrate to Office 365 and reality struck me hard. The azure world is so different and moving so fast with lot of new cool features.

I decided to start by building an application using  Microsoft Graph API and very soon I got lost. Lots of code samples and blogs but many does not work because of upgrades done to nuget packages and Azure portal after they were written. Few which are written recently used MSAL but I wanted to try out ADAL first because MSAL is not yet production ready(as of 21-11-2016). Finally after digging through multiple blog posts and wasting my whole sunday (turns out it was my most productive sunday for quite long time :-) ) I finally managed to learn it !! Yay.. So I developed a code sample which compares Azure AD Graph API and Microsoft Graph API. The sample uses ADAL v3 for authentication.

<ul>Below are some key things which you will learn through the sample code and this post.

<li>How to register an application and assign application permission and delegated permissions.</li>
<li>How to authenticate to Azure using ADAL</li>
<li>How to generate access tokens for user context & application context</li>
<li>How to run your application in User context and in Application context</li>
<li>How to use Microsoft Graph API client and  request resources in user & application context.</li>
<li>How to use Azure AD Graph API client and  request resources in user & application context.</li>
</ul>
Okay now let's get started!!

<ul>Before you start, make sure have below things ready.

<li>You need an Office 365 tenant/ Azure AD tenant.</li>
<li>Visual Studio 2015</li>
</ul>
Register your App
For this code sample and for learning purpose we will register 2 apps, one which will run with Application permissions (Apponly mode) another which will run with Delegated or user permissions.

Sign in to Azure portal --> https://portal.azure.com/
Go to Azure Active Directory and then click on App registrations.
Click Add and register an App using below settings.
Name:AppOnlyModeDemo-GraphApi

Application Type: Web app/API

Sign-on URL:http://localhost:55065/ (Note: this is the url used in code sample. If you change it here make sure it is reflected in the code)

      4. Click on Create . If succesfful, you can see it in the list of registered apps.



5. Now if you click on the app and under GENERAL --> Reply URLs , you can see the Sign-on URL here.You can change this or add new urls anytime.

6. Now under API ACCESS --> Click on Keys. And enter any key description and set the expiration as you like. Then click on save. Attention! As soon as you click save the Value field will be autogenerated and this value will not be displayed again once you leave the panel. Copy this value as it is the ClientSecret and you will need to use it in code.



7. Now go to Required Permissions panel. You will see that Windows Azure Active Directory is already in the list with 1 delegated permission.

8. Click on it and select Read directory data under Application Permissions and now Save.

9. Now in the Permissions panel , click on Add and Select an API. Here you will see all the APIs available which can be used in our application. For this post we will use Microsoft Graph. So select on Microsoft Graph.Now in select permissions, select Read directory data under Application permissions and click done.Now your permissions tab should look like below.



Now let's register another App which will have delegated permissions and will work with user consent.

Click Add and register an App using below settings.


Name:UserModeDemo-GraphApi

Application Type: Native

Sign-on URL:http://localhost:55065/ (Note: this is the url used in code sample. If you                  change it here make sure it is reflected in the code)

2.  Now once it is created, click on the UserModeDemo-GraphApi app and configure the Required Permissions. Here since you have selected Native application type, you will only have Delegated Permissions option and Application permissions cannot be created here.For this sample, you only need Sign in and read user profile permission which is present by default.


Delegated Permissions
3. Here since you are running only on user mode, you do not need to configure any Keys like you did for Application mode app.

Now keys things to be copied to be used in the code.

ApplicationID of both the apps.
ClientSecret or the key value copied for the AppOnlyModeDemo app.
Sign-on url.
Let's Jump to the code !
