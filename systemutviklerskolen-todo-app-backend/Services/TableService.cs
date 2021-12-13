using Azure;
using Azure.Data.Tables;

namespace Systemutviklerskolen_todo_app_backend.Services;

public class TableService
{
    private readonly TableClient _tableClient;

    public TableService(TableClient tableClient)
    {
        _tableClient = tableClient;
    }

    public IEnumerable<Todo> GetAllRows()
    {
        Pageable<TableEntity> entities = _tableClient.Query<TableEntity>();

        return entities.Select(MapTableEntityToToDo);
    }

    public void AddOrUpdateEntity(Todo model)
    {
        TableEntity entity = new TableEntity();
        entity.PartitionKey = model.PartitionKey;
        entity.RowKey = model.Id.ToString();

        // The other values are added like a items to a dictionary
        entity["Task"] = model.Task;
        entity["Done"] = model.Done.ToString();

        _tableClient.UpsertEntity(entity);
    }

    public void DeleteEntity(Todo model)
    {
        _tableClient.DeleteEntity(model.PartitionKey, model.Id.ToString());
    }

    public Todo MapTableEntityToToDo(TableEntity entity)
    {
        var todo = new Todo();
        todo.Id = new Guid(entity.RowKey);
        todo.Done = (string)entity["Done"] == "True";
        todo.Task = (string)entity["Task"];
       
        return todo;
    }
}
