namespace tasklists.Contract.Responses
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; } = ResponseStatus.OK;
        public List<string> ErrorMessages { get; set; } = new List<string>();
    }
}
