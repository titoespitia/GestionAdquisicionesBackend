using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public record CrearAdquisicionCommand(
    decimal Presupuesto,
    string UnidadAdministrativa,
    string TipoBienServicio,
    int Cantidad,
    decimal ValorUnitario,
    decimal ValorTotal,
    DateTime FechaAdquisicion,
    string Proveedor,
    string Documentacion
) : IRequest<int>;