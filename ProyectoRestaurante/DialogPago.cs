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
    public partial class DialogPago : Form
    {
        double SUB, TOT, IVA, DESC;
        string TICKET;
        public DialogPago(double subtotal,double total, double iva, double descuento, string ticket)
        {
            InitializeComponent();
            this.SUB = subtotal;
            this.TOT = total;
            this.IVA = iva;
            this.DESC = descuento;
            this.TICKET = ticket;
            txtCoste.Text = "$" + Convert.ToString(TOT);
            printTicket();
        }

        private void pago(string cant)
        {
            //Pincipio de la calculadora
            double actual = Convert.ToDouble(txtPago.Text);
            if (actual<=0)
                txtPago.Text = cant;
            else
                txtPago.Text += cant;

            double pago = Convert.ToDouble(txtPago.Text);

            if (pago > TOT)
            {
                btnPay.Enabled = true;
                txtCambio.Text = Convert.ToString(Convert.ToDouble(txtPago.Text) - TOT);
            }
            else
            {
                txtCambio.Text = "0";
                btnPay.Enabled = false;
            }
        }

        private void ConfirmaVta() 
        {

            double vuelto =  Convert.ToDouble(txtPago.Text)- TOT;
            if (vuelto < 0)
            {
                //Ctl.ForeColor = Color.Red
                txtPago.ForeColor = Color.Red;
                txtCambio.Text="$0";
                MessageBox.Show("El valor de pado no debe ser menor a la venta");
            }
            else
            {
                txtCambio.Text = Convert.ToString(vuelto);
                MessageBox.Show("VENTA EXITOSA");
                ViewPrincipal.cambio = Convert.ToString(vuelto);
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ConfirmaVta();
        }

        private void printTicket() {
            txtTIcket.Text = TICKET;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogPago_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            pago("1");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pago("2");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pago("3");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pago("4");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pago("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pago("6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pago("7");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pago("8");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pago("9");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pago("0");
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPago.Text = "0";
            pago("0");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pago(".");
        }

    }
}
