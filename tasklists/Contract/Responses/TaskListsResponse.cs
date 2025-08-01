using tasklists.Contract.DTO;

namespace tasklists.Contract.Responses
{
    public class TaskListsResponse : BaseResponse
    {
        public IEnumerable<TaskListPreview>? TaskLists { get; set; }
    }
}
