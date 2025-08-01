using tasklists.BuisnessLogic.Helpers;
using tasklists.Contract;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class ShareTaskListHandler : BaseTaskListHandler<ShareTaskListRequest, BaseResponse>
    {
        protected readonly UserManager userManager;
        public ShareTaskListHandler(UserManager userManager, TaskListManager taskListManager) 
            : base(taskListManager) 
        {
            this.userManager = userManager;
        }

        public override async Task HandleAsync(ShareTaskListRequest request, BaseResponse response)
        {
            ValidateRequest(request, response);
            if(response.Status != ResponseStatus.OK)
                return;

            var taskListInDb = await taskListManager.GetTaskListWithUsersByIdAsync(request.TaskListId);
            if (taskListInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.TaskListId);
                return;
            }

            ValidationHelper.ValidateOwnershipOrSharing(response, taskListInDb, request.UserId);
            if (response.Status != ResponseStatus.OK)
                return;

            if (taskListInDb.OwnerId == request.UserToShareId)
            {
                response.AddErrorMessage(ErrorMessages.UserIsOwner);
                return;
            }

            if (taskListInDb.SharedTo!.Any(x => x.Id == request.UserToShareId))
            {
                response.AddErrorMessage(ErrorMessages.AlreadyShared);
                return;
            }

            var userInDb = await userManager.GetUserByIdAsync(request.UserToShareId);
            if (userInDb == null)
            {
                response.AddErrorMessage(ErrorMessages.TaskListNotFound, request.UserToShareId);
                return;
            }

            await taskListManager.ShareTaskListToUserAsync(taskListInDb, userInDb);
        }

        private void ValidateRequest(ShareTaskListRequest request, BaseResponse response)
        {
            if(request.UserId == request.UserToShareId)
            {
                response.AddErrorMessage(ErrorMessages.SelfSharing);
            }
        }
    }
}
