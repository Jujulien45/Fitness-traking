namespace Systeme_mutli_langages;
using System.Windows.Forms.DataVisualization.Charting;

public partial class ProfileForm : Form
{
    private UserDto? _user;
    private readonly System.Windows.Forms.Timer _timer = new();
    private readonly ApiService _service = new ApiService();

    public ProfileForm()
    {
        InitializeComponent();
        _timer.Interval = 5000;
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

private async void Timer_Tick(object? sender, EventArgs e)
    {
        await RefreshBmi();
    }

    // RefreshChart only updates the chart data, never recreates the control
    private async Task RefreshBmi()
    {
        if (_user == null) return;

        var history = await _service.BmiHistoryAsync(_user.Id);
        var latest = history.LastOrDefault();
        if (latest == null) return;

        bmi_label.Text = $"BMI: {latest.Bmi:F1}";
        category_label.Text = latest.Category;
        category_label.ForeColor = latest.Category switch
        {
            "under"  => System.Drawing.Color.DodgerBlue,
            "normal" => System.Drawing.Color.Green,
            "over"   => System.Drawing.Color.Orange,
            "obese"  => System.Drawing.Color.Red,
            _        => System.Drawing.SystemColors.ControlText
        };
    }

    public async Task SetUser(UserDto user)
    {
        _user = user;
        await RefreshBmi();
    }

    private async void button1_Click(object? sender, EventArgs e)
    {
        if (_user == null) return;

        string newName = textBox2.Text.Trim();
        var dto = new WriteUserDto
        {
            Name = string.IsNullOrEmpty(newName) ? _user.Name : newName,
            Age = numericUpDown4.Value > 0 ? (int)numericUpDown4.Value : _user.Age,
            Height_m = numericUpDown5.Value > 0 ? (float)numericUpDown5.Value / 100f : _user.Height_m,
            Weight_kg = numericUpDown6.Value > 0 ? (float)numericUpDown6.Value : _user.Weight_kg,
            Sex = _user.Sex
        };

        try
        {
            await _service.UpdateUserAsync(_user.Id, dto);
            _user = await _service.GetUserAsync(_user.Id);
            MessageBox.Show("Profile updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await RefreshBmi();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    
    private void open_history_btn_Click(object? sender, EventArgs e)
    {
        if (_user == null) return;
        // "using var" ensures the form is disposed when closed
        using var form = new HistoryForm(_user.Id);
        form.ShowDialog();  // ShowDialog = modal (blocks ProfileForm until closed)
    }

    private void open_add_session_btn_Click(object? sender, EventArgs e)
    {
        if (_user == null) return;
        using var form = new AddSessionForm(_user.Id);
        form.ShowDialog();
    }

    private void open_stats_btn_Click(object? sender, EventArgs e)
    {
        if (_user == null) return;
        using var form = new StatsForm(_user.Id);
        form.ShowDialog();
    }
}