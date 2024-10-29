namespace Lab03_23521572_LeQuangTien
{
    partial class Room
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
            this.label_message = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.listBox_chatboxC = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(308, 28);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(158, 39);
            this.title.TabIndex = 20;
            this.title.Text = "Chat Room";
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_message.Location = new System.Drawing.Point(42, 375);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(72, 19);
            this.label_message.TabIndex = 19;
            this.label_message.Text = "Message:";
            this.label_message.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_name.Location = new System.Drawing.Point(42, 324);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(88, 19);
            this.label_name.TabIndex = 18;
            this.label_name.Text = "Your name:";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_send.Location = new System.Drawing.Point(634, 386);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(102, 37);
            this.button_send.TabIndex = 17;
            this.button_send.Text = "SEND";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_message.Location = new System.Drawing.Point(46, 397);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(566, 26);
            this.textBox_message.TabIndex = 16;
            this.textBox_message.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_message_KeyDown);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_name.Location = new System.Drawing.Point(46, 346);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(195, 26);
            this.textBox_name.TabIndex = 15;
            // 
            // listBox_chatboxC
            // 
            this.listBox_chatboxC.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listBox_chatboxC.FormattingEnabled = true;
            this.listBox_chatboxC.ItemHeight = 19;
            this.listBox_chatboxC.Location = new System.Drawing.Point(46, 70);
            this.listBox_chatboxC.Name = "listBox_chatboxC";
            this.listBox_chatboxC.ScrollAlwaysVisible = true;
            this.listBox_chatboxC.Size = new System.Drawing.Size(713, 251);
            this.listBox_chatboxC.TabIndex = 14;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.listBox_chatboxC);
            this.Name = "Room";
            this.Text = "Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.ListBox listBox_chatboxC;
    }
}