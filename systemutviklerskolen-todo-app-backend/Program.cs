using Azure.Data.Tables;
using Systemutviklerskolen_todo_app_backend.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
services.AddSingleton<TableClient>(new TableClient("", "Sysut"));
services.AddSingleton<TableService>();
services.AddSpaStaticFiles(options => options.RootPath = "todo-app-frontend");

var app = builder.Build();

app.UseSpa(opts => { });
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
