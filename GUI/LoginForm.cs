namespace Systeme_mutli_langages;

public partial class LoginForm : Form
{
    private readonly ApiService _api;
    public LoginForm()
    {
        InitializeComponent();
        _api = new ApiService();
        this.Load += LoginForm_Load;
    }
    private async void LoginForm_Load(
        object sender,
        EventArgs e)
    {
        var users = await _api.GetUsersAsync();

        comboUsers.DataSource = users;
        comboUsers.DisplayMember = "Name";
        comboUsers.ValueMember = "Id";
    }
}