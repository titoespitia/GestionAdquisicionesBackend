using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;

namespace GestionAdquisiciones.Dominio.Servicios;

public class ServicioHistorial(IRepositorioHistorial repositorioHistorial) : IServicioHistorial
{
    /// <summary>
    /// Obtiene el historial de cambios de una adquisición.
    /// </summary>
    public async Task<List<HistorialAdquisicion>> ObtenerHistorialPorAdquisicionAsync(int adquisicionId) =>
        await repositorioHistorial.ObtenerPorAdquisicionIdAsync(adquisicionId);

    /// <summary>
    /// Registra un nuevo cambio en el historial de adquisiciones.
    /// </summary>
    public async Task RegistrarCambioAsync(
        int adquisicionId,
        string campoModificado,
        string valorAnterior,
        string valorNuevo,
        string usuarioModificador
    )
    {
        var historial = new HistorialAdquisicion(adquisicionId, usuarioModificador, campoModificado, valorAnterior, valorNuevo);
        await repositorioHistorial.AgregarAsync(historial);
    }
}
