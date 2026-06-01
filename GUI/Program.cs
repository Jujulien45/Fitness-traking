namespace Systeme_mutli_langages;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        // ApiService api = new ApiService();
        // Console.WriteLine((await api.GetUserAsync(1)).Name);
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}