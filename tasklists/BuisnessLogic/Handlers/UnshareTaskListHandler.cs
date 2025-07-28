using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class UnshareTaskListHandler : BaseTaskListHandler<UnshareTaskListRequest, BaseResponse>
    {
        public UnshareTaskListHandler(TaskListManager taskListManager) 
            : base(taskListManager)
        { }

        public override async Task HandleAsync(UnshareTaskListRequest request, BaseResponse response)
        {
            var taskListInDb = await taskListManager.GetTaskListWithUsersByIdAsync(request.TaskListId);
            if (taskListInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.TaskListId);
                return;
            }

            if (taskListInDb.OwnerId != request.UserId && request.UserToUnshareId != request.UserId)
            {
                response.AddErrorMessage(ErrorMessages.NoRights);
                return;
            }

            var userInDb = taskListInDb.SharedTo!.Where(x => x.Id == request.UserToUnshareId).FirstOrDefault();
            if (userInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.NotShared);
                return;
            }

            await taskListManager.UnshareTaskListFromUserAsync(taskListInDb, userInDb);
        }
    }
}
