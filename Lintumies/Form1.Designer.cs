namespace Lintumies
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            panel2 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(287, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 280);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(80, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(165, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(118, 169);
            button1.Name = "button1";
            button1.Size = new Size(79, 30);
            button1.TabIndex = 0;
            button1.Text = "Play sound";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(287, 354);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 73);
            panel2.TabIndex = 1;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDarkDark;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(232, 0);
            button4.Name = "button4";
            button4.Size = new Size(79, 70);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDarkDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(118, 1);
            button3.Name = "button3";
            button3.Size = new Size(79, 70);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDarkDark;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(3, 0);
            button2.Name = "button2";
            button2.Size = new Size(79, 70);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(287, 274);
            label1.Name = "label1";
            label1.Size = new Size(314, 62);
            label1.TabIndex = 2;
            label1.Text = "Welcome to bird quiz. \r\nYour task is to listen to the bird song and \r\nselect the corresponding bird from the 3 options below";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 525);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private PictureBox pictureBox1;
        private Label label1;
    }
}