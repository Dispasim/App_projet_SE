using System;
using System.Media;


namespace App_projet_SE
{
    public partial class Form1 : Form
    {
        private SoundPlayer lecteurAudio;
        public Form1()
        {
            InitializeComponent();
            lecteurAudio = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cheminFichierAudio = @"C:\Users\eliot\Downloads\[Artcore] An(AcuticNotes) - ExaVid (CV4 Remix).wav";

            try
            {
                lecteurAudio.SoundLocation = cheminFichierAudio;
                lecteurAudio.Load();
                lecteurAudio.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de lecture : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }
    }