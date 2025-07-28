using tasklists.Entities;

namespace tasklists.Contract.Requests
{
    public class UpdateTaskListRequest : BaseRequest
    {
        public required TaskList TaskList { get; set; }
    }
}
