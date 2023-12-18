namespace App_projet_SE
{
    partial class PagePrincipale
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
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labelTitre = new Label();
            labelAlbum = new Label();
            labelDuree = new Label();
            buttonLecture = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(45, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(361, 629);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(703, 103);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 1;
            label1.Text = "Titre ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(703, 253);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 2;
            label2.Text = "Album";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(703, 401);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 3;
            label3.Text = "Durée";
            // 
            // labelTitre
            // 
            labelTitre.AutoSize = true;
            labelTitre.Location = new Point(703, 176);
            labelTitre.Name = "labelTitre";
            labelTitre.Size = new Size(0, 25);
            labelTitre.TabIndex = 4;
            // 
            // labelAlbum
            // 
            labelAlbum.AutoSize = true;
            labelAlbum.Location = new Point(703, 328);
            labelAlbum.Name = "labelAlbum";
            labelAlbum.Size = new Size(0, 25);
            labelAlbum.TabIndex = 5;
            // 
            // labelDuree
            // 
            labelDuree.AutoSize = true;
            labelDuree.Location = new Point(703, 470);
            labelDuree.Name = "labelDuree";
            labelDuree.Size = new Size(0, 25);
            labelDuree.TabIndex = 6;
            // 
            // buttonLecture
            // 
            buttonLecture.Location = new Point(547, 512);
            buttonLecture.Name = "buttonLecture";
            buttonLecture.Size = new Size(376, 116);
            buttonLecture.TabIndex = 7;
            buttonLecture.Text = "Télécharger";
            buttonLecture.UseVisualStyleBackColor = true;
            buttonLecture.Click += buttonLecture_Click;
            // 
            // button1
            // 
            button1.Location = new Point(751, 669);
            button1.Name = "button1";
            button1.Size = new Size(172, 134);
            button1.TabIndex = 8;
            button1.Text = "Lecture";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(547, 669);
            button2.Name = "button2";
            button2.Size = new Size(172, 134);
            button2.TabIndex = 9;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // PagePrincipale
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 920);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonLecture);
            Controls.Add(labelDuree);
            Controls.Add(labelAlbum);
            Controls.Add(labelTitre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "PagePrincipale";
            Text = "PagePrincipale";
            Load += PagePrincipale_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelTitre;
        private Label labelAlbum;
        private Label labelDuree;
        private Button buttonLecture;
        private Button button1;
        private Button button2;
    }
}