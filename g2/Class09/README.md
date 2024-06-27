## Entity Framework 6 and the Basics

Entity Framework (EF) is an Object-Relational Mapping (ORM) framework that enables developers to work with databases using .NET objects. EF 6 is a version of Entity Framework that provides a variety of features for data access in .NET applications.

### Installation

To use Entity Framework 6 in your project, you can install it via NuGet Package Manager:

```bash
Install-Package EntityFramework
```

### Database First vs Code First

Entity Framework supports two primary development approaches: Database First and Code First.

- **Database First**: In this approach, you start by designing your database schema, and EF generates entity classes based on the existing database structure.

- **Code First**: With Code First, you define your entity classes in code, and EF generates the database schema based on these classes.


## What is the DbContext Class?

The `DbContext` class is a fundamental component of Entity Framework that represents a session with the database and serves as a bridge between your domain/entity classes and the database. It encapsulates the Entity Framework Core components required to interact with the database, such as change tracking, querying, and database connection management.

### Key Concepts:

1. **Session with the Database**: An instance of the `DbContext` class represents a session with the database. It maintains a connection to the database, tracks changes to entities, and orchestrates the interaction between your application and the database.

2. **Entity Sets (DbSets)**: The `DbContext` class typically contains properties representing entity sets, also known as `DbSet<T>`. Each `DbSet<T>` property corresponds to a table in the database and allows you to perform CRUD (Create, Read, Update, Delete) operations on entities of type `T`.

3. **Change Tracking**: The `DbContext` class tracks changes made to entities within its scope. It detects modifications to entity properties and keeps track of which entities have been added, modified, or deleted since they were last queried from or saved to the database.

### Creating a DbContext Class

To create a `DbContext` class, you typically derive from the `DbContext` base class provided by Entity Framework:

```csharp
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    // Other DbSet properties for entity classes
}
```

In this example, `MyDbContext` is a custom `DbContext` class that represents a session with the database. It contains `DbSet` properties for the `Customer` and `Order` entities.

### Configuring Connection String

The constructor of the `DbContext` class typically specifies the connection string to be used for connecting to the database. You can provide the connection string name defined in the application configuration file (`web.config` or `app.config`).

```csharp
public MyDbContext(DbContextOptions options) : base(options) { }
```

### Querying Data

You can query data from the database using LINQ (Language Integrated Query) within the scope of a `DbContext` instance. Entity Framework translates LINQ queries into SQL queries to retrieve data from the database.

```csharp
using (var context = new MyDbContext())
{
    var customers = context.Customers.Where(c => c.City == "London").ToList();
}
```

This LINQ query retrieves all customers from the `Customers` table where the `City` property is equal to "London".

### Saving Changes

To persist changes made to entities to the database, you call the `SaveChanges` method on the `DbContext` instance.

```csharp
using (var context = new MyDbContext())
{
    var newCustomer = new Customer { Name = "John Doe", City = "New York" };
    context.Customers.Add(newCustomer);
    context.SaveChanges();
}
```

This code snippet adds a new customer entity to the `Customers` table and saves the changes to the database.

The `DbContext` class in Entity Framework serves as a central component for interacting with the database in your application. It provides a high-level abstraction over the underlying database operations, allowing you to focus on working with domain/entity classes rather than dealing with database-specific details. By creating a custom `DbContext` class and utilizing its features such as entity sets, change tracking, and LINQ querying, you can efficiently manage data persistence within your application.


## What is the DbSet Class?

The `DbSet` class in Entity Framework represents a collection of entities of a specific type in the context of the database. It acts as a gateway for querying, inserting, updating, and deleting entities of that type within the database.

### Key Concepts:

1. **Entity Type**: A `DbSet` corresponds to a specific entity type in your application. For example, if you have a `Customer` entity class, you would typically have a `DbSet<Customer>` property in your `DbContext` to represent the collection of customers.

2. **Database Table**: Each `DbSet` maps to a database table with the same name as the entity type. Entity Framework automatically generates SQL queries to interact with this table based on the LINQ queries and operations you perform on the `DbSet`.

### Creating DbSet Properties

To define a `DbSet` property in your `DbContext`, you typically declare a public property of type `DbSet<T>` where `T` is your entity type.

