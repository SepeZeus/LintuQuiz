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
        bool correctAnswer = false;
        string bird = "";
        string birdImagePath = "";
        Random random = new Random();
        Button[] buttons = new Button[4];
        int rndBtn = 0;
        private SoundPlayer player;
        BirdDB.BirdDBMethods birdDetails;
        SpacedRepetition spacedRepetition = new SpacedRepetition();
        List<string> linnut;

        bool locked = false;


        public Form1()
        {
            InitializeComponent();
            linnut = spacedRepetition.listOfBirds();
            bird = Satunnainen();
            birdDetails = BirdDB.BirdDBMethods.GetBirdDetails(bird);
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
            Satunnainen();
            locked = true;

            buttons[rndBtn].Text = bird;
            

            if (button2.Text != buttons[rndBtn].Text)
                button2.Text = Satunnainen();
            if (button3.Text != buttons[rndBtn].Text)
                button3.Text = Satunnainen();
            if (button4.Text != buttons[rndBtn].Text)
                button4.Text = Satunnainen();
            if (button5.Text != buttons[rndBtn].Text)
                button5.Text = Satunnainen();

            checkIfSame();

        }

        //checks if any of the choices are the same -> change name of one of the choices
        public void checkIfSame()
        {

            if (button2.Text == button3.Text || button2.Text == button4.Text || button2.Text == button5.Text ||
                button3.Text == button4.Text || button3.Text == button5.Text ||
                button4.Text == button5.Text) {

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
                checkIfSame();
            }
        }


        //select the chosen bird's audio file randomly
        private void button1_Click(object sender, EventArgs e)
        {
            birdDetails = BirdDB.BirdDBMethods.GetBirdDetails(bird);
            int rndBirdSound = random.Next(0, 5);

            player = new SoundPlayer(birdDetails.birdSounds[rndBirdSound]);
            player.Play();


        }

        /*
         * button changes colors of wrong answers to red and correct to green
         * chosen answer changes outline to yellow
         * bird image will be shown
        */

        private void birdUpdater(bool correct)
        {
            BirdDB.BirdDBMethods birdUpdate = new BirdDB.BirdDBMethods();

            int heardCnt = birdDetails.heardCnt, correctCnt = birdDetails.correctCnt, wrongCnt = birdDetails.wrongCnt, rowCnt = birdDetails.rowCnt;

            if (correct)
            {
                heardCnt += 1;
                correctCnt += 1;
            }
            else
            {
                heardCnt += 1;
                wrongCnt += 1;
            }
            double priority = spacedRepetition.priotityCalculator(heardCnt, wrongCnt);
            birdUpdate.UpdateBird(bird, heardCnt, correctCnt, wrongCnt, rowCnt, priority);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!clicked)
            {
                if (btn.Text == bird)
                    correctAnswer = true;
                else
                    correctAnswer = false;
                birdUpdater(correctAnswer);
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
            linnut = spacedRepetition.listOfBirds();
            string rndBird = Satunnainen();
            birdImagePath = Path.GetFullPath("../../../Lintukuvat/" + rndBird + ".jpg");
            pictureBox1.Image = Image.FromFile("../../../Lintukuvat/Lintu.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            locked = false;

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

            if (!clicked)
            {
                correctAnswer = false;
                birdUpdater(correctAnswer);
            }

            clicked = false;

            button1_Click(sender, e);

        }


        public string Satunnainen()
        {
            Random random = new Random();
            int luku = random.Next(0, 5);
            var lintu = linnut[luku];

            if (!locked)
            {
                Debug.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

                for (int i = 0; i < 5; i++)
                {
                    Debug.WriteLine(linnut[i]);
                }
            }
            return lintu;


        }
    }
}