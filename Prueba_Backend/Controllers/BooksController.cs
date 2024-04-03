/*
 * Descripción: API de control.
 * Autor: Marcelo
 * Fecha creación: 02-04-2024
 * Control de Cambios
 * Fecha            Autor              Descricpión
 * ----------------------------------------------------------------------------------------------------------
 * xx-xx-xxxx       xxxxx              xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Backend.Modelo;
using Prueba_Backend.Procedure;


namespace Prueba_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase// hot

    {
        [HttpGet]
        public ActionResult<Books> Get([FromQuery] int BookId)
        {
            if (BookId <= 0) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            Books Libro = proceso.SeleccionarLibro(BookId);

            return Ok(Libro);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Books>> GetAll()
        {
            ProcedureBooks proceso = new ProcedureBooks();
            List<Books> Libros = proceso.SeleccionarTodos();

            return Ok(Libros);
        }

        [HttpPut]
        public ActionResult Put([FromQuery] Books Libro)
        {
            if (Libro == null) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            proceso.Crear(Libro);

            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Books Libro)
        {
            if (Libro == null) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            proceso.Actualizar(Libro);

            return Ok();

        }

        [HttpDelete]
        public ActionResult Delete(int BookId) 
        {
            if (BookId <= 0) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            proceso.Eliminar(BookId);

            return Ok();
        }
    }
}
