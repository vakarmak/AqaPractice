namespace PlaywrightUiTests.Api.Models;

internal class UserToken
{
    public string? Token { get; set; }

    public DateTime Expires { get; set; }

    public string? Status { get; set; }
    public string? Result { get; set; }
}