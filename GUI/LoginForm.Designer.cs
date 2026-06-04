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
        users_combo = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        login_btn = new System.Windows.Forms.Button();
        username_tb = new System.Windows.Forms.TextBox();
        create_btn = new System.Windows.Forms.Button();
        label4 = new System.Windows.Forms.Label();
        is_male_cb = new System.Windows.Forms.CheckBox();
        height_nup = new System.Windows.Forms.NumericUpDown();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        age_nup = new System.Windows.Forms.NumericUpDown();
        label7 = new System.Windows.Forms.Label();
        weight_nup = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)height_nup).BeginInit();
        ((System.ComponentModel.ISupportInitialize)age_nup).BeginInit();
        ((System.ComponentModel.ISupportInitialize)weight_nup).BeginInit();
        SuspendLayout();
        // 
        // users_combo
        // 
        users_combo.FormattingEnabled = true;
        users_combo.Location = new System.Drawing.Point(95, 158);
        users_combo.Name = "users_combo";
        users_combo.Size = new System.Drawing.Size(111, 28);
        users_combo.TabIndex = 0;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(44, 98);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(212, 57);
        label1.TabIndex = 1;
        label1.Text = "Login";
        label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(310, 154);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(74, 40);
        label2.TabIndex = 2;
        label2.Text = "OR";
        label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(483, 42);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(243, 98);
        label3.TabIndex = 3;
        label3.Text = "Create a new account";
        label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // login_btn
        // 
        login_btn.Location = new System.Drawing.Point(44, 223);
        login_btn.Name = "login_btn";
        login_btn.Size = new System.Drawing.Size(213, 36);
        login_btn.TabIndex = 4;
        login_btn.Text = "Login";
        login_btn.UseVisualStyleBackColor = true;
        // 
        // username_tb
        // 
        username_tb.Location = new System.Drawing.Point(594, 140);
        username_tb.Name = "username_tb";
        username_tb.Size = new System.Drawing.Size(152, 27);
        username_tb.TabIndex = 5;
        username_tb.Text = "username here";
        // 
        // create_btn
        // 
        create_btn.Location = new System.Drawing.Point(513, 350);
        create_btn.Name = "create_btn";
        create_btn.Size = new System.Drawing.Size(213, 36);
        create_btn.TabIndex = 6;
        create_btn.Text = "Create";
        create_btn.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(492, 140);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(96, 33);
        label4.TabIndex = 7;
        label4.Text = "username:";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // is_male_cb
        // 
        is_male_cb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
        is_male_cb.Location = new System.Drawing.Point(526, 300);
        is_male_cb.Name = "is_male_cb";
        is_male_cb.Size = new System.Drawing.Size(102, 36);
        is_male_cb.TabIndex = 8;
        is_male_cb.Text = "is male";
        is_male_cb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        is_male_cb.UseVisualStyleBackColor = true;
        // 
        // height_nup
        // 
        height_nup.DecimalPlaces = 1;
        height_nup.Location = new System.Drawing.Point(594, 267);
        height_nup.Maximum = new decimal(new int[] { 230, 0, 0, 0 });
        height_nup.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        height_nup.Name = "height_nup";
        height_nup.Size = new System.Drawing.Size(73, 27);
        height_nup.TabIndex = 9;
        height_nup.Value = new decimal(new int[] { 170, 0, 0, 0 });
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(492, 259);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(96, 40);
        label5.TabIndex = 10;
        label5.Text = "height (cm)";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(513, 226);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(75, 40);
        label6.TabIndex = 12;
        label6.Text = "age";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // age_nup
        // 
        age_nup.Location = new System.Drawing.Point(594, 234);
        age_nup.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        age_nup.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        age_nup.Name = "age_nup";
        age_nup.Size = new System.Drawing.Size(73, 27);
        age_nup.TabIndex = 11;
        age_nup.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(492, 193);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(96, 40);
        label7.TabIndex = 14;
        label7.Text = "weight (kg)";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // weight_nup
        // 
        weight_nup.DecimalPlaces = 1;
        weight_nup.Location = new System.Drawing.Point(594, 201);
        weight_nup.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        weight_nup.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        weight_nup.Name = "weight_nup";
        weight_nup.Size = new System.Drawing.Size(73, 27);
        weight_nup.TabIndex = 13;
        weight_nup.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // LoginForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label7);
        Controls.Add(weight_nup);
        Controls.Add(label6);
        Controls.Add(age_nup);
        Controls.Add(label5);
        Controls.Add(height_nup);
        Controls.Add(is_male_cb);
        Controls.Add(label4);
        Controls.Add(create_btn);
        Controls.Add(username_tb);
        Controls.Add(login_btn);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(users_combo);
        Text = "login";
        ((System.ComponentModel.ISupportInitialize)height_nup).EndInit();
        ((System.ComponentModel.ISupportInitialize)age_nup).EndInit();
        ((System.ComponentModel.ISupportInitialize)weight_nup).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox is_male_cb;
    private System.Windows.Forms.NumericUpDown height_nup;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown age_nup;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown weight_nup;

    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox username_tb;
    private System.Windows.Forms.Button create_btn;

    private System.Windows.Forms.Button login_btn;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ComboBox users_combo;

    #endregion
}