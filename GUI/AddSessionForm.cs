namespace Systeme_mutli_langages;

public partial class AddSessionForm : Form
{
    private readonly ApiService _api = new ApiService();
    private readonly int _userId;
    private List<ActivityDto> _activities = new();

    public AddSessionForm(int userId)
    {
        InitializeComponent();
        _userId = userId;
        this.Load += AddSessionForm_Load;
    }

    private async void AddSessionForm_Load(object? sender, EventArgs e)
    {
        _activities = await _api.GetSessionTypesAsync();
        type_combo.DataSource = _activities;
        type_combo.DisplayMember = "Name";
        type_combo.ValueMember = "ActivityId";

        date_picker.Value = DateTime.Now;
        date_picker.Format = DateTimePickerFormat.Custom;
        date_picker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
    }

    private async void add_btn_Click(object? sender, EventArgs e)
    {
        if (type_combo.SelectedItem is not ActivityDto selected) return;

        var dto = new WriteSessionDto
        {
            UserId = _userId,
            Type = selected.Name,
            DurationMin = (int)duration_nup.Value,
            Met = selected.Met,
            Date = date_picker.Value.ToString("yyyy-MM-dd HH:mm:ss")
        };

        try
        {
            await _api.AddSessionAsync(dto);
            MessageBox.Show("Session added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cancel_btn_Click(object? sender, EventArgs e) => this.Close();
}