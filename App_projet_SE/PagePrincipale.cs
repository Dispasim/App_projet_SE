using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static App_projet_SE.Program;

namespace App_projet_SE
{
    public partial class PagePrincipale : Form
    {
        private readonly HttpClient _client;
        private string token;
        public PagePrincipale(string token_)
        {
            
            InitializeComponent();
            _client = new HttpClient();
            token = token_;
            
        }

        private async void PagePrincipale_Load(object sender, EventArgs e)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://127.0.0.1:8000/musiques_detail/");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<MyModel> myObjects = JsonSerializer.Deserialize<List<MyModel>>(responseBody);


                    foreach (MyModel obj in myObjects)
                    {
                        listBox1.Items.Add(obj.titre);
                    }

                }
                else
                {
                    MessageBox.Show("La requête a échoué avec le code : " + response.StatusCode,
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erreur lors de la requête : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
