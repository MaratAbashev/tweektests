namespace SeleniumTests;

public class NavigationHelper(AppManager manager, string baseUrl) : HelperBase(manager)
{
    public void GoToMainPage()
    {
        Driver.Navigate().GoToUrl(baseUrl);
    }
}
