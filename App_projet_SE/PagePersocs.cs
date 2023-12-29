using NAudio.Wave;
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
using static App_projet_SE.Program;

namespace App_projet_SE
{
    public partial class PagePersocs : Form
    {
        private readonly string token;
        private AudioFileReader audiofile;
        private string audiopath;
        private readonly HttpClient _client;
        private string duree;
        public PagePersocs(string token)
        {
            InitializeComponent();
            this.token = token;
            _client = new HttpClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog dossierDialogue = new OpenFileDialog())
            {
               
                DialogResult resultat = dossierDialogue.ShowDialog();

                if (resultat == DialogResult.OK && !string.IsNullOrWhiteSpace(dossierDialogue.FileName))
                {

                    try
                    {
                        using (var audioFile = new AudioFileReader(dossierDialogue.FileName))
                        {
                       
                            audiofile = new AudioFileReader(dossierDialogue.FileName);
                            audiopath = dossierDialogue.FileName;
                            duree = ((int)audiofile.TotalTime.TotalSeconds).ToString();
                            labelNom.Text = dossierDialogue.FileName;
                            labelDuree.Text = string.Format("{0:hh\\:mm\\:ss}", audiofile.TotalTime);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                    MessageBox.Show("Aucun dossier sélectionné.");
                }
            }
        }

        private void PagePersocs_Load(object sender, EventArgs e)
        {

        }

        private void labelNom_Click(object sender, EventArgs e)
        {

        }

        private void labelDuree_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (audiofile != null)
            {
                int id;
                using var httpClient = new HttpClient();
                string titre;
                string artiste;
                string album;




                var endpointUrl = "http://127.0.0.1:8000/get_user_from_token/";


                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                HttpResponseMessage response;
                try
                {

                    response = await httpClient.GetAsync($"{endpointUrl}?token={token}");


                    if (response.IsSuccessStatusCode)
                    {

                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var responseObject = JsonSerializer.Deserialize<IdModel>(jsonResponse);
                        id = responseObject.id;
                        titre = textBoxTitre.Text;
                        artiste = textBoxAlbum.Text;
                        album = textBoxAlbum.Text;
                        try
                        {
                            


                            using MultipartFormDataContent form = new MultipartFormDataContent();

                            form.Add(new StringContent(id.ToString()), "auteur");
                            form.Add(new StringContent(album), "album");
                            form.Add(new StringContent(titre), "titre");
                            form.Add(new StringContent(artiste), "artiste");
                            form.Add(new StringContent(duree), "duree");


                            using FileStream fileStream = new FileStream(audiopath, FileMode.Open);
                            form.Add(new StreamContent(fileStream), "fichier_audio", Path.GetFileName(audiopath));

                            HttpResponseMessage response1 = await httpClient.PostAsync("http://127.0.0.1:8000/musiques/", form);

                            if (response1.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Fichier audio envoyé avec succès.");

                            }
                            else
                            {
                                MessageBox.Show($"Erreur lors de l'envoi du fichier audio. Code de statut : {response.StatusCode}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Une exception s'est produite : {ex.Message}");
                        }


                    }
                    else
                    {
                        MessageBox.Show($"Erreur : Statut de la réponse : {response.StatusCode}");
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une exception s'est produite : {ex.Message}");


              
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Pargeperso pargeperso = new Pargeperso(token);
            pargeperso.ShowDialog();
            this.Close();
        }
    }
    
}
