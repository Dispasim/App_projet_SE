namespace App_projet_SE
{
    partial class PageConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.pseudo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mdp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pseudo";
            // 
            // pseudo
            // 
            this.pseudo.Location = new System.Drawing.Point(313, 127);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(150, 31);
            this.pseudo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mot de passe";
            // 
            // mdp
            // 
            this.mdp.Location = new System.Drawing.Point(313, 266);
            this.mdp.Name = "mdp";
            this.mdp.PasswordChar = '-';
            this.mdp.Size = new System.Drawing.Size(150, 31);
            this.mdp.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 96);
            this.button1.TabIndex = 4;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(27, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(332, 92);
            this.button2.TabIndex = 5;
            this.button2.Text = "Retour";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // PageConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pseudo);
            this.Controls.Add(this.label1);
            this.Name = "PageConnection";
            this.Text = "PageConnection";
            this.Load += new System.EventHandler(this.PageConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox pseudo;
        private Label label2;
        private TextBox mdp;
        private Button button1;
        private Button button2;
    }
}