using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Historial.Queries;

public class ObtenerHistorialPorAdquisicionHandler(IServicioHistorial servicioHistorial)
    : IRequestHandler<ObtenerHistorialPorAdquisicionQuery, List<HistorialAdquisicion>>
{
    public async Task<List<HistorialAdquisicion>> Handle(ObtenerHistorialPorAdquisicionQuery request, CancellationToken cancellationToken) =>
        await servicioHistorial.ObtenerHistorialPorAdquisicionAsync(request.AdquisicionId);
}