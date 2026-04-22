namespace SeleniumTests;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class AppManager
{
    private readonly string _baseUrl = "https://tweek.so/ru";

    public AppManager()
    {
        Driver = new FirefoxDriver();
        Navigation = new NavigationHelper(this, _baseUrl);
        Auth = new LoginHelper(this);
        Task = new TaskHelper(this);
    }

    public IWebDriver Driver { get; }

    public NavigationHelper Navigation { get; }

    public LoginHelper Auth { get; }

    public TaskHelper Task { get; }

    public void Stop()
    {
        Driver.Quit();
    }
}
