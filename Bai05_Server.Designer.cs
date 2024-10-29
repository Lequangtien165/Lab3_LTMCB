namespace Lab03_23521572_LeQuangTien
{
    partial class Bai05_Server
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
            this.title = new System.Windows.Forms.Label();
            this.listBox_listChat = new System.Windows.Forms.ListBox();
            this.button_Listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(41, 34);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(235, 36);
            this.title.TabIndex = 8;
            this.title.Text = "Server - ChatRoom";
            // 
            // listBox_listChat
            // 
            this.listBox_listChat.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listBox_listChat.FormattingEnabled = true;
            this.listBox_listChat.ItemHeight = 19;
            this.listBox_listChat.Location = new System.Drawing.Point(47, 90);
            this.listBox_listChat.Name = "listBox_listChat";
            this.listBox_listChat.ScrollAlwaysVisible = true;
            this.listBox_listChat.Size = new System.Drawing.Size(712, 327);
            this.listBox_listChat.TabIndex = 7;
            // 
            // button_Listen
            // 
            this.button_Listen.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_Listen.Location = new System.Drawing.Point(634, 34);
            this.button_Listen.Name = "button_Listen";
            this.button_Listen.Size = new System.Drawing.Size(113, 36);
            this.button_Listen.TabIndex = 6;
            this.button_Listen.Text = "LISTEN";
            this.button_Listen.UseVisualStyleBackColor = true;
            this.button_Listen.Click += new System.EventHandler(this.button_Listen_Click);
            // 
            // Bai05_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.title);
            this.Controls.Add(this.listBox_listChat);
            this.Controls.Add(this.button_Listen);
            this.Name = "Bai05_Server";
            this.Text = "Bai05_Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ListBox listBox_listChat;
        private System.Windows.Forms.Button button_Listen;
    }
}