# Controllers 🍪

Controllers in ASP.NET MVC are simply classes with methods (Actions) that represent the end-points or points from or to where we want to send data. The controller class you create must always inherit from an existing controller class from the ASP.NET framework and it must always be in a folder called controllers. We can always create our class and inherit from the correct ASP.NET class and create the methods on our own, but Visual Studio makes it easy for us by giving us an option to create a preset controller. This is done by right-clicking on the **Controllers** folder -> Add -> Controller and choosing the MVC Empty template. Controllers are named with PascalCase and they ALWAYS HAVE **Controller** at the end. If they are not named in this way, the application might not work as intended.

An example of a simple controller:

```csharp
public class HomeController : Controller // Must inherit from Controller
{
// A method ( Action )
public IActionResult Index() // localhost:port/home/index
{
    return View(); // When it is called it returns a view
}
}
```

## Actions 🔹

Actions are the methods that we have in the controller. Actions are the main source of interaction in and out of the controller. Every action has an address and when that address is called, the action is executed. With this, the action can execute some code and return a view or a view with some result in it. The actions can be annotated depending on the request they are waiting for. This means that we can have actions that wait for a GET request, POST request, etc. In ASP.NET Core MVC applications if we don't annotate our actions, they are by default GET. If we want to explicitly mark an action with what kind of request it waits we can use the [HttpXXX] attribute. Ex: GET -> [HttpGet]

```csharp
public class HomeController : Controller
{
[HttpGet]
public IActionResult Index() // localhost:port/home/index
{
    return View();
}
}
```

### View Result

An action can return a view. This means that if someone were to access the address of that action through the browser, they will get an HTML page back. Attaching a view to an action can be done by creating a folder with the controller name in the **Views** folder and inside creating a file with the same name as the action. Ex:

- we have **HomeController** and inside **Index** action
- we create **Home** folder in the **Views** folder and inside that folder, we create a view called **Index**

That was the manual approach. Visual Studio offers a shorter and automatic way of doing this. If we click right-click on the action itself ( the line of code where we declare it ) there is an option **Add View**. If we click that and click **OK** it will automatically create the folder structure if it does not exist and create the view with some default HTML. If we don't want to return a view by the same name as the action we can always pass a name (string) and tell the Action Result what view to return from that controller folder.

### Action Result

The results that the action gives back to the browser whether it is a view or some other type of result are always packaged in an Action Result. That is why the controller returns IActionResult meaning it will return some action that inherits from IActionResult interface. There are multiple actions that we can return. Some of them are:

- ViewResult - A result used when we want to return some view

```csharp
// Empty View() will get the view corresponding with this action ( Index )
public IActionResult Index()
{
    return View(); // return type: ViewResult
}
```

```csharp
// A string parameter will return a view by that name from that controller
public IActionResult Index()
{
    return View("Home"); // return type: ViewResult
}
```

