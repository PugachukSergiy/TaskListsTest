namespace tasklists.Contract.Requests
{
    public class UnshareTaskListRequest : BaseRequest
    {
        public int TaskListId { get; set; }
        public int UserToUnshareId { get; set; }
    }
}
