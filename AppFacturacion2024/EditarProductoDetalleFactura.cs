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
    public partial class EditarProductoDetalleFactura : Form
    {
        public string NuevaCantidad { get; private set; }

        public EditarProductoDetalleFactura(string cantidad)
        {
            InitializeComponent();
            txtCantidad.Text = cantidad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                aceptar();
            }
        }

        private void aceptar()
        {
            if (!string.IsNullOrWhiteSpace(txtCantidad.Text) && int.TryParse(txtCantidad.Text, out _))
            {
                NuevaCantidad = txtCantidad.Text;
                if (int.Parse(NuevaCantidad) <= 0)
                    MessageBox.Show("La cantidad tiene que ser mayor a 0");
                else
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            else
                MessageBox.Show("El numero no es correcto para el atributo cantidad");

        }
    }
}
