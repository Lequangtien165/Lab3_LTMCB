namespace Lab03_23521572_LeQuangTien
{
    partial class ChatRoomForm
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
            this.bt_join = new System.Windows.Forms.Button();
            this.bt_create = new System.Windows.Forms.Button();
            this.tb_room_id = new System.Windows.Forms.TextBox();
            this.lbl_input_id = new System.Windows.Forms.Label();
            this.lbl_instruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_join
            // 
            this.bt_join.Location = new System.Drawing.Point(226, 153);
            this.bt_join.Name = "bt_join";
            this.bt_join.Size = new System.Drawing.Size(129, 58);
            this.bt_join.TabIndex = 0;
            this.bt_join.Text = "Tham gia group chat ";
            this.bt_join.UseVisualStyleBackColor = true;
            this.bt_join.Click += new System.EventHandler(this.bt_join_Click);
            // 
            // bt_create
            // 
            this.bt_create.Location = new System.Drawing.Point(373, 153);
            this.bt_create.Name = "bt_create";
            this.bt_create.Size = new System.Drawing.Size(129, 58);
            this.bt_create.TabIndex = 1;
            this.bt_create.Text = "Tạo một group chat mới";
            this.bt_create.UseVisualStyleBackColor = true;
            this.bt_create.Click += new System.EventHandler(this.bt_create_Click);
            // 
            // tb_room_id
            // 
            this.tb_room_id.Location = new System.Drawing.Point(268, 77);
            this.tb_room_id.Name = "tb_room_id";
            this.tb_room_id.Size = new System.Drawing.Size(276, 20);
            this.tb_room_id.TabIndex = 2;
            // 
            // lbl_input_id
            // 
            this.lbl_input_id.AutoSize = true;
            this.lbl_input_id.Location = new System.Drawing.Point(173, 80);
            this.lbl_input_id.Name = "lbl_input_id";
            this.lbl_input_id.Size = new System.Drawing.Size(89, 13);
            this.lbl_input_id.TabIndex = 3;
            this.lbl_input_id.Text = "Nhập mã phòng  ";
            // 
            // lbl_instruction
            // 
            this.lbl_instruction.AutoSize = true;
            this.lbl_instruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_instruction.Location = new System.Drawing.Point(63, 117);
            this.lbl_instruction.Name = "lbl_instruction";
            this.lbl_instruction.Size = new System.Drawing.Size(640, 13);
            this.lbl_instruction.TabIndex = 4;
            this.lbl_instruction.Text = "Hướng dẫn: Nhập mã phòng ở ô trống trên, bạn có thể chọn tham gia phòng chat hoặc" +
    " là tạo phòng chat mới với mã đó.";
            // 
            // ChatRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 289);
            this.Controls.Add(this.lbl_instruction);
            this.Controls.Add(this.lbl_input_id);
            this.Controls.Add(this.tb_room_id);
            this.Controls.Add(this.bt_create);
            this.Controls.Add(this.bt_join);
            this.Name = "ChatRoomForm";
            this.Text = "ChatRoomForm";
            this.Load += new System.EventHandler(this.ChatRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_join;
        private System.Windows.Forms.Button bt_create;
        private System.Windows.Forms.TextBox tb_room_id;
        private System.Windows.Forms.Label lbl_input_id;
        private System.Windows.Forms.Label lbl_instruction;
    }
}