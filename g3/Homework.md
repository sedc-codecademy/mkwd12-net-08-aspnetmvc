# ***__Video rental online store__***

## Application requirements

### Models

- **User**: This model represents a user in the system. It includes properties like `Id`, `FullName`, `Age`, `CardNumber`, `CreatedOn`, `IsSubscriptionExpired`, and `SubscriptionType`. The `SubscriptionType` indicates the type of subscription the user has.

- **Movie**: This model represents a movie available for rent. It includes properties like `Id`, `Title`, `Genre`, `Language`, `IsAvailable`, `ReleaseDate`, `Length`, `AgeRestriction`, and `Quantity`. The `Genre` and `Language` are enumerations, providing a predefined set of values. The `IsAvailable` property indicates whether the movie is currently available for rent.

- **Cast**: This model represents a person involved in the making of a movie, such as an actor or director. It includes properties like `Id`, `Name`, `MovieId`, and `Part`. The `Part` is an enumeration, indicating the role of the person in the movie.

- **Rental**: This model represents a rental transaction. It includes properties like `Id`, `MovieId`, `UserId`, `RentedOn`, and `ReturnedOn`. The `MovieId` and `UserId` link the rental to the relevant movie and user.

- **SubscriptionType**: This is an enumeration that represents the type of subscription a user has. It can have values like `Monthly`, `Yearly`, etc.

- **Genre**: This is an enumeration that represents the genre of a movie. It can have values like `Action`, `Comedy`, `Drama`, etc.

- **Language**: This is an enumeration that represents the language of a movie. It can have values like `English`, `Spanish`, `French`, etc.

- **Part**: This is an enumeration that represents the role of a person in the making of a movie. It can have values like `Actor`, `Director`, `Camera`, etc.


```csharp
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string CardNumber { get; set; }
    public DateTime CreatedOn { get; set; }}
    public bool IsSubscriptionExpired { get; set; }
    public string SubscriptionType { get; set; } // Consider using an Enum here
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; } // Consider using an Enum here
    public string Language { get; set; } // Consider using an Enum here
    public bool IsAvailable { get; set; }
    public DateTime ReleaseDate { get; set; }
    public TimeSpan Length { get; set; }
    public int AgeRestriction { get; set; }
    public int Quantity { get; set; }
}

public class Cast
{
    public int Id { get; set; }
    public string MovieId { get; set; }
    public string Name { get; set; }
    public string Part { get; set; } // Consider using an Enum here
}

public class Rental
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime ReturnedOn { get; set; }
}

if (you want to use enums) 
{
    public enum SubscriptionType
    {
        Monthly,
        Yearly,
        // Add more subscription types as needed
    }

    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        SciFi,
        // Add more genres as needed
    }

    public enum Language
    {
        English,
        Spanish,
        French,
        German,
        // Add more languages as needed
    }

    public enum Part
    {
        Actor,
        Director,
        Camera,
        Sound,
        Visuals,
        Other
        // Add more roles as needed
    }
}
```

### Requirements 

- **User Login**: Even though you're not using authentication, you still need a way to identify users. You could create a simple login page where users enter their `CardNumber` or you can use `Email`. Once they're logged in, you can store their `User` object in a session variable or use ViewData to pass the user information between different requests.

- **View Movies**: Create a page that displays a list or grid of all the movies. Each item should show basic information about the movie, such as the title and genre. You could also show whether the movie is currently available for rent.

- **Movie Details**: Each movie in the list should be clickable and lead to a detailed page for that movie. This page should display all the information about the movie, such as the title, genre, language, release date, length, age restriction, and quantity available.

- **Rent Movie**: If a movie is available (i.e., the quantity is more than 0), show a "Rent" button on the movie's detail page. When this button is clicked, create a new `Rental` object, link it to the current user and the movie. Don't forget to decrease the quantity of the movie.

 - **Return Movie**: Create a page that shows all the movies currently rented by the user. Each item should have a "Return" button. When this button is clicked, find the corresponding `Rental` object in the `Rentals` list using the `Rental.Id`, `Rental.UserId`, and `Rental.MovieId`. Set the `ReturnedOn` property of the `Rental` object to the current date and time. Also, find the corresponding `Movie` object using `Rental.MovieId` and increase the `Quantity` of the `Movie` object by 1, indicating that the movie has been returned and is now available for rent again.
