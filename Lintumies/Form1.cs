using System.Diagnostics;
using System.Media;
using Lintumies.Database;


namespace Lintumies
{
    public partial class Form1 : Form
    {
        bool clicked = false;
        bool correctAnswer = false;

        string bird = "";
        string birdImagePath = "";

        List<string> linnut;
        Button[] buttons = new Button[4];

        Random random = new Random();
        int rndBtn = 0;

        private SoundPlayer player;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        BirdDB.BirdDBMethods birdDetails;
        SpacedRepetition spacedRepetition = new SpacedRepetition();

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
            timer.Interval = 5000; //set the duration to 5 seconds
            timer.Tick += Timer_Tick;
            birdRowCntReset();
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

            checkIfSame(); //make sure none of the buttons have the same bird
        }

        //checks if any of the choices are the same -> change name of one of the choices
        public void checkIfSame()
        {

            if (button2.Text == button3.Text || button2.Text == button4.Text || button2.Text == button5.Text ||
                button3.Text == button4.Text || button3.Text == button5.Text ||
                button4.Text == button5.Text)
            {

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
                    else if (button3.Text != bird && (button3.Text == button4.Text || button3.Text == button5.Text))
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
            timer.Start();
        }

        /*
         * button changes colors of wrong answers to red and correct to green
         * chosen answer changes outline to yellow
         * bird image will be shown
        */
        private void birdUpdater(bool correct, BirdDB.BirdDBMethods birdDetails)
        {
            BirdDB.BirdDBMethods birdUpdate = new BirdDB.BirdDBMethods();

            int heardCnt = birdDetails.heardCnt, correctCnt = birdDetails.correctCnt, wrongCnt = birdDetails.wrongCnt;

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
            birdUpdate.UpdateBird(birdDetails.birdName, heardCnt, correctCnt, wrongCnt, birdDetails.rowCnt, priority);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!clicked)
            {
                label1.Visible = false;
                clicked = true;

                if (btn.Text == bird)
                    correctAnswer = true;
                else
                    correctAnswer = false;

                birdUpdater(correctAnswer, birdDetails);

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
            //if user pressed Next without answering update bird with +1 in wrongCnt
            if (!clicked)
            {
                correctAnswer = false;
                birdUpdater(correctAnswer, birdDetails);
            }

            clicked = false;

            if (player != null)
            {
                player.Stop();
                timer.Stop();
            }
            linnut = spacedRepetition.listOfBirds();
            string rndBird = Satunnainen();
            bird = rndBird;
            birdImagePath = Path.GetFullPath("../../../Lintukuvat/" + rndBird + ".jpg");
            pictureBox1.Image = Image.FromFile("../../../Lintukuvat/Lintu.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            setButtons();

            //reset buttons to default values
            for (int i = 0; i < 4; i++)
            {
                buttons[i].BackColor = Color.Black;
                buttons[i].ForeColor = Color.White;
            }

            button1_Click(sender, e);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            player.Stop();
            timer.Stop(); 
        }
        private string Satunnainen()
        {
            Random random = new Random();
            int luku = random.Next(0, 4);
            var lintu = linnut[luku];
            return lintu;
        }

        //Reset the rowCnt for all birds
        private void birdRowCntReset()
        {
            List<string> birds = new List<string>();
            birds.Add("Harakka");
            birds.Add("Hippiainen");
            birds.Add("Jarripeippo");
            birds.Add("Kaki");
            birds.Add("Pajulintu");
            birds.Add("Peippo");
            birds.Add("Punarinta");
            birds.Add("Rakattirastas");
            birds.Add("Selkalokki");
            birds.Add("Varis");
            foreach (string bird in birds)
            {
                birdDetails = BirdDB.BirdDBMethods.GetBirdDetails(bird);
                BirdDB.BirdDBMethods birdUpdate = new BirdDB.BirdDBMethods();
                birdUpdate.UpdateBird(birdDetails.birdName, birdDetails.heardCnt, birdDetails.correctCnt, birdDetails.wrongCnt, 0, birdDetails.Priority);
            }
        }

        //reset rowCnt when exiting the application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            birdRowCntReset();
        }

        //go see your results
        private void button7_Click(object sender, EventArgs e)
        {
            if (player != null)
                player.Stop();
            // Create an instance of the new form
            Form2 form2 = new Form2();

            // Show the new form
            form2.Show();

            // Hide the current form (Form1)
            this.Hide();
        }
    }
}