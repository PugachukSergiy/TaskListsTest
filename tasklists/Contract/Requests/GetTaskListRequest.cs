namespace tasklists.Contract.Requests
{
    public class GetTaskListRequest : BaseRequest
    {
        public int TaskListId { get; set; }
    }
}
