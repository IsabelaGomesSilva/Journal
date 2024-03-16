namespace PersonalJournal.Domain.Models
{
    public class Note
    {
       public  int Id { get; private set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public DateTime CurrentDate { get; set; }
       public int UserId { get; set; } 
    }
}