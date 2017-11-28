# ASP.NET Core 2.0 Auth System Demystified

This is the source code for the excellent article by David McCullough.  
The original article is here: [ASP.NET Core 2.0 Auth System Demystified](https://digitalmccullough.com/posts/aspnetcore-auth-system-demystified.html).  

I've modified the source code to run on .NET Framework 4.6.2.  
Removed the all-in-one dependency Microsoft.AspNetCore.All, which doesn't support .NET 4.6.2.  
Added the required Nuget packages one-by-one, enabled console logging and using Kestrel host.  

The code uses the following Nuget packages:

* Microsoft.AspNetCore.Authentication.Cookies
* Microsoft.AspNetCore.Diagnostics
* Microsoft.AspNetCore.Hosting
* Microsoft.AspNetCore.Mvc
* Microsoft.AspNetCore.Server.Kestrel
* Microsoft.AspNetCore.Server.Kestrel.Https
* Microsoft.AspNetCore.StaticFiles
* Microsoft.Extensions.Logging.Console
* Microsoft.VisualStudio.Web.BrowserLink

## Authentication and Authorization Flow

![Auth Flow Illustration](https://cdn.rawgit.com/yallie/CoreAuthDemystified/master/aspnetcore-auth-system-demystified_auth-flow.svg)

The local copy of the article is here: [ASP.NET Core 2.0 Auth System Demystified](https://github.com/yallie/CoreAuthDemystified/wiki/ASP.NET-Core-2.0-Authentication-and-Authorization-System-Demystified).