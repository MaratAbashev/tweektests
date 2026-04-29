namespace SeleniumTests;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class AppManager
{
    private static ThreadLocal<AppManager> _app = new ThreadLocal<AppManager>();

    private readonly string _baseUrl = "https://tweek.so/ru";
    private readonly IWebDriver _driver;

    private AppManager()
    {
        _driver = new FirefoxDriver();
        Navigation = new NavigationHelper(this, _baseUrl);
        Auth = new LoginHelper(this);
        Task = new TaskHelper(this);
    }

    ~AppManager()
    {
        try
        {
            _driver.Quit();
        }
        catch (Exception)
        {
            // ignore
        }
    }

    public IWebDriver Driver => _driver;

    public NavigationHelper Navigation { get; }

    public LoginHelper Auth { get; }

    public TaskHelper Task { get; }

    public static AppManager GetInstance()
    {
        if (!_app.IsValueCreated)
        {
            AppManager newInstance = new AppManager();
            newInstance.Navigation.GoToMainPage();
            _app.Value = newInstance;
        }

        return _app.Value!;
    }
}
