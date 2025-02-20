using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Queries;

public class ObtenerAdquisicionPorIdHandler(IServicioAdquisiciones servicioAdquisiciones)
    : IRequestHandler<ObtenerAdquisicionPorIdQuery, Adquisicion?>
{
    public async Task<Adquisicion?> Handle(ObtenerAdquisicionPorIdQuery request, CancellationToken cancellationToken) =>
        await servicioAdquisiciones.ObtenerPorIdAsync(request.Id);
}