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


## Using Boostrap
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
- IEnumerator, IEnumerable, ICollection, IList, List
- IEnumerator: has one method to enumerate the next object
- IEnumerable: can only loop through data and no manipulation of collection, Count the records, GetEnumerator() method
- ICollection: can do add, remove
- IList: add, insert, remove, IndexOf (have option to modify collection)
- List: Add, RemoveRange, InsertAt, Remove

![img.png](img.png)

# Partial Views
- What if we want to reuse the card for other screens
- Use the concept of partial views
- View within a view
- We create that view under the shared folder
```csharp
@foreach (var product in Model)
{
<div class="col-lg-4">
<partial name="_ProductInfo" model="product"/>
</div>
}

// Define Partial View
@model ProductViewModel
<div class="card" style="width: 18rem;">
    <div class="card-body">
        <h5 class="card-title">@Model.ProductName</h5>
        <h6 class="card-subtitle mb-2 text-body-secondary">@Model.Price</h6>
        <p>Product Code: @Model.ProductCode</p>
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
        <a href="#" class="btn btn-warning">View</a>

    </div>
</div>

```
- We will use partial tag with name of partial view and pass it the model
- We use a partial view to separate out complex screens into chunks
- We can pass the model into the partial view
- Everytime loop runs, it will pass the model to the partial view

# Consistent Layout in Application
- Use Layout View
- It is a view shared across by all the views
- Create it inside the shared folder
- Partial view can be loaded into a main view.
- We use underscore sign just to signify it is a shared view. It is a convention
```html
@{
    Layout = null;
}

<!DOCTYPE html>
<html>
<head>
    <title>My Demo Web App</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body class="container">
<header> My Header </header>
<div>
@RenderBody()    
</div>

<footer>Copyright @@ 2024</footer>
</body>
</html>
```
- Inside the RenderBody all the other views will be rendered
- Go to the View and set the Layout to the layout we created
```csharp
@model IEnumerable<ProductViewModel>

@{
    Layout = "_MyLayout";
}


<a asp-action="Create" asp-controller="Product" class="btn btn-dark">Go Back</a>
<table class="table table-hover">
    <thead>
    <tr>
        <th>Product Id</th>
        <th>Product Name</th>
        <th>Product Code</th>
        <th>Product Price</th>
    </tr>
    </thead>
    <tbody>
    @foreach (var item in Model)
    {
        <tr>
            <td>@item.ProductId</td>
            <td>@item.ProductName</td>
            <td>@item.ProductCode</td>
            <td>@item.Price</td>
        </tr>
    }
    </tbody>
</table>
```
- Now we don't need html, header tags in all the cshtml pages as it is already in Layout View
- Now all screens will have consistent UI
- No need to specify Header and Footer in each view
**- We cant keep specifying Layout in each page
- Use _ViewStart.cshtml**
```csharp
@{
    Layout = "_MyLayout";
}

```
- **If we don't specify Layout in cshtml file, it will automatically pick from _ViewStart.html**
- However, if we set Layout as NULL, no layout will be set for the page, but if no layout is specified, the one in _ViewStart.html is used
- In Partial Views, we don't have a Layout

# Specifying Navbar
- Put Navbar in _MyLayout.cshtml
```html
<body class="container">
<nav class="navbar navbar-expand-lg bg-body-tertiary">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">Navbar</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link active" aria-current="page" asp-action="Create" asp-controller="Product">Add Product</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" asp-action="Summary" asp-controller="Product">Product List</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" asp-action="Summary" asp-controller="Product" asp-route-view="1">Product List(Cards)</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link disabled" aria-disabled="true">About Us</a>
                </li>
            </ul>
        </div>
    </div>
</nav>
<header> My Header </header>
<div>
    @RenderBody()
</div>

<div class="alert alert-warning text-center">
    <footer>Copyright @@ 2024</footer> 
</div>

</body>
```
- asp-route-[id] is a tag helper, it is basically any data we pass to the controller, here id is passed as an argument to controller action method
```csharp
<a class="nav-link" asp-action="Summary" asp-controller="Product" asp-route-id = "2" asp-route-view="1">Product List(Cards)</a>
```
- We can pass multiple query strings like this
- We can always create a Menu Partial View and paste the common code inside that,so that our view is not so complicated.


# Specifying Dynamic Content
- We can create dynamic partial views
- Dynamic partial views in ASP.NET Core are called **ViewComponents**
- To create a Viewcomponent, we create a separate folder called Custom
- There are some rules we need to follow
- Name can be DiscountOfferViewComponent.cs
```csharp
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Custom;

public class DiscountOfferViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(decimal productPrice)
    {
        //fetch value from db
        if (productPrice > 1000)
        {
            decimal discount = productPrice * 10/100;
            decimal finalPrice = productPrice - discount;
            return View("DiscountOffer", finalPrice);
        }
        return View("NoOffer");
    }
}
```
- Inherits from ViewComponent class
- We will pass the price of the product to the viewcomponent and on basis it of it, it will display View
- Here DiscountOffer and NoOffer must be in a specific structure
- We can pass arguments/models to the views also inside viewcomponents
```csharp
return View("DiscountOffer", finalPrice);
```
- Calling a view component is done like this:
```csharp
@model ProductViewModel
<div class="card" style="width: 18rem;">
    <div class="card-body">
        <h5 class="card-title">@Model.ProductName</h5>
        <h6 class="card-subtitle mb-2 text-body-secondary">@Model.Price</h6>
        <p>Product Code: @Model.ProductCode</p>
        <vc:discount-offer productprice = "@Model.Price"></vc:discount-offer>
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
        <a href="#" class="btn btn-warning">View More</a>
           
    </div>
</div>
```
- Another alternative is this approach where we directly invoke the View Component
```csharp
@model ProductViewModel
<div class="card" style="width: 18rem;">
    <div class="card-body">
        <h5 class="card-title">@Model.ProductName</h5>
        <h6 class="card-subtitle mb-2 text-body-secondary">@Model.Price</h6>
        <p>Product Code: @Model.ProductCode</p>
        @*<vc:discount-offer productprice = "@Model.Price"></vc:discount-offer>*@
        <!-- Use the View Component in a View (e.g., Views/Home/Index.cshtml) -->
        @await Component.InvokeAsync("DiscountOffer", new { productPrice = @Model.Price })

        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
        <a href="#" class="btn btn-warning">View More</a>
           
    </div>
</div>
```
- Inside the _ViewImports.cshtml add a tag for the namespace of viewcomponent 
```csharp
@using WebApp.Custom
@addTagHelper *, WebApp
```
- ViewImports has all the namespaces which we don't want to repeat in our views
- We use Kebab casing: NishantTaneja becomes nishant-taneja
- View Components need to be in shared folder


