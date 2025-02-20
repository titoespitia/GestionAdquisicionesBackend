using GestionAdquisiciones.Dominio.Entidades;

namespace GestionAdquisiciones.Dominio.Puertos;

public interface IRepositorioHistorial
{
    /// <summary>
    /// Obtiene el historial de cambios de una adquisición específica.
    /// </summary>
    /// <param name="adquisicionId">ID de la adquisición.</param>
    /// <returns>Lista de registros de historial.</returns>
    Task<List<HistorialAdquisicion>> ObtenerPorAdquisicionIdAsync(int adquisicionId);

    /// <summary>
    /// Agrega un nuevo registro al historial.
    /// </summary>
    /// <param name="historial">Registro de historial a agregar.</param>
    Task AgregarAsync(HistorialAdquisicion historial);
}
