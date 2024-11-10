# .NET Training by Pradeep


- Visual Studio 17.11 update includes .NET 8
- .NET 1.0 was launched in 2002.
- .NET 2.0 was launched in 2005.(Very successful)
- .NET 3.5 was released in 2008.
- In 2016, .NET Core 1.0 was launched along with .NET 4.5
- In 2016, Microsoft rewrote .NET from scratch.
- 2017 - .NET Core 2.0
- 2019 - .NET Core 3.0/3.1
- 2020 - .NET 5
- 2021 - .NET 6.0
- 2022 - .NET 7.0 (Out of support)
- 2023 - .NET 8.0 (LTS) / .NET 4.8(Traditional)
- 2024 - .NET 9.0 (STS Version)
- 2025 - .NET 10.0 (LTS)
- .NET 8.0 is basically the Core version

## .NET Core 
- Single platform to build apps for web,mobile
- Cross Platform (Windows, Linux and Mac)
- Everything is a nuget package
- Traditional .NET only works in windows.
- Open Source
- Highly Performant and scalable
- Docker (containerization)
- Dotnet CLI
- .NET MAUI (Desktop Application)
- Blazor(Web Apps)
- Xamarin(Mobile Apps)
- Unity (Gaming Application)
- ML.NET (AI apps)
- Cloud (Azure)
- Apache Spark (AI Apps)

- We have compilers that convert code into IL
- We have CLR which can convert IL Code into Machine Code (0s and 1s)
- FCL (foundational core libraries)

## Changes done in .NET Core

### Roslyn Compiler
- Came as part of .NET Core
- Converts code into IL
- Now foundational libraries are known as Core FX
- In .NET Core we convert IL Code into Machine Code using Core CLR (RyuJIT Compiler)
- Modern compiler for compiling C#, VB
- Superb API for code analyzing, code refactoring, generating code
- Gives on the fly code errors.

### Ryu JIT
- Faster, GC
- Cross Platform

 **.NET Apps can be hosted in IIS (Windows) or Nginx (Linux)**
 - We used to have HttpHandler and HttpModules in IIS
 - In .NET Core we have the same IIS Server but HttpHandler and HttpModules has been replaced with Middleware.
 - Now Request will go through middleware pipeline.
 - Middleware pipelines are cross-platform
 - They are software components which are plug and play.

### Kestrel Server
 - Now we also have Kestrel server on the web server
 - Kestrel is a server developed by Microsoft.
 - It is the fastest server to handle requests and responses.
 - Problem is that it can only do request and response. Cannot do sessions in Kestrel. So we need to have a reverse proxy like IIS or Nginx.
 - On top of Kestrel we have IIS and nginx.
 - Sessions, caching is not available in Kestrel so we need IIS.
 - Kestrel is an internal server that is always there as part of .NET Core.
 - Think of Kestrel as a base class which can handle only request and response.
 - .NET Core is 2300% faster at handling requests compared to .NET Framework 4.6
 - All requests go to IIS or nginx first,  then it goes to Kestrel.
 - A reverse proxy sits between client and web server(kestrel)
 - Reverse proxy like IIS or Nginx can handle SSL Termination, Caching, Load Balancing, Security
 - Web.config is only readable by IIS Server, so it's not there in .NET Core. We have appsettings.json

## Differences between Http Handler, Http Modules and Middleware
### HttpHandler
- Purpose: Processes HTTP requests based on file extensions (e.g., .html, .cs).
- Usage: Used for handling specific types of requests.
- Configuration: Registered in web.config.

### HttpModules
- Purpose: Processes HTTP requests at various stages of the request pipeline.
- Usage: Used for tasks like authentication, logging, and custom header processing.
- Configuration: Registered in web.config.

### Middleware
- Purpose: Provides a unified pipeline for handling HTTP requests.
- Usage: Used for tasks like logging, authentication, and more.
- Configuration: Configured in code, highly flexible and reusable.

**Middleware in ASP.NET Core replaces the need for HttpHandlers and HttpModules by providing a more unified and flexible approach to handling HTTP requests**


