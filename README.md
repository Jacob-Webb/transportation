# Transportation API v1.0

## Steps for Local set up

* Download and install Visual Studio for mac

* Clone this respository (https://github.com/Jacob-Webb/transportation.git)

* Environment variables
  * Contact development team for access to environment variables listed in appsettings.json 
  * Utilize user secrets for Visual Studio on Mac (learn more from [this link](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=linux))
    * Enable secret storage
      - To use user secrets, run the following command in the project directory: `dotnet user-secrets init`
      - The preceding command adds a UserSecretsId element within a PropertyGroup of the project file. By default, the inner text of UserSecretsId is a GUID. The inner text is arbitrary, but is unique to the project.
    * Set a secret
      - Define an app secret consisting of a key and its value. The secret is associated with the project's UserSecretsId value. For example, run the following command from the directory in which the project file exists: `dotnet user-secrets set "Movies:ServiceApiKey" "12345"`

* [Set up mssql server on mac with azure data studio as a GUI](https://asifwaquar.com/connect-mssql-server-on-mac-with-azure-data-studio/)

* [Set up testing for Twilio Verify locally](https://www.twilio.com/blog/test-verify-no-rate-limits)

* Managing Nuget Packages
  * AutoMapper.Extensions.Microsoft.DependencyInjection - 8.1.1   
  * Microsoft.AspNetCore.Authentication.JwtBearer - 5.0.10  
  * Microsoft.AspNetCore.Identity.EntityFrameworkCore - 5.0.10  
  * Microsoft.EntityFrameworkCore - 5.0.10  
  * Microsoft.EntityFrameworkCore.SqlServer - 5.0.10  
  * Microsoft.EntityFrameworkCore.Tools - 5.0.10  
  * Microsoft.Extensions.Configuration.Json - 5.0.0   
  * Microsoft.VisualStudio.Web.CodeGeneration.Design - 5.0.2
  * Quartz.Extensions.Hosting - 3.3.3
  * Serilog.AspNetCore - 4.1.0   
  * Swashbuckle.AspNetCore - 6.2.3   
  * Twilio - 5.50.0 
    * Twilio package needs to be at 5.50.0 to avoid errors with TryGetValue at TransportationAPI/Controllers/AccountControllers.cs::63 
  * Twilio.AspNet.Core - 5.37.2  
  * Z.EntityFramework.Extensions.EFCore - 5.2.17
