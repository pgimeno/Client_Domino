namespace Client_Domino
{
    partial class Form1
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
            this.lbl_txt_ConfiguraPartida = new System.Windows.Forms.Label();
            this.tb_ConnectionString = new System.Windows.Forms.TextBox();
            this.tb_PlayerName = new System.Windows.Forms.TextBox();
            this.bt_StartGame = new System.Windows.Forms.Button();
            this.board_fitxes = new System.Windows.Forms.Label();
            this.grup_fitxes = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fitxa1 = new System.Windows.Forms.Button();
            this.grup_fitxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_txt_ConfiguraPartida
            // 
            this.lbl_txt_ConfiguraPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_txt_ConfiguraPartida.AutoSize = true;
            this.lbl_txt_ConfiguraPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_txt_ConfiguraPartida.Location = new System.Drawing.Point(23, 18);
            this.lbl_txt_ConfiguraPartida.Name = "lbl_txt_ConfiguraPartida";
            this.lbl_txt_ConfiguraPartida.Size = new System.Drawing.Size(139, 18);
            this.lbl_txt_ConfiguraPartida.TabIndex = 0;
            this.lbl_txt_ConfiguraPartida.Text = "Configura la partida:";
            // 
            // tb_ConnectionString
            // 
            this.tb_ConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ConnectionString.Location = new System.Drawing.Point(168, 13);
            this.tb_ConnectionString.Name = "tb_ConnectionString";
            this.tb_ConnectionString.Size = new System.Drawing.Size(148, 26);
            this.tb_ConnectionString.TabIndex = 1;
            // 
            // tb_PlayerName
            // 
            this.tb_PlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_PlayerName.Location = new System.Drawing.Point(332, 13);
            this.tb_PlayerName.Name = "tb_PlayerName";
            this.tb_PlayerName.Size = new System.Drawing.Size(148, 26);
            this.tb_PlayerName.TabIndex = 2;
            // 
            // bt_StartGame
            // 
            this.bt_StartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_StartGame.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.bt_StartGame.FlatAppearance.BorderSize = 2;
            this.bt_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bt_StartGame.Location = new System.Drawing.Point(698, 13);
            this.bt_StartGame.Name = "bt_StartGame";
            this.bt_StartGame.Size = new System.Drawing.Size(90, 40);
            this.bt_StartGame.TabIndex = 3;
            this.bt_StartGame.Text = "Uneix-te a la partida";
            this.bt_StartGame.UseVisualStyleBackColor = true;
            // 
            // board_fitxes
            // 
            this.board_fitxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.board_fitxes.BackColor = System.Drawing.Color.Snow;
            this.board_fitxes.Location = new System.Drawing.Point(23, 74);
            this.board_fitxes.Name = "board_fitxes";
            this.board_fitxes.Size = new System.Drawing.Size(814, 329);
            this.board_fitxes.TabIndex = 4;
            this.board_fitxes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.board_fitxes.Visible = false;
            // 
            // grup_fitxes
            // 
            this.grup_fitxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grup_fitxes.Controls.Add(this.button6);
            this.grup_fitxes.Controls.Add(this.button5);
            this.grup_fitxes.Controls.Add(this.button4);
            this.grup_fitxes.Controls.Add(this.button3);
            this.grup_fitxes.Controls.Add(this.button2);
            this.grup_fitxes.Controls.Add(this.button1);
            this.grup_fitxes.Controls.Add(this.fitxa1);
            this.grup_fitxes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grup_fitxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grup_fitxes.Location = new System.Drawing.Point(26, 419);
            this.grup_fitxes.Name = "grup_fitxes";
            this.grup_fitxes.Size = new System.Drawing.Size(811, 100);
            this.grup_fitxes.TabIndex = 5;
            this.grup_fitxes.TabStop = false;
            this.grup_fitxes.Text = "Les teves fitxes";
            this.grup_fitxes.Visible = false;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(667, 31);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 48);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(562, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 48);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(457, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 48);
            this.button4.TabIndex = 0;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(352, 31);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 48);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(247, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 48);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(142, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 48);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fitxa1
            // 
            this.fitxa1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fitxa1.Location = new System.Drawing.Point(37, 31);
            this.fitxa1.Name = "fitxa1";
            this.fitxa1.Size = new System.Drawing.Size(99, 48);
            this.fitxa1.TabIndex = 0;
            this.fitxa1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 531);
            this.Controls.Add(this.grup_fitxes);
            this.Controls.Add(this.board_fitxes);
            this.Controls.Add(this.bt_StartGame);
            this.Controls.Add(this.tb_PlayerName);
            this.Controls.Add(this.tb_ConnectionString);
            this.Controls.Add(this.lbl_txt_ConfiguraPartida);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grup_fitxes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_txt_ConfiguraPartida;
        public System.Windows.Forms.TextBox tb_ConnectionString;
        public System.Windows.Forms.TextBox tb_PlayerName;
        public System.Windows.Forms.Button bt_StartGame;
        public System.Windows.Forms.Label board_fitxes;
        public System.Windows.Forms.GroupBox grup_fitxes;
        private System.Windows.Forms.Button fitxa1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

