using GestionAdquisiciones.Dominio.Entidades;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Queries;

public record ObtenerAdquisicionPorIdQuery(int Id) : IRequest<Adquisicion?>;
