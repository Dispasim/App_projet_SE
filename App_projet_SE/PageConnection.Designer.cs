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
            label1 = new Label();
            pseudo = new TextBox();
            label2 = new Label();
            mdp = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(355, 80);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 0;
            label1.Text = "Pseudo";
            label1.Click += label1_Click;
            // 
            // pseudo
            // 
            pseudo.Location = new Point(313, 127);
            pseudo.Name = "pseudo";
            pseudo.Size = new Size(150, 31);
            pseudo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(330, 225);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 2;
            label2.Text = "Mot de passe";
            // 
            // mdp
            // 
            mdp.Location = new Point(313, 266);
            mdp.Name = "mdp";
            mdp.PasswordChar = '-';
            mdp.Size = new Size(150, 31);
            mdp.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(384, 342);
            button1.Name = "button1";
            button1.Size = new Size(332, 96);
            button1.TabIndex = 4;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(27, 342);
            button2.Name = "button2";
            button2.Size = new Size(332, 92);
            button2.TabIndex = 5;
            button2.Text = "Retour";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PageConnection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(mdp);
            Controls.Add(label2);
            Controls.Add(pseudo);
            Controls.Add(label1);
            Name = "PageConnection";
            Text = "PageConnection";
            ResumeLayout(false);
            PerformLayout();
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