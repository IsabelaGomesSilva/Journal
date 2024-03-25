using PersonalJournal.Domain.Entities;
using PersonalJournal.Domain.Validations;

namespace PersonalJournal.Domain.Models
{
    public class Remimder : EntityBase
    {
        public Remimder(string name, string description, DateTime alarmDate, int userId)
        {
            ValidateName(name,100,2);
            Name = name;
            ValidateDescription(description, 400, 5);
            Description = description;
            ValidateAlarmDate(alarmDate);
            AlarmDate = alarmDate;
            ValidateUserId(userId);
            UserId = userId;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime AlarmDate { get; private set; }
        public int UserId { get; private set; }
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
        public void ValidateAlarmDate(DateTime alarmDate)
        {
            DomainExceptionsValidations.ExceptionHandler(alarmDate < DateTime.Today,
                "Invalid alarmDate. Alarm date must be greater than or equal to the current date!");
        }
        public void ValidateUserId(int userId)
        {
            DomainExceptionsValidations.ExceptionHandler(userId <= 0,
                "Invalid userId. UserId must be greater than 0.");
        }
    }
}