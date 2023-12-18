using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;



namespace App_projet_SE
{

    public partial class PageConnection : Form
    {
        private readonly HttpClient _client;
        private string token;
        public PageConnection()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string pseudo_ = pseudo.Text;
            string mdp_ = mdp.Text;

            var data = new { username = pseudo_, password = mdp_ };

            try
            {
                string jsonData = JsonSerializer.Serialize(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync("http://127.0.0.1:8000/connexion/", content);

                if (response.IsSuccessStatusCode)
                {

                    var responseData = await response.Content.ReadAsStringAsync();


                    var jsonDoc = JsonDocument.Parse(responseData);
                    var _token = jsonDoc.RootElement.GetProperty("token").GetString();


                    token = _token;

                    MessageBox.Show("Connexion réussie ! Token : " + token, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    PagePrincipale pagePrincipale = new PagePrincipale(token);
                    pagePrincipale.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage();
            mainPage.ShowDialog();
            this.Close();
        }
    }
}
