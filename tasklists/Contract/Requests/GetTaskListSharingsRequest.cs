namespace tasklists.Contract.Requests
{
    public class GetTaskListSharingsRequest : BaseRequest
    {
        public int TaskListId { get; set; }
    }
}
