using System.Text.Json.Serialization;

namespace tasklists.Contract.Requests
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
