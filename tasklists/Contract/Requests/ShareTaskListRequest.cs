namespace tasklists.Contract.Requests
{
    public class ShareTaskListRequest : BaseRequest
    {
        public int TaskListId { get; set; }
        public int UserToShareId { get; set; }
    }
}
