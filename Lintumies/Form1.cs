using System.Diagnostics;
using System.Media;
using Lintumies.Database;


namespace Lintumies
{
    //basic code to create and save a bird

    //BirdBD bird = new BirdBD()
    //{
    //    birdName = "Some bird name",
    //    heardCnt = 10,
    //    correctCnt = 5,
    //    wrongCnt = 5,
    //    Priority = 2
    //};
    //bird.SaveToJson("birdData.json");
    public partial class Form1 : Form
    {
        bool clicked = false;
        string bird = "";
        string birdImagePath = "";
        Random random = new Random();
        Button[] buttons = new Button[4];
        int rndBtn = 0;
        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
            bird = Satunnainen();
            birdImagePath = Path.GetFullPath("../../../Lintukuvat/" + bird + ".jpg");
            buttons[0] = button2;
            buttons[1] = button3;
            buttons[2] = button4;
            buttons[3] = button5;
            setButtons();
        }

        //set the buttons to random names (except for the chosen bird)
        // chosen bird button is a random button
        public void setButtons()
        {
            rndBtn = random.Next(0, 4);

            buttons[rndBtn].Text = bird;
            

            if (button2.Text != buttons[rndBtn].Text)
                button2.Text = Satunnainen();
            if (button3.Text != buttons[rndBtn].Text)
                button3.Text = Satunnainen();
            if (button4.Text != buttons[rndBtn].Text)
                button4.Text = Satunnainen();
            if (button5.Text != buttons[rndBtn].Text)
                button5.Text = Satunnainen();

            Debug.WriteLine(rndBtn);
            checkIfSame();

        }

        //checks if any of the choices are the same -> change name of one of the choices
        public void checkIfSame()
        {

            if (button2.Text == button3.Text || button2.Text == button4.Text || button2.Text == button5.Text ||
                button3.Text == button4.Text || button3.Text == button5.Text ||
                button4.Text == button5.Text) {

                Debug.WriteLine(buttons[0].Text);
                Debug.WriteLine(button3.Text);
                Debug.WriteLine(button4.Text);
                Debug.WriteLine(button5.Text);
                for (int i = 0; i < 4; i++)
                {
                    if (buttons[i].Text == bird && i != rndBtn)
                    {
                        buttons[i].Text = Satunnainen();
                    }
                    else if (button2.Text != bird && (button2.Text == button3.Text || button2.Text == button4.Text || button2.Text == button5.Text))
                    {
                        button2.Text = Satunnainen();
                    }
                    else if(button3.Text != bird && (button3.Text == button4.Text || button3.Text == button5.Text))
                    {
                        button3.Text = Satunnainen();
                    }
                    else if (button4.Text != bird && (button4.Text == button5.Text))
                    {
                        button4.Text = Satunnainen();
                    }
                }
                Debug.WriteLine("----------------------------------");
                checkIfSame();
            }
        }


        List<string> arr = new List<string> { "Varis_1.wav", "Varis_2.wav", "Varis_3.wav"
            , "Varis_4.wav", "Varis_5.wav" }; //Test code for .wav files


        //select the chosen bird's audio file randomly
        private void button1_Click(object sender, EventArgs e)
        {
            BirdDB.BirdDBMethods birdDetails = BirdDB.BirdDBMethods.GetBirdDetails(bird);
            int rndBirdSound = random.Next(0, 5);

            player = new SoundPlayer(birdDetails.birdSounds[rndBirdSound]);
            player.Play();


        }

        /*
         * button changes colors of wrong answers to red and correct to green
         * chosen answer changes outline to yellow
         * bird image will be shown
        */
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!clicked)
            {
                label1.Visible = false;
                clicked = true;
                btn.ForeColor = Color.Yellow;
                if (button2.Text == bird)
                {
                    button2.BackColor = Color.Green;
                    button3.BackColor = Color.Red;
                    button4.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else if (button3.Text == bird)
                {
                    button3.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button4.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (button4.Text == bird)
                {
                    button4.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button3.BackColor = Color.Red;
                    button5.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                else if (button5.Text == bird)
                {
                    button5.BackColor = Color.Green;

                    button2.BackColor = Color.Red;
                    button3.BackColor = Color.Red;
                    button4.BackColor = Color.Red;


                    pictureBox1.Image = Image.FromFile(birdImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        //button for Next bird sound
        private void button6_Click(object sender, EventArgs e)
        {
            if(player != null)
                player.Stop();
            string rndBird = Satunnainen();
            birdImagePath = Path.GetFullPath("../../../Lintukuvat/" + rndBird + ".jpg");
            pictureBox1.Image = Image.FromFile("../../../Lintukuvat/Lintu.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            bird = rndBird;
            setButtons();



            button2.BackColor = Color.Magenta;
            button3.BackColor = Color.Magenta;
            button4.BackColor = Color.Magenta;
            button5.BackColor = Color.Magenta;


            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.White;

            clicked = false;

            button1_Click(sender, e);
            List<BirdDB.BirdDBMethods> birdList = new List<BirdDB.BirdDBMethods>();
            //bird.AddBird("bird name", 10, 5, 5, 1);




        }


        public string Satunnainen()
        {
            List<string> linnut = new List<string>();
            linnut.Add("Harakka");
            linnut.Add("Hippiainen");
            linnut.Add("Jarripeippo");
            linnut.Add("Kaki");
            linnut.Add("Pajulintu");
            linnut.Add("Peippo");
            linnut.Add("Punarinta");
            linnut.Add("Rakattirastas");
            linnut.Add("Selkalokki");
            linnut.Add("Varis");
            Random random = new Random();
            int luku = random.Next(0, 10);
            var lintu = linnut[luku];
            Debug.WriteLine(luku);

            return lintu;


        }
    }
}