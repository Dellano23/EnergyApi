namespace Fiap.Api.Energy.Models;

    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Em produção somente
        public string? Role { get; set; }
    }
