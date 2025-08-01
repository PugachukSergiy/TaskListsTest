using tasklists.Contract.DTO;

namespace tasklists.Contract.Responses
{
    public class TaskListSharingsResponse : BaseResponse
    {
        public IEnumerable<User>? Sharings { get; set; }
    }
}
