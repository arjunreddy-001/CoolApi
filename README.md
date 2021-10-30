# CoolApi

.NET Core REST API using EF & Swagger (Project created in VS Code)

## To develop this project in VS Code

1. Install VS Code
2. Install .NET Core SDK (This project uses version 3.1)
3. Open VS Code & Install few extenstions to make your life bit easier

   - C# (by Microsoft)
   - Visual Studio IntelliCode (by Microsoft)
   - NuGet Package Manager (by jmrog)
   - C# Extenstions (by JosKreativ)

NOTE : To create, execute, build .... a .NET application without using Visual Studio we should be aware of various .NET CLI commands. You can find them on official documentation by Microsoft.

### Commands used to create project, open it in VS Code & Executing it are as follows -

```
dotnet new webapi -o CoolApi

cd CoolApi

code .

dotnet run
```

### To avoid "dotnet run" after every change you can use -

```
dotnet watch run
```

## Commands for Entity Framework migrations

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

NOTE : "dotnet ef" tool is no longer a part of .NET Core SDK after release of .NET Core 3. We need to install it explicitly.

### To install latest version of "dotnet ef" tool -

```
dotnet tool install --global dotnet-ef
```

### To install specific version of "dotnet ef" tool -

```
dotnet tool install --global dotnet-ef --version 3.0.0
```

### You should also install below nuget packages of same version (here, 3.0.0) as that of "dotnet ef" tool.

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

HINT : In VS Code (Windows), Ctrl + Shift + P will open command pallete, search for NuGet Package Manager & make use of it.

Now, Install packages that were added using NuGet Package Manger. VS Code will notify you to "Restore", if you dint get notification, simply make use of below command.

```
dotnet restore
```

Run migration commands after all the above installations are done.

## Implementation of Swagger API documentation

Swagger (www.swagger.io) is a great tool for documenting your APIs and it also provides great UI for testing APIs that you have created.

nuget package -

```
Swashbuckle.AspNetCore
```

Install above mentioned NuGet Package & Write few lines of code in Startup.cs to use Swagger in your Web API project.
