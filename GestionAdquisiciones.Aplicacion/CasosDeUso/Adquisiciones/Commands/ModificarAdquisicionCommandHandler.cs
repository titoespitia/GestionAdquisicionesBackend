using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public class ModificarAdquisicionHandler(IServicioAdquisiciones servicioAdquisiciones)
    : IRequestHandler<ModificarAdquisicionCommand>
{
    public async Task Handle(ModificarAdquisicionCommand request, CancellationToken cancellationToken) =>
        await servicioAdquisiciones.ModificarAdquisicionAsync(
            request.Id,
            request.Presupuesto,
            request.UnidadAdministrativa,
            request.TipoBienServicio,
            request.Cantidad,
            request.ValorUnitario,
            request.FechaAdquisicion,
            request.Proveedor,
            request.Documentacion,
            request.UsuarioModificador
        );
}
