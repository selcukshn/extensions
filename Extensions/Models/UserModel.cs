namespace Extensions.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserModel() { }
        public UserModel(Guid userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }
    }
}