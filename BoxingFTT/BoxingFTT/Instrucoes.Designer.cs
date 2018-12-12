namespace BoxingFTT
{
    partial class Instrucoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instrucoes));
            this.btnInstrucoes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInstrucoes
            // 
            this.btnInstrucoes.BackColor = System.Drawing.Color.Black;
            this.btnInstrucoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInstrucoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstrucoes.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnInstrucoes.FlatAppearance.BorderSize = 0;
            this.btnInstrucoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInstrucoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInstrucoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstrucoes.ForeColor = System.Drawing.Color.Transparent;
            this.btnInstrucoes.Location = new System.Drawing.Point(509, 736);
            this.btnInstrucoes.Name = "btnInstrucoes";
            this.btnInstrucoes.Size = new System.Drawing.Size(178, 64);
            this.btnInstrucoes.TabIndex = 3;
            this.btnInstrucoes.UseVisualStyleBackColor = false;
            // 
            // Instrucoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoxingFTT.Properties.Resources.intrucoes;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1203, 864);
            this.Controls.Add(this.btnInstrucoes);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Instrucoes";
            this.Text = "Instruções";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstrucoes;
    }
}