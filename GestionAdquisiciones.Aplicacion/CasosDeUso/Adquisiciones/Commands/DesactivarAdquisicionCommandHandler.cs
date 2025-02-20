using GestionAdquisiciones.Dominio.Puertos;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public class DesactivarAdquisicionHandler(IServicioAdquisiciones servicioAdquisiciones)
    : IRequestHandler<DesactivarAdquisicionCommand>
{
    public async Task Handle(DesactivarAdquisicionCommand request, CancellationToken cancellationToken) =>
        await servicioAdquisiciones.DesactivarAdquisicionAsync(request.Id, request.UsuarioModificador);
}