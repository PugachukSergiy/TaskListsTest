using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class DeleteTaskListHandler : BaseTaskListHandler<DeleteTaskListRequest, BaseResponse>
    {
        public DeleteTaskListHandler(TaskListManager taskListManager) 
            : base(taskListManager) 
        { }

        public override async Task HandleAsync(DeleteTaskListRequest request, BaseResponse response)
        {
            var taskListInDb = await taskListManager.GetTaskListByIdAsync(request.TaskListId);
            if (taskListInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.TaskListId);
                return;
            }

            if (taskListInDb.OwnerId != request.UserId)
            {
                response.AddErrorMessage(ErrorMessages.NoRights);
                return;
            }

            await taskListManager.DeleteTaskListByIdAsync(request.TaskListId);
        }
    }
}
