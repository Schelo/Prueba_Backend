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
using Microsoft.AspNetCore.Cors;

using Prueba_Backend.Modelo;
using Prueba_Backend.Procedure;
using Microsoft.AspNetCore.Authorization;



namespace Prueba_Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BooksController : ControllerBase

    {
        [HttpPost("Create")]
        public ActionResult Post(Books Libro) 
        {
            string salida = string.Empty;
            if (Libro == null) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            var respuesta = proceso.Crear(Libro);

            if (respuesta)
            {
                salida = "Se ha creado correctamente el libro " + Libro.Title;
            }
            
            return Ok(salida);

        }

        [HttpGet]
        [Route("GetOne/{BookId}")]
        public ActionResult<Books> Get(int BookId)
        {
            if (BookId <= 0) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            Books Libro = proceso.SeleccionarLibro(BookId);

            if (Libro == null) return NotFound();

            return Ok(Libro);
        }

        [HttpGet("GetAll")]
        public ActionResult<List<GetBooks>> GetAll()
        {
            ProcedureBooks proceso = new ProcedureBooks();
            List<GetBooks> Libros = proceso.SeleccionarTodos();

            return Ok(Libros);
             
            
        }

        [HttpPut("Update")]
        public ActionResult Put(Books Libro)
        {

            //bool resultado = VerificaToken(Libro.TokenUser, Libro.TokenPass);

            //if (resultado)
            //{
            if (Libro == null) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            proceso.Actualizar(Libro);
            //}

            return Ok(Libro);
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int BookId)
        {

            if (BookId <= 0) return NotFound();

            ProcedureBooks proceso = new ProcedureBooks();
            proceso.Eliminar(BookId);



            return Ok("El libro con el codigo: "+ BookId +", fue eliminado correctamente.");
        }
    }
}
