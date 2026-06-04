namespace Systeme_mutli_langages;

partial class HistoryForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label_type    = new System.Windows.Forms.Label();
        filter_combo  = new System.Windows.Forms.ComboBox();
        label_from    = new System.Windows.Forms.Label();
        from_picker   = new System.Windows.Forms.DateTimePicker();
        label_to      = new System.Windows.Forms.Label();
        to_picker     = new System.Windows.Forms.DateTimePicker();
        sessions_grid = new System.Windows.Forms.DataGridView();
        prev_btn      = new System.Windows.Forms.Button();
        next_btn      = new System.Windows.Forms.Button();
        page_label    = new System.Windows.Forms.Label();

        ((System.ComponentModel.ISupportInitialize)sessions_grid).BeginInit();
        SuspendLayout();

        // type filter
        label_type.Text = "Activity:";
        label_type.Location = new System.Drawing.Point(10, 15);
        label_type.Size = new System.Drawing.Size(70, 28);
        label_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        filter_combo.Location = new System.Drawing.Point(85, 15);
        filter_combo.Size = new System.Drawing.Size(200, 28);
        filter_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        filter_combo.SelectedIndexChanged += filter_combo_SelectedIndexChanged;

        // from date — ShowCheckBox lets the user leave it blank
        label_from.Text = "From:";
        label_from.Location = new System.Drawing.Point(300, 15);
        label_from.Size = new System.Drawing.Size(45, 28);
        label_from.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        from_picker.Location = new System.Drawing.Point(350, 15);
        from_picker.Size = new System.Drawing.Size(160, 28);
        from_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        from_picker.ShowCheckBox = true;
        from_picker.Checked = false;
        from_picker.ValueChanged += from_picker_ValueChanged;

        // to date
        label_to.Text = "To:";
        label_to.Location = new System.Drawing.Point(520, 15);
        label_to.Size = new System.Drawing.Size(30, 28);
        label_to.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        to_picker.Location = new System.Drawing.Point(555, 15);
        to_picker.Size = new System.Drawing.Size(160, 28);
        to_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        to_picker.ShowCheckBox = true;
        to_picker.Checked = false;
        to_picker.ValueChanged += to_picker_ValueChanged;

        // grid
        sessions_grid.Location = new System.Drawing.Point(10, 55);
        sessions_grid.Size = new System.Drawing.Size(860, 340);
        sessions_grid.ReadOnly = true;
        sessions_grid.AllowUserToAddRows = false;
        sessions_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        sessions_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        sessions_grid.Columns.Add("Date", "Date");
        sessions_grid.Columns.Add("Type", "Activity");
        sessions_grid.Columns.Add("Duration", "Duration");
        sessions_grid.Columns.Add("Calories", "Calories");

        // pagination
        prev_btn.Text = "← Prev";
        prev_btn.Location = new System.Drawing.Point(10, 410);
        prev_btn.Size = new System.Drawing.Size(90, 32);
        prev_btn.Click += prev_btn_Click;

        page_label.Location = new System.Drawing.Point(110, 410);
        page_label.Size = new System.Drawing.Size(160, 32);
        page_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        next_btn.Text = "Next →";
        next_btn.Location = new System.Drawing.Point(280, 410);
        next_btn.Size = new System.Drawing.Size(90, 32);
        next_btn.Click += next_btn_Click;

        ((System.ComponentModel.ISupportInitialize)sessions_grid).EndInit();

        ClientSize = new System.Drawing.Size(880, 460);
        Text = "Session History";
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.AddRange(new System.Windows.Forms.Control[] {
            label_type, filter_combo,
            label_from, from_picker,
            label_to, to_picker,
            sessions_grid,
            prev_btn, page_label, next_btn
        });
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label_type;
    private System.Windows.Forms.ComboBox filter_combo;
    private System.Windows.Forms.Label label_from;
    private System.Windows.Forms.DateTimePicker from_picker;
    private System.Windows.Forms.Label label_to;
    private System.Windows.Forms.DateTimePicker to_picker;
    private System.Windows.Forms.DataGridView sessions_grid;
    private System.Windows.Forms.Button prev_btn;
    private System.Windows.Forms.Button next_btn;
    private System.Windows.Forms.Label page_label;
}