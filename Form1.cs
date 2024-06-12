using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraMemo
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
        "red", "czerwony", "green", "zielony", "violet", "fioletowy", "white", "biały",
        "blue", "niebieski", "brown", "brązowy", "yellow", "żółty", "orange", "pomarańczowy"
        };

        Label firstClicked = null;
        Label secondClicked = null;

        private int _ticks;

        private void AssignIconsToSquares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);

                    if (iconLabel.Text == "blue" || iconLabel.Text == "niebieski")
                    {
                        iconLabel.Tag = "Blue";
                    }
                    else if (iconLabel.Text == "red" || iconLabel.Text == "czerwony")
                    {
                        iconLabel.Tag = "Red";
                    }
                    else if (iconLabel.Text == "green" || iconLabel.Text == "zielony")
                    {
                        iconLabel.Tag = "Green";
                    }
                    else if (iconLabel.Text == "violet" || iconLabel.Text == "fioletowy")
                    {
                        iconLabel.Tag = "Violet";
                    }
                    else if (iconLabel.Text == "white" || iconLabel.Text == "biały")
                    {
                        iconLabel.Tag = "White";
                    }
                    else if (iconLabel.Text == "brown" || iconLabel.Text == "brązowy")
                    {
                        iconLabel.Tag = "Brown";
                    }
                    else if (iconLabel.Text == "yellow" || iconLabel.Text == "żółty")
                    {
                        iconLabel.Tag = "Yellow";
                    }
                    else if (iconLabel.Text == "orange" || iconLabel.Text == "pomarańczowy")
                    {
                        iconLabel.Tag = "Orange";
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            timer2.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    firstClicked.BackColor = Color.FromName(firstClicked.Tag.ToString());
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                secondClicked.BackColor = Color.FromName(secondClicked.Tag.ToString());

                CheckForWinner();

                if (firstClicked.Tag == secondClicked.Tag)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = Color.CornflowerBlue;
            firstClicked.BackColor = Color.CornflowerBlue;
            secondClicked.ForeColor = Color.CornflowerBlue;
            secondClicked.BackColor = Color.CornflowerBlue;

            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            timer2.Stop();
            MessageBox.Show("Połączyłeś wszystkie pary!", "Gratulacje!");
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _ticks++;
            label17.Text = "Czas: " + _ticks.ToString() + " s";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }
    }
}
