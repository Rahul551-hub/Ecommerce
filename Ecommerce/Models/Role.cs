namespace Ecommerce.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
        
        public ICollection<UserRole>? UserRoles { get; set; }
    }

    //here we are predefining the Roles out side the class
    public enum Roles
    {
        User,
        Department,
        Admin,

    }

}
