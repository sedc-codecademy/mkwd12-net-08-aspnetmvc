using Qinshift.Asp.Net.Class06.App.Database;
using Qinshift.Asp.Net.Class06.App.Models.Dtos;
using Qinshift.Asp.Net.Class06.App.Models.Entities;
using Qinshift.Asp.Net.Class06.App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qinshift.Asp.Net.Class06.App.Services
{
    public class TodoService
    {
        public List<TodoDto> GetTodos(int? categoryId, int? statusId)
        {
            var todos = InMemoryDatabase.Todos;

            if (categoryId.HasValue && categoryId.Value != 0)
            {
                todos = todos.Where(x => x.CategoryId == categoryId.Value).ToList();
            }

            if (statusId.HasValue && statusId.Value != 0)
            {
                todos = todos.Where(x => x.StatusId == statusId.Value).ToList();
            }

            var result = new List<TodoDto>();
            foreach (var todo in todos)
            {
                result.Add(new TodoDto
                {
                    Id = todo.Id,
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    Category = InMemoryDatabase.Categories.FirstOrDefault(x => x.Id == todo.CategoryId)?.Name ?? string.Empty,
                    Status = InMemoryDatabase.Statuses.FirstOrDefault(x => x.Id == todo.StatusId)?.Name ?? string.Empty,
                    StatusId = todo.StatusId,
                });
            }

            return result;
        }

        public bool MarkComplete(int todoId)
        {
            var todo = InMemoryDatabase.Todos.FirstOrDefault(x => x.Id == todoId);
            if (todo == null)
            {
                return false;
            }
            InMemoryDatabase.Todos.Remove(todo);
            todo.StatusId = 2;
            InMemoryDatabase.Todos.Add(todo);
            return true;
        }

        public void RemoveComplete()
        {
            var completeTodos = InMemoryDatabase.Todos.Where(x => x.StatusId == 2).ToList();

            foreach (var todo in completeTodos)
            {
                InMemoryDatabase.Todos.Remove(todo);
            }
        }

        internal void AddTodo(CreateTodoVM todo)
        {
            var newTodo = new Todo
            {
                Id = InMemoryDatabase.Todos.Count + 1,
                Description = todo.Description,
                CategoryId = todo.CategoryId,
                DueDate = todo.DueDate,
                StatusId = 1 // always open
            };

            InMemoryDatabase.Todos.Add(newTodo);
        }
    }
}
