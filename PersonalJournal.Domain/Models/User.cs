namespace PersonalJournal.Domain.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}