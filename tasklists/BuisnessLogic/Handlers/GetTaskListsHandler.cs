using tasklists.BuisnessLogic.Helpers;
using tasklists.Contract;
using tasklists.Contract.Requests;
using tasklists.Contract.Responses;

namespace tasklists.BuisnessLogic.Handlers
{
    public class GetTaskListsHandler : BaseTaskListHandler<GetTaskListsRequest, TaskListsResponse>
    {
        public GetTaskListsHandler(TaskListManager taskListManager) 
            : base(taskListManager) 
        { }

        public override async Task HandleAsync(GetTaskListsRequest request, TaskListsResponse response)
        {
            ValidateRequest(request, response);
            if (response.Status != ResponseStatus.OK)
                return;

            var taskLists = await taskListManager.GetTaskListsByUserIdAsync(request.UserId, request.Offset, request.Count);

            response.TaskLists = taskLists.MapToDTOPreviews();
        }

        private void ValidateRequest(GetTaskListsRequest request, TaskListsResponse response)
        {
            ValidationHelper.ValidateNotNegativeProperty(response, request.Offset, nameof(request.Offset));
            ValidationHelper.ValidateNotNegativeProperty(response, request.Count, nameof(request.Count));
        }
    }
}
