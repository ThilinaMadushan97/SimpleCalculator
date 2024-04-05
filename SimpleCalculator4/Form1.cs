using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator4
{
    public partial class Form1 : Form
    {
        private decimal firstNum = 0;
        private decimal secondNum = 0;
        private decimal result = 0;
        private int operatorType = (int)mathOperator.noOperator;

        public enum mathOperator
        {
            noOperator = 0,
            Add = 1,
            Min = 2,
            Divid = 3,
            Multi = 4,
            Precentage = 5
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn(object sender, EventArgs e)
        {
            if(textBox1.Text == "0")
            {
                textBox1.Clear();
            }
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;   
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("-"))
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text.Trim('-');
            }
          
        }

        private void saveValueAndOperator(int operatation)
        {
            operatorType = operatation;
            firstNum = decimal.Parse(textBox1.Text);
            textBox1.Text = "0";
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            saveValueAndOperator((int)mathOperator.Add);
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            saveValueAndOperator((int)mathOperator.Min);

        }

        private void btn_divid_Click(object sender, EventArgs e)
        {
            saveValueAndOperator((int)mathOperator.Divid);

        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            saveValueAndOperator((int)mathOperator.Multi);

        }

        private void btn_precentage_Click(object sender, EventArgs e)
        {
            saveValueAndOperator((int)mathOperator.Precentage);

        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            secondNum = decimal.Parse(textBox1.Text);

            switch(operatorType)
            {
                case (int)mathOperator.Add:
                    result = firstNum + secondNum;
                    break;
                case (int)mathOperator.Min:
                    result = firstNum - secondNum;
                    break;
                case (int)mathOperator.Divid:
                    result = firstNum / secondNum;
                    break;
                case (int)mathOperator.Multi:
                    result = firstNum * secondNum;
                    break;
                case (int)mathOperator.Precentage:
                    result = (firstNum / secondNum) * 100;
                    break;
            }

            textBox1.Text = result.ToString();
        }

        private void btnClearEnter_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            firstNum = 0;
            secondNum = 0;
            result = 0;
            operatorType = (int)mathOperator.noOperator;
        }
    }
}
