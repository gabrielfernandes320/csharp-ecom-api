using Domain.Auth.Entities;
using Domain.Common.Entities;

namespace Domain.Users.Entities
{
    public sealed class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}