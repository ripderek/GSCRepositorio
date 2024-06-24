using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            MenuSelector();
        }
        private void MenuSelector()
        {
           
            //para abrir los menus 
            TreeNode node = treeView1.SelectedNode;
            switch (node.Text)
            {
                case "Consulta Clientes":
                    ConsultaClientes ConsultaCliente = new ConsultaClientes();
                    ConsultaCliente.ShowDialog();
                    break;
                case "Imprimir Lista Clientes":
                    MessageBox.Show("Imprimir Lista Clientes");
                    break;
                case "Consulta Productos":
                    ConsultaProductos ConsultaProductos = new ConsultaProductos();
                    ConsultaProductos.ShowDialog();
                    break;
                case "Imprimir Lista":
                    MessageBox.Show("Imprimir Lista");
                    break;
                case "Registrar Factura":
                    RegistrarFactura RegistrarFact = new RegistrarFactura();
                    RegistrarFact.ShowDialog();
                    break;     
                case "Imprimir Factura":
                    ConsultaFacturas ConsultaFacturas = new ConsultaFacturas();
                    ConsultaFacturas.ShowDialog();
                    break;
                default:

                    break;
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MenuSelector();
            }
        }
    }
}
