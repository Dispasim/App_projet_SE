using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static App_projet_SE.Program;

namespace App_projet_SE
{
    public partial class Pargeperso : Form
    {
        private readonly string token;
        private int id;
        private readonly HttpClient _client;
        private List<MyModel> myObjects;
        private int selectedId;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        private System.Windows.Forms.Timer timer;
        private readonly string audiopath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "temp.ext");
        public Pargeperso(string token)
        {
            InitializeComponent();
            this.token = token;
            _client = new HttpClient();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += timer1_Tick;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagePersocs pagePersocs = new PagePersocs(token);
            pagePersocs.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                MyModel selectedObject = myObjects.Find(item => item.titre == selectedItem);
                if (selectedItem != null)
                {
                    labelTitre.Text = selectedObject.titre;
                    labelAlbum.Text = selectedObject.album;
                    labelDuree.Text = selectedObject.duree;
                    selectedId = selectedObject.id;

                }
            }
        }

        private async void Pargeperso_Load(object sender, EventArgs e)
        {
            var endpointUrl = "http://127.0.0.1:8000/get_user_from_token/";


            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync($"{endpointUrl}?token={token}");
                if (response.IsSuccessStatusCode)
                {

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var responseObject = JsonSerializer.Deserialize<IdModel>(jsonResponse);
                    id = responseObject.id;
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    try
                    {
                        HttpResponseMessage response1 = await _client.GetAsync("http://127.0.0.1:8000/musiques_detail_id/" + id.ToString());

                        if (response1.IsSuccessStatusCode)
                        {
                            string responseBody = await response1.Content.ReadAsStringAsync();
                            myObjects = JsonSerializer.Deserialize<List<MyModel>>(responseBody);


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

        private async void button2_Click(object sender, EventArgs e)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync("http://127.0.0.1:8000/musique/" + selectedId.ToString() + "/delete/");

                if (response.IsSuccessStatusCode)
                {

                    MessageBox.Show("Fichier audio supprimé avec succès !");
                    this.Hide();

                    Pargeperso pargeperso = new Pargeperso(token);
                    pargeperso.ShowDialog();
                    this.Close();




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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagePrincipale pagePrincipale = new PagePrincipale(token);
            pagePrincipale.ShowDialog();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                audioFile.Dispose();
                outputDevice.Dispose();
            }
        }

        private async void buttonLecture_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }
            File.Delete(audiopath);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://127.0.0.1:8000/musique/" + selectedId.ToString() + "/fichier_audio/");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    using (Stream audioStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = File.Create(audiopath))
                        {

                            await audioStream.CopyToAsync(fileStream);
                        }
                    }
                    MessageBox.Show("Fichier audio téléchargé avec succès !");





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

        private void button6_Click(object sender, EventArgs e)
        {
            if (outputDevice!= null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
            }
            audioFile = new AudioFileReader(audiopath);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null)
            {



                progressBar1.Maximum = (int)audioFile.TotalTime.TotalSeconds;
                progressBar1.Value = (int)audioFile.CurrentTime.TotalSeconds;
                label4.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
                label6.Text = audioFile.TotalTime.ToString(@"mm\:ss");

            }
        }

        private void progressBar1_Scroll(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(progressBar1.Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (outputDevice == null || audioFile == null)
            {

                MessageBox.Show("Veuillez d'abord sélectionner un fichier audio et appuyer sur 'lecture'.");
                return;

            }

            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Pause();
                button4.Text = "Play";
            }
            else if (outputDevice.PlaybackState == PlaybackState.Paused)
            {
                outputDevice.Play();
                button4.Text = "Pause";
            }
            else
            {
                outputDevice.Play();
                button4.Text = "Pause";
            }
        }
    }
}
