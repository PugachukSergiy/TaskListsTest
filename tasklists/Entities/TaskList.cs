namespace tasklists.Entities
{
    public class TaskList : BaseEntitiy
    {
        public required string Name { get; set; }
        public required int OwnerId { get; set; }
        public User? Owner { get; set; }
        public DateTime CreationDateTime { get; set; }
        public List<User>? SharedTo { get; set; }
    }
}
