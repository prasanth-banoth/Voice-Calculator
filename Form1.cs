using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace SlidingPanelForm
{
    sealed public partial class SlidingForm : Form
    {
        // Variables
        private int panel2_width;
        private int panel1_width;
        private bool is_hidden;
        private bool button_is_clicked;
        private int panel_resize_speed;
        private bool changed_colors;
        List<string> operators;
        List<char> operations;
        SpeechSynthesizer my_speaker;

        public SlidingForm()
        {
            InitializeComponent();
            this.Name = "Calculator";
            this.Text = "Calculator";

            // Get panel width
            panel2_width = panel2.Width;
            panel1_width = panel1.Width;
            panel2.Width = panel1.Width;
            is_hidden = true;
            panel_resize_speed = 2;

            // Get button status
            button_is_clicked = false;
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
            changed_colors = false;

            // Hide calculator and initialise operators
            panel3.Visible = false;
            operators = new List<string>();
            operations = new List<char>();

            // Create speaker
            my_speaker = new SpeechSynthesizer();
        }

        // Center app
        private void SlidingForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        // Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (is_hidden == false && button_is_clicked == true)
            {
                panel2.Width = panel2.Width + panel_resize_speed;
                if(panel2.Width > panel2_width)
                {
                    button_is_clicked = false;
                    timer_1.Stop();
                }
            }
            else if(is_hidden == true && button_is_clicked == true)
            {
                panel2.Width = panel2.Width - panel_resize_speed;
                if (panel2.Width < panel1_width)
                {
                    button_is_clicked = false;
                    timer_1.Stop();
                }
            }
        }

        // Display menu
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "EXPAND")
            {
                // if expanded, show shrink button
                is_hidden = false;
                button1.Text = "SHRINK";
                button_is_clicked = true;

                // Timer to resize the menu
                timer_1.Enabled = true;
                timer_1.Start();

                // Default colors
                if (changed_colors == false)
                {   // SHRINK
                    button1.BackColor = Color.Yellow;
                    button1.ForeColor = Color.Black;
                }
                else
                {   // SHRINK CHANGED COLORS
                    button1.BackColor = Color.Purple;
                    button1.ForeColor = Color.White;
                }
            }

            // If shrinked, display EXPAND
            else if(button1.Text == "SHRINK")
            {
                // Display expand button
                button1.Text = "EXPAND";
                is_hidden = true;
                button_is_clicked = true;

                // Resize with the timer
                timer_1.Enabled = true;
                timer_1.Start();

                // EXPAND
                if (changed_colors == false)
                {
                    button1.BackColor = Color.Green;
                    button1.ForeColor = Color.White;
                }
                else
                {   // EXPAND CHANGED COLORS
                    button1.BackColor = Color.Red;
                    button1.ForeColor = Color.White;
                }
            }
        }

        // Change interface colors
        private void button2_Click(object sender, EventArgs e)
        {
            if (changed_colors == false)
            {
                // Change panel color
                panel1.BackColor = Color.Black;
                panel2.BackColor = Color.DarkGray;
                changed_colors = true;

                // Change menu button color
                if(button1.Text == "EXPAND")
                {
                    button1.BackColor = Color.Red;
                    button1.ForeColor = Color.White;
                }
                else 
                {  // SHRINK
                    button1.BackColor = Color.Purple;
                    button1.ForeColor = Color.White;
                }
            }
            else
            {  // Change panel color to default
                panel1.BackColor = Color.DarkBlue;
                panel2.BackColor = Color.Blue;
                changed_colors = false;

                // Change button to default
                if (button1.Text == "EXPAND")
                {
                    button1.BackColor = Color.Green;
                    button1.ForeColor = Color.White;
                }
                else
                {
                    button1.BackColor = Color.Yellow;
                    button1.ForeColor = Color.Black;
                }
            }
        }

        // Display calculator
        private void button3_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
                Display.Focus();
            }
            else
            {
                panel3.Visible = false;
            }
        }

        // Numbers inserted from the calculator
        private void button4_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "1";
            else
            {
                Display.Text = Display.Text + 1.ToString();
            }
            my_speaker.Speak("1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "2";
            else
            {
                Display.Text = Display.Text + 2.ToString();
            }
            my_speaker.Speak("2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "3";
            else
            {
                Display.Text = Display.Text + 3.ToString();
            }
            my_speaker.Speak("3");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "4";
            else
            {
                Display.Text = Display.Text + 4.ToString();
            }
            my_speaker.Speak("4");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "5";
            else
            {
                Display.Text = Display.Text + 5.ToString();
            }
            my_speaker.Speak("5");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "6";
            else
            {
                Display.Text = Display.Text + 6.ToString();
            }
            my_speaker.Speak("6");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "7";
            else
            {
                Display.Text = Display.Text + 7.ToString();
            }
            my_speaker.Speak("7");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "8";
            else
            {
                Display.Text = Display.Text + 8.ToString();
            }
            my_speaker.Speak("8");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "9";
            else
            {
                Display.Text = Display.Text + 9.ToString();
            }
            my_speaker.Speak("9");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
                Display.Text = "0";
            else
            {
                Display.Text = Display.Text + 0.ToString();
            }
            my_speaker.Speak("0");
        }

        // Clear button
        private void button13_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            my_speaker.Speak("CLEAR");
        }

        // Addition
        private void button15_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                operators.Add(Display.Text);
                operations.Add('+');
                Display.Text = "";
            }
            my_speaker.Speak("plus");
        }

        // Substraction
        private void button16_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                operators.Add(Display.Text);
                operations.Add('-');
                Display.Text = "";
            }
            my_speaker.Speak("minus");
        }

        // Multiplication
        private void button17_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                operators.Add(Display.Text);
                operations.Add('*');
                Display.Text = "";
            }
            my_speaker.Speak("multiplied by");
        }

        // Division
        private void button18_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                operators.Add(Display.Text);
                operations.Add('/');
                Display.Text = "";
            }
            my_speaker.Speak("divided by");
        }

        // Equals -> returns value
        private void button19_Click(object sender, EventArgs e)
        {
            if (Display.Text != "")
            {
                operators.Add(Display.Text);
            }

            // Check if we have elements in the list
            if (operators.Count == 0 || operators.First() == "")
            {
                Display.Text = "0";
                return;
            }

            // Calculate result
            int result;
            try
            {
                result = Convert.ToInt32(operators.First());
            }
            catch
            {
                result = 0;
            }

            operators.RemoveAt(0);
            
            while (operators.Count !=0)
            {
                if(operations.First() == '+')
                {
                    result = result + Convert.ToInt32(operators.First());
                    operators.RemoveAt(0);
                    operations.RemoveAt(0);
                }
                else if (operations.First() == '-')
                {
                    result = result - Convert.ToInt32(operators.First());
                    operators.RemoveAt(0);
                    operations.RemoveAt(0);
                }
                else if (operations.First() == '*')
                {
                    result = result * Convert.ToInt32(operators.First());
                    operators.RemoveAt(0);
                    operations.RemoveAt(0);
                }
                else if (operations.First() == '/')
                {
                    result = result / Convert.ToInt32(operators.First());
                    operators.RemoveAt(0);
                    operations.RemoveAt(0);
                }
            }

            Display.Text = result.ToString();
            my_speaker.Speak("equals" + result.ToString());
        }

        // Write numbers from the keyboard
        private void SlidingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (panel3.Visible == false)
                return;

            Display.Focus();

            if (e.KeyCode == Keys.D1)
            {
                if (Display.Text == "0")
                    Display.Text = "1";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 1.ToString();
                    else Display.Text = number.ToString() + 1.ToString();
                }
                my_speaker.Speak("1");
            }
            else if (e.KeyCode == Keys.D2)
            {
                if (Display.Text == "0")
                    Display.Text = "2";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 2.ToString();
                    else Display.Text = number.ToString() + 2.ToString();
                }
                my_speaker.Speak("2");
            }
            else if (e.KeyCode == Keys.D3)
            {
                if (Display.Text == "0")
                    Display.Text = "3";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 3.ToString();
                    else Display.Text = number.ToString() + 3.ToString();
                }
                my_speaker.Speak("3");
            }
            else if (e.KeyCode == Keys.D4)
            {
                if (Display.Text == "0")
                    Display.Text = "4";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 4.ToString();
                    else Display.Text = number.ToString() + 4.ToString();
                }
                my_speaker.Speak("4");
            }
            else if (e.KeyCode == Keys.D5)
            {
                if (Display.Text == "0")
                    Display.Text = "5";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 5.ToString();
                    else Display.Text = number.ToString() + 5.ToString();
                }
                my_speaker.Speak("5");
            }
            else if (e.KeyCode == Keys.D6)
            {
                if (Display.Text == "0")
                    Display.Text = "6";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 6.ToString();
                    else Display.Text = number.ToString() + 6.ToString();
                }
                my_speaker.Speak("6");
            }
            else if (e.KeyCode == Keys.D7)
            {
                if (Display.Text == "0")
                    Display.Text = "7";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 7.ToString();
                    else Display.Text = number.ToString() + 7.ToString();
                }
                my_speaker.Speak("7");
            }
            else if (e.KeyCode == Keys.D8)
            {
                if (Display.Text == "0")
                    Display.Text = "8";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 8.ToString();
                    else Display.Text = number.ToString() + 8.ToString();
                }
                my_speaker.Speak("8");
            }
            else if (e.KeyCode == Keys.D9)
            {
                if (Display.Text == "0")
                    Display.Text = "9";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 9.ToString();
                    else Display.Text = number.ToString() + 9.ToString();
                }
                my_speaker.Speak("9");
            }
            else if (e.KeyCode == Keys.D0)
            {
                if (Display.Text == "0")
                    Display.Text = "0";
                else
                {
                    int number = Convert.ToInt32(Display.Text);
                    if (number == 0)
                        Display.Text = 0.ToString();
                    else Display.Text = number.ToString() + 0.ToString();
                }
                my_speaker.Speak("0");
            }
        }
    }
}