# Steps for creating ViewComponent
- Create a class that inherits from ViewComponent
- Add a method Invoke()-->it is predefined
- This method returns IViewComponentResult
- For Views, create a folder within Shared Folder
- Views/Shared/Components/<View_Component_Name>/<ViewName>.cshtml
- To call the viewcomponent, we need <vc:discount-offer productPrice="@Model.Price"></vc:discount-offer>. Note the Viewcomponent name is in kebab case
- Alternatively, we can invoke the view component directly using @await Component.InvokeAsync("VC_Name",model_data_to_be_passed)
- We can hardcode name of ViewComponent like this

- We need to add a line in _ViewImports.cshtml file to specify the namespace under which the view component is created
```csharp
@using WebApp.Custom
@addTagHelper *, WebApp
```
- In MVC, structure of folder is very important.
- If there is no layout specified for a page, MVC checks in ViewStart.cshtml
- Each layout must have @RenderBody() method
- We can have nested layouts also
- **Each layout can have a parent layout**
- **ViewImports.cshtml file is used for having all the imported namespaces in one place**
- It gets applied for all the views
- Partial Views are static, if we want to call the database and do some logic, we need ViewComponents

## Custom Tag Helpers
- Create a class: Custom_Class_NameTagHelper
- Inherit from Tag Helper
- Override the method Process and write logic
- Provide the attribute to the class if any other name is expected
- Add a line in _ViewImport.cshtml
  @addTagHelper *,WebApp
- It will use kebab casing
```c#
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.Custom
{
    [HtmlTargetElement("custom")]
    public class MyCustomTagHelper: TagHelper
    {
        public string Message { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<div class='alert alert-warning'>{Message}</div>");
        }
    }
}


```
- Use a Tag Helper like this
```html
 <custom message="this is nishant"></custom>
     <custom message="here here"></custom>
```

- Use Strongly Typed Models
- To use Strongly Typed Models in custom Tag Helper add this property
```c#
public ModelExpression ProductName { get; set; }

//Modify code as follows
 output.Content.SetHtmlContent($"<div class='alert alert-warning'>{Message}-{ProductName.Model}</div>");

 //Use it like this
 <custom message="this is nishant" product-name="ProductName"></custom>

```

- TO get input from user and modify the html and display output use this
- Here we are taking comma separated values and displaying them in a list
```c#
public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
{
    output.TagName = "ul";
    var existingContent = await output.GetChildContentAsync();
    var existingData = existingContent.GetContent();
    var names = existingData.Split(',', StringSplitOptions.RemoveEmptyEntries);
    foreach(var item in names)
    {
        output.Content.AppendHtml($"<li>{item}</li>");
    }
    //return base.ProcessAsync(context, output);
}

//Use like this
 <custom>nishant,nalin,susan,victor</custom>


```

## Validation
- To protect the form from passing invalid data to server
- Client Side and Server Side Validation
- Types of Validation
- Explicit Model Validation
- Data Annotation: Required, Range, MinLength, MaxLength, RegularExpression,EmailAddress,Phone, Url
- Below is the traditional way of doing validations
```c#
 public IActionResult SaveProduct(ProductViewModel productViewModel)
 {
     if(string.IsNullOrEmpty(productViewModel.ProductCode))
     {
         ModelState.AddModelError("ProductCode", "Product Code is required");
     }
     if (ModelState.IsValid)
     {
         //save in db
         products.Add(productViewModel);
         return RedirectToAction("Summary");
     }
     else
     {
         return View("CreateV1");
     }
     
 }


 //Use it like this
 <span asp-validation-for="ProductCode" class="text-danger"></span>

```
- Another way of doing validations is using annotations and we can provide custom error messages
```c#
  [Required(ErrorMessage = "Product name is Mandatory")]
  [RegularExpression("^[a-zA-Z0-9 ]+$",ErrorMessage ="Product Name is invalid")]
  [Range(1,double.MaxValue)]
```
- We can display all error messages as a list like this
```html
 <div asp-validation-summary="All" class="text-danger"></div>
```

## Custom Validation

- We can do custom validation like this by inheriting from ValidationAttribute
  ```c#
     public class CodeValidator:ValidationAttribute
    {
     public string Character { get; set; }
     protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
     {
         string code = value as string;
         if(code != null && !code.StartsWith(Character,StringComparison.OrdinalIgnoreCase))
         {
             return new ValidationResult(ErrorMessage);
         }
         return ValidationResult.Success;
     }
    }
  ```
- Use it like this
```c#
    [CodeValidator(Character ="P",  ErrorMessage ="Product code is not starting with P")]
    public string? ProductCode { get; set; }
```

- All the above validations are server-side validations

## Client Side Validations
- To perform client side validations in Razor Page, just drag these 3 files from wwwroot into the cshtml page
- All validations including Model Validations will work client-side.
```html
<script src="~/lib/jquery/dist/jquery.min.js"></script>
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>

```
- These 3 js files are working because all server side validations are moved over to client side using data-val attributes
- These 3 files do all the magic using data-val attributes
- However custom validations will not work, to make them work, we will have to plugin all our custom validation logic into the unobtrusive.js file using adapters
  
