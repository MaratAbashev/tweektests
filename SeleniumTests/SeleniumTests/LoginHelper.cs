namespace SeleniumTests;

using OpenQA.Selenium;

public class LoginHelper(AppManager manager) : HelperBase(manager)
{
    public bool IsLoggedIn { get; private set; }
    public void Login(AccountData accountData)
    {
        FindElement("._variantOutlined_w81oo_35").Click();
        Driver.FindElement(By.Name("email")).SendKeys(accountData.Mail);
        Driver.FindElement(By.Name("password")).SendKeys(accountData.Password);
        FindElement("._fullWidth_w81oo_20").Click();
        Thread.Sleep(5000);
        IsLoggedIn = true;
    }

    public void Logout()
    {
        FindElement("._bars_1i8t4_107").Click();
        FindElement("._backdrop_1ewsq_1").Click();
        FindElement("._profile_1i8t4_82").Click();
        FindElement("._footerLink_1c22j_104:nth-child(2)").Click();
        IsLoggedIn = false;
    }
}
