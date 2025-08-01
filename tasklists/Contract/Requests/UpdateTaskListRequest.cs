using tasklists.Contract.DTO;

namespace tasklists.Contract.Requests
{
    public class UpdateTaskListRequest : BaseRequest
    {
        public required TaskList TaskList { get; set; }
    }
}
