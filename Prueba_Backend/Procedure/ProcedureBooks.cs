/*
 * Descripción: Procedimientos almacenados.
 * Autor: Marcelo
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 */
using System.Data.SqlClient;
using Prueba_Backend.Modelo;

namespace Prueba_Backend.Procedure
{
    public class ProcedureBooks
    {
        SqlConnection conn = new SqlConnection("Server=(localdb)\\localDB01;Database=Librodb;User Id=usuario;Password=password;");
        public void Crear(Books  Libro) 
        {
            // 
            string procedure = "sp_InsertBook";
            SqlCommand command = new SqlCommand(procedure, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@title", Libro.Title);
            command.Parameters.AddWithValue("@auth",Libro.Author);
            command.Parameters.AddWithValue("@genre",Libro.Genre);
            command.Parameters.AddWithValue("@date",Libro.PublishDate);

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
        public void Actualizar(Books Libro)
        {
            // 
            string procedure = "sp_UpdateBook";
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
        public void Eliminar(int BookId)
        {
            //
            string procedure = "sp_DeleteBook";
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
        public Books SeleccionarLibro(int BookId)
        {
            //
            string sql = "select BookId, Title, Author, Genre, PublishDate from Books where bid = " + BookId.ToString() + " ";
            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            Books Libro = new Books();
            try
            {
                conn.Open();
                SqlDataReader datos = command.ExecuteReader();
                
                while (datos.Read()) 
                {
                    Libro.BookId = int.Parse(datos["bid"].ToString()!);
                    Libro.Title = datos["title"].ToString()!;
                    Libro.Author = datos["auth"].ToString()!;
                    Libro.Genre = datos["genre"].ToString()!;
                    Libro.PublishDate = DateTime.Parse(datos["date"].ToString()!);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                // Control de errores.
            }
            return Libro;
        }
        public List<Books> SeleccionarTodos()
        {
            //
            string sql = "select BookId, Title, Author, Genre, PublishDate from Books order by BookId ";
            SqlCommand command = new SqlCommand(sql, conn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
            List<Books> listaLibros = new List<Books>();
            try
            {
                conn.Open();
                SqlDataReader datos = command.ExecuteReader();

                while (datos.Read())
                {
                    Books Libro = new Books();
                    Libro.BookId = int.Parse(datos["bid"].ToString()!);
                    Libro.Title = datos["title"].ToString()!;
                    Libro.Author = datos["auth"].ToString()!;
                    Libro.Genre = datos["genre"].ToString()!;
                    Libro.PublishDate = DateTime.Parse(datos["date"].ToString()!);

                    listaLibros.Add(Libro);
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
