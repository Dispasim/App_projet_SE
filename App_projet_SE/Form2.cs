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
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace App_projet_SE
{
    public partial class Form2 : Form
    {
        private AudioFileReader audioFile;
        private WaveOutEvent outputDevice;
        public Form2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://127.0.0.1:8000/musique/1/fichier-audio/";
            string audioFilePath = "C:/Users/eliot/Downloads/temporaire.ext";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    using (Stream audioStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = File.Create(audioFilePath))
                        {
                            await audioStream.CopyToAsync(fileStream);
                        }
                    }

                    // Jouer le fichier audio téléchargé avec NAudio
                    audioFile = new AudioFileReader(audioFilePath);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                }
                else
                {
                    MessageBox.Show("Erreur lors du téléchargement du fichier audio.");
                }
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
