namespace eCommerceAPI.Application.Exceptions
{
    public class UserAuthenticationException:Exception
    {
        public UserAuthenticationException():base("Credential verify error!")
        {

        }
        public UserAuthenticationException(string message):base(message)
        {

        }
    }
}
