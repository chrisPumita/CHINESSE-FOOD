using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRestaurante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text;
            string idSesion = txtpw.Text;
            //Validar el cuenta etc etc
            if (name == "chris" && idSesion == "jenni")
            {
                ViewPrincipal p = new ViewPrincipal(this, name, idSesion);
                p.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Disculpa, las claves son incorrectas");


        }
    }
}
