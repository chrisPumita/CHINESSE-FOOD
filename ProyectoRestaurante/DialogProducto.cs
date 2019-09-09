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
    public partial class DialogProducto : Form
    {
        //Variables globales de productos seleccionados
        private double costo;
        int cantidad;
        private string nameProducto, desc;
        private Image img;

        public DialogProducto(double costo, string nameProducto, string desc, Image img)
        {
            InitializeComponent();
            this.costo = costo;
            this.nameProducto = nameProducto;
            this.desc = desc;
            this.img = img;
            LlenaDatos();
            calculaTotal();
        }

        private void LlenaDatos() {
            txtCoste.Text = "$" + Convert.ToString(costo);
            txtNameProducto.Text = nameProducto;
            txtDesc.Text = desc;
            pickCont.Image = img;
            pickCont.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Event to buy  public void agregarToList(string nombre, int cantidad, double costo, double total)
            ViewPrincipal.getDataProduct(nameProducto, cantidad,costo);
            this.Close();
        }

        private void calculaTotal() {
            double total = costo * Convert.ToDouble(numericCantidad.Value);
            cantidad = Convert.ToInt32(numericCantidad.Value);
            lblTotal.Text = "$" + total;
            if (total <= 0)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            addCant(1);
            calculaTotal();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addCant(2);
            calculaTotal();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addCant(3);
            calculaTotal();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addCant(4);
            calculaTotal();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addCant(5);
            calculaTotal();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addCant(6);
            calculaTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addCant(7);
            calculaTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addCant(8);
            calculaTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addCant(9);
            calculaTotal();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            addCant(0);
            calculaTotal();
        }

        private void addCant(int cant) 
        { 
            //Pincipio de la calculadora
            //OBtengo lo que tiene el spiner
            int actual = Convert.ToInt32(numericCantidad.Value);
            // verifico el valor que contiene, si es mayor a 0 entonces modifico.
            if (actual <= 0)
                numericCantidad.Value = cant;
            else if (actual >= 1 && actual < 100) //sino, simplemente lo agrego pero multiploco por 10 lo que tiene
            {
                actual = actual*10 + cant;
                if (actual < 100)
                    numericCantidad.Value = actual;
                else
                    numericCantidad.Value = cant;
            }
            else if (cant == 0 && (actual > 0 || actual <= 99))
                numericCantidad.Value = 0;
        }

        private void numericCantidad_ValueChanged(object sender, EventArgs e)
        {
            calculaTotal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numericCantidad.Value = 0;
            calculaTotal();
        }
    }
}
