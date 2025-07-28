namespace tasklists.Contract.Requests
{
    public class GetTaskListsRequest : BaseRequest
    {
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
