using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Commands;

public record DesactivarAdquisicionCommand(int Id, string UsuarioModificador) : IRequest;
