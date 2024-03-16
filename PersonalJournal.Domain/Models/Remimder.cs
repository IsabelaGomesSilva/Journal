namespace PersonalJournal.Domain.Models
{
    public class Remimder
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LarmDate { get; set; }
        public int UserId { get; set; }
    }
}