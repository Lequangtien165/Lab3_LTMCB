namespace Lab03_23521572_LeQuangTien
{
    partial class Bai05
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lbl_username = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.bt_sign_in = new System.Windows.Forms.Button();
            this.lbl_to_sign_up_form = new System.Windows.Forms.LinkLabel();
            this.lbl_ask = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(40, 62);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(58, 13);
            this.lbl_username.TabIndex = 0;
            this.lbl_username.Text = "Username ";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(110, 62);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(203, 20);
            this.tb_username.TabIndex = 1;
            // 
            // tb_pass
            // 
            this.tb_pass.Location = new System.Drawing.Point(110, 108);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(203, 20);
            this.tb_pass.TabIndex = 3;
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(40, 108);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(56, 13);
            this.lbl_pass.TabIndex = 2;
            this.lbl_pass.Text = "Password ";
            // 
            // bt_sign_in
            // 
            this.bt_sign_in.Location = new System.Drawing.Point(225, 150);
            this.bt_sign_in.Name = "bt_sign_in";
            this.bt_sign_in.Size = new System.Drawing.Size(88, 30);
            this.bt_sign_in.TabIndex = 4;
            this.bt_sign_in.Text = "Đăng nhập ";
            this.bt_sign_in.UseVisualStyleBackColor = true;
            this.bt_sign_in.Click += new System.EventHandler(this.bt_sign_in_Click);
            // 
            // lbl_to_sign_up_form
            // 
            this.lbl_to_sign_up_form.AutoSize = true;
            this.lbl_to_sign_up_form.Location = new System.Drawing.Point(258, 197);
            this.lbl_to_sign_up_form.Name = "lbl_to_sign_up_form";
            this.lbl_to_sign_up_form.Size = new System.Drawing.Size(49, 13);
            this.lbl_to_sign_up_form.TabIndex = 5;
            this.lbl_to_sign_up_form.TabStop = true;
            this.lbl_to_sign_up_form.Text = "Đăng kí ";
            this.lbl_to_sign_up_form.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_to_sign_up_form_LinkClicked);
            // 
            // lbl_ask
            // 
            this.lbl_ask.AutoSize = true;
            this.lbl_ask.Location = new System.Drawing.Point(146, 197);
            this.lbl_ask.Name = "lbl_ask";
            this.lbl_ask.Size = new System.Drawing.Size(106, 13);
            this.lbl_ask.TabIndex = 6;
            this.lbl_ask.Text = "Chưa có tài khoản?  ";
            // 
            // Bai05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 271);
            this.Controls.Add(this.lbl_ask);
            this.Controls.Add(this.lbl_to_sign_up_form);
            this.Controls.Add(this.bt_sign_in);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.lbl_username);
            this.Name = "Bai05";
            this.Text = "Bai05";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Button bt_sign_in;
        private System.Windows.Forms.LinkLabel lbl_to_sign_up_form;
        private System.Windows.Forms.Label lbl_ask;
    }
}