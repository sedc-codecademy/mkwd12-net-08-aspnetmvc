using TodoApplication.Dtos.Dto;
using TodoApplication.Dtos.ViewModel;

namespace TodoApplication.Services.Interfaces
{
    public interface ITodoService
    {
        List<TodoDto> GetTodos(int? categoryId, int? statusId);
        bool MarkComplete(int todoId);
        void RemoveComplete();
        void AddTodo(CreateTodoVM createTodo);
    }
}
