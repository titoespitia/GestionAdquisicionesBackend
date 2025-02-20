using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Queries;

public class ObtenerAdquisicionesHandler(IServicioAdquisiciones servicioAdquisiciones)
    : IRequestHandler<ObtenerAdquisicionesQuery, List<Adquisicion>>
{
    public async Task<List<Adquisicion>> Handle(ObtenerAdquisicionesQuery request, CancellationToken cancellationToken) =>
        await servicioAdquisiciones.ObtenerTodasAsync();
}