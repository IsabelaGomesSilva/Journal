using PersonalJournal.Domain.Entities;
using PersonalJournal.Domain.Validations;

namespace PersonalJournal.Domain.Models
{
    public class Note : EntityBase
    {
        public Note(string name, string description, DateTime currentDate, int userId)
        {
            ValidateName(name, 100, 2);
            Name = name;
            ValidateDescription(description, 400, 10);
            Description = description;
            ValidateCurrentDate(currentDate);
            CurrentDate = currentDate;
            ValidateUserId(userId);
            UserId = userId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CurrentDate { get; set; }
        public int UserId { get; set; }
        public void ValidateDescription(string description, int maxLength, int minLength)
        {
            DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(description),
                "Invalid description. Description is required!");
            DomainExceptionsValidations.ExceptionHandler(description.Length > maxLength,
                $"Invalid description. Description cannot exceed {maxLength} characters.");
            DomainExceptionsValidations.ExceptionHandler(description.Length < minLength,
                $"Invalid description. Description must be at least {minLength} characters.");
        }
        public void ValidateName(string name, int maxLength, int minLength)
        {
            DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");
            DomainExceptionsValidations.ExceptionHandler(name.Length > maxLength,
                $"Invalid name. Name cannot exceed {maxLength} characters.");
            DomainExceptionsValidations.ExceptionHandler(name.Length < minLength,
                $"Invalid name. Name must be at least {minLength} characters.");

        }
        public void ValidateCurrentDate(DateTime currentDate)
        {
            DomainExceptionsValidations.ExceptionHandler(currentDate == DateTime.Today,
                "Invalid currentDate.The currentDate must be the current date.");
        }
        public void ValidateUserId(int userId)
        {
            DomainExceptionsValidations.ExceptionHandler(userId <= 0,
                "Invalid userId. UserId must be greater than 0.");
        }
    }
}