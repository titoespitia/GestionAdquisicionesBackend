using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using GestionAdquisiciones.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace GestionAdquisiciones.Infraestructura.Adaptadores;

public class RepositorioHistorial(ContextoBaseDatos contexto) : IRepositorioHistorial
{
    /// <summary>
    /// Obtiene el historial de cambios de una adquisición específica.
    /// </summary>
    public async Task<List<HistorialAdquisicion>> ObtenerPorAdquisicionIdAsync(int adquisicionId) =>
        await contexto.HistorialAdquisiciones
            .AsNoTracking()
            .Where(h => h.AdquisicionId == adquisicionId)
            .OrderByDescending(h => h.FechaCambio)
            .ToListAsync();

    /// <summary>
    /// Agrega un nuevo registro al historial.
    /// </summary>
    public async Task AgregarAsync(HistorialAdquisicion historial)
    {
        await contexto.HistorialAdquisiciones.AddAsync(historial);
        await contexto.SaveChangesAsync();
    }
}