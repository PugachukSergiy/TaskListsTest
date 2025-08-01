using tasklists.BuisnessLogic.Helpers;
using tasklists.Contract;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class UpdateTaskListHandler : BaseTaskListHandler<UpdateTaskListRequest, BaseResponse>
    {
        public UpdateTaskListHandler(TaskListManager taskListManager) 
            : base(taskListManager) 
        { }

        public override async Task HandleAsync(UpdateTaskListRequest request, BaseResponse response)
        {
            ValidateRequest(request, response);
            if(response.Status != ResponseStatus.OK)
                return;

            var taskListInDb = await taskListManager.GetTaskListWithUsersByIdAsync(request.TaskList.Id);
            if (taskListInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.TaskList.Id);
                return;
            }

            ValidationHelper.ValidateOwnershipOrSharing(response, taskListInDb, request.UserId);
            if (response.Status != ResponseStatus.OK)
                return;

            taskListInDb.ApplyPropertiesFromDTO(request.TaskList);

            await taskListManager.SaveChangesInDbAsync();
        }

        private void ValidateRequest(UpdateTaskListRequest request, BaseResponse response)
        {
            ValidationHelper.ValidateListName(response,  request.TaskList.Name);
        }
    }
}
