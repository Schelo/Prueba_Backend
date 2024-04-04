using System.Data;

namespace Prueba_Backend.Modelo
{
    public class GetBooks
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authoro { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }

        public GetBooks()
        {

        }

        public GetBooks(DataRow row)
        {
            try
            {
                BookId = row["BookId"] != DBNull.Value ? Convert.ToInt16(row["BookId"]) : 0;
                Title = row["Title"] != DBNull.Value ? Convert.ToString(row["Title"]) : "";
                Authoro = row["Author"] != DBNull.Value ? Convert.ToString(row["Author"]) : "";
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
