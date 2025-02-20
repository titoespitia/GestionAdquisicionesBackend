using GestionAdquisiciones.Dominio.Entidades;

namespace GestionAdquisiciones.Dominio.Puertos;

public interface IServicioAdquisiciones
{
    /// <summary>
    /// Crea una nueva adquisición y la almacena en el sistema.
    /// </summary>
    /// <param name="adquisicion">Objeto adquisición con datos a registrar.</param>
    /// <returns>El ID de la adquisición creada.</returns>
    Task<int> CrearAdquisicionAsync(Adquisicion adquisicion);

    /// <summary>
    /// Obtiene todas las adquisiciones registradas en el sistema.
    /// </summary>
    /// <returns>Lista de adquisiciones.</returns>
    Task<List<Adquisicion>> ObtenerTodasAsync();

    /// <summary>
    /// Obtiene una adquisición específica por su ID.
    /// </summary>
    /// <param name="id">ID de la adquisición a consultar.</param>
    /// <returns>La adquisición encontrada o null si no existe.</returns>
    Task<Adquisicion?> ObtenerPorIdAsync(int id);

    /// <summary>
    /// Modifica una adquisición existente en el sistema.
    /// </summary>
    /// <param name="id">ID de la adquisición a modificar.</param>
    /// <param name="presupuesto">Nuevo presupuesto.</param>
    /// <param name="unidadAdministrativa">Nueva unidad administrativa.</param>
    /// <param name="tipoBienServicio">Nuevo tipo de bien o servicio.</param>
    /// <param name="cantidad">Nueva cantidad.</param>
    /// <param name="valorUnitario">Nuevo valor unitario.</param>
    /// <param name="fechaAdquisicion">Nueva fecha de adquisición.</param>
    /// <param name="proveedor">Nuevo proveedor.</param>
    /// <param name="documentacion">Nueva documentación.</param>
    /// <param name="usuarioModificador">Usuario que realiza la modificación.</param>
    Task ModificarAdquisicionAsync(
        int id,
        decimal presupuesto,
        string unidadAdministrativa,
        string tipoBienServicio,
        int cantidad,
        decimal valorUnitario,
        DateTime fechaAdquisicion,
        string proveedor,
        string documentacion,
        string usuarioModificador
    );

    /// <summary>
    /// Desactiva una adquisición específica.
    /// </summary>
    /// <param name="id">ID de la adquisición a desactivar.</param>
    /// <param name="usuarioModificador">Usuario que realiza la desactivación.</param>
    Task DesactivarAdquisicionAsync(int id, string usuarioModificador);
}