```csharp
public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    // Other DbSet properties for entity classes
}
```

In this example, `Customers` and `Orders` are `DbSet` properties representing collections of `Customer` and `Order` entities, respectively.

### Querying Data

You can query data from a `DbSet` using LINQ (Language-Integrated Query). Entity Framework translates LINQ queries into SQL queries to fetch data from the database.

```csharp
using (var context = new MyDbContext())
{
    var customersInLondon = context.Customers.Where(c => c.City == "London").ToList();
}
```

This LINQ query retrieves all customers from the `Customers` table where the `City` property is equal to "London".

### Adding and Updating Data

You can add new entities to a `DbSet` using the `Add` method.

```csharp
var newCustomer = new Customer { Name = "John Doe", City = "New York" };
context.Customers.Add(newCustomer);
context.SaveChanges();
```

Similarly, you can update existing entities by modifying their properties and then calling `SaveChanges` to persist the changes to the database.

```csharp
var customer = context.Customers.Find(1);
customer.City = "Los Angeles";
context.SaveChanges();
```

### Deleting Data

To delete an entity from a `DbSet`, you can use the `Remove` method and then call `SaveChanges`.

```csharp
var customer = context.Customers.Find(1);
context.Customers.Remove(customer);
context.SaveChanges();
```

This removes the specified customer entity from the `Customers` table.


The `DbSet` class in Entity Framework provides a convenient and efficient way to interact with entities in your database. By defining `DbSet` properties in your `DbContext` and using methods like `Add`, `Remove`, and LINQ queries, you can perform CRUD operations and query data with ease. It serves as a bridge between your entity classes and the underlying database tables, enabling seamless data manipulation within your application.

## What are Migrations?

Migrations in Entity Framework are a way to manage changes to your database schema over time, allowing you to evolve your database schema alongside your application's codebase. Rather than manually updating the database schema every time you make a change to your entity classes, migrations enable you to define these changes in code and apply them to the database in a structured and automated manner.

### Key Concepts:

1. **Migration Files**: Each migration is represented by a migration file, which contains code to describe the changes to be applied to the database schema. These files are generated automatically by Entity Framework when you create a new migration.

2. **Migration History**: Entity Framework maintains a record of all applied migrations in a special table called `__MigrationHistory` in your database. This table keeps track of which migrations have been applied and in what order.

3. **Migration Operations**: Migration files contain instructions to perform various database schema operations, such as creating tables, modifying columns, adding indexes, etc. Entity Framework translates these operations into SQL commands to execute against the database.

## Using Migrations

### 1. The First Migration
To manage the migrations, we’ll use dotnet ef tools, so let’s install them by running this in the cmd:
```bash
dotnet tool install --global dotnet-ef
```

### 2. Creating Migrations

Create a new migration whenever you make changes to your entity classes. To create a new migration, run the following command in PMC:

```bash
dotnet ef migrations add <MigrationName>
```

Replace `<MigrationName>` with a descriptive name for your migration. This command will generate a new migration file in your project's Migrations folder.

### 3. Reviewing Migration Code

Open the generated migration file to review the code. It contains two main methods: `Up` and `Down`.

- **Up**: Contains code to apply the changes to the database schema.
- **Down**: Contains code to revert the changes if the migration needs to be rolled back.

### 4. Applying Migrations

Once you're satisfied with the changes in the migration file, you can apply the migration to the database using the following command:

```bash
dotnet ef database update
```

This command executes the `Up` method of the pending migration and updates the database schema accordingly. Entity Framework also updates the `__MigrationHistory` table to reflect that the migration has been applied.

### 5. Rolling Back Migrations

If you need to revert a migration, you can use the `Update-Database` command with the `-TargetMigration` parameter to specify the target migration to roll back to:

```bash
dotnet ef database update -TargetMigration <TargetMigrationName>
```

This command will execute the `Down` method of migrations from the current state to the specified target migration, effectively rolling back the changes.


Migrations in Entity Framework provide a structured and automated way to manage database schema changes, making it easier to evolve your database alongside your application. By enabling migrations, creating migration files, and applying them to the database, you can maintain a consistent and up-to-date database schema throughout the development lifecycle of your application.
