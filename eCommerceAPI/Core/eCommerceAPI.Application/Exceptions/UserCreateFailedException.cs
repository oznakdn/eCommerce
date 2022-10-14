namespace eCommerceAPI.Application.Exceptions
{
    public class UserCreateFailedException:Exception
    {

        public UserCreateFailedException():base("An unexpected error occurred while creating a user!")
        {

        }
        public UserCreateFailedException(string message):base(message)
        {

        }

        public UserCreateFailedException(List<string> errorMessages):this()
        {

        }
    }
}
