using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public interface ITaskListHandler<TRequest, TResponse>
        where TRequest : BaseRequest
        where TResponse : BaseResponse
    {
        public Task HandleAsync(TRequest request, TResponse response);
    }

    public abstract class BaseTaskListHandler<TRequest,TResponse> : ITaskListHandler<TRequest, TResponse>
        where TRequest : BaseRequest
        where TResponse : BaseResponse
    {
        protected readonly TaskListManager taskListManager;

        public BaseTaskListHandler(TaskListManager taskListManager)
        {
            this.taskListManager = taskListManager;
        }

        public abstract Task HandleAsync(TRequest request, TResponse response);
    }
}
