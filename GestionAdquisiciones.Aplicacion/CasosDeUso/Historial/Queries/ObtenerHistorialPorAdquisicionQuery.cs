using GestionAdquisiciones.Dominio.Entidades;
using MediatR;

namespace GestionAdquisiciones.Aplicacion.CasosDeUso.Historial.Queries;

public record ObtenerHistorialPorAdquisicionQuery(int AdquisicionId) : IRequest<List<HistorialAdquisicion>>;
