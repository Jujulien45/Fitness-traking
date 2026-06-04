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

    private async void LoginForm_Load(object? sender, EventArgs e)
    {
        var users = await _api.GetUsersAsync();
        users_combo.DataSource = users;
        users_combo.DisplayMember = "Name";
        users_combo.ValueMember = "Id";
    }

    public async void PressLoginbtn(object? sender, EventArgs e)
    {
        if (users_combo.SelectedItem == null) return;
        UserDto user = (UserDto)users_combo.SelectedItem;
        await Program.Forms.ShowForm(FormManager.ProfileFormId, user);
    }

    private async void create_btn_Click(object? sender, EventArgs e)
    {
        string name = username_tb.Text.Trim();
        if (string.IsNullOrEmpty(name) || name == "username here")
        {
            MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var dto = new WriteUserDto
        {
            Name = name,
            Age = (int)age_nup.Value,
            Height_m = (float)height_nup.Value / 100f,  // cm → meters
            Weight_kg = (float)weight_nup.Value,
            Sex = is_male_cb.Checked ? "M" : "F"
        };

        try
        {
            UserDto created = await _api.AddUserAsync(dto);
            MessageBox.Show($"Account created for {created.Name}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh the combo and auto-select the new user
            var users = await _api.GetUsersAsync();
            users_combo.DataSource = users;
            users_combo.DisplayMember = "Name";
            users_combo.ValueMember = "Id";
            users_combo.SelectedValue = created.Id;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}