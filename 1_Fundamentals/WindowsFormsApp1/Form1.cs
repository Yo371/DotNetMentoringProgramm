using System;
using System.Windows.Forms;
using ConcatenationLibrary;

namespace WindowsFormsApp1
{
    public partial class Hello : Form
    {
        public Hello()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            MessageBox.Show("Hello "+ name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            MessageBox.Show(ConcatenationLogic.GetGreetingLineWithDate(name));
        }
    }
}
