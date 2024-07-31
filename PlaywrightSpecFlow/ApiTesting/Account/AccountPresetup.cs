using PlaywrightSpecFlow.ApiTesting.Models;

namespace PlaywrightSpecFlow.ApiTesting.Account
{
    internal class AccountPreSetup
    {
        private static readonly string UserName = "Usr" + GetCurrentTimestamp();
        private const string Password = "Pa$$word1";
        internal string? UserId;

        private readonly UserModel _mainUser = new()
        {
            userName = UserName,
            password = Password
        };

        internal async Task AccountApiPreSetup()
        {
            var account = new AccountApi("https://demoqa.com/");
            UserId = await account.AddUserAndGetId(_mainUser);
            var token = await account.GenerateToken(_mainUser);
            var user = await account.GetUserById(UserId, token!);
            var body = await user.Content.ReadAsStringAsync();
            Console.WriteLine("user info: " + body);
        }

        internal async Task AccountApiCleanup()
        {
            var account = new AccountApi("https://demoqa.com/");
            var token = await account.GenerateToken(_mainUser);
            await account.DeleteAccountById(UserId!, token!);
        }

        private static string GetCurrentTimestamp()
        {
            var currentTimestamp = DateTime.UtcNow;

            var timestamp = currentTimestamp.ToString("u");

            timestamp = Regex.Replace(timestamp, @"\D", "");

            return timestamp;
        }
    }
}
