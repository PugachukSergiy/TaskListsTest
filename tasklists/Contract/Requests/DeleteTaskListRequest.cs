namespace tasklists.Contract.Requests
{
    public class DeleteTaskListRequest : BaseRequest
    {
        public int TaskListId { get; set; }
    }
}
