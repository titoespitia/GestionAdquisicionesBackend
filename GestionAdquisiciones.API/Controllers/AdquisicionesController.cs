using GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;
using GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionAdquisiciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdquisicionesController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Crea una nueva adquisición.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearAdquisicion([FromBody] CrearAdquisicionCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerAdquisicionPorId), new { id }, command);
        }

        /// <summary>
        /// Obtiene todas las adquisiciones.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerAdquisiciones()
        {
            var adquisiciones = await mediator.Send(new ObtenerAdquisicionesQuery());
            return Ok(adquisiciones);
        }

        /// <summary>
        /// Obtiene una adquisición por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAdquisicionPorId(int id)
        {
            var adquisicion = await mediator.Send(new ObtenerAdquisicionPorIdQuery(id));
            if (adquisicion == null)
                return NotFound();

            return Ok(adquisicion);
        }

        /// <summary>
        /// Modifica una adquisición existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarAdquisicion(int id, [FromBody] ModificarAdquisicionCommand command)
        {
            if (id != command.Id)
                return BadRequest("El ID de la solicitud no coincide con el ID de la URL.");

            await mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Desactiva una adquisición.
        /// </summary>
        [HttpPut("{id}/desactivar")]
        public async Task<IActionResult> DesactivarAdquisicion(int id)
        {
            await mediator.Send(new DesactivarAdquisicionCommand(id, "UsuarioSistema"));
            return NoContent();
        }
    }
}
