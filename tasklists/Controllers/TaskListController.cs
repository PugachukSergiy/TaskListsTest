using Microsoft.AspNetCore.Mvc;
using tasklists.BuisnessLogic;
using tasklists.BuisnessLogic.Handlers;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskListController : ControllerBase
    {
        private readonly ILogger<TaskListController> _logger;

        public TaskListController(ILogger<TaskListController> logger)
        {
            _logger = logger;
        }

        [HttpPost("CreateTaskList")]
        public Task<TaskListResponse> CreateTaskList([FromServices]CreateTaskListHandler handler, CreateTaskListRequest request)
        {
            return handleRequest(handler, request);
        }

        [HttpGet("GetTaskList")]
        public Task<TaskListResponse> GetTaskList([FromServices]GetTaskListHandler handler, int userId, int taskListId)
        {
            var request = new GetTaskListRequest()
            {
                UserId = userId,
                TaskListId = taskListId
            };
            return handleRequest(handler, request);
        }

        [HttpGet("GetTaskLists")]
        public Task<TaskListsResponse> GetTaskList([FromServices] GetTaskListsHandler handler, int userId, int offset, int count)
        {
            var request = new GetTaskListsRequest()
            {
                UserId = userId,
                Offset = offset,
                Count = count
            };
            return handleRequest(handler, request);
        }

        [HttpPost("UpdateTaskList")]
        public Task<BaseResponse> UpdateTaskList([FromServices] UpdateTaskListHandler handler, UpdateTaskListRequest request)
        {
            return handleRequest(handler, request);
        }

        [HttpDelete("DeleteTaskList")]
        public Task<BaseResponse> DeleteTaskList([FromServices] DeleteTaskListHandler handler, int userId, int taskListId)
        {
            var request = new DeleteTaskListRequest()
            {
                UserId = userId,
                TaskListId = taskListId
            };
            return handleRequest(handler, request);
        }

        [HttpPost("ShareTaskList")]
        public Task<BaseResponse> ShareTaskList([FromServices] ShareTaskListHandler handler, ShareTaskListRequest request)
        {
            return handleRequest(handler, request);
        }

        [HttpPost("UnshareTaskList")]
        public Task<BaseResponse> UnshareTaskList([FromServices] UnshareTaskListHandler handler, UnshareTaskListRequest request)
        {
            return handleRequest(handler, request);
        }

        [HttpGet("GetTaskListSharings")]
        public Task<TaskListSharingsResponse> GetTaskListSharings([FromServices] GetTaskListSharingsHandler handler, int userId, int taskListId)
        {
            var request = new GetTaskListSharingsRequest()
            {
                UserId = userId,
                TaskListId = taskListId
            };
            return handleRequest(handler, request);
        }

        private async Task<TResponse> handleRequest<TRequest, TResponse>([FromServices] ITaskListHandler<TRequest, TResponse> handler, TRequest request)
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
