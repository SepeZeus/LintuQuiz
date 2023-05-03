using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Media;

namespace Lintumies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        List<string> arr = new List<string> { "Varis_1.wav", "Varis_2.wav", "Varis_3.wav"
            , "Varis_4.wav", "Varis_5.wav" }; //Test code for .wav files

        private void button1_Click(object sender, EventArgs e)
        {
            //Test code for .wav files

            //Random rnd = new Random();
            //int rndN = rnd.Next(0, arr.Count);
            string birdSound = arr[0];
            //Debug.WriteLine(arr[0]);
            string birdSoundPath = Path.GetFullPath("../../../Lintuaanet/Varis/" + birdSound);

            SoundPlayer player = new SoundPlayer(birdSoundPath);
            Debug.WriteLine(birdSoundPath);

            player.Play();

        }
    }
}