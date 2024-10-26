namespace Lab03_23521572_LeQuangTien
{
    partial class Bai03_Server
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
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.bt_listen = new System.Windows.Forms.Button();
            this.rtb_rcv_mess = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(25, 30);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(184, 20);
            this.tb_IP.TabIndex = 0;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(215, 30);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(95, 20);
            this.tb_port.TabIndex = 1;
            // 
            // bt_listen
            // 
            this.bt_listen.Location = new System.Drawing.Point(660, 30);
            this.bt_listen.Name = "bt_listen";
            this.bt_listen.Size = new System.Drawing.Size(112, 23);
            this.bt_listen.TabIndex = 2;
            this.bt_listen.Text = "Listen";
            this.bt_listen.UseVisualStyleBackColor = true;
            this.bt_listen.Click += new System.EventHandler(this.bt_listen_Click);
            // 
            // rtb_rcv_mess
            // 
            this.rtb_rcv_mess.Location = new System.Drawing.Point(25, 77);
            this.rtb_rcv_mess.Name = "rtb_rcv_mess";
            this.rtb_rcv_mess.Size = new System.Drawing.Size(747, 342);
            this.rtb_rcv_mess.TabIndex = 3;
            this.rtb_rcv_mess.Text = "";
            // 
            // Bai03_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_rcv_mess);
            this.Controls.Add(this.bt_listen);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_IP);
            this.Name = "Bai03_Server";
            this.Text = "Bai03_Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai03_Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button bt_listen;
        private System.Windows.Forms.RichTextBox rtb_rcv_mess;
    }
}