- ![alt text](image.png)
- ![alt text](image-1.png)  
- Another way to make this client side validations is to use _ValidationScriptsPartial partial view and we can put it inside any view
```html
    <partial name="_ValidationScriptPartial"/>
```
- To add our custom validator as a client side validation we need to do this:
```c#
     public class CodeValidator:ValidationAttribute, IClientModelValidator
 {
     public string Character { get; set; }

     public void AddValidation(ClientModelValidationContext context)
     {
         context.Attributes.Add("data-val-codevalidator", ErrorMessage);
         context.Attributes.Add("data-val-codevalidator-character",Character);
     }

     protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
     {
         string code = value as string;
         if(code != null && !code.StartsWith(Character,StringComparison.OrdinalIgnoreCase))
         {
             return new ValidationResult(ErrorMessage);
         }
         return ValidationResult.Success;
     }
 }

```
- ![alt text](image-2.png)
- Next step is to create a validation.js file in js folder in wwwroot
 ```js
    jQuery.validator.addMethod("codevalidator", function (val, ele, param) {
    if (val != '' && val.indexOf(param.char) == -1) {
        return false;
    } else {
        return true;
    }
    })

    jQuery.validator.unobtrusive.adapters.add("codevalidator", ["char"], function (option) {
    option.rules['codevalidator'] = { char: option.params.char };
    option.messages['codevalidator'] = option.message;
    })
```
- Then just include this JS into your page
```js
<script src="/js/validation.js"></script>
```
- Now the server side validations will work client side but please note the server side logic has to again be written on the client side as well
- ![alt text](image-3.png)

## Steps to implement custom validator client side
- Implement the interface IClientModelValidator and implement method AddValidation. 
- Whatever we need to render in client side, add it here as an attribute
- In javascript, add a function performing the same validation logic like server side using JQuery.validation.addMethod
- In JS plugin your custom js validation along with parameters and error messages with unobtrusive.js
 ```js
    jQuery.validator.unobtrusive.adapters.add("codevalidator", ["char"], function (option) {
    option.rules['codevalidator'] = { char: option.params.char };
    option.messages['codevalidator'] = option.message;
    })
```
## Connecting Application to the Database
- ADO.Net
- SqlConnection, SqlCommand, SqlDataReader, SqlDataAdapter
- ORM(Object Relational Mapping)
- Helps to do all RDBMS activity with object oriented programming
- We create a class that acts like database
- We call them Entity Classes that will act like tables 
- Inside the entity class, there are properties that will act like columns
- DbSet<Entity> acts like rows
- No need to write insert/update queries, this is done by ORM 
- Different ORMs in market like NHibernate, Dapper,ORMLite, EF Core, EF (Traditional)
- ORM will map your database tables with C# classes and properties
- They have APIs to do CRUD operations without writing any scripts
- ORMs can connect to various DBs like Cosmos DB, MySql, DB2, Sql Server,Postgres SQL

### Types of Data Modeling
- Code First Approach
- DB First Approach (Reverse Engineering)
- In Code First, we will make some classes and map them to the database
- Nuget Packages: EntityFrameworkCore, EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools

### Migration Commands
- Command line to execute and generate SQL Scripts
- Execute Sql Script in the database
- Tools > Nuget Package Manager > Package Manager Console
### Steps in Migration
- Add-Migration <migration_name>
- Update-Database
- Script-Migration

```c#
public class DemoDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=localhost;Initial Catalog=questponddb;Integrated Security=True";
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Product> Products { get; set; }

}
```
- In code-first we write code first in c#, convert it to a script and then update the database.
- A table called EFMigrationHistory is also generated which tracks all the migrations
- We have a **navigation property** to get the foreign key relationship with
```c#
 namespace DataAccessLayer.Entities
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; } //int
        [Column(TypeName ="varchar(200)")]
        public string ProductCode { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; } //nvarchar(MAX) by default
        public decimal Price { get; set; }
      
        public int CategoryId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
    }
}

```
- Another way is
```c#
  [ForeignKey(nameof(Category))]
 public int CatId { get; set; }

 //Navigation Property
 public Category Category { get; set; }

```

## Repository Pattern 
- We cannot directly connect our frontend application to data access layer
- It will cause tight coupling.
- We need repository layer
- According to Martin Fowler, the repository pattern mediates between domain and data mapping layer acting like an in-memory collection of domain object.
- When we connect to a database we get the result back as rows and columns. We need to map them to domain objects which our application uses.
- It decouples application from persistent framework like Entity Framework. Provides an abstraction between them.
- Entity Framework also implements repository pattern since it also maps my database rows and columns to my entity objects.
- Even Entity Framework also has methods for Add, Remove, Find, Where
- But even then we need some abstraction because domain objects are complex in nature.
- Every repository class will have CRUD methods.
- We need to **minimize duplicate code.**
- var products = context.Products.Where(d=>d.ProductId > 0); //Connect to database, generate a script, execute the query, deserialize to List<Products>, close the connection.
- In old days, ADO.NET used to have lot of code just to do the above.
- **Repository pattern also allows unit testing** since we create interfaces. 
- Repositories give domain objects
- Our webapp should deal with domain objects not entity objects 
- Webapp needs DTOs/ViewModels
- ![alt text](image-5.png)
- Business Layer ensures we get data in terms of ViewModels, DTOs 
- Business Layer talks to Repositories
- Repositories talks to Database (Core Project)
- context.SaveChanges() gives the rows affected
- Different ways to do CRUD operations
```c#
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoDbContext _context;

        public ProductRepository()
        {
            _context = new DemoDbContext();
        }
        public bool Add(Product productToAdd)
        {
             _context.Products.Add(productToAdd);
            //context.SaveChanges gives the rows affected
            return _context.SaveChanges() > 0; //open connection, generate script, execute script, fetch latest id, insert, close connection
        }

        public bool Delete(int productId)
        {
            //_context.Products.Where(x => x.ProductId == productId).ExecuteDelete();
            //return _context.SaveChanges() > 0;
            var productToDelete = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            _context.Products.Remove(productToDelete);
            return  _context.SaveChanges() > 0;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = (from prod in  _context.Products
                            where prod.ProductId > 0 select prod).ToList();
            return products;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public bool Update(Product productToUpdate)
        {
            //_context.Products.Update(productToUpdate);
            //return _context.SaveChanges() > 0;
            //_context.Products.Where(x=>x.ProductId == productToUpdate.ProductId)
            //    .ExecuteUpdate(s=>s.SetProperty(p=>p.ProductCode, productToUpdate.ProductCode));
           ** _context.Entry<Product>(productToUpdate).State = EntityState.Modified;
            _context.SaveChanges();**
            return true;
        }
    }
}


```
- **To not lock the table while doing reads, use AsNoTracking**
- In EF Core, we have _context.Database.BeginTransaction() to start a transaction
- In catch block we will have rollback
```c#
 try
{
    _context.Database.BeginTransaction();
    _context.Products.Add(productToAdd);
    _context.Database.CommitTransaction();
    //context.SaveChanges gives the rows affected
    return _context.SaveChanges() > 0; //open connection, generate script, execute script, fetch latest id, insert, close connection
}
catch (Exception ex)
{
    _context.Database.RollbackTransaction();
    return false;
}

```
- Repository pattern will minimize duplicate code 
- We will have separate Business Layer and another project for the Models(ViewModels)
- Controllers will talk to Business Layer and Business Layer will talk to Repository Layer which in turn talks to Data Access Layer
- If we click on a Link we cant do a Delete, when we click on a link <a></a> it would do a HttpGet request. To make HttpDelete request, use AJAX
## In EFCore if want to exclude data at the global level, we can also use Global Query Filters.

