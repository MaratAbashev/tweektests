using Xunit.Priority;
using System.Xml.Serialization;

namespace SeleniumTests;

[CollectionDefinition("Sequential", DisableParallelization = true)]
public class SequentialCollection { }

[Collection("Sequential")]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class SuiteTests
{
    private readonly AppManager _app = AppManager.GetInstance();
    private readonly AccountData _accountData = new("maratabashevabashev@yandex.ru", "randomPassword123");

    [Fact, Priority(1)]
    public void LoginTest()
    {
        if (!_app.Auth.IsLoggedIn)
            _app.Auth.Login(_accountData);

        Assert.True(_app.Auth.IsLoggedIn, "Пользователь должен быть авторизован после логина");
    }

    [Fact, Priority(2)]
    public void CreateTaskTest()
    {
        if (!_app.Auth.IsLoggedIn)
            _app.Auth.Login(_accountData);

        var tasks = TaskDataFromXmlFile();

        foreach (var taskData in tasks)
        {
            _app.Task.CreateTask(taskData.Name);

            var createdTask = _app.Task.GetLastTaskName();
            Assert.Equal(taskData.Name, createdTask);
        }
    }

    public static IEnumerable<TaskData> TaskDataFromXmlFile()
    {
        var serializer = new XmlSerializer(
            typeof(List<TaskData>),
            new XmlRootAttribute("ArrayOfTaskData")
        );
        using var reader = new StreamReader("tasks.xml");
        return (List<TaskData>)serializer.Deserialize(reader)!;
    }

    [Fact, Priority(3)]
    public void DeleteTaskTest()
    {
        if (!_app.Auth.IsLoggedIn)
            _app.Auth.Login(_accountData);

        const string taskToDelete = "task to delete";
        _app.Task.CreateAndDeleteTask(taskToDelete);

        Assert.True(_app.Task.IsTaskDeleted(taskToDelete), $"Задача '{taskToDelete}' должна быть удалена");
    }

    [Fact, Priority(4)]
    public void EditTaskTest()
    {
        if (!_app.Auth.IsLoggedIn)
            _app.Auth.Login(_accountData);

        _app.Task.CreateTask("Original task");

        const string editedName = "Edit task name";
        _app.Task.EditTask(editedName);

        string actualName = _app.Task.GetEditedTaskName();
        Assert.Equal(editedName, actualName);
    }

    [Fact, Priority(5)]
    public void LogoutTest()
    {
        if (_app.Auth.IsLoggedIn)
            _app.Auth.Logout();

        Assert.False(_app.Auth.IsLoggedIn, "Пользователь должен быть разлогинен после выхода");
    }
}