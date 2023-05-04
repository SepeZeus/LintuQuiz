using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Media;

namespace Lintumies
{
    public partial class Form1 : Form
    {
        string bird = "Varis";
        public Form1()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.ForeColor = Color.Yellow;
            if (button2.Text == bird)
            {
                button2.BackColor = Color.Green;
                button3.BackColor = Color.Red;
                button4.BackColor = Color.Red;

            }
            else if (button3.Text == bird)
            {
                button3.BackColor = Color.Green;

                button2.BackColor = Color.Red;
                button4.BackColor = Color.Red;
            }
            else if (button4.Text == bird)
            {
                button4.BackColor = Color.Green;

                button2.BackColor = Color.Red;
                button3.BackColor = Color.Red;
            }
        }


    }
}