## Creating Projects using dotnet CLI
- Can create, build, compile projects
- dotnet new list(to find all the projects that can be created)
- dotnet new mvc --name=name_of_project
- cd name_of_project
- dotnet build
- dotnet run
- dotnet publish
- dotnet core does not support Crystal Reports or SSRS.
- 2 ways to design web applications: MVC and Blazor(Web Assembly wasm)

# ASP.NET Core MVC
- Model, View and Controller
- Separation of Concerns(SoC)
- Requests from server try to find controller first.
- Controller has power to decide which model and view to load
- Views are cshtml pages
- Models are the data
- We have different types of models: data model(bound to database(entities)), business model, presentation model(viewmodel)
- Controller is the brain of MVC
- Views are of different types: Standard View, Strongly Typed View, Layout View, Partial View, ViewComponent(part of partial view)
- In webforms, we used to have aspx attached to cs file. They are co-dependent.
- There is a connection between view and model called ViewModel.
- Dto(Data Transfer Object)-->More like a business object
- Do not use top level statements option(). If this option is not checked, then a class is created and method is defined(public static void main())
- We can have only 1 top level statement in the project

 ## Difference between ASP.NET MVC and ASP.NET Core MVC
- No web.config in core, we have appsettings.json
- web.config is tightly bound to IIS will not work in nginx so we have appsettings.json
- We no longer have Global.asax (Application Start, Application End)
- We now have Program.cs instead of Global.asax
- Instead of HttpHandlers and Modules we have middleware.
- Now we don't have GAC(global assembly cache) instead everything is a nuget package.
- In ASP.NET Core we not only have html helpers we also have tag helpers
- In old ASP.NET MVC we used to have static and dynamic partial views, but for ASP.NET Core we have Static Partial views and we have ViewComponents(dynamic)

## Program.cs
- It has 2 sections
- We need to add services to the container
- Next section is the execution pipeline (which has the middleware)
- Each step in the pipeline is executed.
- Earlier in Startup.cs we used to have ConfigureServices() and Configure() method
- From .NET 6.0 it was removed, now it is included in Program.cs

### wwwroot folder contains all the static files: css/js/pure html files

## Routing
- Serving a webpage based on requested URL
- Matches the pattern of request and execute the code accordingly
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
- Here pattern is controller\action\(optional) id
- MVC based on this pattern will load the screen accordingly.
- We can modify this pattern to suit our requirements
- We can create multiple patterns as well
- curly braces are the placeholder above.
- Types of Routing
  1. Conventional based routing
  2. Attribute based routing
- Internally it creates a route table and there is a route parser
- It will match the route against the pattern in the route table.
- Above is example of Conventional Routing
- For attribute routing we can do this where we use Route attribute.
```csharp
[Route("fc")]
[Route("newname")]
public class FirstController:Controller
{
    [Route("myname")]
    public string GetName() => "FirstController";
    public string GetAddress() => "Chandigarh";
}
```
- app.MapControllerToRoute is a middleware also
- In attribute based routing, the above route attributes are also added to route table.
- In attribute based routing, we don't really need the middleware.
- If we have multiple routing types, attribute based routing is always preferred.
- If attribute routing is provided, conventional routing will not work.

### Model Binder
- We can use model binders to pass values to controller methods
- Maps the matching values from querystring/ route data
- We can have constraints inside route data like city:int
- It binds the arguments of methods
```csharp
 //[Route("address")]
[Route("address/{city:int}/{country}")] 
    public string GetAddress(string city, string country) => $"{city} - {country}";
```
## Razor Pages
- cshtml files that can contain server side code and HTML markup
- Viewbag is syntatic sugar over ViewData
- Viewbag is dynamic
- Viewbag is wrapper around Viewdata
- We can also create views as strongly typed views (View has the datatype defined)
- In this view, we can specify the type of ViewModel inside the Razor page.
- We can use @Model keyword.
- We can have only 1 Model inside the view. 

