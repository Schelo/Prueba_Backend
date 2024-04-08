/*
 * Descripción: Procedimientos almacenados.
 * Autor: Marcelo
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 */
using System.Data;
using System.Data.SqlClient;
using Prueba_Backend.Modelo;

namespace Prueba_Backend.Procedure
{
    public class ProcedureBooks
    {
        SqlConnection conn = new SqlConnection("Data source=DEVCL-JOSEFA;initial catalog=Prueba;persist security info=True;user id=aspnet;password=123;");
        public bool Crear(Books Libro) //[Funcional]
        {
            bool respuesta = false;
            // 
            string procedure = "[dbo].[sp_InsertBook]";
            SqlCommand command = new SqlCommand(procedure, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", Libro.Title);
            command.Parameters.AddWithValue("@auth", Libro.Author);
            command.Parameters.AddWithValue("@genre", Libro.Genre);
            command.Parameters.AddWithValue("@date", Libro.PublishDate);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                respuesta = true;

            }
            catch
            {
                // Control de errores.
            }
            return respuesta;
        }
        public void Actualizar(Books Libro) //[]
        {
            // 
            string procedure = "[dbo].[sp_UpdateBook]";
            SqlCommand command = new SqlCommand(procedure, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bid", Libro.BookId);
            command.Parameters.AddWithValue("@title", Libro.Title);
            command.Parameters.AddWithValue("@auth", Libro.Author);
            command.Parameters.AddWithValue("@genre", Libro.Genre);
            command.Parameters.AddWithValue("@date", Libro.PublishDate);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                // Control de errores.
            }
        }
        public void Eliminar(int BookId)  //[Funciona]
        {
            //
            string procedure = "[dbo].[sp_DeleteBook]";
            SqlCommand command = new SqlCommand(procedure, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bid", BookId);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                // Control de errores.
            }
        }
        public Books SeleccionarLibro(int BookId) //[ahora no funciona T-T]
        {
            //
            string procedure = "[dbo].[sp_GetBookById]";
            SqlCommand command = new SqlCommand(procedure, conn);
            DataTable dt = new DataTable();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            Books Libro = new Books();
            command.Parameters.AddWithValue("@bid", BookId);
            try
            {
               
                conn.Open();
                var da = new SqlDataAdapter(command);
                da.Fill(dt);

                Libro.BookId = Int32.Parse(dt.Rows[0]["BookId"].ToString()); 
                Libro.Title = dt.Rows[0]["Title"].ToString();
                Libro.Author= dt.Rows[0]["Author"].ToString();
                Libro.Genre = dt.Rows[0]["Genre"].ToString();
                Libro.PublishDate = dt.Rows[0]["PublishDate"].ToString();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                //Control de errores.
            }
            return Libro;
        }
        public List<GetBooks> SeleccionarTodos()  //[Funciona]
        {
            //
            string procedure = "[dbo].[sp_GetAllBooks]";
            SqlCommand command = new SqlCommand(procedure, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<GetBooks> listaLibros = new List<GetBooks>();

            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                var da = new SqlDataAdapter(command);
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return new List<GetBooks>();
                }

                foreach (DataRow row in dt.Rows)
                {
                    var libro = new GetBooks(row);
                    listaLibros.Add(libro);
                }

                conn.Close();
            }
            catch
            {
                // Control de errores.
            }
            return listaLibros;
        }
    }
}
