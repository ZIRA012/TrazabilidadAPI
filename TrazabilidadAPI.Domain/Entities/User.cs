namespace TrazabilidadAPI.Domain.Entities;

public class User
{
    public int UserID { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }

    public required ICollection<UserRole> UserRoles { get; set; }
    public required ICollection<Procedure> CreatedProcedures { get; set; }
    public required ICollection<Procedure> ModifiedProcedures { get; set; }
}
