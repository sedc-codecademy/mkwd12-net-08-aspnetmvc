# Burger App 🍔

## Summary

A small burger shop wants a web app that can offer simple ordering of burgers. Since they don't know if the idea will work, they need a small prototype to get started.

## Features

This prototype needs to have the following functions:

* Burgers
  * Show a menu of all available burgers
  * Edit every burger on the menu
  * Add a new burger to the menu
  * Delete a burger from the menu
* Orders
  * Make an order
  * Edit an order
  * Delete an order
  * List all orders
* Home
  * Show the most popular burger ( The burger that has been ordered the most )
  * Show how many orders have the app serviced so far
  * Show an average price of an order
  * List of all locations of the burger place
  * Navigation to Burgers Menu, Orders and About Us page
    * About Us page is just a page with some text about the burger place

## Business Domain Information

Users will not be part of the prototype at this moment. Here is some business domain information:

* Burger
  * Name
  * Price
  * IsVegetarian
  * IsVegan
  * HasFries
* Order
  * FullName
  * Address
  * IsDelivered
  * Burgers
  * Location ( String )

## Bonus

* Change location from string to model
* Add locations section
  * List all locations of burger places
  * Add new location
  * Edit location
  * Delete location
* Location Model
  * Name
  * Address
  * OpensAt
  * ClosesAt
