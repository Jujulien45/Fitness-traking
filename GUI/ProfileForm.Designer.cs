using System.ComponentModel;

namespace Systeme_mutli_langages;

partial class ProfileForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        numericUpDown4 = new System.Windows.Forms.NumericUpDown();
        numericUpDown5 = new System.Windows.Forms.NumericUpDown();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        textBox2 = new System.Windows.Forms.TextBox();
        numericUpDown6 = new System.Windows.Forms.NumericUpDown();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        history_btn = new System.Windows.Forms.Button();
        stats_btn = new System.Windows.Forms.Button();
        add_session_btn = new System.Windows.Forms.Button();
        bmi_label = new System.Windows.Forms.Label();
        category_label = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
        SuspendLayout();
        // 
        // numericUpDown4
        // 
        numericUpDown4.Location = new System.Drawing.Point(162, 308);
        numericUpDown4.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        numericUpDown4.Name = "numericUpDown4";
        numericUpDown4.Size = new System.Drawing.Size(73, 27);
        numericUpDown4.TabIndex = 19;
        // 
        // numericUpDown5
        // 
        numericUpDown5.DecimalPlaces = 1;
        numericUpDown5.Location = new System.Drawing.Point(162, 341);
        numericUpDown5.Maximum = new decimal(new int[] { 230, 0, 0, 0 });
        numericUpDown5.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
        numericUpDown5.Name = "numericUpDown5";
        numericUpDown5.Size = new System.Drawing.Size(73, 27);
        numericUpDown5.TabIndex = 17;
        numericUpDown5.Value = new decimal(new int[] { 170, 0, 0, 0 });
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(15, 214);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(141, 33);
        label5.TabIndex = 16;
        label5.Text = "new username*:";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(81, 300);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(75, 40);
        label6.TabIndex = 20;
        label6.Text = "age*";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(162, 214);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(152, 27);
        textBox2.TabIndex = 15;
        // 
        // numericUpDown6
        // 
        numericUpDown6.DecimalPlaces = 1;
        numericUpDown6.Location = new System.Drawing.Point(162, 275);
        numericUpDown6.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
        numericUpDown6.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDown6.Name = "numericUpDown6";
        numericUpDown6.Size = new System.Drawing.Size(73, 27);
        numericUpDown6.TabIndex = 21;
        numericUpDown6.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(60, 333);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(96, 40);
        label7.TabIndex = 18;
        label7.Text = "height (cm)";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label8
        // 
        label8.Location = new System.Drawing.Point(60, 267);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(96, 40);
        label8.TabIndex = 22;
        label8.Text = "weight (kg)";
        label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(1, 177);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(155, 37);
        label1.TabIndex = 23;
        label1.Text = "* for optional values";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(25, 84);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(289, 93);
        label2.TabIndex = 24;
        label2.Text = "Update your account data";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(25, 391);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(241, 47);
        button1.TabIndex = 25;
        button1.Text = "Update";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // history_btn
        // 
        history_btn.Location = new System.Drawing.Point(547, 12);
        history_btn.Name = "history_btn";
        history_btn.Size = new System.Drawing.Size(241, 47);
        history_btn.TabIndex = 26;
        history_btn.Text = "History";
        history_btn.UseVisualStyleBackColor = true;
        history_btn.Click += open_history_btn_Click;
        // 
        // stats_btn
        // 
        stats_btn.Location = new System.Drawing.Point(297, 12);
        stats_btn.Name = "stats_btn";
        stats_btn.Size = new System.Drawing.Size(241, 47);
        stats_btn.TabIndex = 27;
        stats_btn.Text = "Stats";
        stats_btn.UseVisualStyleBackColor = true;
        stats_btn.Click += open_stats_btn_Click;
        // 
        // add_session_btn
        // 
        add_session_btn.Location = new System.Drawing.Point(50, 12);
        add_session_btn.Name = "add_session_btn";
        add_session_btn.Size = new System.Drawing.Size(241, 47);
        add_session_btn.TabIndex = 28;
        add_session_btn.Text = "Add session";
        add_session_btn.UseVisualStyleBackColor = true;
        add_session_btn.Click += open_add_session_btn_Click;
        // 
        // bmi_label
        // 
        bmi_label.Location = new System.Drawing.Point(324, 372);
        bmi_label.Name = "bmi_label";
        bmi_label.Size = new System.Drawing.Size(112, 32);
        bmi_label.TabIndex = 29;
        // 
        // category_label
        // 
        category_label.Location = new System.Drawing.Point(334, 303);
        category_label.Name = "category_label";
        category_label.Size = new System.Drawing.Size(112, 32);
        category_label.TabIndex = 30;
        // 
        // ProfileForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1087, 567);
        Controls.Add(category_label);
        Controls.Add(bmi_label);
        Controls.Add(add_session_btn);
        Controls.Add(stats_btn);
        Controls.Add(history_btn);
        Controls.Add(button1);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(numericUpDown6);
        Controls.Add(textBox2);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(numericUpDown4);
        Controls.Add(numericUpDown5);
        Text = "ProfileForm";
        ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label bmi_label;
    private System.Windows.Forms.Label category_label;

    private System.Windows.Forms.Button history_btn;
    private System.Windows.Forms.Button stats_btn;
    private System.Windows.Forms.Button add_session_btn;


    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.NumericUpDown numericUpDown4;
    private System.Windows.Forms.NumericUpDown numericUpDown5;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.NumericUpDown numericUpDown6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    #endregion
}