namespace AcademyApp.Application.Exceptions
{
    public class DuplicateEntityException:Exception
    {
        public DuplicateEntityException(){}
        public DuplicateEntityException(string message):base(message) 
        {
            
        }
    }
}
