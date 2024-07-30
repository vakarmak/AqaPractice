using PlaywrightSpecFlow.ApiTesting.Models;

namespace PlaywrightSpecFlow.ApiTesting.Account
{
    internal class AccountPresetup
    {
        internal static string UserName = "Usr" + GetCurrentTimestamp();
        internal static string Password = "Pa$$word1";
        internal bool AccountCreated = false;
        internal string? UserId;

        internal UserModel MainUser = new()
        {
            UserName = UserName,
            Password = Password
        };

        internal async Task AccountApiPresetup()
        {
            AccountApi account = new AccountApi("https://demoqa.com/");
            UserId = await account.AddUserAndGetId(MainUser);
            var token = await account.GenerateToken(MainUser);
            var user = await account.GetUserById(UserId, token);
            var body = await user.Content.ReadAsStringAsync();
            Console.WriteLine("user info: " + body);
        }

        internal async Task AccountApiCleanup()
        {
            AccountApi account = new AccountApi("https://demoqa.com/");
            await account.DeleteAccountByID(ID: UserId);
        }

        internal static string GetCurrentTimestamp()
        {
            DateTime currentTimestamp = DateTime.UtcNow;

            string timestamp = currentTimestamp.ToString("u");

            timestamp = Regex.Replace(timestamp, @"\D", "");

            return timestamp;
        }
    }
}
