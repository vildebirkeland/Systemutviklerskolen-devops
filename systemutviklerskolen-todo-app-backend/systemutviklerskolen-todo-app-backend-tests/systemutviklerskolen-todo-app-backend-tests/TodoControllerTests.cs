using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Systemutviklerskolen_todo_app_backend;
using Systemutviklerskolen_todo_app_backend.Controllers;
using Systemutviklerskolen_todo_app_backend.Services;

namespace systemutviklerskolen_todo_app_backend_tests
{
    public class TodoControllerTests
    {
        [Test]
        public void TodoController_Index_CallsGetAllRows() 
        {
            var mock = new Mock<ITableService>();
            mock.Setup(x => x.GetAllRows()).Returns(new List<Todo> { new Todo() });

            var target = new TodoController(mock.Object);

            target.Index();

            mock.Verify(x => x.GetAllRows(), Times.Once);
        }
    }
}
