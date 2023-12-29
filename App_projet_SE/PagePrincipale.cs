using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static App_projet_SE.Program;
using NAudio.Wave;
using System.Reflection;


namespace App_projet_SE
{
    public partial class PagePrincipale : Form
    {
        private readonly HttpClient _client;
        private string token;
        private List<MyModel> myObjects;
        private int selectedId;
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        private readonly string audiopath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "temp.ext");
        private System.Windows.Forms.Timer timer;
        public PagePrincipale(string token_)
        {

            InitializeComponent();
            _client = new HttpClient();
            token = token_;
            myObjects = new List<MyModel>();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += timer1_Tick;



        }

        private async void PagePrincipale_Load_1(object sender, EventArgs e)
        {
            MessageBox.Show(audiopath);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://127.0.0.1:8000/musiques_detail/");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
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

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private async void buttonLecture_Click_1(object sender, EventArgs e)
        {
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                audioFile = new AudioFileReader(audiopath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            timer.Start();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                audioFile.Dispose();
                outputDevice.Dispose();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreationCompte creationCompte = new CreationCompte();
            PagePersocs pagePersocs = new PagePersocs(token);    
            pagePersocs.ShowDialog();
            this.Close();
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

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

        private void progressBar1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void progressBar1_Scroll_1(object sender, EventArgs e)
        {
            if (audioFile != null && outputDevice != null)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(progressBar1.Value);
            }

        }
    }
}
