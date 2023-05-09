using System;

namespace Class1
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoListResponse>>> GetTodoLists()
        {
            return await Task.FromResult(NoContent());
        }

        [HttpPost]
        public async Task<ActionResult<TodoListResponse>> CreateTodoList(CreateTodoListRequest request)
        {
            return await Task.FromResult(NoContent());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodoList(UpdateTodoListRequest request)
        {
            return await Task.FromResult(NoContent());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTodoList(int id)
        {
            return await Task.FromResult(NoContent());
        }
    }    
}

