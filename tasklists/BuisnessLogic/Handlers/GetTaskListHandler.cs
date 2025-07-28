using tasklists.Contract;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class GetTaskListHandler : BaseTaskListHandler<GetTaskListRequest, TaskListResponse>
    {
        public GetTaskListHandler(TaskListManager taskListManager) 
            : base(taskListManager) 
        { }

        public override async Task HandleAsync(GetTaskListRequest request, TaskListResponse response)
        {
            var taskListInDb = await taskListManager.GetTaskListWithUsersByIdAsync(request.TaskListId);
            if (taskListInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.TaskListId);
                return;
            }

            ValidationHelper.ValidateOwnershipOrSharing(response, taskListInDb, request.UserId);
            if (response.Status != ResponseStatus.OK)
                return;

            response.TaskList = taskListInDb;
        }
    }
}
