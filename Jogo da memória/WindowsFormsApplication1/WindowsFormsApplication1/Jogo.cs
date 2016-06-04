using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace WindowsFormsApplication1
{
    public partial class Jogo : Form
    {

        /*private PictureBox indiceVirada1;*/
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Eduardo\Desktop\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Banco\JogoDaMemoria.mdf;Integrated Security=True;Connect Timeout=30");
        
        public PictureBox [,] cartas; //vetor para cartas

        public int score = 0;

        public int comprimento = 0;
        public int largura = 0;
        public string nomeTabela = "animais";
        public string [] imagem;
        static Random _random = new Random();
        public string card1 = "", card2 = "";
        public int contar = 1;
        public PictureBox primeiraCarta = new PictureBox();
        public PictureBox segundaCarta = new PictureBox();
        public int fim = 0;
        public int maximo;
        
        
        public string fundoCarta = @"carta\estrela.png";

        

        public PictureBox smile = new PictureBox();
        

        public Jogo(int larguraP, int comprimentoP, string Tabela, string pFundoCarta)
        {
            
            fundoCarta = pFundoCarta;
            comprimento = comprimentoP;
            largura = larguraP;
            maximo = (comprimento * largura) / 2;
            
            if(Tabela != "" ){
                nomeTabela = Tabela;
            }
            InitializeComponent();


        }


        //randomizar vetores ↓↓↓
        static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(_random.NextDouble() * (n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }

        //↑↑

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand selectCartas = new SqlCommand("Select id , imagem from " + nomeTabela +"", conn);
            SqlCommand countCartas = new SqlCommand("Select count (id) from "+ nomeTabela +"",conn);

            
            conn.Open();
            SqlDataReader numeroDeCartas =  countCartas.ExecuteReader();

            numeroDeCartas.Read();
            imagem   = new string[comprimento * largura];
            int[] teste = new int[numeroDeCartas.GetInt32(0)];
            numeroDeCartas.Close();

            SqlDataReader idCarta = selectCartas.ExecuteReader();
            int x2 = 0;
            while(idCarta.Read())
            {              
                teste[x2] = (int) idCarta.GetValue(0);
               
                x2++;
            }
            
            idCarta.Close();
            
            Shuffle(teste); //função para embaralhar
            
            int []teste2 = new int [(comprimento*largura)];
            int xis=0;
            int i2=0;
            for ( i2=i2; i2 < maximo; i2++)
            {
                
                teste2[i2] = teste[xis];
                xis++;
            }
            xis = 0;
            for ( i2=i2; i2 < (comprimento * largura); i2++)
            {
                
                teste2[i2] = teste[xis];
                xis++;

            }
            Shuffle(teste2);
            conn.Close();
            
            //largura da carta

            int larguraCarta = 100;
            int larguraTotalCarta = larguraCarta * largura;
            int espacoEntreCartaX = (groupBox2.Width - larguraTotalCarta) / (largura + 1);

            //comprimento da carta
            int comprimentoCarta = 100;
            int comprimentoTotalCarta = comprimentoCarta * comprimento;
            int espacoEntreCartaY = (groupBox2.Height - comprimentoTotalCarta) / (comprimento + 1);

            int top = 0;
            cartas = new PictureBox[comprimento, largura];                      //cria cartas de acordo com o n° escolhido
            int cout = 0;

          
            //matriz que cria as cartas e posiciona
            for (int k = 0; k < comprimento; k++)
            {
                int left = espacoEntreCartaX;
                top += espacoEntreCartaY;

                for (int i = 0; i < largura; i++)
                {
                    imagem[cout] = carregarImagem(teste2[cout]);
                    cartas[k, i] = new PictureBox();
                    cartas[k, i].Name = cout.ToString();
                    cartas[k, i].ImageLocation = imagem[cout];
                    cartas[k, i].Click += new System.EventHandler(this.botoes_Click);      //aciona evento ao clicar em carta
                    groupBox2.Controls.Add(cartas[k, i]);                                  //adiciona (já criadas) cartas no groupbox2
                    cartas[k, i].Width = larguraCarta;
                    cartas[k, i].Height = comprimentoCarta;
                    cartas[k, i].Top = top;                                                // posiciona carta vertical
                    cartas[k, i].Left = left;
                    cartas[k, i].SizeMode = PictureBoxSizeMode.StretchImage;
                    
                    left += espacoEntreCartaX + larguraCarta;
                    cout++;
                }
                top += comprimentoCarta;

            }

            timer1.Start();    
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void botoes_Click(object sender, EventArgs e)
        {

            if (contar == 3)
            {
                if (primeiraCarta.ImageLocation != segundaCarta.ImageLocation)
                {
                    primeiraCarta.ImageLocation = fundoCarta;
                    segundaCarta.ImageLocation = fundoCarta;
                } contar = 1;
            }

           segundaCarta = (PictureBox)sender;
                        
            if (segundaCarta.ImageLocation == fundoCarta )
            {
                segundaCarta.ImageLocation = imagem[Int32.Parse(segundaCarta.Name)];
                
                if (contar == 1)
                {
                    primeiraCarta = segundaCarta;
                    contar++;
                }
                else {
                    if (primeiraCarta.ImageLocation == segundaCarta.ImageLocation)
                    {
                        //MessageBox.Show("são iguais");
                        /*MessageBox.Show("são diferentes"); MessageBox.Show(
                             primeiraCarta.Name + " " + primeiraCarta.ImageLocation + " \n " +
                             segundaCarta.Name + " " + segundaCarta.ImageLocation
                         );*/

                        pictureBox1.ImageLocation = @"smile\feliz.png";

                        score++;
                        label1.Text = "Pontuação: " + score.ToString();
                        fim++;
                       
                        if(fim == (comprimento*largura)/2){
                            Congratulation congratulation = new Congratulation(score, this, maximo);
                            congratulation.Show();
                        }
                        contar = 1;
                    }
                    else {
                        //MessageBox.Show("são diferentes"); 
                        /*MessageBox.Show(
                            primeiraCarta.Name + " " + primeiraCarta.ImageLocation + " \n " +
                            segundaCarta.Name + " " + segundaCarta.ImageLocation
                        );*/

                        pictureBox1.ImageLocation = @"smile\triste.png";

                        contar = 3;
                        score--;
                        label1.Text = "Pontuação: " + score.ToString();
                    }
                    
                    
                }                
            }
        }
        private string carregarImagem(int indice){
            conn.Open();
            SqlCommand selectCartas = new SqlCommand("SELECT imagem FROM " +nomeTabela+" where id = "+indice.ToString(), conn);
            SqlDataReader idCarta = selectCartas.ExecuteReader();
            idCarta.Read();
            string var = idCarta.GetValue(0).ToString();
            conn.Close();
            return var;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int k = 0; k < comprimento; k++)
            {
                for (int i = 0; i < largura; i++)
                {
                    cartas[k, i].ImageLocation = fundoCarta;
                }
            }
            timer1.Stop();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
           
        }
    }
}


