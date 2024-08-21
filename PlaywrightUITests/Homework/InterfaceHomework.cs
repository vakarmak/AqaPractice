namespace PlaywrightUiTests.Homework;

public interface IMyWebDriver
{
    public void Open(string url);
    public void FindElement(string locator);
    public void Close();
}

public interface IMyWindowsWebDriver
{
    public string GetWindowsVersion();
}

public class ChromeDriver : IMyWebDriver, IMyWindowsWebDriver
{
    private const string DriverName = "Chrome";

    public void Open(string url)
    {
        Console.WriteLine($"Opening {DriverName}");
    }

    public void FindElement(string locator)
    {
        Console.WriteLine($"Find {locator}");
    }

    public void Close()
    {
        Console.WriteLine($"Closing {DriverName}");
    }

    public string GetWindowsVersion()
    {
        return "Windows 10";
    }
}

public class SafariDriver : IMyWebDriver
{
    private const string DriverName = "Safari";

    public void Open(string url)
    {
        Console.WriteLine($"Opening {DriverName}");
    }

    public void Close()
    {
        Console.WriteLine($"Closing {DriverName}");
    }

    public void FindElement(string locator)
    {
        Console.WriteLine($"Find {locator}");
    }
}

public class FirefoxDriver : IMyWebDriver, IMyWindowsWebDriver
{
    private const string DriverName = "Firefox";

    public void FindElement(string locator)
    {
        Console.WriteLine($"Find {locator}");
    }

    public void Open(string url)
    {
        Console.WriteLine($"Opening {DriverName}");
    }

    public string GetWindowsVersion()
    {
        return "Windows 11";
    }

    public void Close()
    {
        Console.WriteLine($"Closing {DriverName}");
    }
}