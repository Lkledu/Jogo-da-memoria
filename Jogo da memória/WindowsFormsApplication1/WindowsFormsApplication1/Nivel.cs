using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Nivel : Form
    {
        public int largura = 0;
        public int comprimento = 0;
        public string nomeTabela = "";
        public string fundoCarta = @"carta\estrela.png";

        public Nivel()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogo jogo = new Jogo(largura,comprimento, comboBox1.Text, fundoCarta);
            Nivel.ActiveForm.Close();
            jogo.Show();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                largura = 2;
                comprimento = 2;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                largura = 2;
                comprimento = 3;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                largura = 4;
                comprimento = 2;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                largura = 4;
                comprimento = 3;
            }
            if (comboBox2.SelectedIndex == 4)
            {
                largura = 4;
                comprimento = 4;
            }
            if (comboBox2.SelectedIndex == 5)
            {
                largura = 5;
                comprimento = 2;
            }
            if (comboBox2.SelectedIndex == 6)
            {
                largura = 5;
                comprimento = 4;
            }
        }

        private void Nivel_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = 100;
            pictureBox1.Height = 100;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.Text == "Android"){
                pictureBox1.ImageLocation = @"carta\android.png";
            }
            if (comboBox3.Text == "Apple")
            {
                pictureBox1.ImageLocation = @"carta\apple.png";
            }
            if (comboBox3.Text == "Companion")
            {
                pictureBox1.ImageLocation = @"carta\companion.jpg";
            }
            if (comboBox3.Text == "Estrela") {
                pictureBox1.ImageLocation = @"carta\estrela.png";
            }
            if (comboBox3.Text == "Fractal")
            {
                pictureBox1.ImageLocation = @"carta\fractal.jpg";
            }
            if (comboBox3.Text == "Fractal 2")
            {
                pictureBox1.ImageLocation = @"carta\fractal2.jpg";
            }
            if (comboBox3.Text == "Pinguin")
            {
                pictureBox1.ImageLocation = @"carta\tux.png";
            }
            if (comboBox3.Text == "Windows")
            {
                pictureBox1.ImageLocation = @"carta\windows.png";
            }

            fundoCarta = pictureBox1.ImageLocation;
        }

    }
}
