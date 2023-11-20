namespace SimpleRegistration.Api.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Guid? ProvinceId { get; set; }
    public Province Province { get; set; }
}
