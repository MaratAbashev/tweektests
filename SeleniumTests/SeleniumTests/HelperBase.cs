namespace SeleniumTests;

using OpenQA.Selenium;

public class HelperBase(AppManager manager)
{
    protected AppManager Manager = manager;
    protected IWebDriver Driver = manager.Driver;

    protected IWebElement FindElement(string selector)
    {
        return Driver.FindElement(By.CssSelector(selector));
    }
    
    protected IEnumerable<IWebElement> FindElements(string selector)
    {
        return Driver.FindElements(By.CssSelector(selector));
    }
}
