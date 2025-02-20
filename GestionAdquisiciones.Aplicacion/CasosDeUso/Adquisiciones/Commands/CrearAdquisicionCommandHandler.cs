using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public class CrearAdquisicionHandler(IServicioAdquisiciones servicioAdquisiciones)
    : IRequestHandler<CrearAdquisicionCommand, int>
{
    public async Task<int> Handle(CrearAdquisicionCommand request, CancellationToken cancellationToken) =>
        await servicioAdquisiciones.CrearAdquisicionAsync(new Adquisicion(
            request.Presupuesto,
            request.UnidadAdministrativa,
            request.TipoBienServicio,
            request.Cantidad,
            request.ValorUnitario,
            request.FechaAdquisicion,
            request.Proveedor,
            request.Documentacion
        ));
}
