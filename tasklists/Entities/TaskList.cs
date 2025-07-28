using System.Text.Json.Serialization;

namespace tasklists.Entities
{
    public class TaskList : BaseEntitiy
    {
        public required string Name { get; set; }
        public required int OwnerId { get; set; }
        [JsonIgnore]
        public User? Owner { get; set; }
        [JsonIgnore]
        public DateTime CreationDateTime { get; set; }
        [JsonIgnore]
        public List<User>? SharedTo { get; set; }
    }
}
