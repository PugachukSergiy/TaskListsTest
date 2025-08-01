namespace tasklists.Contract.DTO
{
    public class TaskList : BaseEntitiy
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
