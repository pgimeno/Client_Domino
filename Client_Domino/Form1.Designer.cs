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
            this.SuspendLayout();
            // 
            // lbl_txt_ConfiguraPartida
            // 
            this.lbl_txt_ConfiguraPartida.AutoSize = true;
            this.lbl_txt_ConfiguraPartida.Location = new System.Drawing.Point(81, 31);
            this.lbl_txt_ConfiguraPartida.Name = "lbl_txt_ConfiguraPartida";
            this.lbl_txt_ConfiguraPartida.Size = new System.Drawing.Size(101, 13);
            this.lbl_txt_ConfiguraPartida.TabIndex = 0;
            this.lbl_txt_ConfiguraPartida.Text = "Configura la partida:";
            // 
            // tb_ConnectionString
            // 
            this.tb_ConnectionString.Location = new System.Drawing.Point(219, 23);
            this.tb_ConnectionString.Name = "tb_ConnectionString";
            this.tb_ConnectionString.Size = new System.Drawing.Size(100, 20);
            this.tb_ConnectionString.TabIndex = 1;
            // 
            // tb_PlayerName
            // 
            this.tb_PlayerName.Location = new System.Drawing.Point(349, 23);
            this.tb_PlayerName.Name = "tb_PlayerName";
            this.tb_PlayerName.Size = new System.Drawing.Size(100, 20);
            this.tb_PlayerName.TabIndex = 2;
            // 
            // bt_StartGame
            // 
            this.bt_StartGame.Location = new System.Drawing.Point(500, 10);
            this.bt_StartGame.Name = "bt_StartGame";
            this.bt_StartGame.Size = new System.Drawing.Size(80, 44);
            this.bt_StartGame.TabIndex = 3;
            this.bt_StartGame.Text = "Uneix-te a la partida";
            this.bt_StartGame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_StartGame);
            this.Controls.Add(this.tb_PlayerName);
            this.Controls.Add(this.tb_ConnectionString);
            this.Controls.Add(this.lbl_txt_ConfiguraPartida);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_txt_ConfiguraPartida;
        public System.Windows.Forms.TextBox tb_ConnectionString;
        public System.Windows.Forms.TextBox tb_PlayerName;
        public System.Windows.Forms.Button bt_StartGame;
    }
}

