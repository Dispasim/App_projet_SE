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
            email = new TextBox();
            mdp = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label1 = new Label();
            pseudo = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // email
            // 
            email.Location = new Point(282, 144);
            email.Name = "email";
            email.Size = new Size(231, 31);
            email.TabIndex = 1;
            // 
            // mdp
            // 
            mdp.Location = new Point(282, 240);
            mdp.Name = "mdp";
            mdp.Size = new Size(231, 31);
            mdp.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 189);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 4;
            label2.Text = "Mot de passe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 99);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // button1
            // 
            button1.Location = new Point(380, 317);
            button1.Name = "button1";
            button1.Size = new Size(231, 108);
            button1.TabIndex = 6;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(365, 9);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 7;
            label1.Text = "Pseudo";
            // 
            // pseudo
            // 
            pseudo.Location = new Point(282, 52);
            pseudo.Name = "pseudo";
            pseudo.Size = new Size(231, 31);
            pseudo.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(112, 317);
            button2.Name = "button2";
            button2.Size = new Size(231, 108);
            button2.TabIndex = 9;
            button2.Text = "Retour";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CreationCompte
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(pseudo);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(mdp);
            Controls.Add(email);
            Name = "CreationCompte";
            Text = "CreationCompte";
            ResumeLayout(false);
            PerformLayout();
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