## Dependency Injection
- Software Design principle that transfer the control of object creation to an external source.
- This is done to promote loose coupling.
- Design Pattern to inject the dependent object rather than create the object inside the class. 
- Instead of creating concrete objects inside class, we should be injecting objects
- Implements the dependency inversion principle. 
- We can do method injection or constructor injection or property injection
- Inversion of control will help to create instances of a class rather than us creating it directly.
- IOC transfer the control of object creation to an external source, rather than application code.
- IOC creates a container called IOC Container.
- ![alt text](image-6.png)
- IOC Container gives us an instance of an interface or a class. 
- Helps to promote loose coupling.
- In IOC Containers, we register all our requirements like for IProductBL give me ProductBL or for IProductRepo give me ProductRepo.
- IOC container is also capable of maintaining the **lifetime scope** of the object. 
- It can help decide how long the ProductBL or ProductRepo object should be in memory.
- This is done using 3 methods: **AddScoped, AddSingleton, AddTransient**
- AddTransient means everytime the controller is looking for a particular object a new object is created for you. 
```c#
public ProductController(IProductBL productBL, ICategoryBL categoryBL)
{
    _productBL = productBL;   
    _categoryBL = categoryBL;

}

```
- We can configure DbContext like this 
```c#
 services.AddDbContext<DemoDbContext>(option =>
 {
     string connectionString = configuration.GetConnectionString("conn") ?? "";
     option.UseSqlServer(connectionString);
 });

     public class DemoDbContext:DbContext
    {
        public DemoDbContext(DbContextOptions options):base(options) {
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=localhost;Initial Catalog=questponddb;Integrated Security=True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }


```
- Add Transient: Creates new instance everytime for each request and subsequent request 
- Add Scoped: Create new instance everytime for each request and share it for subsequent request. It has nothing to do with HTTP request.
- They determine how an object gets created. 
- ![alt text](image-7.png)
- Here for each requirement of ICustomerBL in AddTransient, 2 separate objects are created of CustomerBL
- For AddScoped, the object is shared. 
- In Singleton , a single object or single instance is created throughout the project. 
- For DbContext we should use AddScoped. For the same request we can share the object and avoid creating too many connections.
- Singleton should not be used as if we make any changes in the object for one user, other users will also have the same updated value which is not correct.
- Caching and System Settings use Singleton
- Please note these settings are not user specific they are request specific.
- If we want to pass some information while object initialization we can do this in IOC Container :
  ```c#
    //Class Constructor
    public CustomerBL(ICategoryRepository categoryRepository,string data)
    {
        counter++;
        Console.WriteLine($"Object created: {counter}");
        _categoryRepository = categoryRepository;   
    }

    //Setup in Configure Dependencies
    services.AddScoped<ICustomerBL>(provider =>
    {
        var catRepo = provider.GetService<ICategoryRepository>();
        return new CustomerBL(catRepo, "test data");
    });

  ```
  - GetService and GetRequiredService are the same except GetRequiredService will give error if the object is null
  - ![alt text](image-8.png)
  - If we have some state issues use Transient rather than Scoped. Transient doesn't maintain any state.
  - AddScoped() is stateful and AddTransient() is stateless.

## Keyed Services in ASP.NET Core
- Lets say an interface has 2 implementations, ICustomerBL is implemented by CustomerBL and CustomerV2BL
- We can also have KeyedTransient and KeyedSingleton
```c#
  services.AddKeyedScoped<ICustomerBL, CustomerBL>("v1");
  services.AddKeyedScoped<ICustomerBL, CustomerV2BL>("v2");


  public ProductController(IProductBL productBL, ICategoryBL categoryBL, [FromKeyedServices("v2")] ICustomerBL customerBL)
{
    _productBL = productBL;   
    _categoryBL = categoryBL;
    _customerBL = customerBL;

}

```
  
## DB First Approach 
- In EFCore we dont have edmx like it used to exist earlier in Entity Framework.
- There is no edmx it only helps to generate the same code as Code First approach.
- DB First is also called Reverse Engineering. 
- Use this command 
- Scaffold-DbContext <ConnectionString> Microsoft.EntityFrameworkCore.SqlServer -ContextDir <NameOfDirWhereContextClassWillSave> -OutputDir <NameOfDirWhereModelsClassesWillSave>
- Data Modeling using 2 ways 
  1. Data Annotations 
  2. Fluent API(using OnModelCreating and specify constraints and relationships like HasKey, OneToMany)
  3. ![alt text](image-9.png)
