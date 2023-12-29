using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace App_projet_SE
{
    public partial class CreationCompte : Form
    {
        private readonly HttpClient _client;
        public CreationCompte()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string pseudo_ = pseudo.Text;
            string email_ = email.Text;
            string mdp_ = mdp.Text;

            var data = new { email = email_, mot_de_passe = mdp_, pseudo = pseudo_ };

            try
            {
                string jsonData = JsonSerializer.Serialize(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync("http://127.0.0.1:8000/creer_utilisateur/", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Utilisateur créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    MainPage mainPage = new MainPage();
                    mainPage.ShowDialog();
                    this.Close();
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Échec de la création de l'utilisateur. Message d'erreur : " + errorContent, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage();
            mainPage.ShowDialog();
            this.Close();
        }

        private void pseudo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
