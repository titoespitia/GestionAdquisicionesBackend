using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public record ModificarAdquisicionCommand(
    int Id,
    decimal Presupuesto,
    string UnidadAdministrativa,
    string TipoBienServicio,
    int Cantidad,
    decimal ValorUnitario,
    DateTime FechaAdquisicion,
    string Proveedor,
    string Documentacion,
    string UsuarioModificador
) : IRequest;
