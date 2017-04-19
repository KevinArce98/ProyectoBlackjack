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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoginFacebook
            // 
            this.btnLoginFacebook.Image = ((System.Drawing.Image)(resources.GetObject("btnLoginFacebook.Image")));
            this.btnLoginFacebook.Location = new System.Drawing.Point(53, 121);
            this.btnLoginFacebook.Name = "btnLoginFacebook";
            this.btnLoginFacebook.Size = new System.Drawing.Size(396, 61);
            this.btnLoginFacebook.TabIndex = 0;
            this.btnLoginFacebook.UseVisualStyleBackColor = true;
            this.btnLoginFacebook.Click += new System.EventHandler(this.btnLoginFacebook_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Image = global::Blackjack.Properties.Resources.logoutfacebbok;
            this.btnLogOut.Location = new System.Drawing.Point(78, 61);
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
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 238);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLoginFacebook);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrincipalJuego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrincipalJuego";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoginFacebook;
        private System.Windows.Forms.Button btnLogOut;
    }
}