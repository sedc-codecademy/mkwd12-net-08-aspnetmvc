# HTML Helpers in .NET

HTML Helpers in ASP.NET MVC are methods that return a string. They are used to create HTML elements in views. They provide a way to generate HTML markup programmatically, which can help keep your views clean and maintainable.

Here's an example of how to use an HTML helper to create a form:

```csharp
@using (Html.BeginForm("Action", "Controller", FormMethod.Post))
{
    @Html.LabelFor(model => model.Property)
    @Html.EditorFor(model => model.Property)
    @Html.ValidationMessageFor(model => model.Property)
    <input type="submit" value="Submit" />
}
```

In this example, `Html.BeginForm` creates a `<form>` element, `Html.LabelFor` creates a `<label>` element, `Html.EditorFor` creates an `<input>` element, and `Html.ValidationMessageFor` creates a validation message if there's a model error for the specified property.

# Tag Helpers in .NET

Tag Helpers in ASP.NET Core MVC are a new way to create dynamic HTML. They are similar to HTML Helpers, but they have a more HTML-like syntax, which can make your views more readable.

Here's an example of how to use a Tag Helper to create the same form:

```html
<form asp-action="Action" asp-controller="Controller" method="post">
    <label asp-for="Property"></label>
    <input asp-for="Property" />
    <span asp-validation-for="Property"></span>
    <input type="submit" value="Submit" />
</form>
```

In this example, the `asp-*` attributes are Tag Helpers. They're used to generate the same HTML as the HTML Helpers in the previous example, but with a more HTML-like syntax.

Both HTML Helpers and Tag Helpers can be useful in different situations. HTML Helpers can be more familiar if you're used to traditional ASP.NET MVC, while Tag Helpers can be more readable if you're used to front-end development with HTML.


# DATA PASSING TECHNIQUES

# ViewData

`ViewData` is a dictionary object that is derived from `ViewDataDictionary` class. You can use it to pass data from controllers to views.

Here's an example of how to use `ViewData`:

```csharp
public ActionResult Index()
{
    ViewData["Message"] = "Hello, World!";
    return View();
}
```

In the view, you can access `ViewData` like this:

```csharp
<p>@ViewData["Message"]</p>
```

# ViewBag

`ViewBag` is a dynamic property that takes advantage of the new dynamic features in C# 4.0. It allows you to share values dynamically between the controller and the view.

Here's an example of how to use `ViewBag`:

```csharp
public ActionResult Index()
{
    ViewBag.Message = "Hello, World!";
    return View();
}
```

In the view, you can access `ViewBag` like this:

```csharp
<p>@ViewBag.Message</p>
```

# ViewModels

A `ViewModel` is a class that contains the properties you need in your view. It allows you to shape multiple entities into a single object, which can be useful for aggregation, computation, and more.

Here's an example of a `ViewModel`:

```csharp
public class HomeViewModel
{
    public string Message { get; set; }
}
```

You can use it in your controller like this:

```csharp
public ActionResult Index()
{
    var viewModel = new HomeViewModel
    {
        Message = "Hello, World!"
    };

    return View(viewModel);
}
```

And in your view, you can access the `ViewModel` like this:

```csharp
@model HomeViewModel

<p>@Model.Message</p>
```

# TempData

`TempData` is a dictionary object derived from `TempDataDictionary` class. It is used to store temporary data which can be used in the subsequent request. `TempData` can be useful for redirections, when you need to retain some data.

Here's an example of how to use `TempData`:

```csharp
public ActionResult FirstAction()
{
    TempData["Message"] = "Hello, World!";
    return RedirectToAction("SecondAction");
}

public ActionResult SecondAction()
{
    var message = TempData["Message"];
    return View();
}
```

In the view of `SecondAction`, you can access `TempData` like this:

```csharp
<p>@TempData["Message"]</p>
```

