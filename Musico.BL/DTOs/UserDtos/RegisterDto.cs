namespace Musico.BL.DTOs.UserDtos;

public class RegisterDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Image { get; set; }
    public bool IsMale { get; set; }
}