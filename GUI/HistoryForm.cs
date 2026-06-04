namespace Systeme_mutli_langages;

public partial class HistoryForm : Form
{
    private readonly ApiService _api = new ApiService();
    private readonly int _userId;

    private List<SessionDto> _allSessions = new();
    private List<SessionDto> _filtered = new();

    // Pagination state
    private int _pageSize = 10;
    private int _currentPage = 0;

    public HistoryForm(int userId)
    {
        InitializeComponent();
        _userId = userId;
        this.Load += HistoryForm_Load;
    }

    private async void HistoryForm_Load(object? sender, EventArgs e)
    {
        _allSessions = await _api.GetSessionsAsync(_userId);

        // Populate type filter with unique activity names + "All"
        var types = _allSessions.Select(s => s.Type).Distinct().OrderBy(t => t).ToList();
        types.Insert(0, "All");
        filter_combo.DataSource = types;
        filter_combo.SelectedIndex = 0;

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        string selectedType = filter_combo.SelectedItem?.ToString() ?? "All";

        _filtered = selectedType == "All"
            ? _allSessions.ToList()
            : _allSessions.Where(s => s.Type == selectedType).ToList();

        // Also apply the date range filter if the user set one
        if (from_picker.Checked)
            _filtered = _filtered.Where(s =>
                DateTime.Parse(s.Date) >= from_picker.Value.Date).ToList();

        if (to_picker.Checked)
            _filtered = _filtered.Where(s =>
                DateTime.Parse(s.Date) <= to_picker.Value.Date.AddDays(1)).ToList();

        _currentPage = 0;
        RenderPage();
    }

    private void RenderPage()
    {
        int totalPages = (int)Math.Ceiling(_filtered.Count / (double)_pageSize);
        // Guard: if filters leave 0 results, totalPages is 0 — keep _currentPage at 0
        if (totalPages == 0) totalPages = 1;

        var page = _filtered
            .Skip(_currentPage * _pageSize)
            .Take(_pageSize)
            .ToList();

        sessions_grid.Rows.Clear();

        foreach (var s in page)
            sessions_grid.Rows.Add(s.Date, s.Type, $"{s.DurationMin} min", $"{s.Calories:F0} kcal");

        page_label.Text = $"Page {_currentPage + 1} / {totalPages}";
        prev_btn.Enabled = _currentPage > 0;
        next_btn.Enabled = _currentPage < totalPages - 1;
    }

    private void filter_combo_SelectedIndexChanged(object? sender, EventArgs e) => ApplyFilter();
    private void from_picker_ValueChanged(object? sender, EventArgs e) => ApplyFilter();
    private void to_picker_ValueChanged(object? sender, EventArgs e) => ApplyFilter();

    private void prev_btn_Click(object? sender, EventArgs e) { _currentPage--; RenderPage(); }
    private void next_btn_Click(object? sender, EventArgs e) { _currentPage++; RenderPage(); }
}