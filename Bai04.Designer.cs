namespace Lab03_23521572_LeQuangTien
{
    partial class Bai04
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
            this.button_openC = new System.Windows.Forms.Button();
            this.button_openS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.title.Location = new System.Drawing.Point(106, 102);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(581, 43);
            this.title.TabIndex = 5;
            this.title.Text = "Bài 04: Nhận gửi dữ liệu (1C - NS)";
            // 
            // button_openC
            // 
            this.button_openC.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_openC.Location = new System.Drawing.Point(411, 196);
            this.button_openC.Name = "button_openC";
            this.button_openC.Size = new System.Drawing.Size(185, 69);
            this.button_openC.TabIndex = 4;
            this.button_openC.Text = "Client";
            this.button_openC.UseVisualStyleBackColor = true;
            this.button_openC.Click += new System.EventHandler(this.button_openC_Click);
            // 
            // button_openS
            // 
            this.button_openS.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_openS.Location = new System.Drawing.Point(144, 196);
            this.button_openS.Name = "button_openS";
            this.button_openS.Size = new System.Drawing.Size(185, 69);
            this.button_openS.TabIndex = 3;
            this.button_openS.Text = "Server";
            this.button_openS.UseVisualStyleBackColor = true;
            this.button_openS.Click += new System.EventHandler(this.button_openS_Click);
            // 
            // Bai04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 390);
            this.Controls.Add(this.title);
            this.Controls.Add(this.button_openC);
            this.Controls.Add(this.button_openS);
            this.Name = "Bai04";
            this.Text = "Bai04";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button button_openC;
        private System.Windows.Forms.Button button_openS;
    }
}