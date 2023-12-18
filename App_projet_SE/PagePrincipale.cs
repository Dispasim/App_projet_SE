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
        public PagePrincipale(string token_)
        {

            InitializeComponent();
            _client = new HttpClient();
            token = token_;
            myObjects = new List<MyModel>();



        }

        private async void PagePrincipale_Load(object sender, EventArgs e)
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

        private async void buttonLecture_Click(object sender, EventArgs e)
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

                    audioFile = new AudioFileReader(audiopath);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Play();



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

        private void button1_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                audioFile = new AudioFileReader(audiopath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                audioFile.Dispose();
                outputDevice.Dispose();
            }

        }
    }
}