- EmptyResult - A result representing an empty result ( When we don't want to return anything but the browser expects a response )

```csharp
public IActionResult Alert()
{
    // Code that alerts someone
    return new EmptyResult(); // return type: EmptyResult
}
```

- RedirectResult - A result that redirects us on the browser to another action

```csharp
// RedirectToAction accepts an action name (string) and redirects to that action from the same controller
public IActionResult Order(int? id)
{
    // Return type must be IActionResult to cover both return types
    if (id.HasValue) return View(); // return type: ViewResult
    return RedirectToAction("Index"); // return type: RedirectToActionResult
}
```

```csharp
// RedirectToAction accepts an action name(string) and a controller name(string) and redirects to that action from that controller
public IActionResult Order(int? id)
{
    // Return type must be IActionResult to cover both return types
    if (id.HasValue) return View(); // return type: ViewResult
    return RedirectToAction("Index", "Orders"); // return type: RedirectToActionResult
}
```

- JsonResult - A result containing a JSON string

```csharp
// JsonResult accepts an object, converts it to json automatically and returns it
public IActionResult OrderData()
{
    var order = new { Id = 12, IsDelivered = false }; // Dummy Order
    return new JsonResult(order); // return type: JsonResult
}
```

## Routing 🔹

To access our actions in our controllers from the browser we need an address. In our application, the handling of requests to addresses is called routing and the addresses to the actions are called routes. The routing is already set with the default setup of our ASP.NET MVC project. That is the default routing and there is no need for extra configuration. If we leave the routing by default the routes would look like this:

- website(localhost)/ControllerName/ActionName
- website(localhost)/ControllerName/ActionName/ExtraParameter

Keep in mind that the name of the controller should be written without the Controller suffix. If we want to add custom routes we can do that in two ways: By changing the router or by adding routing attributes to our action or controller depending on what we need to customize and change.

### The Router

The router can be found in **Program.cs**.

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

There we can find the default settings for our router, the order in which the routes are accessed, and the default values for the controller and action. There is also an **id?** parameter. The question mark indicates that this parameter is optional. We can also add new routes to the router. The default one is localhost:port/Home/Index and will be hit if we type that address or write the name of the page ( localhost:port ).

### Routing Attributes

Routing can be done with routing attributes as well. Attributes are rules that we add in **[ ]** brackets above methods or classes ( actions and controllers in our case ). With these routing attributes, we can change and override the routing at the exact point where we need a custom route. This means that we can create a custom route for a particular controller or an action by just annotating above that controller or action what the new route would be. We can do this with the **Route** annotation:

```csharp
// Custom route for the controller. Action names stay the same
[Route("App/[Action]")]
public class HomeController : Controller
{
    public IActionResult Index() // localhost:port/app/index
    {
        return View();
    }
    public IActionResult Contact() // localhost:port/app/contact
    {
        return View();
    }
}
```

```csharp
[Route("App")]
public class HomeController : Controller
{
    [Route("Start")]
    public IActionResult Index() // localhost:port/app/start
    {
        return View();
    }
    [Route("CallMe")]
    public IActionResult Contact() // localhost:port/app/callme
    {
        return View();
    }
}
```

A good thing to mention is that if we leave the route of the controller, but add custom routes to the actions, the actions can be accessed directly without typing the name of the controller in the address

```csharp
public class HomeController : Controller
{
    [Route("Start")]
    public IActionResult Index() // localhost:port/start
    {
        return View();
    }
    [Route("CallMe/Now")]
    public IActionResult Contact() // localhost:port/callme/now
    {
        return View();
    }
}
```

We can also create custom routes for actions by combining the **HttpGet** attribute and the **Route** attribute:

```csharp
[Route("App")]
public class HomeController : Controller
{
    [HttpGet("Start")]
    public IActionResult Index() // localhost:port/app/start
    {
        return View();
    }
    [HttpGet("CallMe")]
    public IActionResult Contact() // localhost:port/app/callme
    {
        return View();
    }
}
```

```csharp
public class HomeController : Controller
{
    [HttpGet("Start")]
    public IActionResult Index() // localhost:port/start
    {
        return View();
    }
    [HttpGet("CallMe")]
    public IActionResult Contact() // localhost:port/callme
    {
        return View();
    }
}
```

### Routing with extra parameters

As we can tell from the default router of an ASP.NET Core MVC application, we can access an action by writing the controller name first and then the action name. But we can add an extra parameter as well. This is optional. To use this optional parameter we need to create an action first that accepts a parameter, to begin with. This is because C# as a language sees methods with the same names but different parameters as different methods. This is why our method that does not wait for anything ( does not have a parameter ) can't catch the requests from the address when we pass in an extra parameter.

```csharp
// id will get the number from the address ( 12 )
public IActionResult Contact(int? id) // localhost:port/home/contact/12
{
    return View();
}
```

![How a Controller works](img/controller.png)

## Extra Materials 📘

- [ASP.NET Core Action Results In Depth](http://hamidmosalla.com/2017/03/29/asp-net-core-action-results-explained/)
- [Deep Dive in ASP.NET Core Routing](https://stormpath.com/blog/routing-in-asp-net-core)
- [ASP.NET Core MVC and Controllers](https://www.youtube.com/watch?v=2n7keI_E8tE)
