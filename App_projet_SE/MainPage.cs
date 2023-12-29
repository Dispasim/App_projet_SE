using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_projet_SE
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreationCompte creationCompte = new CreationCompte();
            creationCompte.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PageConnection pageConnection = new PageConnection();
            pageConnection.ShowDialog();
            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PageConnection pageConnection = new PageConnection();
            pageConnection.ShowDialog();
            this.Close();

        }
    }
}
