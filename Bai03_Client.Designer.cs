namespace Lab03_23521572_LeQuangTien
{
    partial class Bai03_Client
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
            this.bt_send = new System.Windows.Forms.Button();
            this.bt_connect = new System.Windows.Forms.Button();
            this.rtb_send_mess = new System.Windows.Forms.RichTextBox();
            this.rtb_sent_mess = new System.Windows.Forms.RichTextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(680, 381);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 11;
            this.bt_send.Text = "Send";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(680, 318);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(75, 23);
            this.bt_connect.TabIndex = 10;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // rtb_send_mess
            // 
            this.rtb_send_mess.Location = new System.Drawing.Point(41, 364);
            this.rtb_send_mess.Name = "rtb_send_mess";
            this.rtb_send_mess.Size = new System.Drawing.Size(617, 40);
            this.rtb_send_mess.TabIndex = 9;
            this.rtb_send_mess.Text = "";
            this.rtb_send_mess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_send_mess_KeyDown);
            // 
            // rtb_sent_mess
            // 
            this.rtb_sent_mess.Location = new System.Drawing.Point(41, 71);
            this.rtb_sent_mess.Name = "rtb_sent_mess";
            this.rtb_sent_mess.Size = new System.Drawing.Size(617, 270);
            this.rtb_sent_mess.TabIndex = 8;
            this.rtb_sent_mess.Text = "";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(211, 29);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 20);
            this.tb_port.TabIndex = 7;
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(41, 29);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(164, 20);
            this.tb_IP.TabIndex = 6;
            // 
            // Bai03_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.rtb_send_mess);
            this.Controls.Add(this.rtb_sent_mess);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_IP);
            this.Name = "Bai03_Client";
            this.Text = "Bai03_Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai03_Client_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.RichTextBox rtb_send_mess;
        private System.Windows.Forms.RichTextBox rtb_sent_mess;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_IP;
    }
}