using Domain.Common.Entities;
using Domain.Users.Entities;

namespace Domain.Auth.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<User> Users { get; set; }
}