using tasklists.Contract.DTO;

namespace tasklists.Contract.Responses
{
    public class TaskListResponse : BaseResponse
    {
        public TaskList? TaskList { get; set; }
    }
}
