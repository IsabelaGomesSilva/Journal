
namespace PersonalJournal.Domain.Validations
{
    public class DomainExceptionsValidations : Exception 
    {
       public DomainExceptionsValidations(string error) : base(error){}

        public static void ExceptionHandler(bool hasError, string error)
        {
           if(hasError)
           {
            throw new DomainExceptionsValidations(error); 
           }
        }
    }
}