- We can use an VS Extension: EFCore Power Tools 
- ![alt text](image-10.png)
- ![alt text](image-11.png)
- ![alt text](image-12.png)
- ![alt text](image-13.png)
- ![alt text](image-14.png)
- We can choose whether to use Data Annotations or Fluent API
- Model First Approach is not available in EFCore.
- We can use Script-Migration command to generate a sql script to generate the database and run it on the server.
- Just make sure all Entity Framework packages use version 8.0.11
- We can also use Script-Migration -from <migration_name> -to <migration_name> to just generate the sql script between 2 specific migrations.
- In Db first approach we have 2 options: one is to use scaffold command or using ef core power tools extension or using cli command.

## Multiple appsettings for different environments 
- We can have multiple appsettings file like appsettings.development.json or appsettings.qa.json 
- We then need to register it in Program.cs like this 
```c#
var env = Environment.GetEnvironmentVariable("MyEnv");
if(env == null)
{
    throw new Exception("MyEnv configuration is not set");
}


 builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("MyEnv").ToLower()}.json", optional: false);

```
- We can define the environments in launchSettings.json 
- We can define various environment variables in launchSettings.json 
- Please note launchSettings.json is only for local development, in production we have a different way of defining our environment variables.
- Go to Edit System Environment Variables.
- In ASP.NET MVC we also have a tag helper on basis of which we can switch the environment variables.
- ![alt text](image-16.png)
- By default it uses ASPNETCORE_ENVIRONMENT

## ASPNETCORE Middleware
- It is a function or software component that is executed before and after the request and response is processed. 
- ![alt text](image-17.png)
- Types of Middleware: 
- Use() -> Execute each middleware and delegate to the next, 
- Map() -> Create Branch, 
- Run() -> Terminates the middleware, No other middleware will be executed after Run(), it will start reverse flow.
- It executes from top to bottom one by one.
- Middleware executes the logic and passes the context to next middleware 
- Run() terminates the pipeline and then it executes in reverse once response is sent.
```c#

//custom middleware example
app.Use(async (context, next) =>
{
    Console.WriteLine("a middleware: start");
    await next();
    Console.WriteLine("a middleware: end");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("b middleware: start");
    await next();
    Console.WriteLine("b middleware: end");
});

//Starts a new pipeline
app.Map("/test", mappedMap =>
{
    mappedMap.Use(async (context, next) =>
    {
        Console.WriteLine("Middleware before test");
        await context.Response.WriteAsync("Hello from the test");
        await next();
        Console.WriteLine("Middleware after the test");
    });

    mappedMap.Run(async context =>
    {
        Console.WriteLine("Terminated Middleware");
        await Task.CompletedTask;
    });
});

```
- ![alt text](image-18.png)
- Middlewares are ended when it encounters a Run(). 
- Any middleware written after Run() is never executed. 
- app.UseDeveloperExceptionPage(); --> This middleware gives full error, we should have some logic to say that if the environment is production, this error is not displayed.
- app.UseHttpsRedirection(); -->Converts http request to https one. 
- app.UseStaticFiles() --> used to render and download the files in wwwroot folder , we can run angular and react apps from here.
- Map() creates a separate branching in our pipeline. We can create a different pipeline which can then have a Run() method to stop the pipeline.
- ![alt text](image-19.png)
- ![alt text](image-20.png)
- We can also use MapGet() to define Minimal APIs 
```c#
//This is a separate branch altogether
app.MapGet("/hello", () =>
{
    return "Hello from me";
};
app.Run();
);

app.MapGet("/getmyname/{id}", (string id) =>
{
    return "Hello from me" + id;
});

app.MapGet("/product/list", (IProductBL productBL) =>
{
    return productBL.GetAllProducts();
});
```

## Short Circuit Middleware 
- If we do this 
```c#
app.MapGet("/hello", () =>
{
    return "Hello from me";
}).ShortCircuit();
```
- If we use ShortCircuit() method it will skip all other middlewares and directly execute this function. Will make our functions really fast.

## Custom Middleware 
```c#

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the request information
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        // Call the next middleware in the pipeline
        await _next(context);

        // Log the response information
        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}



```

- We can register it in Program.cs as follows 
```c#
// Register the custom middleware 
app.UseMiddleware<RequestLoggingMiddleware>();

```
- RequestDelegate: Represents a function that can process an HTTP request.

- InvokeAsync: The method that processes the request. The HttpContext parameter provides access to the request and response objects.

- _next: A delegate to the next middleware in the pipeline. Calling _next(context) passes control to the next middleware.
### Use Cases for Custom Middleware
- Logging: Log requests and responses for auditing and debugging.

- Authentication: Validate authentication tokens or API keys.

- Error Handling: Catch and handle exceptions, returning custom error responses.

- Caching: Implement caching mechanisms for certain endpoints.

- Custom Headers: Add or modify HTTP headers.

- We can use Sessions like this 
```c#
builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(20);
});

app.UseSession();

```

## Conditional Middleware 
- MapWhen() in ASP.NET Core is a middleware component used to conditionally branch the request pipeline based on a specified predicate. 
- This is useful when you want to execute different middleware based on certain conditions, such as the request path, headers, or query parameters.
- How MapWhen Works
- Predicate: You provide a function that takes an HttpContext and returns a bool. If the function returns true, the middleware branch will be executed.
- Branching: You can configure separate middleware for each branch.
```c#
 public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Branch the pipeline when the request path starts with /api
        app.MapWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
        {
            appBuilder.Use(async (context, next) =>
            {
                // Custom middleware logic for API paths
                Console.WriteLine("Handling API request");
                await next.Invoke();
            });
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}


```
- Predicate: context.Request.Path.StartsWithSegments("/api") is the predicate function that checks if the request path starts with /api.
- Branch Middleware: Inside the MapWhen block, you define middleware that only runs when the predicate is true.
- Practical Use Cases
- API Versioning: Direct API requests to different versions of the API.
- Feature Flags: Enable or disable certain features based on conditions.
- Custom Logging or Metrics: Apply custom logging for specific request paths or conditions.
- Using MapWhen allows you to create more flexible and modular middleware configurations in your ASP.NET Core application.



