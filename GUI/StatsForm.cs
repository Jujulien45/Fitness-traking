namespace Systeme_mutli_langages;
using System.Windows.Forms.DataVisualization.Charting;

public partial class StatsForm : Form
{
    private readonly ApiService _api = new ApiService();
    private readonly int _userId;

    public StatsForm(int userId)
    {
        InitializeComponent();
        _userId = userId;
        this.Load += StatsForm_Load;
    }

    private async void StatsForm_Load(object? sender, EventArgs e)
    {
        var stats = await _api.GetUserStatsAsync(_userId);
        if (!stats.Any())
        {
            MessageBox.Show("No stats yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        BuildCaloriesChart(stats);
        BuildCountChart(stats);
        PopulateGrid(stats);
    }

    private void BuildCaloriesChart(List<StatsDto> stats)
    {
        var chart = new Chart { Dock = DockStyle.None };
        chart.Location = new System.Drawing.Point(0, 0);
        chart.Size = new System.Drawing.Size(500, 300);

        var area = new ChartArea("Calories");
        chart.ChartAreas.Add(area);

        var series = new Series("Total kcal") { ChartType = SeriesChartType.Bar };
        // Only top 8 activities by calories to keep the chart readable
        foreach (var s in stats.OrderByDescending(s => s.TotalKcal).Take(8))
            series.Points.AddXY(s.Type, s.TotalKcal);

        chart.Series.Add(series);
        chart.Titles.Add("Calories burned by activity");
        area.AxisX.LabelStyle.Angle = -30;
        area.AxisY.Title = "kcal";

        Controls.Add(chart);
    }

    private void BuildCountChart(List<StatsDto> stats)
    {
        var chart = new Chart { Dock = DockStyle.None };
        chart.Location = new System.Drawing.Point(510, 0);
        chart.Size = new System.Drawing.Size(400, 300);

        var area = new ChartArea("Count");
        chart.ChartAreas.Add(area);

        var series = new Series("Session count") { ChartType = SeriesChartType.Pie };
        foreach (var s in stats.OrderByDescending(s => s.Count).Take(6))
        {
            var point = new DataPoint();
            point.SetValueXY(s.Type, s.Count);
            series.Points.Add(point);
        }

        chart.Series.Add(series);
        chart.Titles.Add("Session count by activity");

        Controls.Add(chart);
    }

    private void PopulateGrid(List<StatsDto> stats)
    {
        var grid = new DataGridView
        {
            Location = new System.Drawing.Point(0, 310),
            Size = new System.Drawing.Size(910, 200),
            ReadOnly = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            // AllowUserToAddRows = false keeps the blank "new row" off the bottom
            AllowUserToAddRows = false
        };

        grid.Columns.Add("Type", "Activity");
        grid.Columns.Add("Count", "Sessions");
        grid.Columns.Add("TotalMin", "Total (min)");
        grid.Columns.Add("TotalKcal", "Total (kcal)");

        foreach (var s in stats.OrderByDescending(s => s.TotalKcal))
            grid.Rows.Add(s.Type, s.Count, s.TotalMin, $"{s.TotalKcal:F0}");

        Controls.Add(grid);
    }
}