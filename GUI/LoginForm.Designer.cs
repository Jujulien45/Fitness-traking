namespace Systeme_mutli_langages;

partial class LoginForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        comboUsers = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // comboUsers
        // 
        comboUsers.FormattingEnabled = true;
        comboUsers.Location = new System.Drawing.Point(169, 167);
        comboUsers.Name = "comboUsers";
        comboUsers.Size = new System.Drawing.Size(111, 28);
        comboUsers.TabIndex = 0;
        // 
        // LoginForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(comboUsers);
        Text = "login";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox comboUsers;

    #endregion
}