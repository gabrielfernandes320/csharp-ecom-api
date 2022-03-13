using Domain.Common.Entities;

namespace Domain.Auth.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Resource { get; set; }
        public string Action { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
