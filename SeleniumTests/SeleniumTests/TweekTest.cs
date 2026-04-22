namespace SeleniumTests;

public class SuiteTests : IDisposable
{
    private readonly AppManager _app = new();
    private readonly AccountData _accountData = new("maratabashevabashev@yandex.ru", "randomPassword123");

    public void Dispose()
    {
        _app.Stop();
    }

    [Fact]
    public void TweekTest()
    {
        _app.Navigation.GoToMainPage();
        _app.Auth.Login(_accountData);
        _app.Task.CreateTask();
        _app.Task.CreateAndDeleteTask();
        _app.Task.EditTask();
        _app.Auth.Logout();
    }
}
