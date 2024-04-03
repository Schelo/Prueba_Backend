/*
 * Descripción: Modelo de la tabla Books.
 * Autor: Marcelo
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 */
namespace Prueba_Backend.Modelo
{
    public class Books
    {
        public int BookId { get; set; } = 0;                    // PK
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
    }
}
