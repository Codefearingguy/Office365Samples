<h2>Sample Console application comparing AAD Graph API vs MS Graph API<h2>

This sample console application uses ADAL v3 package and provides code sample to read all AD users and get current logged in user details for below scenarios:

<ul>
<h4>AAD Graph Api</h4>
<li>Get all AD users using application mode or context (No user involved here). This is for scenarios where you need to run background job or process.</li>
<li>Get user details using user mode or context (User have to login and provide consent here). </li>
</ul>

<ul>
<h4>MS Graph Api</h4>
<li>Get all AD users using application mode or context (No user involved here). This is for scenarios where you need to run background job or process.</li>
<li>Get user details using user mode or context (User have to login and provide consent here). </li>
</ul>

In all the above scenarios authentication is done using ADAL v3 library.

