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
    public class GetBooks
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authoro { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }

        public GetBooks()
        {

        }

        public GetBooks(DataRow row)
        {
            try
            {
                BookId = row["Id"] != DBNull.Value ? Convert.ToInt16(row["Id"]) : 0;
                Title = row["Title"] != DBNull.Value ? Convert.ToString(row["Title"]) : "";
                Authoro = row["Author"] != DBNull.Value ? Convert.ToString(row["Author"]) : "";
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
