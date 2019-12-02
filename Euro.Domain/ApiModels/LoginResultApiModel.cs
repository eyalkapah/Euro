namespace Euro.Domain.ApiModels
{
    public class LoginResultApiModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}