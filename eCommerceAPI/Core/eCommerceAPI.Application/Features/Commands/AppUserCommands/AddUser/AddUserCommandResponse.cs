namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.AddUser
{
    public class AddUserCommandResponse
    {
        public AddUserCommandResponse(bool isSucces,string responseMessage)
        {
            this.isSuccess = isSucces;
            ResponseMessage = responseMessage;
        }

        public bool isSuccess { get; set; }
        public string ResponseMessage { get; set; }

        //public override string ToString()
        //{
        //    return isSuccess ? ResponseMessage = $"Successful" : ResponseMessage = $"Unsuccessful";
        //}
    }
}
