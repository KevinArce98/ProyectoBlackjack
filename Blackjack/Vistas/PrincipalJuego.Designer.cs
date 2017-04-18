namespace Blackjack.Vistas
{
    partial class PrincipalJuego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalJuego));
            this.btnLoginFacebook = new System.Windows.Forms.Button();
            this.imgPerfil = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoginFacebook
            // 
            this.btnLoginFacebook.Image = ((System.Drawing.Image)(resources.GetObject("btnLoginFacebook.Image")));
            this.btnLoginFacebook.Location = new System.Drawing.Point(344, 415);
            this.btnLoginFacebook.Name = "btnLoginFacebook";
            this.btnLoginFacebook.Size = new System.Drawing.Size(396, 61);
            this.btnLoginFacebook.TabIndex = 0;
            this.btnLoginFacebook.UseVisualStyleBackColor = true;
            this.btnLoginFacebook.Click += new System.EventHandler(this.btnLoginFacebook_Click);
            // 
            // imgPerfil
            // 
            this.imgPerfil.Location = new System.Drawing.Point(435, 568);
            this.imgPerfil.Name = "imgPerfil";
            this.imgPerfil.Size = new System.Drawing.Size(100, 84);
            this.imgPerfil.TabIndex = 1;
            this.imgPerfil.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Image = global::Blackjack.Properties.Resources.logoutfacebbok;
            this.btnLogOut.Location = new System.Drawing.Point(369, 355);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(331, 54);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // PrincipalJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blackjack.Properties.Resources.Casino_Hd_Hd_Desktop_Wallpaper;
            this.ClientSize = new System.Drawing.Size(1816, 1053);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.imgPerfil);
            this.Controls.Add(this.btnLoginFacebook);
            this.Name = "PrincipalJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrincipalJuego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.imgPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoginFacebook;
        private System.Windows.Forms.PictureBox imgPerfil;
        private System.Windows.Forms.Button btnLogOut;
    }
}