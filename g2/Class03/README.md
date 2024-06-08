# What is a Model?

In software development, a model is a fundamental concept that represents the application's data, business logic, and behavior. It encapsulates the structure, state, and operations of the data entities within the application's domain. Models play a crucial role in MVC (Model-View-Controller) architecture and other software design patterns, providing a structured way to organize and manage the application's data.

A model can be thought of as a blueprint or template for representing real-world entities or concepts within a software application. It defines the attributes, properties, and behaviors associated with the entities, as well as the relationships between them. Models abstract away the complexities of data management and manipulation, providing a clean and organized representation of the application's domain.

### Characteristics of Models:

1. **Data Representation**: Models define the structure and attributes of the data entities within the application. They encapsulate the state of the entities, including their properties, relationships, and constraints.

2. **Business Logic**: Models encapsulate the business rules, validation logic, and behavior associated with the data entities. They enforce data integrity, perform data validation, and implement business logic operations such as calculations, transformations, and validations.

3. **Data Access**: Models may interact with data storage mechanisms such as databases, files, or external services to retrieve, store, and manipulate data. They abstract away the details of data access, providing a uniform interface for accessing and manipulating data regardless of the underlying data source.

## Usage of Models

Models are used across various layers and components of a software application, including:

- **Domain Layer**: In the domain layer, models represent the core entities and concepts within the application's domain. They define the data structures and business rules that govern the behavior of the application.

- **Data Access Layer**: In the data access layer, models are often used to map database tables to object-oriented representations. They provide a way to interact with the database through ORM (Object-Relational Mapping) frameworks, abstracting away the details of database interactions.

- **Application Logic**: Models are used to implement application-specific logic, such as data validation, calculations, and business rules enforcement. They encapsulate the behavior and state of the application's data entities, ensuring consistency and integrity in data operations.

- **User Interface**: In user interface components, models are used to bind data to user interface elements such as forms, controls, and views. They provide a way to display and manipulate data within the user interface, facilitating user interaction and data presentation.


# Types of Models

## 1. Domain Models

Domain models represent the entities and business concepts within the application's domain. They typically map directly to database tables or other data sources and encapsulate the business logic and behavior associated with those entities. Domain models often include properties that correspond to the attributes of the entities, as well as methods for performing domain-specific operations.

Example:
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
}
```

## 2. View Models

View models are specialized models designed to facilitate communication between controllers and views in the MVC pattern. They contain only the data required for rendering the view and handling user input, thus improving separation of concerns and maintainability.

Example:
```csharp
public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsInStock { get; set; }
}
```

## 3. Data Transfer Objects (DTOs)

Data transfer objects are lightweight, serializable objects used to transfer data between different layers of an application or between the application and external systems. They typically contain only data fields and no behavior.

Example:
```csharp
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

## 4. ViewModels (in MVVM)

ViewModels act as an intermediary between the view and the model, exposing properties and commands that the view can bind to. They contain presentation logic and formatting logic, preparing data for display in the view and handling user interactions.

Example:
```csharp
public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string FormattedPrice => Price.ToString("C");

    public void BuyProduct() {
        // Logic for buying the product
    }
}
```


## Extra Materials 📘

- [Model and ViewModel](https://www.tektutorialshub.com/asp-net-core/asp-net-core-model-and-viewmodel/)