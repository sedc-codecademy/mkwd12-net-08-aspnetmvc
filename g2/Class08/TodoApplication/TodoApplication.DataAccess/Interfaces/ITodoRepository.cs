using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Intefaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        IEnumerable<Todo> GetCompletedTodos();
    }
}
