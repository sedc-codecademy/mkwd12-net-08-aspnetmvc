# Model Binding in .NET Core

**Model Binding** is a mechanism in the ASP.NET Core Application that extracts the data from an HTTP request and provides them to the controller action method parameters or object properties. The action method parameters can be simple types like integers, strings, etc., or complex types such as Student, Order, Product, etc.

## Parameter Binding

In ASP.NET Core MVC, parameters can be bound to action methods. For example:

```csharp
public IActionResult Index(int id)
{
    // code here
}
```

In the above code, the `id` parameter is bound from the request.

## Model Binding

Model binding maps data from HTTP requests to action method parameters. The parameters may be simple types such as strings, integers, or floats, or they may be complex types. This is a great feature of MVC because mapping incoming data to a counterpart is an often repeated scenario, regardless of size or complexity of the data.

Here's an example of model binding:

```csharp
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
}

public IActionResult Index(Student std)
{
    // code here
}
```

In the above code, the `std` parameter is a complex type and it's bound from the request.

## Binding Attributes

Binding attributes are used to specify where the action method parameters or the properties of the complex object should be bound from. Here are some of the commonly used binding attributes:

- `[FromQuery]`: Binds the parameter from the query string.
- `[FromRoute]`: Binds the parameter from the route data.
- `[FromForm]`: Binds the parameter from the form data.
- `[FromBody]`: Binds the parameter from the request body.

Here's an example of how to use binding attributes:

```csharp
public IActionResult Update([FromQuery]int id, [FromForm]Student std)
{
    // code here
}
```

In the above code, the `id` parameter is bound from the query string, and the `std` parameter is bound from the form data.


# Data Annotations in ASP.NET MVC

## Validation on View Models

View models are classes that represent data to be displayed or posted back from a view. Here's an example of a view model with validation rules:

```csharp
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
```
In this example, the `Required` attribute indicates that a property must have a value; `EmailAddress` attribute checks if the property has a valid email format; `StringLength` specifies the minimum and maximum length of characters; `DataType` specifies the type of data; `Display` specifies the display name for a property; and `Compare` ensures that two properties in a model match.

## Validation on Domain Models

Domain models represent the data in your application's business domain and often correspond to tables in a database. Here's an example of a domain model with validation rules:

```csharp
public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Range(0, 999.99)]
    public decimal Price { get; set; }

    [Required]
    public string Category { get; set; }
}
```
In this example, the `Range` attribute constrains a value to a specified range. The `Price` property must be between 0 and 999.99.

When you use these models with a view, ASP.NET MVC's model binding will validate the data based on these annotations and add any validation errors to the `ModelState` object. You can check `ModelState.IsValid` in your action methods to see if the posted data is valid.

# Model Validation and Error Display in ASP.NET MVC

## Validate the Model in the Controller

In your controller action, you can use the `ModelState.IsValid` property to check if the model is valid. This property will be `false` if any of the validation rules defined by the Data Annotations were violated.

Here's an example:

```csharp
[HttpPost]
public ActionResult Create(Product product)
{
    if (ModelState.IsValid)
    {
        // Save the product to the database
        // ...

        return RedirectToAction("Index");
    }

    // If we got this far, something failed, redisplay form
    return View(product);
}
```

In this example, if the model is valid, the product is saved to the database and the user is redirected to the Index view. If the model is not valid, the Create view is redisplayed with the current product data.

## Display Errors in the View

You can use the `Html.ValidationMessageFor` helper method in your view to display validation errors. This method generates a `span` element that contains the validation error message for a specific property.

Here's an example:

```html
@model Product

@using (Html.BeginForm())
{
    @Html.LabelFor(m => m.Name)
    @Html.EditorFor(m => m.Name)
    @Html.ValidationMessageFor(m => m.Name)

    @Html.LabelFor(m => m.Price)
    @Html.EditorFor(m => m.Price)
    @Html.ValidationMessageFor(m => m.Price)

    <input type="submit" value="Create" />
}
```

In this example, if there are any validation errors for the `Name` or `Price` properties, they will be displayed next to the corresponding input field.
