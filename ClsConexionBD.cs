using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace PryDamonteConexionBD2
{
    public class ClsConexionBD
    {
        OleDbCommand Comando;
        OleDbConnection Conexion;
        OleDbDataAdapter Adaptador;

        string cadena;

        public ClsConexionBD()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\cande\\source\\repos\\PryDamonteConexionBD2\\bin\\Debug\\Comercio-Lab3.accdb;Persist Security Info=False;";
        }
        public void ListarDatos(DataGridView DgvDatos)
        {
            try
            {
                Conexion = new OleDbConnection(cadena);
                Comando = new OleDbCommand();

                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = "SELECT * FROM Contactos";

                DataTable Contactos = new DataTable();
                Adaptador = new OleDbDataAdapter(Comando);
                Adaptador.Fill(Contactos);

                DgvDatos.DataSource = Contactos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //public void AgregarProductos(Productos nuevoProducto)
        //{
        //    string insertQuery = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId) VALUES (@nombre, @descripcion, @precio, @stock, @categoriaId)";
        //    SqlCommand cmd = new SqlCommand(insertQuery, conn);
        //    cmd.Parameters.AddWithValue("@nombre", "Mouse inalámbrico");
        //    cmd.Parameters.AddWithValue("@descripcion", "Mouse óptico USB");
        //    cmd.Parameters.AddWithValue("@precio", 150000);
        //    cmd.Parameters.AddWithValue("@stock", 20);
        //    cmd.Parameters.AddWithValue("@categoriaId", 1); // Tecnología
        //    cmd.ExecuteNonQuery();

        //}
    }
}
