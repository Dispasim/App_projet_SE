namespace App_projet_SE
{
    partial class CreationCompte
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
            this.email = new System.Windows.Forms.TextBox();
            this.mdp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pseudo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(282, 144);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(231, 31);
            this.email.TabIndex = 1;
            // 
            // mdp
            // 
            this.mdp.Location = new System.Drawing.Point(282, 240);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(231, 31);
            this.mdp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de passe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 108);
            this.button1.TabIndex = 6;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pseudo";
            // 
            // pseudo
            // 
            this.pseudo.Location = new System.Drawing.Point(282, 52);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(231, 31);
            this.pseudo.TabIndex = 8;
            this.pseudo.TextChanged += new System.EventHandler(this.pseudo_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 108);
            this.button2.TabIndex = 9;
            this.button2.Text = "Retour";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CreationCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pseudo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.email);
            this.Name = "CreationCompte";
            this.Text = "CreationCompte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox email;
        private TextBox mdp;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label1;
        private TextBox pseudo;
        private Button button2;
    }
}