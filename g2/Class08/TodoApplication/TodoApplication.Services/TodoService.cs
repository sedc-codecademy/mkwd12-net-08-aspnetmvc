using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess;
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Intefaces;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;
using TodoApplication.Dtos.ViewModel;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public TodoService()
        {
            _todoRepository = new TodoRepository();
            _categoryRepository = new CategoryRepository();
            _statusRepository = new StatusRepository();
        }
        public List<TodoDto> GetTodos(int? categoryId, int? statusId)
        {
            //var todos = InMemoryDataBase.Todos;
            var todos = _todoRepository.GetAll();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                todos = todos.Where(x=> x.CategoryId == categoryId.Value).ToList();
            }

            if (statusId.HasValue && statusId > 0)
            {
                todos = todos.Where(x => x.StatusId == statusId).ToList();
            }

            var result = new List<TodoDto>();
            foreach (var todo in todos)
            {
                result.Add(new TodoDto
                {
                    Id = todo.Id,
                    Description = todo.Description,
                    DueDate = todo.DueDate,
                    //Category = InMemoryDataBase.Categories.FirstOrDefault(x=> x.Id == todo.CategoryId)?.Name ?? string.Empty,
                    Category = _categoryRepository.GetById(todo.CategoryId)?.Name ?? string.Empty,
                    //Status = InMemoryDataBase.Statuses.FirstOrDefault(x=>x.Id == todo.StatusId)?.Name ?? string.Empty,
                    Status = _statusRepository.GetById(todo.StatusId)?.Name ?? string.Empty,
                    StatusId = todo.StatusId
                });
            }
            return result;
        }

        public bool MarkComplete(int todoId)
        {
            //var todo = InMemoryDataBase.Todos.FirstOrDefault(x => x.Id == todoId);
            var todo = _todoRepository.GetById(todoId);
            if (todo == null) return false;

            //InMemoryDataBase.Todos.Remove(todo);
            todo.StatusId = 2;
            //InMemoryDataBase.Todos.Add(todo);
            _todoRepository.Update(todo);
            return true;
        }

        public void RemoveComplete()
        {
            //var completeTodos = InMemoryDataBase.Todos.Where(x=>x.StatusId == 2).ToList();
            var completeTodos = _todoRepository.GetCompletedTodos();
            foreach (var todo in completeTodos)
            {
                //InMemoryDataBase.Todos.Remove(todo);
                _todoRepository.Delete(todo.Id);
            }
        }

        public void AddTodo(CreateTodoVM createTodo)
        {
            var newTodo = new Todo
            {
                //Id = InMemoryDataBase.Todos.Count + 1,
                Description = createTodo.Description,
                CategoryId = createTodo.CategoryId,
                DueDate = createTodo.DueDate,
                StatusId = 1

            };
            //InMemoryDataBase.Todos.Add(newTodo);
            _todoRepository.Add(newTodo);
        }
    }
}
