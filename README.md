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

# Html Helpers
- Extension Methods used for generating the HTML code
- Standard Html Helpers
```csharp
 @Html.TextBox("ProductCode")
```
- Strongly Typed Helpers
```csharp
 @Html.TextBoxFor(x=>x.ProductCode)
```
## Binding Form to the Model

```csharp
<div class="row">
    <div class="col-lg-6">
        @using (Html.BeginForm("save", "product", FormMethod.Post))
        {
        <div class="form-group">
            @Html.LabelFor(x=>x.ProductId)
            @Html.TextBoxFor(x=>x.ProductId,"", new {@class = "form-control"})
        </div>
   
        <div class="form-group">
            @Html.LabelFor(x=>x.ProductCode)
            @Html.TextBoxFor(x=>x.ProductCode, "", new {@class = "form-control"})
        </div>
         <div class="form-group">
            @Html.LabelFor(x=>x.ProductName)
            @Html.TextBoxFor(x=>x.ProductName, "", new {@class = "form-control"})
        </div>
         <div class="form-group" >
            @Html.LabelFor(x=>x.Price)
            @Html.TextBoxFor(x=>x.Price, "", new {@class = "form-control"})
        </div>
        
        <input class="btn btn-primary btn-success" type="submit" value="Save Product"/>
        } 
    </div>
```
# Displaying Labels
- For every label using strongly typed views use this to show label text
````csharp
 [DisplayName("Product Id ")]
        public int? ProductId { get; set; }
````
### Boostrap is a CSS framework for designing responsive UI
- Bootstrap divides screen into 12 columns
- col-6 for 6 columns data
- can accomodate different screen sizes: xs,sm,md
- col-xs-9 (mobile device) col-lg-6(large screen)
- container, row, col, form-group, form-control, btn

## Templated Helper
- We can use @Html.EditorForModel()
- This will automatically design our form based on the properties
- We will see a screen where all controls are loaded automatically. But it depends on data type
- We have no control and are completely dependent on model properties
- Not recommended, though can be used to build a form very quickly
- If we dont want to create any control automatically, we use ScaffoldColumn as false
- ![img_22.png](img_22.png)

## Tag Helpers
- New way of development in .NET Core
- Not available in traditional .NET
- Helper methods to generate HTML code
- Help to embed server side code with html element
- Easier to read
- Helps to have html friendly development
- asp-for is attribute tag helper
```csharp
<body class="container">
<a asp-action="Create" asp-controller="Product" class="btn btn-dark">Go Back</a>
<form asp-action="SaveProduct" asp-controller="Product" method="post">
<div class="row">
    <div class="col-lg-6 col-sm-9">
        <div class="form-group">
            <label asp-for="ProductId"></label>
            <input type="text" asp-for="ProductId" class="form-control"/>
        </div>
        <div class="form-group">
            <label asp-for="ProductCode"></label>
            <input type="text" asp-for="ProductCode" class="form-control"/>
        </div>
        <div class="form-group">
            <label asp-for="ProductName"></label>
            <input type="text" asp-for="ProductName" class="form-control"/>
        </div>
        <div class="form-group">
            <label asp-for="Price"></label>
            <input type="text" asp-for="Price" class="form-control"/>
        </div>
        <input type="submit" value="Save Product"/>
    </div>
   </form>
```
- asp-*

# Boostrap
# IEnumerable, ICollection, IList(derived class of ICollection to insert,remove)
- List is derived class of IEnumerable, ICollection and IList

# Using Boostrap
- We can display items in a card like structure
- Based on input arguments, controller can display a different view
```c#
public IActionResult Summary(int view = 0)
{
    if(view == 1)
    {
        return View("ProductsView",products);
    }
        else return View("CardsView",products);
}
```
![img.png](img.png)

# Partial Views
- What if we want to reuse the card for other screens
- Use the concept of partial views
- View within a view
- We create that view under the shared folder
- ![img_1.png](img_1.png)
- ![img_2.png](img_2.png) 
- ![img_3.png](img_3.png)
- We will use partial tag with name of partial view and pass it the model
- We use a partial view to separate out complex screens into chunks
- We can pass the model into the partial view
- Everytime loop runs, it will pass the model to the partial view

# Consistent Layout in Application
- Use Layout View
- It is a view shared across by all the views
- Create it inside the shared folder
- We use underscore sign just to signify its a shared view. It is a convention
- ![img_4.png](img_4.png)
- ![img_5.png](img_5.png)
- Inside the RenderBody all the other views will be rendered
- Go to the View and set the Layout to the layout we created
- ![img_6.png](img_6.png)
- Now we don't need html, header tags in all the cshtml pages as it is already in Layout View
- Now all screens will have consistent UI
- No need to specify Header and Footer in each view
**- We cant keep specifying Layout in each page
- Use _ViewStart.cshtml**
- ![img_7.png](img_7.png)
- **If we don't specify Layout in cshtml file, it will automatically pick from _ViewStart.html**
- However, if we set Layout as NULL, no layout will be set for the page, but if no layout is specified, the one in _ViewStart.html is used
- In Partial Views, we don't have a Layout

# Specifying Navbar
- Put Navbar in _MyLayout.cshtml
- ![img_8.png](img_8.png)
- ![img_9.png](img_9.png)
- ![img_10.png](img_10.png)
- asp-route-[id] is a tag helper, it is basically any data we pass to the controller, here id is passed as an argument to controller action method
- ![img_11.png](img_11.png)
- We can pass multiple query strings like this
- We can always create a Menu Partial View and paste the common code inside that,so that our view is not so complicated.
- ![img_12.png](img_12.png)

# Specifying Dynamic Content
- We can create dynamic partial views
- Dynamic partial views in ASP.NET Core are called **ViewComponents**
- To create a Viewcomponent, we create a separate folder called Custom
- There are some rules we need to follow
- Name can be DiscountOfferViewComponent.cs
- ![img_13.png](img_13.png)
- Inherits from ViewComponent class
- We will pass the price of the product to the viewcomponent and on basis it of it, it will display View
- ![img_14.png](img_14.png)
- Here DiscountOffer and NoOffer must be in a specific structure
- ![img_15.png](img_15.png)
- We can pass arguments/models to the views also inside viewcomponents
- ![img_16.png](img_16.png)
- Calling a view component is done like this:
- Inside the _ViewImports.cshtml add a tag for the namespace of viewcomponent 
- ![img_17.png](img_17.png)
- ViewImports has all the namespaces which we dont want to repeat in our views
- We use Kebab casing: NishantTaneja becomes nishant-taneja
- ![img_19.png](img_19.png)
- View Components need to be in shared folder
- ![img_20.png](img_20.png)

# Steps for creating ViewComponent
- Create a class that inherits from ViewComponent
- Add a method Invoke()-->it is predefined
- This method returns IViewComponentResult
- For Views, create a folder within Shared Folder
- Views/Shared/Components/<View_Component_Name>/<ViewName>.cshtml
- To call the viewcomponent, we need <vc:discount-offer productPrice="@Model.Price"></vc:discount-offer>
- We can hardcode name of ViewComponent like this
- ![img_21.png](img_21.png)
- We need to add a line in _ViewImports.cshtml file to specify the namespace under which the view component is created

- In MVC, structure of folder is very important.
- If there is no layout specified for a page, MVC checks in ViewStart.cshtml
- Each layout must have @RenderBody() method
- We can have nested layouts also
- **Each layout can have a parent layout**
- **ViewImports.cshtml file is used for having all the imported namespaces in one place**
- It gets applied for all the views
- Partial Views are static, if we want to call the database and do some logic, we need ViewComponents