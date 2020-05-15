using Audit.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Audit.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
