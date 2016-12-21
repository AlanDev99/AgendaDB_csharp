using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace AgendaDB_csharp
{
    class Operaciones
    {
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;

        public Operaciones()
        {
            
        }

        public string insertar(string nombre, string apellido, string apodo, string telFijo, string telMovil, string email, string foto, string observacion)
        {
            string salida = "Si se inserto";
            string commandText = "Insert into contacto(nombre, apellido, apodo, telefonoFijo, telefonoMovil, email, foto, observacion)" +
                                 "values(@nombre, @apellido, @apodo, @telFijo, @telMovil, @email, @foto, @observacion) ";

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
            {
                try
                {
                    cmd = new SqlCommand(commandText, cn);
                    cmd.Parameters.AddWithValue("nombre", nombre);
                    cmd.Parameters.AddWithValue("apellido", apellido);
                    cmd.Parameters.AddWithValue("apodo", apodo);
                    cmd.Parameters.AddWithValue("telFijo", telFijo);
                    cmd.Parameters.AddWithValue("telMovil", telMovil);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("foto", foto);
                    cmd.Parameters.AddWithValue("observacion", observacion);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    salida = "No se conecto: " + ex.ToString();
                }
            }
            return salida;
        }

        public void cargarContactos(DataGridView dgv)
        {
            using(SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString))
            {
                try
                {
                    da = new SqlDataAdapter("Select idContacto, nombre, apellido, telefonoMovil, email from contacto", cn);
                    dt = new DataTable();
                    cn.Open();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar el Datagridview: " + ex.ToString());

                }
            }            
            
        }

    }
}
