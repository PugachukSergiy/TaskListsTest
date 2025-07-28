using tasklists.Contract;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class CreateTaskListHandler : BaseTaskListHandler<CreateTaskListRequest, TaskListResponse>
    {
        public CreateTaskListHandler(TaskListManager taskListManager) 
            : base(taskListManager)
        { }

        public override async Task HandleAsync(CreateTaskListRequest request, TaskListResponse response)
        {
            ValidateRequest(request, response);
            if (response.Status != ResponseStatus.OK)
                return;

            response.TaskList = await taskListManager.CreateTaskListAsync(request.UserId, request.Name);
        }

        private void ValidateRequest(CreateTaskListRequest request, BaseResponse response)
        {
            ValidationHelper.ValidateListName(response, request.Name);
        }
    }
}
