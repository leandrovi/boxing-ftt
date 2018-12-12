namespace BoxingFTT
{
    partial class Jogo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jogo));
            this.pgbVidaMaquina = new System.Windows.Forms.ProgressBar();
            this.pgbVidaJogador = new System.Windows.Forms.ProgressBar();
            this.picMaquina = new System.Windows.Forms.PictureBox();
            this.picJogador = new System.Windows.Forms.PictureBox();
            this.timerMaquina = new System.Windows.Forms.Timer(this.components);
            this.movimentoMaquina = new System.Windows.Forms.Timer(this.components);
            this.movimentoJogador = new System.Windows.Forms.Timer(this.components);
            this.lblCronometro = new System.Windows.Forms.Label();
            this.timerCronometro = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMaquina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJogador)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbVidaMaquina
            // 
            this.pgbVidaMaquina.Location = new System.Drawing.Point(108, 74);
            this.pgbVidaMaquina.Name = "pgbVidaMaquina";
            this.pgbVidaMaquina.Size = new System.Drawing.Size(400, 45);
            this.pgbVidaMaquina.TabIndex = 0;
            // 
            // pgbVidaJogador
            // 
            this.pgbVidaJogador.Location = new System.Drawing.Point(686, 72);
            this.pgbVidaJogador.Name = "pgbVidaJogador";
            this.pgbVidaJogador.Size = new System.Drawing.Size(404, 45);
            this.pgbVidaJogador.TabIndex = 1;
            // 
            // picMaquina
            // 
            this.picMaquina.BackColor = System.Drawing.Color.Transparent;
            this.picMaquina.Image = global::BoxingFTT.Properties.Resources.enemy_stand;
            this.picMaquina.Location = new System.Drawing.Point(578, 392);
            this.picMaquina.Name = "picMaquina";
            this.picMaquina.Size = new System.Drawing.Size(77, 185);
            this.picMaquina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMaquina.TabIndex = 2;
            this.picMaquina.TabStop = false;
            // 
            // picJogador
            // 
            this.picJogador.BackColor = System.Drawing.Color.Transparent;
            this.picJogador.Image = global::BoxingFTT.Properties.Resources.boxer_stand;
            this.picJogador.Location = new System.Drawing.Point(532, 515);
            this.picJogador.Name = "picJogador";
            this.picJogador.Size = new System.Drawing.Size(61, 153);
            this.picJogador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picJogador.TabIndex = 3;
            this.picJogador.TabStop = false;
            // 
            // timerMaquina
            // 
            this.timerMaquina.Enabled = true;
            this.timerMaquina.Interval = 1000;
            this.timerMaquina.Tick += new System.EventHandler(this.eventoSocoMaquina);
            // 
            // movimentoMaquina
            // 
            this.movimentoMaquina.Enabled = true;
            this.movimentoMaquina.Interval = 20;
            this.movimentoMaquina.Tick += new System.EventHandler(this.eventoMovimentoMaquina);
            // 
            // movimentoJogador
            // 
            this.movimentoJogador.Enabled = true;
            this.movimentoJogador.Interval = 20;
            this.movimentoJogador.Tick += new System.EventHandler(this.eventoMovimentoJogador);
            // 
            // lblCronometro
            // 
            this.lblCronometro.AutoSize = true;
            this.lblCronometro.Location = new System.Drawing.Point(570, 106);
            this.lblCronometro.Name = "lblCronometro";
            this.lblCronometro.Size = new System.Drawing.Size(0, 20);
            this.lblCronometro.TabIndex = 4;
            this.lblCronometro.Tag = " ";
            // 
            // timerCronometro
            // 
            this.timerCronometro.Enabled = true;
            this.timerCronometro.Tick += new System.EventHandler(this.eventoCronometro);
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoxingFTT.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1198, 1034);
            this.Controls.Add(this.lblCronometro);
            this.Controls.Add(this.picJogador);
            this.Controls.Add(this.picMaquina);
            this.Controls.Add(this.pgbVidaJogador);
            this.Controls.Add(this.pgbVidaMaquina);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1220, 1090);
            this.Name = "Jogo";
            this.Text = "Ultimate Boxing FTT";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaPraBaixo);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.teclaPraCima);
            ((System.ComponentModel.ISupportInitialize)(this.picMaquina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJogador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbVidaMaquina;
        private System.Windows.Forms.ProgressBar pgbVidaJogador;
        private System.Windows.Forms.PictureBox picMaquina;
        private System.Windows.Forms.PictureBox picJogador;
        private System.Windows.Forms.Timer timerMaquina;
        private System.Windows.Forms.Timer movimentoMaquina;
        private System.Windows.Forms.Timer movimentoJogador;
        private System.Windows.Forms.Label lblCronometro;
        private System.Windows.Forms.Timer timerCronometro;
    }
}

