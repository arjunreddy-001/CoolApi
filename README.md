# CoolApi

.NET Core REST API using EF & Swagger (Project created using VS Code)

## To develop this project in VS Code

1. Install [VS Code](https://code.visualstudio.com/download)
2. Install [.NET Core SDK](https://dotnet.microsoft.com/download) (This project uses version 3.1)
3. Open VS Code & Install few extenstions to make your life bit easier

   - C# (by Microsoft)
   - Visual Studio IntelliCode (by Microsoft)
   - NuGet Package Manager (by jmrog)
   - C# Extenstions (by JosKreativ)

NOTE : To create, execute, build .... a .NET application without using Visual Studio we should be aware of various .NET CLI commands. You can find them on [official documentation](https://docs.microsoft.com/en-us/dotnet/core/tools) by Microsoft.

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

---

## Commands for Entity Framework migrations

NOTE : Make sure that you're connected to your Database Engine. In other words, your Database server is running. Before you execute any "dotnet ef" commands.

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

---

### Migration & Update for specific DbContext

If we have multiple DbContext files (here, StudentContext & CommandContext) in our project. General commands wont work. We need to explicitly specify our DbContext in the command we will execute.

Example -

```
dotnet ef migrations add CommanderDB --context CommandContext
```

```
dotnet ef database update --context CommandContext
```

---

## Implementation of Swagger API documentation

Swagger (www.swagger.io) is a great tool for documenting your APIs and it also provides great UI for testing APIs that you have created.

nuget package -

```
Swashbuckle.AspNetCore
```

Install above mentioned NuGet Package & Write few lines of code in Startup.cs to use Swagger in your Web API project.

---

## Working with PATCH requests

With PATCH we can perform 6 different operations -

1. Add
2. Remove
3. Replace
4. Copy
5. Move
6. Test

To work with PATCH, we need below NuGet packages -

- Microsoft.AspNetCore.JsonPatch
- Microsoft.AspNetCore.Mvc.NewtonsoftJson

Example Request Body for PATCH -

```
[
   {
      "op": "replace",
      "path": "/howto",
      "value": "Some new value"
   },
   {
      "op": "test",
      "path": "/line",
      "value": "dotnet new"
   }
]
```

With PATCH request, either all operations should complete successfully or fail.
