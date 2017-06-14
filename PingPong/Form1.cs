using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;  //Speed of the ball
        public int speed_top = 4;
        public int point = 0;         // Scored points

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            Racket.Top = playground.Bottom - (playground.Bottom / 10); // Set the position of the racket
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Racket.Left = Cursor.Position.X - (Racket.Width / 2);  // Set the center of the racket to the position of the cursor

            Ball.Left += speed_left;   //Move the ball
            Ball.Top += speed_top;

            if (Ball.Bottom >= Racket.Top && Ball.Bottom <= Racket.Bottom && Ball.Left >= Racket.Left && Ball.Right <= Racket.Right)  //Racket collision
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;  //Change direction
                point += 1;

            }

            if (Ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (Ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (Ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if (Ball.Bottom >= playground.Bottom)
                timer1.Enabled = false;  //Ball is out -> Stop the game
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } // press escape to quit
        }
    }
}

