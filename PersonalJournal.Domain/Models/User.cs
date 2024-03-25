using System.Text.RegularExpressions;
using PersonalJournal.Domain.Entities;
using PersonalJournal.Domain.Validations;

namespace PersonalJournal.Domain.Models
{
    public class User : EntityBase
    {
        public User(string name, string password, string email)
        {
            ValidateName(name,100,2);
            Name = name;
            ValidatePassword(password,15,8);
            Password = password;
            ValidateEmail(email);
            Email = email;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public void ValidateName(string name, int maxLength, int minLength)
        {
            DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");
            DomainExceptionsValidations.ExceptionHandler(name.Length > maxLength,
                $"Invalid name. Name cannot exceed {maxLength} characters.");
            DomainExceptionsValidations.ExceptionHandler(name.Length < minLength,
                $"Invalid name. Name must be at least {minLength} characters.");
        }
        public void ValidateEmail(string email)
        {
            DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(email),
                "Invalid email. Email is required!");

            string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            DomainExceptionsValidations.ExceptionHandler(!Regex.IsMatch(email, emailRegex),
                "Invalid email. Please enter a valid email address.");
        }
        public void ValidatePassword(string password, int maxLength, int minLength)
        {
           DomainExceptionsValidations.ExceptionHandler(string.IsNullOrEmpty(password),
            "Invalid password. Password is required!");
            DomainExceptionsValidations.ExceptionHandler(password.Length > maxLength,
                $"Invalid password. Password cannot exceed {maxLength} characters.");
            DomainExceptionsValidations.ExceptionHandler(password.Length < minLength,
                $"Invalid password. Password must be at least {minLength} characters.");
             DomainExceptionsValidations.ExceptionHandler(!password.Any(char.IsUpper) || !password.Any(char.IsDigit),
                "Invalid password. Password must contain at least one uppercase letter and one digit.");
        }
    }
}