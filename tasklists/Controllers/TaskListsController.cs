using Microsoft.AspNetCore.Mvc;
using tasklists.BuisnessLogic;
using tasklists.BuisnessLogic.Handlers;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskListsController : ControllerBase
    {
        private readonly ILogger<TaskListsController> _logger;

        public TaskListsController(ILogger<TaskListsController> logger)
        {
            _logger = logger;
        }

        [HttpPost()]
        public Task<TaskListResponse> Post([FromServices] CreateTaskListHandler handler, [FromQuery] int userId, CreateTaskListRequest request)
        {
            request.UserId = userId;
            return handleRequest(handler, request);
        }

        [HttpGet("{id}")]
        public Task<TaskListResponse> Get([FromServices] GetTaskListHandler handler, [FromQuery] int userId, int id)
        {
            var request = new GetTaskListRequest()
            {
                UserId = userId,
                TaskListId = id
            };
            return handleRequest(handler, request);
        }

        [HttpGet()]
        public Task<TaskListsResponse> Get([FromServices] GetTaskListsHandler handler, [FromQuery] int userId, [FromQuery] int offset, [FromQuery] int count)
        {
            var request = new GetTaskListsRequest()
            {
                UserId = userId,
                Offset = offset,
                Count = count
            };
            return handleRequest(handler, request);
        }

        [HttpPut()]
        public Task<BaseResponse> Put([FromServices] UpdateTaskListHandler handler, [FromQuery] int userId, UpdateTaskListRequest request)
        {
            request.UserId = userId;
            return handleRequest(handler, request);
        }

        [HttpDelete("{id}")]
        public Task<BaseResponse> Delete([FromServices] DeleteTaskListHandler handler, [FromQuery] int userId, int id)
        {
            var request = new DeleteTaskListRequest()
            {
                UserId = userId,
                TaskListId = id
            };
            return handleRequest(handler, request);
        }

        [HttpGet("{id}/users")]
        public Task<TaskListSharingsResponse> Get([FromServices] GetTaskListSharingsHandler handler, [FromQuery] int userId, int id)
        {
            var request = new GetTaskListSharingsRequest()
            {
                UserId = userId,
                TaskListId = id
            };
            return handleRequest(handler, request);
        }

        [HttpPost("{taskListId}/sharing/{userToShareId}")]
        public Task<BaseResponse> Post([FromServices] ShareTaskListHandler handler, [FromQuery] int userId, int taskListId, int userToShareId)
        {
            var request = new ShareTaskListRequest()
            {
                UserId = userId,
                TaskListId = taskListId,
                UserToShareId = userToShareId

            };
            return handleRequest(handler, request);
        }

        [HttpDelete("{taskListId}/sharing/{userToUnshareId}")]
        public Task<BaseResponse> Delete([FromServices] UnshareTaskListHandler handler, [FromQuery] int userId, int taskListId, int userToUnshareId)
        {
            var request = new UnshareTaskListRequest()
            {
                UserId = userId,
                TaskListId = taskListId,
                UserToUnshareId = userToUnshareId

            };
            return handleRequest(handler, request);
        }

        private async Task<TResponse> handleRequest<TRequest, TResponse>(ITaskListHandler<TRequest, TResponse> handler, TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse, new()
        {
            var response = new TResponse();
            try
            {
                await handler.HandleAsync(request, response);
            }
            catch (Exception ex)
            {
                response.AddErrorMessage(ex.Message);
                _logger.LogError(ex, null);
            }
            return response;
        }
    }
}
