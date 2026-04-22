namespace SeleniumTests;

using OpenQA.Selenium;

public class TaskHelper(AppManager manager) : HelperBase(manager)
{
    public void CreateTask()
    {
        FindElement("._input_15t7a_19").Click();
        FindElement("._input_15t7a_19").SendKeys("Do task");
    }

    public void CreateAndDeleteTask()
    {
        FindElement("._list_13lvv_22:nth-child(3) ._body_1wvuv_92").Click();
        FindElement("._input_15t7a_19").SendKeys("task to delete");
        FindElement(".App").Click();
        FindElement("._list_13lvv_22:nth-child(1) ._cell_1wvuv_23:nth-child(2)").Click();
        FindElement("svg:nth-child(2)").Click();
        Thread.Sleep(1000);
    }

    public void EditTask()
    {
        FindElement("._list_13lvv_22:nth-child(1) span").Click();
        FindElement(".RichNotes-button:nth-child(1)").Click();
        FindElement("._input_dq3mo_15._input_uyi05_1").Click();
        FindElement("._input_dq3mo_15._input_uyi05_1").Clear();
        FindElement("._input_dq3mo_15._input_uyi05_1").SendKeys("Edit task name");
        FindElement("._input_dq3mo_15._input_uyi05_1").SendKeys(Keys.Enter);
        Thread.Sleep(1000);
    }
}
