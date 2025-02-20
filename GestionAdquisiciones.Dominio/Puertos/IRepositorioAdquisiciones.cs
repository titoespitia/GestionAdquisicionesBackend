using GestionAdquisiciones.Dominio.Entidades;

namespace GestionAdquisiciones.Dominio.Puertos;

public interface IRepositorioAdquisiciones
{
    /// <summary>
    /// Obtiene todas las adquisiciones registradas en la base de datos.
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
    /// Agrega una nueva adquisición a la base de datos.
    /// </summary>
    /// <param name="adquisicion">Objeto adquisición con datos a registrar.</param>
    Task AgregarAsync(Adquisicion adquisicion);

    /// <summary>
    /// Actualiza una adquisición existente en la base de datos.
    /// </summary>
    /// <param name="adquisicion">Objeto adquisición con datos actualizados.</param>
    Task ActualizarAsync(Adquisicion adquisicion);

    /// <summary>
    /// Desactiva una adquisición cambiando su estado a inactivo.
    /// </summary>
    /// <param name="id">ID de la adquisición a desactivar.</param>
    Task DesactivarAsync(int id);
}