## JWT Authentication
- Used for authentication and authorization
- JWT-->Json Web Token
- Self contained to store info needed for authentication and authorization within itself
- JSON format is transmitted over network making it better in performance
- Data is in JSON format for compact and secure as well.
- Data is secure and tamper proof as signed by crytographic signing. 
- Cross Platform
- Flexible with Roles, Claims and Permission and Expiration.
- Creation: The server generates a JWT after the user successfully logs in. The server's secret key is used to sign the token, which ensures that the token's data can't be tampered with.
- Transmission: The JWT is sent to the client and is typically stored in localStorage or a cookie.
- Usage: For each subsequent request, the client sends the JWT in the HTTP header using the Bearer schema:
- Stateless: The server doesn't need to store a session for the client; everything the server needs is in the token itself.
- Compact: JWTs are small enough to be sent via URL, POST parameter, or inside an HTTP header.
- ![alt text](image-22.png)
- We will have the following settings in appsettings.json
  ```c#
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "conn": "Data Source=localhost;Initial Catalog=questponddb;Integrated Security=True;TrustServerCertificate=True;"
  },
  "JwtSettings": {
    "Issuer": "www.abc.com",
    "Audience": "www.abc.com",
    "SecretKey": "YourSuperSecretKey"
    }
    }


  ```
  - We will create a JwtMiddleware to validate the incoming token
  - We will use the JwtSecurityTokenHandler class to validate the token.
  - There are 2 types of cookies: Persistent Cookies and Non-Persistent cookies 
  - We can pass the role as a claim type inside the JWT Token
  - To verify the role, we can add the following code inside Program.cs 
  - ![alt text](image-24.png)
  - ![alt text](image-25.png)
  - ![alt text](image-26.png)
  - In Web.Api we dont use cookies to send data. There we will pass the JWT Token in the Authorization Bearer Header.
  
## Open ID Connect 
- OpenID Connect (OIDC) is an identity layer built on top of the OAuth 2.0 protocol, designed to provide a simple and secure way to authenticate users and obtain their identity information. 
- It allows clients (such as web and mobile applications) to verify the identity of an end-user and obtain basic profile information in a standardized and interoperable manner.
- User Authentication: Provides a way for applications to authenticate users via an identity provider (IdP).
- Interoperability: Standardized protocols and endpoints ensure compatibility across different identity providers and applications.
- Claims: Uses JWT (JSON Web Token) to securely transmit claims about the user, such as their name, email, and other profile information.
- Authorization Code Flow: Supports a secure way to obtain both access tokens and ID tokens using authorization code flow.
- Authorization Request: The client application redirects the user to the identity provider's authorization endpoint, requesting authentication.
- User Authentication: The user authenticates with the identity provider (e.g., by logging in).
- Authorization Code: Upon successful authentication, the identity provider redirects the user back to the client application with an authorization code.
- Token Exchange: The client application exchanges the authorization code for an ID token and an access token by making a request to the identity provider's token endpoint.
- ID Token: The ID token contains information about the authenticated user, such as their identity and profile claims, and is used by the client application to verify the user's identity.
- Setting up Open ID Connect in an ASP.NET Core application using authentication middleware can be done as follows:
  ```c#
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect(options =>
    {
        options.Authority = "https://your-identity-provider.com";
        options.ClientId = "your-client-id";
        options.ClientSecret = "your-client-secret";
        options.ResponseType = "code";
        options.SaveTokens = true;

        options.Scope.Add("profile");
        options.Scope.Add("email");

        options.GetClaimsFromUserInfoEndpoint = true;
    });

     services.AddControllersWithViews();
  }

   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
   {
     if (env.IsDevelopment())
     {
         app.UseDeveloperExceptionPage();
     }

     app.UseRouting();
     app.UseAuthentication();
     app.UseAuthorization();
     app.UseEndpoints(endpoints =>
     {
         endpoints.MapDefaultControllerRoute();
     });
  }

  ```
## Configuring Jwt Based Authentication and Authorization in the Application

- Step 1: Adding the Authentication and Authorization Services in the Program.cs file
```c#
  builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.Cookie.Name = "AuthToken";
        options.LoginPath = new PathString("/account/login");
        options.AccessDeniedPath = new PathString("/account/accessdenied");
    });

  builder.Services.AddAuthorization(options =>
 {
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUser", policy => policy.RequireRole("User"));
 });

```
- Step 2: In the Account Controller, if the user successfully logs in with his username password, then generate a token and set the token inside the cookie like this:

```c#
//Code to generate token
public string GenerateToken(UserViewModel userVM)
{
    var jwtSettings = _configuration.GetSection("JwtSettings");
    var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? "");

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, userVM.FullName),
        new Claim(ClaimTypes.Email, userVM.EmailId),
        new Claim(ClaimTypes.Role, userVM.Role)
    };

    var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

    //parameters to generate the token
    var token = new JwtSecurityToken(
        issuer: jwtSettings["Issuer"],
        audience: jwtSettings["Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddSeconds(5),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
}


//Using the above code inside the Account Controller on the Login Post Action Method

[HttpPost]
public IActionResult Login(LoginViewModel loginViewModel)
{
    if (ModelState.IsValid)
    {
        UserViewModel loggedInUser = _userBL.ValidateUser(loginViewModel);
        if (loggedInUser != null)
        {
            string token = _userBL.GenerateToken(loggedInUser);
            HttpContext.Response.Cookies.Append("AuthToken", token);
            return RedirectToAction("Create", "Product");
        }
    }
    ViewBag.InvalidUser = "Invalid emailid & password.Try again";
    return View("Index");
}

```

