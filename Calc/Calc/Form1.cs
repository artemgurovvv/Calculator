using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Printing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float a, b;
        int count;
        bool znak = true;


        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:

                    float divider;
                    divider = float.Parse(textBox1.Text);
                    if (divider == 0.0)
                        MessageBox.Show("Внимание! Деление на ноль! А на ноль делить нельзя =)");
                    else
                    {
                        b = a / divider;
                        textBox1.Text = b.ToString();
                    }
                    break;

                default:
                    break;
            }


        }


        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(label1.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                calculate();
                label1.Text = "";
                znak = true;
                a = b;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            {
                HandleOperatorButtonClick("+");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HandleOperatorButtonClick("-");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            HandleOperatorButtonClick("*");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HandleOperatorButtonClick("/");
        }

        private void HandleOperatorButtonClick(string newOperator)
        {

            if (!znak)
            {


                if (!string.IsNullOrEmpty(label1.Text))
                {

                    label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                    label1.Text += newOperator;

                   
                }
                 else if (!string.IsNullOrEmpty(label1.Text))
                {
                    label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                    calculate();
                    label1.Text = b.ToString() + newOperator;
                    a = b;
                    textBox1.Clear();
                }


          

                if (!string.IsNullOrEmpty(label1.Text) && !string.IsNullOrEmpty(textBox1.Text))
                {

                    calculate();

                    label1.Text = b.ToString() + newOperator;

                    a = b;
                }
                else if (textBox1.Text == "-" && string.IsNullOrEmpty(label1.Text))
                {

                    label1.Text = textBox1.Text + newOperator;
                    textBox1.Clear();
                    return;
                }
            }

            if (string.IsNullOrEmpty(textBox1.Text) && newOperator == "-")
            {
                textBox1.Text = textBox1.Text;
                switchCount(newOperator);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) && newOperator == "+")
            {
                textBox1.Text = textBox1.Text;
                switchCount(newOperator);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) && newOperator == "*")
            {
                textBox1.Text = textBox1.Text;
                switchCount(newOperator);
                return;
            }
            if (string.IsNullOrEmpty(textBox1.Text) && newOperator == "/")
            {
                textBox1.Text = textBox1.Text;
                switchCount(newOperator);
                return;
            }

            else
            {
                a = float.Parse(textBox1.Text);

                label1.Text = a.ToString() + newOperator;
                znak = false;
            }
            textBox1.Clear();

            switchCount(newOperator);

        }

        private void switchCount(string newOperator)
        {
            switch (newOperator)
            {
                case "+":
                    count = 1;
                    break;
                case "-":
                    count = 2;
                    break;
                case "*":
                    count = 3;
                    break;
                case "/":
                    count = 4;
                    break;
                default:
                    count = 0;
                    break;
            }


        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            a = 0;
            b = 0;
            count = 0;
            znak = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string txt = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + txt[i];
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf(',') == -1)
            {
                textBox1.Text += ',';
            }
        }
    }
}
