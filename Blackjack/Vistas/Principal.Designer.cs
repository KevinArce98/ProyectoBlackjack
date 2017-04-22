namespace Blackjack.Vistas
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnJugar = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.txtUsu = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnJugar
            // 
            this.btnJugar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnJugar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnJugar.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.Location = new System.Drawing.Point(74, 186);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(94, 44);
            this.btnJugar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Demi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(259, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 44);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button1.TabIndex = 3;
            this.button1.Text = "Historial";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUsu
            // 
            this.txtUsu.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.txtUsu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsu.Font = new System.Drawing.Font("Engravers MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsu.ForeColor = System.Drawing.Color.White;
            this.txtUsu.Location = new System.Drawing.Point(-4, -1);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(423, 23);
            this.txtUsu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.txtUsu.TabIndex = 4;
            this.txtUsu.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(424, 289);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnJugar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Principal_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnJugar;
        private DevComponents.DotNetBar.ButtonX button1;
        private DevComponents.DotNetBar.LabelX txtUsu;
    }
}