- Step 3: Validate the Token inside the JwtMiddleware i.e Create a separate middleware to validate incoming tokens 
```c#
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Custom
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Cookies["AuthToken"];

            if (token != null)
            {
                try
                {
                    var jwtSettings = _configuration.GetSection("JwtSettings");
                    var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var parameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };

                    var principal = tokenHandler.ValidateToken(token, parameters, out var validatedToken);
                    context.User = principal; // Populate HttpContext.User
                }
                catch
                {
                    // If token validation fails, clear the cookie &this will redirect to login page
                    context.Response.Cookies.Delete("AuthToken");
                }
            }

            await _next(context);
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}



```

- Step 4: Call this Middleware from inside Program.cs like this:

```c#
app.UseAuthentication();

app.UseJwtMiddleware();

app.UseAuthorization();

```


  ### Potential Downsides of using OIDC
  - Additional Requests: OIDC introduces additional network requests for token exchange, user information retrieval, and token validation. This can add latency to the authentication process.
  - Session Management: Managing user sessions and token lifecycles can introduce performance overhead on both the client and server sides.
  
## WebAPI
- REST 
- Representational State Transfer 
- Earlier we used to have SOAP format, before that Webservices(ASMX)
- We used to have WCF also.
- WCF had the concept of ABC(Address Binding Contract). There was wsHttpBinding for REST Services 
- REST is an architectural style for designing services that can communicate between different systems.
### REST has some principles:
- Addressable Resource(each resource should have a URL)
- Every resource should be simple and uniform (Leverage HTTP methods like GET,PUT,POST,DELETE) 
- Representation Oriented (Representation of resource can be in any format like XML, JSON)
- Communication is stateless.(HTTP itself is a stateless protocol). No session is maintained on the server
- Cacheable: Client should be able to cache the response for future use.

### All the above principles are followed by WebAPI. That is why WebAPI follows REST based architecture.
- Remember SOAP was very verbose, REST is lightweight.

### Content Negotiation
- Process of selecting the best representation of response. 
- JSON is default representation format.
- Provide **Accept header with values like "application/json" or "application/xml".**
- Content negotiation in WebAPI is a mechanism that allows clients and servers to agree on the most appropriate format for the response content. This process ensures that clients receive data in the format they prefer, such as JSON, XML, or other media types.
- 1. Accept Header:
- The client specifies the desired response format using the Accept header in the HTTP request. For example, a client can request JSON or XML by setting the Accept header to application/json or application/xml, respectively.
- **Content-Type Header**:
- The server indicates the format of the response using the Content-Type header in the HTTP response.
- **MediaTypeFormatters**:
- ASP.NET Core WebAPI uses MediaTypeFormatters to handle serialization and deserialization of data. By default, ASP.NET Core supports JSON and XML formatters.
- **Configuring Formatters**:
- You can configure formatters in the Startup.cs file to support different media types.
- Configure JSON and XML Formatters
- In your Startup.cs file, you can configure the formatters in the ConfigureServices method:
```c#
 public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        // Remove the default JSON formatter
        options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();

        // Add JSON and XML formatters
        options.OutputFormatters.Add(new NewtonsoftJsonOutputFormatter(new JsonSerializerSettings(), ArrayPool<char>.Shared, new MvcOptions()));
        options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    })
    .AddNewtonsoftJson(); // For JSON serialization
}

```
- This can also be done like this 
  ```c#
    builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters();
  ```
  ### We can force data to be returned by a method in a specific format using Produces() annotation 
  ```c#
   [Produces("application/json")]
   [Route("getall")]

    public IActionResult GetAllProducts()
    {
    var products = _productBL.GetAllProducts();
    //return Ok(products);
    return StatusCode(StatusCodes.Status200OK, products);
    }
  ```
  ### To restrict to get information only from body of the request and not from querystring we can use [FromBody]
```c#
   [HttpPost]
 [Route("add")]
 public IActionResult AddProduct([FromBody] ProductViewModel productVM)
 {
     var isAdded = _productBL.AddProduct(productVM);
     if (isAdded)
     {
         return StatusCode(StatusCodes.Status201Created, isAdded);
     }
     else
     {
         return StatusCode(StatusCodes.Status404NotFound, isAdded);
     }
 }
```
- We can specify the response type also
```c#
 [HttpGet]
[Route("get/{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
public IActionResult GetById(int id)
{
    var product = _productBL.GetProductById(id);
    //return Ok(products);
    return StatusCode(StatusCodes.Status200OK, product);
}


```

### We can configure JSONOptions also like this 
```c#
  builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
```

- Content negotiation in WebAPI allows clients to specify their preferred response format using the Accept header. 
- The server uses MediaTypeFormatters to serialize the response in the appropriate format. 
- By configuring formatters and handling content negotiation properly, you can build flexible and interoperable APIs that cater to various client preferences.

## API Versioning
- Version using querystring 
- Version using Headers 
- Version using MediaType 
  
- Install Nuget package :
```shell
  //Deprecated
  Install-Package Microsoft.AspNetCore.Mvc.Versioning

  //Latest one
  Install-Package Asp.Versioning.Mvc.ApiExplorer
```
- Configure versioning in Program.cs like this 
```c#
 public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("x-api-version"),
            new MediaTypeApiVersionReader("v"));
    });
}


```
- Inside controllers we can do this 
```c#
//Version 1

[ApiController]
[Route("api/v{version:apiVersion}/values")]
[ApiVersion("1.0")]
public class ValuesV1Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "This is version 1.0" });
    }
}

//Version 2
[ApiController]
[Route("api/v{version:apiVersion}/values")]
[ApiVersion("2.0")]
public class ValuesV2Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "This is version 2.0" });
    }
}



```
- Clients can access different versions of your API using query strings, headers, or media types, depending on how you've configured the ApiVersionReader.
- Using querystring: 
  ```shell
  GET /api/v1.0/values?api-version=1.0
  GET /api/v2.0/values?api-version=2.0

  ```
