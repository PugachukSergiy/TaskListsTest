using tasklists.Entities;

namespace tasklists.Contract.Responses
{
    public class TaskListsResponse : BaseResponse
    {
        public List<TaskList>? TaskLists { get; set; }
    }
}
