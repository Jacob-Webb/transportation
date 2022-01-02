# Transportation API v1.0
## Purpose

This software was designed as a replacement for the pre-existing app that allowed people to text in for rides to The Rock Church services.
This app seeks to allow (potential) riders access to clean UI to

    1. Enhance the user experience with the church's app

    2. Eliminate mistakes made by users through an intuitive system, relieving the transportion administration.

This software is utilizes Angular for the web app interface, C# and .NET Core on the server side, and MSSQL Server as the RBDMS.

To see the client side code, please visit https://github.com/Jacob-Webb/transportation-client

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

## Versioning and CHANGELOG.md generation

* See [Versionize](https://www.nuget.org/packages/Versionize/) docs for automatic changelog generation and versioning.