- Using headers 
```c#
  GET /api/v1.0/values
 Header: x-api-version: 1.0

 GET /api/v2.0/values
 Header: x-api-version: 2.0

```
- Using Media Type 
```c#
 GET /api/v1.0/values
Header: Accept: application/json; v=1.0

GET /api/v2.0/values
Header: Accept: application/json; v=2.0

```
- We can mark Api versions as deprecated as follows :
```c#
 [ApiController]
[Route("api/v{version:apiVersion}/values")]
[ApiVersion("1.0")]
[ApiVersion("1.0", Deprecated = true)]
public class ValuesV1Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "This is version 1.0 (Deprecated)" });
    }
}


```

- To do versioning do these changes in Program.cs file like this 
```c#

builder.Services.AddApiVersioning()
.AddMvc(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention());
    options.Conventions.Controller<WebAPI.V1.Controllers.ProductAPIController>().HasApiVersion(1.0);
    options.Conventions.Controller<WebAPI.V2.Controllers.ProductAPIV2Controller>().HasApiVersion(2.0);
});

```
- Controllers will look like this 
```c#

namespace WebAPI.V2.Controllers
{
    [ApiVersion(2.0)]
    [Route("api/v{version:apiVersion}/productapi")]
    [Route("api/productapi")]
    [ApiController]
    public class ProductAPIV2Controller : ControllerBase
    {
        private readonly IProductBL _productBL;
        public ProductAPIV2Controller(IProductBL productBL)
        {
            _productBL = productBL;
        }


        [Route("getall")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productBL.GetAllProducts();
            //return Ok(products);
            return StatusCode(StatusCodes.Status200OK, products);
        }

        
    }
}


namespace WebAPI.V1.Controllers
{
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/productapi")]
    [Route("api/productapi")]
    [ApiController]
    
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductBL _productBL;
        public ProductAPIController(IProductBL productBL)
        {
            _productBL = productBL;
        }


        [Route("getall")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productBL.GetAllProducts();
            //return Ok(products);
            return StatusCode(StatusCodes.Status200OK, products);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct([FromBody] ProductViewModel productVM)
        {
            var isAdded = _productBL.AddProduct(productVM);
            if (isAdded)
            {
                return StatusCode(StatusCodes.Status201Created, isAdded);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, isAdded);
            }
        }

        
    }
}



```

## Minimal APIs
- We can write this code in Program.cs only 
- This is usually for small apis which have no dependencies.
- We can have a separate extension method for minimal apis and use them.

```c#
 app.MapGet("/getname/{id}", (string id) => $"Hello {id}");

 app.MapGet("/list", (IProductBL productBL) => 
GetAllProducts(productBL)).Accepts<List<ProductViewModel>>("application/json");

 IResult GetAllProducts(IProductBL productBL)
{
    return Results.Ok(productBL.GetAllProducts());
}
```

## JWT Authentication in WebAPI
- Make this change in Program.cs file 
```c#

//Responsible for validating the JWT 
 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer( config =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
    
   
});

```
- Add an AuthAPIController.cs file 
```c#
 namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController(IUserBL userBL, IConfiguration configuration) : ControllerBase
    {

        [HttpPost]
        [Route("auth")]
        public IActionResult Authenticate(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel loggedInUser = userBL.ValidateUser(loginViewModel);
                if (!string.IsNullOrEmpty(loggedInUser.EmailId))
                {
                    string token = userBL.GenerateToken(loggedInUser);
                    return StatusCode(StatusCodes.Status200OK, new { message = "success", token = token });
                }

            }
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "failure" });
        }

    }
}

```
- If inside the Authorize attribute, we specify the Role and the JWT token contains a different role, we will get a 403 Forbidden instead of 401 UnAuthorized
- 401 Unauthorized status code is returned if the Bearer Token is not specified 
- Claim is the payload we want in our token
- JWT Token validation in WebAPI is done by the following code:
```c#
 //Responsible for validating the JWT 
 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer( config =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
    
   
});

```
- In .NET 9 , swagger has been removed by default 
- We now have a .http file which contains all the apis we have in our application.
- We can use Endpoints Explorer in Visual Studio

## Calling WebAPI from javascript 

```c#
  <script>

     $(document).ready(function () {
     loadProducts();

     $('#btnSave').click(saveProduct);
 });

 function loadProducts(){
     $.ajax({
         url:'https://localhost:7126/api/v1.0/productapi/getall',
         type: 'GET',
         headers: {
             "Authorization": "Bearer" + localStorage["token"]
         },
         success: (response) => {
             var tbody = $('#tblProducts > tbody');
             tbody.html('');
             $.each(resp, (k, v) => {
                 var tr = $('<tr></tr>');
                 tr.append(`<td>${v.pid}</td>`);
                 tr.append(`<td>${v.ProductName}</td>`);
                 tr.append(`<td>${v.Price}</td>`);
                 tr.appendTo(tbody);
             });
         },
         error: (err) => {
             console.log(err);
         }
     })
 }

 function saveProduct() {
     let productToAdd = {
         ProductName: $('#productName').val(),
         ProductCode: $('#productCode').val(),
         Price: $('#price').val(),
             CategoryId: 1
     };

     $.ajax({
         url: "https://localhost:7126/api/v1.0/productapi/add",
         type: 'POST',
         headers: {
            "Authorization": "Bearer" + localStorage["token"],
            "Content-Type": "application/json"
         },
         data: JSON.stringify(productToAdd),
         success: (resp) => {
             if(resp) {
                 alert("Product Added");
                 loadProducts();
             }
         },
         error: (err) => {
             console.log(err);
         }
     })
 }
</script>

```
- This will give a CORS issue. To fix it we will have to enable CORS in our webapi Program.cs file 
```c#

//Add a Service
  builder.Services.AddCors(config =>
{
    config.AddPolicy("mypolicy", opt =>
    {
        opt.AllowAnyHeader();
        //Url of web application which is calling this API
        opt.WithOrigins("https://localhost:7066");
        opt.AllowAnyMethod();
    });
});


//Use Cors Policy
app.UseCors("mypolicy")

```