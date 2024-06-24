using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024.Clases
{
    internal class Productos : ConexionBD

    {
        private string CODIGO;
        private string PRODUCTO;
        private string PRECIO_UNITARIO;
        private string ESTADO;


        public string CODIGO_ {  get => CODIGO; set => CODIGO = value ; }
        public string PRODUCTO_ { get => PRODUCTO; set => PRODUCTO = value; }
        public string PRECIO_UNITARIO_ {  get => PRECIO_UNITARIO; set =>  PRECIO_UNITARIO = value;}
        public string ESTADO_ {  get => ESTADO; set => ESTADO = value; }

        //FUNCION PARA LISTAR LOS CLIENTES

       
        //funcion para crear productos
        public void CrearProducto()
        {
            string SQL = "EXEC SP_InsertarProducto  '" + PRODUCTO_ + "' , '" + PRECIO_UNITARIO_ + "'";
            ConcatenacionCadena(SQL);
        }
        //funcion para editar PRODUCTO
        public void Editar_Producto()
        {
            string SQL = "EXEC SP_EditarProducto '" + CODIGO_ + "', '" + PRODUCTO_ + "', '" + PRECIO_UNITARIO_ + "'";
            ConcatenacionCadena(SQL);
        }
        //funcion para eliminar el PRODUCTO 
        public void Eliminar_Producto()
        {
            string SQL = "EXEC SP_EliminarProducto '" + CODIGO_ + "'";
            ConcatenacionCadena(SQL);
        }
        public DataTable Listar_Productos()
        {
            return Cargar_Data_Table("EXEC SP_ListarProductos;");
        }
        //funcion para buscar el producto por palabra clave
        public DataTable Buscar_Producto(string Palabra_Clave)
        {
            return Cargar_Data_Table("EXEC [SP_Buscar_Producto] '" + Palabra_Clave + "'");

        }

    }
}
