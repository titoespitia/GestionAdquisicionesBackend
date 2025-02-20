using GestionAdquisiciones.Dominio.Entidades;

namespace GestionAdquisiciones.Dominio.Puertos;

public interface IServicioHistorial
{
    /// <summary>
    /// Obtiene el historial de cambios de una adquisición específica.
    /// </summary>
    /// <param name="adquisicionId">ID de la adquisición.</param>
    /// <returns>Lista de registros de historial.</returns>
    Task<List<HistorialAdquisicion>> ObtenerHistorialPorAdquisicionAsync(int adquisicionId);

    /// <summary>
    /// Registra un nuevo cambio en el historial de adquisiciones.
    /// </summary>
    /// <param name="adquisicionId">ID de la adquisición modificada.</param>
    /// <param name="campoModificado">Nombre del campo que fue modificado.</param>
    /// <param name="valorAnterior">Valor antes del cambio.</param>
    /// <param name="valorNuevo">Valor después del cambio.</param>
    /// <param name="usuarioModificador">Usuario que realizó la modificación.</param>
    Task RegistrarCambioAsync(
        int adquisicionId,
        string campoModificado,
        string valorAnterior,
        string valorNuevo,
        string usuarioModificador
    );
}
