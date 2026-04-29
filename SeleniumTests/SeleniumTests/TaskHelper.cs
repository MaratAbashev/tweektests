namespace SeleniumTests;

using OpenQA.Selenium;

public class TaskHelper(AppManager manager) : HelperBase(manager)
{
    private const string TaskInputSelector = "._input_15t7a_19";
    private const string LastTaskSelector = "._list_1q8sw_27:nth-child(1) span";

    public void CreateTask(string taskName = "Do task")
    {
        FindElement(TaskInputSelector).Click();
        FindElement(TaskInputSelector).SendKeys(taskName);
        FindElement(TaskInputSelector).SendKeys(Keys.Enter);
        FindElement(".App").Click();
        Thread.Sleep(1000);
    }

    public string GetLastTaskName()
    {
        return FindElements(LastTaskSelector).Last().Text;
    }

    public void CreateAndDeleteTask()
    {
        FindElement(TaskInputSelector).SendKeys("task to delete");
        FindElement(".App").Click();
        FindElements(LastTaskSelector).Last().Click();
        FindElement("svg:nth-child(2)").Click();
        Thread.Sleep(1000);
        FindElement(".App").Click();
        Thread.Sleep(1000);
    }

    public bool IsTaskDeleted(string taskName)
    {
        var tasks = Driver.FindElements(By.CssSelector(LastTaskSelector));
        return tasks.All(t => t.Text != taskName);
    }

    public void EditTask(string newName = "Edit task name")
    {
        FindElement(LastTaskSelector).Click();
        FindElement(".RichNotes-button:nth-child(1)").Click();
        var input = FindElement("._input_dq3mo_15._input_uyi05_1");
        input.Click();
        input.Clear();
        input.SendKeys(newName);
        input.SendKeys(Keys.Enter);
        Thread.Sleep(1000);
        FindElement(".App").Click();
        Thread.Sleep(1000);
    }

    public string GetEditedTaskName()
    {
        return FindElement(LastTaskSelector).Text;
    }
}
