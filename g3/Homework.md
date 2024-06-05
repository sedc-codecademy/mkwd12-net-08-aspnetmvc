# ***__Video rental online store__***

## Application requirements

### Models

- **User**: 
- **Movie**: 
- **Rental**: 
- **SubscriptionType**: 

- **Genre**: #Enum

- **Language**: #Enum

- **Part**: #Enum


### Requirements 

- **User Login**: Even though you're not using authentication, you still need a way to identify users.
-  You could create a simple login page where users enter their `CardNumber` or you can use `Email`.
-   Once they're logged in, you can store their `User` object in a session variable or use ViewData to pass the user information between different requests.

- **View Movies**: Create a page that displays a list or grid of all the movies.
-  Each item should show basic information about the movie, such as the title and genre.
-   You could also show whether the movie is currently available for rent.

- **Movie Details**: Each movie in the list should be clickable and lead to a detailed page for that movie.
-  This page should display all the information about the movie, such as the title, genre, language, release date, length, age restriction, and quantity available.

- **Rent Movie**: If a movie is available (i.e., the quantity is more than 0), show a "Rent" button on the movie's detail page. When this button is clicked, create a new `Rental` object, link it to the current user and the movie. Don't forget to decrease the quantity of the movie.

 - **Return Movie**: Create a page that shows all the movies currently rented by the user.
 -  Each item should have a "Return" button. When this button is clicked, find the corresponding `Rental` object in the `Rentals` list using the `Rental.Id`, `Rental.UserId`, and `Rental.MovieId`.
 -   Set the `ReturnedOn` property of the `Rental` object to the current date and time.
 -   Also, find the corresponding `Movie` object using `Rental.MovieId` and increase the `Quantity` of the `Movie` object by 1, indicating that the movie has been returned and is now available for rent again.

