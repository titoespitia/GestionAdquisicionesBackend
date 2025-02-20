using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;
using GestionAdquisiciones.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace GestionAdquisiciones.Infraestructura.Adaptadores;

public class RepositorioAdquisiciones(ContextoBaseDatos contexto) : IRepositorioAdquisiciones
{
    /// <summary>
    /// Obtiene todas las adquisiciones registradas en la base de datos.
    /// </summary>
    public async Task<List<Adquisicion>> ObtenerTodasAsync() =>
        await contexto.Adquisiciones.AsNoTracking().ToListAsync();

    /// <summary>
    /// Obtiene una adquisición específica por su ID.
    /// </summary>
    public async Task<Adquisicion?> ObtenerPorIdAsync(int id) =>
        await contexto.Adquisiciones.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

    /// <summary>
    /// Agrega una nueva adquisición a la base de datos.
    /// </summary>
    public async Task AgregarAsync(Adquisicion adquisicion)
    {
        await contexto.Adquisiciones.AddAsync(adquisicion);
        await contexto.SaveChangesAsync();
    }

    /// <summary>
    /// Actualiza una adquisición existente en la base de datos.
    /// </summary>
    public async Task ActualizarAsync(Adquisicion adquisicion)
    {
        contexto.Adquisiciones.Update(adquisicion);
        await contexto.SaveChangesAsync();
    }

    /// <summary>
    /// Desactiva una adquisición cambiando su estado a inactivo.
    /// </summary>
    public async Task DesactivarAsync(int id)
    {
        var adquisicion = await contexto.Adquisiciones.FindAsync(id);
        if (adquisicion is not null)
        {
            adquisicion.Desactivar("Sistema");
            await contexto.SaveChangesAsync();
        }
    }
}
