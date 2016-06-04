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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nivel nivel = new Nivel();
            nivel.Show();
            //Form.ActiveForm.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
