# Todo application

## Models

### Todo Model:
- **Attributes**: 
    - Id,
    - Description,
    - DueDate,
    - CategoryId,
    - StatusId.
- **Relationships**: 
    - Belongs to one Category and one Status (both are lookup tables).

### Status Model:
- **Attributes**: 
    - Id,
    - Name.

### Category Model:
- **Attributes**: 
    - Id,
    - Name.


# Functionalities

### Listing All Todos
- **Functionality**:
  - Users can view a list of all Todo items.
  - Each Todo item should display its Description, DueDate, Category Name, and Status Name.
  - Users can filter Todo items based on Category or Status.
  
### Technical Considerations:
- Implement a controller action to retrieve and display the list of Todo items.
- Implement filtering functionality using query parameters or form submissions.
  
### Additional Considerations:
- Provide visual indicators for overdue or completed Todo items for better user experience.


### Marking Item Complete
- **Functionality**:
  - Users can mark a Todo item as complete.
  - Completed Todo items should be visually distinguished from incomplete ones.
  - Once marked as complete, the item's status should be updated accordingly.

### Removing All Complete Todos
- **Functionality**:
  - Users can remove all completed Todo items in bulk.

### Technical Considerations:
- Implement controller actions to handle marking items complete and removing completed todos.
- Utilize appropriate HTTP methods (e.g., POST, DELETE) for these operations.

### Adding Todo
- **Functionality**:
  - Users can add a new Todo item.
  - The user interface should provide input fields for Description, DueDate, Category.
  - Status should be added automaticaly when creating new Todo item.
  - Category should be selectable from predefined options (lookup tables).
  - After successful addition, the new Todo item should be displayed in the list of Todos.

### Technical Considerations:
- Implement a form for adding Todo items.
- Utilize client-side scripting to enhance user experience, such as date pickers for selecting DueDate.