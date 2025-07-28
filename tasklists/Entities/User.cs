using System.Text.Json.Serialization;

namespace tasklists.Entities
{
    public class User : BaseEntitiy
    {
        public required string Name { get; set; }
        [JsonIgnore]
        public List<TaskList>? SharedTaskLists { get; set; }
    }
}
