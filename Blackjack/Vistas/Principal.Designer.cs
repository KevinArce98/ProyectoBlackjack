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
            this.btnJugar.Location = new System.Drawing.Point(39, 120);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(75, 32);
            this.btnJugar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnJugar.TabIndex = 2;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button1.Location = new System.Drawing.Point(171, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button1.TabIndex = 3;
            this.button1.Text = "Historial";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUsu
            // 
            this.txtUsu.BackColor = System.Drawing.Color.Blue;
            // 
            // 
            // 
            this.txtUsu.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsu.ForeColor = System.Drawing.Color.Black;
            this.txtUsu.Location = new System.Drawing.Point(-5, -4);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(295, 23);
            this.txtUsu.TabIndex = 4;
            this.txtUsu.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(285, 189);
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