using tasklists.Entities;

namespace tasklists.Contract.Responses
{
    public class TaskListSharingsResponse : BaseResponse
    {
        public List<User>? Sharings { get; set; }
    }
}
