/*
 * Descripción: Modelo de la tabla Books.
 * Autor: Marcelo H
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 * 15-04-2024       Marcelo H          Leves correcciones en el codigo.
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
        public DateTime PublishDate { get; set; }

        public Books ()
        {

        }

        public Books(DataRow row)
        {
            try
            {
                BookId = row["Id"] != DBNull.Value ? Convert.ToInt16(row["Id"]) : 0;
                Title = row["Title"] != DBNull.Value ? Convert.ToString(row["Title"]) : "";
                Author = row["Author"] != DBNull.Value ? Convert.ToString(row["Author"]) : "";
                Genre = row["Genre"] != DBNull.Value ? Convert.ToString(row["Genre"]) : "";
                PublishDate = row["PublishDate"] != DBNull.Value ? Convert.ToDateTime(row["PublishDate"]) : DateTime.MinValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
