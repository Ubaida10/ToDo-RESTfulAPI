namespace BackendAssignment.Model
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }     //Foreign Key
        public User? User { get; set; }
    }
}
