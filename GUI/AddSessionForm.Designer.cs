namespace Systeme_mutli_langages;

partial class AddSessionForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label_title   = new System.Windows.Forms.Label();
        label_type    = new System.Windows.Forms.Label();
        type_combo    = new System.Windows.Forms.ComboBox();
        label_dur     = new System.Windows.Forms.Label();
        duration_nup  = new System.Windows.Forms.NumericUpDown();
        label_date    = new System.Windows.Forms.Label();
        date_picker   = new System.Windows.Forms.DateTimePicker();
        add_btn       = new System.Windows.Forms.Button();
        cancel_btn    = new System.Windows.Forms.Button();

        ((System.ComponentModel.ISupportInitialize)duration_nup).BeginInit();
        SuspendLayout();

        // title
        label_title.Text = "Add a Session";
        label_title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        label_title.Location = new System.Drawing.Point(20, 20);
        label_title.Size = new System.Drawing.Size(360, 40);
        label_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;

        // type
        label_type.Text = "Activity type:";
        label_type.Location = new System.Drawing.Point(20, 80);
        label_type.Size = new System.Drawing.Size(120, 28);
        label_type.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        type_combo.Location = new System.Drawing.Point(150, 80);
        type_combo.Size = new System.Drawing.Size(220, 28);
        type_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        // duration
        label_dur.Text = "Duration (min):";
        label_dur.Location = new System.Drawing.Point(20, 130);
        label_dur.Size = new System.Drawing.Size(120, 28);
        label_dur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        duration_nup.Location = new System.Drawing.Point(150, 130);
        duration_nup.Size = new System.Drawing.Size(80, 28);
        duration_nup.Minimum = 1;
        duration_nup.Maximum = 600;
        duration_nup.Value = 30;

        // date
        label_date.Text = "Date:";
        label_date.Location = new System.Drawing.Point(20, 180);
        label_date.Size = new System.Drawing.Size(120, 28);
        label_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        date_picker.Location = new System.Drawing.Point(150, 180);
        date_picker.Size = new System.Drawing.Size(220, 28);

        // buttons
        add_btn.Text = "Add";
        add_btn.Location = new System.Drawing.Point(150, 240);
        add_btn.Size = new System.Drawing.Size(100, 36);
        add_btn.Click += add_btn_Click;

        cancel_btn.Text = "Cancel";
        cancel_btn.Location = new System.Drawing.Point(270, 240);
        cancel_btn.Size = new System.Drawing.Size(100, 36);
        cancel_btn.Click += cancel_btn_Click;

        ((System.ComponentModel.ISupportInitialize)duration_nup).EndInit();

        ClientSize = new System.Drawing.Size(420, 310);
        Text = "Add Session";
        Controls.AddRange(new System.Windows.Forms.Control[] {
            label_title, label_type, type_combo,
            label_dur, duration_nup,
            label_date, date_picker,
            add_btn, cancel_btn
        });
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label_title;
    private System.Windows.Forms.Label label_type;
    private System.Windows.Forms.ComboBox type_combo;
    private System.Windows.Forms.Label label_dur;
    private System.Windows.Forms.NumericUpDown duration_nup;
    private System.Windows.Forms.Label label_date;
    private System.Windows.Forms.DateTimePicker date_picker;
    private System.Windows.Forms.Button add_btn;
    private System.Windows.Forms.Button cancel_btn;
}