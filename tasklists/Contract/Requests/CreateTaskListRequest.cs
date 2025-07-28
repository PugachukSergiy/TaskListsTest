namespace tasklists.Contract.Requests
{
    public class CreateTaskListRequest : BaseRequest
    {
        public required string Name { get; set; }
    }
}
