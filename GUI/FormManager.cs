namespace Systeme_mutli_langages;

public class FormManager
{
    private Form? _currentForm;

    private LoginForm _loginForm = new LoginForm();
    private ProfileForm _profileForm = new ProfileForm();

    public static int LoginFormId = 0;
    public static int ProfileFormId = 1;

    public FormManager()
    {
        _loginForm.FormClosing += Exit;
        _profileForm.FormClosing += Exit;
    }

    public void ShowForm(int formId)
    {
        _currentForm?.Hide();
        if (LoginFormId == formId) _currentForm = _loginForm;
        if (ProfileFormId == formId) _currentForm = _profileForm;
        _currentForm?.Show();
    }

    public async Task ShowForm(int formId, UserDto user)
    {
        _currentForm?.Hide();
        await _profileForm.SetUser(user);
        _currentForm = _profileForm;
        _currentForm?.Show();
    }

    public void Exit(object? sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }
}