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
    public partial class Congratulation : Form
    {

        public int score;
        public Jogo jogo;
        public int maximo;

        public Congratulation()
        {
            InitializeComponent();
        }
        public Congratulation(int pScore,Jogo pJogo, int pMaximo)
        {
            maximo = pMaximo;
            score = pScore;
            jogo = pJogo;
            InitializeComponent();
        }

        private void Congratulation_Load(object sender, EventArgs e)
        {

            label1.Text = "voce ganhou \n"+ "fez: " + score + " pontos de " + maximo;
            
            if(score == maximo){
                smile.ImageLocation = @"smile\maximo.png";
            }
            else if (score > 0 )
            {
                smile.ImageLocation = @"smile\feliz.png";
            }
            else if (score == 0)
            {
                smile.ImageLocation = @"smile\normal.png";
            }
            else { smile.ImageLocation = @"smile\triste.png"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            jogo.Close();
            this.Close();            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
