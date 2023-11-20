namespace SimpleRegistration.Api.Models;

public class RegisterModel
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string RepeatedPassword { get; set; }
    public bool IsConfirmed { get; set; }
}
