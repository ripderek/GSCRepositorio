using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024.Clases
{
    internal class Clientes : ConexionBD
    {
        private string IDENTIFICACION;
        private string NOMBRES;
        private string CORREO;
        private string TELEFONO;
        private string ESTADO;

        public string IDENTIFICACION_ { get => IDENTIFICACION; set => IDENTIFICACION = value; }
        public string NOMBRES_ { get => NOMBRES; set => NOMBRES = value; }
        public string CORREO_ { get => CORREO; set => CORREO = value; }
        public string TELEFONO_ { get => TELEFONO; set => TELEFONO = value; }
        public string ESTADO_ { get => ESTADO; set => ESTADO = value; }

        //funcion para crear el cliente 
        public void CrearCliente()
        {
            ConcatenacionCadena("EXEC SP_Insertar_Cliente '" + IDENTIFICACION_ + "' ,'" + NOMBRES_ + "',  '" + CORREO_ + "' , '" + TELEFONO_ + "'"); 
        }
        //funcion para editar el cliente
        public void Editar_Cliente()
        {
            ConcatenacionCadena("EXEC SP_Actualizar_Cliente '" + IDENTIFICACION_ + "' , '" + NOMBRES_ + "', '" + CORREO_ + "' , '" + TELEFONO_ + "'");
        }
        //funcion para eliminar el cliente 
        public void Eliminar_Cliente()
        {
            ConcatenacionCadena("EXEC SP_Eliminar_Cliente '" + IDENTIFICACION_ + "'");
        }
        //funcion para listar los clientes 

        public DataTable Listar_Clientes()
        {
            return Cargar_Data_Table("EXEC SP_Mostrar_Clientes;");
        }

        //funcion para buscar el cliente por palabra clave
        public DataTable Buscar_Cliente(string Palabra_Clave)
        {
            return Cargar_Data_Table("EXEC [SP_Buscar_Cliente] '"+Palabra_Clave+"'");

        }
    }
}
