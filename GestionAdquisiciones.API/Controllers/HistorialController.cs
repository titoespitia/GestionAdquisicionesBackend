using GestionAdquisiciones.Aplicacion.CasosDeUso.Historial.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionAdquisiciones.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistorialController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Obtiene el historial de cambios de una adquisición específica.
    /// </summary>
    [HttpGet("{adquisicionId}")]
    public async Task<IActionResult> ObtenerHistorialPorAdquisicion(int adquisicionId)
    {
        var historial = await mediator.Send(new ObtenerHistorialPorAdquisicionQuery(adquisicionId));

        return Ok(historial);
    }
}
