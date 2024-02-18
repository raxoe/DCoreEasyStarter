https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio

Required Ef Core Packages to install as follow :

Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore




---
https://learn.microsoft.com/en-us/ef/core/cli/dotnet

EF Core Command-line Tools

Installing new Cli tools
dotnet tool install --global dotnet-ef

Updating existing Cli tools
dotnet tool update --global dotnet-ef

Verify EF Cli version after installation
dotnet ef

----

EF Migration
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
dotnet add package Microsoft.EntityFrameworkCore.Design (Already added)

-First Migration
dotnet ef migrations add InitialCreate
dotnet ef migrations add InitialCreate --project EasyStarter.EntityFramework --startup-project EasyStarter.API

-Update command after migration file is added: (for latest entity changes)
dotnet ef database update --project EasyStarter.EntityFramework --startup-project EasyStarter.API

-Make changes in entity model and Add migration class for changes: (Adding another migration)
dotnet ef migrations add yourMigrationchangesName --project EasyStarter.EntityFramework --startup-project EasyStarter.API

-Rollback mirgration for development , but it will override to latest when application is launch with mirgrate method.
dotnet ef database update yourMigrationchangesName --project EasyStarter.EntityFramework --startup-project EasyStarter.API


-Remove lastly added migration
dotnet ef migrations remove --project EasyStarter.EntityFramework --startup-project EasyStarter.API
