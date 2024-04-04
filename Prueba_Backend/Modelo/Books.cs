/*
 * Descripción: Modelo de la tabla Books.
 * Autor: Marcelo
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 */
using System.Data;

namespace Prueba_Backend.Modelo
{
    public class Books
    {
        public int? BookId { get; set; }                   // PK 
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string PublishDate { get; set; }

        public Books ()
        {

        }

        public Books(DataRow row)
        {
            try
            {
                BookId = row["BookId"] != DBNull.Value ? Convert.ToInt16(row["BookId"]) : 0;
                Title = row["Title"] != DBNull.Value ? Convert.ToString(row["Title"]) : "";
                Author = row["Author"] != DBNull.Value ? Convert.ToString(row["Author"]) : "";
                Genre = row["Genre"] != DBNull.Value ? Convert.ToString(row["Genre"]) : "";
                PublishDate = row["PublishDate"] != DBNull.Value ? Convert.ToString(row["PublishDate"]) : "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
