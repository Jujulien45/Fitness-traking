namespace Systeme_mutli_langages;

partial class StatsForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        ClientSize = new System.Drawing.Size(930, 530);
        Text = "Stats";
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ResumeLayout(false);
    }
}