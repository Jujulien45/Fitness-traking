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

        users_combo.DataSource = users;
        users_combo.DisplayMember = "Name";
        users_combo.ValueMember = "Id";
    }
}