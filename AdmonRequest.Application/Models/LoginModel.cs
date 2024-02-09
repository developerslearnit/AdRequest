namespace AdmonRequest.Application.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool PersistLogin { get; set; }
    }

    public class ChangePasswordModel
    {
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }
        public string username { get; set; }
    }
}
