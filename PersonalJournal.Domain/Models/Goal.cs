namespace PersonalJournal.Domain.Models
{
    public class Goal
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LimitDate { get; set; }
        public int LevelsId { get; set; }
        public int UserId { get; set; }
    }
}