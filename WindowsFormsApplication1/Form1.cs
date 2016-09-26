using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form   
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            if (Directory.Exists(address)){
                WorkWithFolder workWithFolder = new WorkWithFolder(address);
            }
            else
            {
                MessageBox.Show("Извините, указанная вами папка не найдена");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
