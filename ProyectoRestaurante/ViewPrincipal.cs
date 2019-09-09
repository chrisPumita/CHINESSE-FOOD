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
    public partial class ViewPrincipal : Form
    {
        //varuables globales
        private string name;
        private string sessionId;
        Form1 FORMlogin;
        public static int cantidad;

        //Bilioteca de platillos
        Dictionary<int, string> listaPlatillosPath = null;
        Dictionary<int, string> listaPlatillosDesc = null;
        Dictionary<int, double> listaPlatillosCosto = null;
        Dictionary<int, string> listaPlatillosName= null;

        //Creando una nueva lista de la clase listTicket que contendra los elementos que seleccione
        List<listTIcket> obj = new List<listTIcket>();
        private static string NAME_P;
        private static double COSTO_P;
        private static int CANT_P;
        //Cuentas, variables globales
        double SUBTOTAL_VTA = 0, DESCT_VTA = 0, IVA_VTA = 0 ,TOTAL_VTA = 0, IVA_DATA = 16;
        public static string cambio = "";
        //Metodo constructor
        public ViewPrincipal(Form1 frmLogin, string nameUser, string sId)
        {
            this.FORMlogin = frmLogin;
            this.name = nameUser;
            this.sessionId = sId;
            InitializeComponent();
            lblNameUser.Text= name;
            lblMje.Text = "Hola " +name + ". Listos.";
            setItemPlatillos();
        }

        public void buscaElemento()
        {
            try
            {
                int i = obj.FindIndex(BuscarRegistro);
                if (i < 0) { MessageBox.Show("El Código no existe."); }
                else
                {
                    MessageBox.Show("Ya se agrego elemento");
                    /*
                    this.txtApellido.Text = obj[i].Apellido;
                    this.txtNombres.Text = obj[i].Nombre;
                    this.txtEdad.Text = obj[i].Edad.ToString();
                    this.txtTelefono.Text = obj[i].Telefono.ToString();
                    this.maskedFecha.Text = obj[i].Fecha.ToString();
                     *  */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: 443 " +ex.ToString());
            }
        }

        //FUNCIONES PARA AGREGAR LA INFORMACION AL CARRITO DE COMRPAS
        private bool BuscarRegistro(listTIcket Parametro)
        {
            return Parametro.Nombre == this.txtCliente.Text;
        }

        void CargarDatos()
        {
            BindingSource ds = new BindingSource(obj, "");
            this.gridDatos.DataSource = ds;
            this.lblCount.Text = "Total : " + obj.Count.ToString() + " agregados";
        }

        public static void getDataProduct(string name, int cant, double costo) {
            /*
         private string NAME_P;
         private double COSTO_P;
         private int CANT_P;
             */
            NAME_P = name;
            COSTO_P = costo;
            CANT_P = cant;
        }


        public void agregarToList(string nombre, int cantidad, double costo)
        {
            try
            {
                string Nombre = nombre;
                double Costo = costo;
                int Cantidad = cantidad;
                double Total = Costo * Cantidad;
                obj.Add(new listTIcket(Cantidad, Nombre, Costo, Total));
                CargarDatos();
                CalculaCuentas(Total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error de adding " + ex.ToString());
            }
        }

        private void CalculaCuentas(double cuenta)
        {
            SUBTOTAL_VTA += cuenta;
            IVA_VTA = (SUBTOTAL_VTA * IVA_DATA) / 100;
            TOTAL_VTA = IVA_VTA + SUBTOTAL_VTA + DESCT_VTA;
            lblSub.Text = "$" + Convert.ToString(SUBTOTAL_VTA);
            lblDesc.Text = "$" + Convert.ToString(DESCT_VTA);
            lblIVA.Text = "$" + Convert.ToString(IVA_VTA);
            lblTotal.Text = "$" + Convert.ToString(TOTAL_VTA);
        }

        //FUNCIONES PARA AGREGAR LA INFORMACION AL CARRITO DE COMRPAS
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FORMlogin.Close();
        }

        private void cerrarSesiónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            FORMlogin.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadProducto(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadProducto(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadProducto(3);
        }


        private void btnRollos_Click(object sender, EventArgs e)
        {
            loadProducto(4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadProducto(5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadProducto(8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadProducto(6);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            loadProducto(7);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            loadProducto(9);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            loadProducto(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            loadProducto(11);
        }

        /*
        Funcion que invica al metodo constructor de la ventana de producto
        */

        private void creaVentanaProducto(double costo, string name, string desc, Image img)
        {
            //double costo, string nameProducto, string desc
            DialogProducto producto = new DialogProducto(costo, name, desc, img);
            producto.ShowDialog();
        }

        private void loadProducto(int id)
        {
            //Reiniciando Variables
            NAME_P=""; CANT_P=0; COSTO_P=0;
            Image img = Image.FromFile("Resources/platillos/" + listaPlatillosPath[id]);
            double costo = listaPlatillosCosto[id];
            lblMje.Text = listaPlatillosName[id] + " cuesta: $" + listaPlatillosCosto[id];
            creaVentanaProducto(costo, listaPlatillosName[id], listaPlatillosDesc[id], img);
            if (CANT_P > 0)
                agregarToList(NAME_P, CANT_P, COSTO_P);
        }

        //Funcion que agrega los platillos correspondientes e ID
        private void setItemPlatillos()
        {
            listaPlatillosPath = new Dictionary<int, string>();
            listaPlatillosDesc = new Dictionary<int, string>();
            listaPlatillosCosto = new Dictionary<int, double>();
            listaPlatillosName = new Dictionary<int, string>();

            listaPlatillosName.Add(1, "Arroz");
            listaPlatillosPath.Add(1, "rice.png");
            listaPlatillosDesc.Add(1, "Arroz acondicionado con especias");
            listaPlatillosCosto.Add(1, 13.60);

            listaPlatillosName.Add(2, "Espaguetti");
            listaPlatillosPath.Add(2, "noodles.png");
            listaPlatillosDesc.Add(2, "Espagueti con salsa de tomate y especias.");
            listaPlatillosCosto.Add(2, 15.60);

            listaPlatillosName.Add(3, "Alistas Agridulces");
            listaPlatillosPath.Add(3, "chicken-wings.png");
            listaPlatillosDesc.Add(3, "Alitas agridulces con adimentos de especias.");
            listaPlatillosCosto.Add(3, 18.60);

            listaPlatillosName.Add(4, "Rollos Primavera");
            listaPlatillosPath.Add(4, "spring-rolls.png");
            listaPlatillosDesc.Add(4, "Orden de 2 Rollitos primavera acidas");
            listaPlatillosCosto.Add(4, 50.50);

            listaPlatillosName.Add(5, "Pollo a la naranja");
            listaPlatillosPath.Add(5, "orange.png");
            listaPlatillosDesc.Add(5, "Pechuga de Pollo a la naranja, orden sopa y arroz");
            listaPlatillosCosto.Add(5, 21.50);

            listaPlatillosName.Add(6, "Pulpo cocido");
            listaPlatillosPath.Add(6, "octopus.png");
            listaPlatillosDesc.Add(6, "Pulpo prparado con naranja y especias");
            listaPlatillosCosto.Add(6, 13.50);

            listaPlatillosName.Add(7, "Costilla");
            listaPlatillosPath.Add(7, "ribs.png");
            listaPlatillosDesc.Add(7, "Costilla de cerdo a la BBK");
            listaPlatillosCosto.Add(7, 26.00);

            listaPlatillosName.Add(8, "Pezcado Empanizado");
            listaPlatillosPath.Add(8, "fish.png");
            listaPlatillosDesc.Add(8, "Pezcado fresco empanizado con arina y aceite de oliva");
            listaPlatillosCosto.Add(8, 25.80);

            listaPlatillosName.Add(9, "Sushi");
            listaPlatillosPath.Add(9, "sushi.png");
            listaPlatillosDesc.Add(9, "Sushi con salmon y pezacado crudo. Orden de 5 rollos");
            listaPlatillosCosto.Add(9, 56.60);

            listaPlatillosName.Add(10, "Camarón Capeado");
            listaPlatillosPath.Add(10, "breaded-shrimp.png");
            listaPlatillosDesc.Add(10, "Camarones capeados de arina, con aderezo y salsas. Orden de 6 piezas");
            listaPlatillosCosto.Add(10, 45.60);

            listaPlatillosName.Add(11, "Camarón Salado");
            listaPlatillosPath.Add(11, "shrimp.png");
            listaPlatillosDesc.Add(11, "Orden de 5 camarones azados al mojo de ajo.");
            listaPlatillosCosto.Add(11, 86.30);

            listaPlatillosName.Add(12, "Lata de regresco");
            listaPlatillosPath.Add(12, "can.png");
            listaPlatillosDesc.Add(12, "Regresco de sabor cola");
            listaPlatillosCosto.Add(12, 13.5);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
           bool v =  procedeVenta();
           if (v) {
               lblMje.Text = "CAMBIO: $" + cambio;
               clean();
           }
        }


        private void clean() {
            try
            {
                int can = obj.Count;
                for (int i = 1; i <= can; i++)
                    quitaUltimo();

                SUBTOTAL_VTA = 0;
                DESCT_VTA = 0;
                IVA_VTA = 0;
                TOTAL_VTA = 0;
                CargarDatos();
                txtCliente.Text = "";
                lblSub.Text = "$0.00";
                lblIVA.Text = "$0.00";
                lblDesc.Text = "$0.00";
                lblTotal.Text = "$0.00";
                lblCount.Text = "No se han agregado productos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error delete ALL " + ex.ToString());
            }
        }
        /* Pocediendo a la venta  */

        private bool procedeVenta() 
        {
            bool success = false;
            if (TOTAL_VTA > 0)
            {
                if (txtCliente.Text == "")
                {
                    MessageBox.Show("Escriba el nombre del cliente a que saldra el pedido");
                    txtCliente.Focus();
                    lblMje.Text = "Falta nombre del cliente";
                    success = false;
                }
                else 
                {
                    //PROCESANDO PAGO
                    //(double subtotal,double total, double iva, double descuento, string ticket)
                    DialogPago pago = new DialogPago(SUBTOTAL_VTA, TOTAL_VTA, IVA_VTA, DESCT_VTA, ticketBuild());
                    pago.ShowDialog();
                    success = true;
                }

            }
            else
                MessageBox.Show("La venta debe ser mayor a $0 pesos \r\n Agrege Productos a la venta");
            return success;
        }
        private string ticketBuild() 
        {

            BindingSource ds = new BindingSource(obj, "");
            //Cantidad de elementos seleccionados
            int contObj = obj.Count;
            string name = "", contplemenSpace="";
            
             string dataTIcket = "\t\t       COMIDA CHINA\r\n";
             dataTIcket += "\t\t   S H I N - G A O  \r\n\r\n";
             dataTIcket += "\t\t  TICKET DE VENTA  \r\n\r\n";
            dataTIcket += "Cant \t Descripción        $Costo \t$Total\r\t";
            dataTIcket += "--------------------------------------------------\r\n";
            for (int i = 0; i < contObj; i++) {
                name = obj[i].Nombre;
                contplemenSpace = "";
                for (int j = name.Length; j < 20; j++)
                {
                    contplemenSpace += " ";
                }
                dataTIcket += obj[i].Cantidad + "\t" + name + contplemenSpace + + obj[i].Costo + "\t" + obj[i].Total + "\r\n";
            }
            dataTIcket += "--------------------------------------------------";
            dataTIcket += "\r\n\t\t\t\t Subtotal: $" + SUBTOTAL_VTA ;
            dataTIcket += "\r\n\t\t\t\tDescuento: $" + DESCT_VTA;
            dataTIcket += "\r\n\t\t\t\t      IVA: $" + IVA_VTA;
            dataTIcket += "\r\n\t\t\t\t    TOTAL: $" + TOTAL_VTA;
            if (cboLlevar.Checked)
                dataTIcket += "\r\n\t\t SERVICIO PARA LLEVAR ";
            dataTIcket += "\r\n\t\t **   CLIENTE:** ";
            dataTIcket += "\r\n\t\t **" + txtCliente.Text+ "** ";
            dataTIcket += "\r\n\t\t GRACIAS POR SU PREFERENCIA\r\n";

            return dataTIcket;
        }
        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            quitaUltimo();
        }

        private void quitaUltimo() {
            try
            {
                int ultimo = obj.Count;
                //int i = obj.FindIndex( total);
                if (ultimo > 0)
                {
                    obj.RemoveAt(ultimo - 1);
                    CargarDatos();
                }
                else {
                    MessageBox.Show("NO se puede eleminiar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("error delete " + ex.ToString());
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            loadProducto(12);
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreditos fc = new frmCreditos();
            fc.ShowDialog();
        }
    }
}
