namespace TunifyPlatform.Models.DTO
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}
