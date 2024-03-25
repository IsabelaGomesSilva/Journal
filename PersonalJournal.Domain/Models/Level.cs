using PersonalJournal.Domain.Entities;
using PersonalJournal.Domain.Validations;

namespace PersonalJournal.Domain.Models
{
    public sealed class Level : EntityBase
    {
        public Level(string description)
        {
            ValidateDomain(description, 100, 3);
            Description = description;
        }
        public string Description { get; private set; }
        public void ValidateDomain(string description, int maxLength, int minLength)
        {
            DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(description),
                "Invalid description. Description is required!");

            DomainExceptionsValidations.ExceptionHandler(description.Length > maxLength,
                $"Invalid description. Description cannot exceed {maxLength} characters.");
            
            DomainExceptionsValidations.ExceptionHandler(description.Length < minLength,
                $"Invalid description. Description must be at least {minLength} characters.");
        }
    }
}