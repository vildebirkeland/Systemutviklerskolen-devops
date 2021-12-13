using Azure.Data.Tables;

namespace Systemutviklerskolen_todo_app_backend.Services
{
    public interface ITableService
    {
        void AddOrUpdateEntity(Todo model);
        void DeleteEntity(Todo model);
        IEnumerable<Todo> GetAllRows();
        Todo MapTableEntityToToDo(TableEntity entity);
    }
}