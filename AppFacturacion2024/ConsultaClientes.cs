using AppFacturacion2024.Clases;
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
    public partial class ConsultaClientes : Form
    {
        Clientes obj_clientes = new Clientes();
        //la accion= true es para saber si se va a retornar datos del datagridview en caso que se use para listar en la factura 
        bool accion_ = false;
        public ConsultaClientes(bool acccion=false)
        {
            InitializeComponent();
            this.KeyPreview = true;
            accion_ = acccion;
            dtListaClientes.KeyDown += new KeyEventHandler(dtListaClientes_KeyDown);
            dtListaClientes.CellEnter += new DataGridViewCellEventHandler(dtListaClientes_CellEnter);

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ConsultaClientesLista()
        {
            
            DataTable dataTable = obj_clientes.Listar_Clientes();
            if (dataTable != null)
            {
                // dataGridViewClientes.DataSource = dataTable; para enviarla directamente al data source 
                Console.WriteLine(dataTable);
                dtListaClientes.Rows.Clear();
             
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    dtListaClientes.Rows.Add();

                    for (int j = 0; j < row.ItemArray.Length-1; j++)
                    {
                        dtListaClientes[j, i].Value = row[j].ToString().Trim();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se pudo obtener datos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaClientes_Load(object sender, EventArgs e)
        {
            ConsultaClientesLista();
        }

        private void dtListaClientes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dtListaClientes.CurrentCell = dtListaClientes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        //aqui se debe tomar los datos para abrir una nueva ventana si en caso quiere actualizar la linea 
                        menuOpciones.Show(Cursor.Position);
                        DataGridViewRow row = dtListaClientes.Rows[e.RowIndex];
                        obj_clientes.IDENTIFICACION_ = row.Cells[0].Value.ToString();
                        obj_clientes.NOMBRES_ = row.Cells[1].Value.ToString();
                        obj_clientes.CORREO_ = row.Cells[2].Value.ToString();
                        obj_clientes.TELEFONO_ = row.Cells[3].Value.ToString();
                    }
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message);
                }
            }
        }

        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearEditarClientes ventana_crear_editar_clientes = new CrearEditarClientes(true);
            ventana_crear_editar_clientes.ShowDialog();
            ConsultaClientesLista();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearEditarClientes ventana_crear_editar_clientes = new CrearEditarClientes(false, obj_clientes.IDENTIFICACION_, obj_clientes.NOMBRES_, obj_clientes.CORREO_, obj_clientes.TELEFONO_);
            ventana_crear_editar_clientes.ShowDialog();
            ConsultaClientesLista();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj_clientes.Eliminar_Cliente();
            ConsultaClientesLista();
        }
        public string ClienteID { get; private set; }
        public string ClienteNombre { get; private set; }
        public string ClienteIdentificacion { get; private set; }
        public string ClienteCorreo { get; private set; }
        private void dtListaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (accion_)
            {
                if (e.RowIndex >= 0)
                {
                    // Obtén la información del cliente desde la fila seleccionada en el DataGridView usando los índices de las columnas
                    ClienteID = dtListaClientes.Rows[e.RowIndex].Cells[0].Value.ToString(); // Índice 0 para la columna ID
                    ClienteNombre = dtListaClientes.Rows[e.RowIndex].Cells[1].Value.ToString(); // Índice 1 para la columna Nombre
                    //ClienteIdentificacion = dtListaClientes.Rows[e.RowIndex].Cells[2].Value.ToString(); // Índice 1 para la columna Nombre
                    ClienteCorreo = dtListaClientes.Rows[e.RowIndex].Cells[2].Value.ToString(); // Índice 1 para la columna Nombre

                    this.DialogResult = DialogResult.OK;
                    // Cierra el formulario de clientes
                    this.Close();
                }
            }
            
        }

        private void ConsultaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                txtBuscador.Visible = true;
                txtBuscador.BringToFront();
                txtBuscador.Focus();
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                ConsultaClientesLista();
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtBuscador_KeyDown(object sender, KeyEventArgs e)
        {
            //detectar si se da enter para aceptar la busqueda del texto que contiene
            if (e.KeyCode == Keys.Enter)
            {
                //funcion para buscar
                Busqueda_Palabra_Clave();
                txtBuscador.Visible = false;
                txtBuscador.Text = "";
              
            }
        }
        private void Busqueda_Palabra_Clave()
        {
            DataTable dataTable = obj_clientes.Buscar_Cliente(txtBuscador.Text);
            if (dataTable != null)
            {
                // dataGridViewClientes.DataSource = dataTable; para enviarla directamente al data source 
                Console.WriteLine(dataTable);
                dtListaClientes.Rows.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    dtListaClientes.Rows.Add();

                    for (int j = 0; j < row.ItemArray.Length - 1; j++)
                    {
                        dtListaClientes[j, i].Value = row[j].ToString().Trim();
                    }
                }
            }
            else if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos");
            }
            else
            {
                MessageBox.Show("No se pudo obtener datos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtListaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            //para abrir el menu desde el teclado
            if (e.Control && e.KeyCode == Keys.O)
            {
                if (currentRowIndex >= 0 && currentColumnIndex >= 0)
                {
                    dtListaClientes.CurrentCell = dtListaClientes.Rows[currentRowIndex].Cells[currentColumnIndex];
                    // Aquí se deben tomar los datos para abrir una nueva ventana si en caso quiere actualizar la línea 
                    Rectangle cellRectangle = dtListaClientes.GetCellDisplayRectangle(currentColumnIndex, currentRowIndex, false);
                    Point cellLocation = dtListaClientes.PointToScreen(new Point(cellRectangle.X, cellRectangle.Y));
                    // Mostrar el menú contextual en la posición de la celda
                    menuOpciones.Show(cellLocation);
                    DataGridViewRow row = dtListaClientes.Rows[currentRowIndex];
                    obj_clientes.IDENTIFICACION_ = row.Cells[0].Value.ToString();
                    obj_clientes.NOMBRES_ = row.Cells[1].Value.ToString();
                    obj_clientes.CORREO_ = row.Cells[2].Value.ToString();
                    obj_clientes.TELEFONO_ = row.Cells[3].Value.ToString();
                }
                e.Handled = true; // Indica que el evento ha sido manejado
            }
        }
        private int currentRowIndex;
        private int currentColumnIndex;
        private void dtListaClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentRowIndex = e.RowIndex;
            currentColumnIndex = e.ColumnIndex;
        }
    }
}
