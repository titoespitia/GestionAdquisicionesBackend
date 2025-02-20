using GestionAdquisiciones.Dominio.Entidades;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Adquisiciones.Queries;

public record ObtenerAdquisicionesQuery() : IRequest<List<Adquisicion>>;
