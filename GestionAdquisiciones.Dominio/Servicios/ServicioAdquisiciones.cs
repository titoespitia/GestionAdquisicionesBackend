using GestionAdquisiciones.Dominio.Entidades;
using GestionAdquisiciones.Dominio.Puertos;

namespace GestionAdquisiciones.Dominio.Servicios;

public class ServicioAdquisiciones(
    IRepositorioAdquisiciones repositorioAdquisiciones,
    IServicioHistorial servicioHistorial
) : IServicioAdquisiciones
{
    /// <summary>
    /// Crea una nueva adquisición y la almacena en el sistema.
    /// </summary>
    public async Task<int> CrearAdquisicionAsync(Adquisicion adquisicion)
    {
        await repositorioAdquisiciones.AgregarAsync(adquisicion);
        return adquisicion.Id;
    }

    /// <summary>
    /// Obtiene todas las adquisiciones registradas en el sistema.
    /// </summary>
    public async Task<List<Adquisicion>> ObtenerTodasAsync() =>
        await repositorioAdquisiciones.ObtenerTodasAsync();

    /// <summary>
    /// Obtiene una adquisición específica por su ID.
    /// </summary>
    public async Task<Adquisicion?> ObtenerPorIdAsync(int id) =>
        await repositorioAdquisiciones.ObtenerPorIdAsync(id);

    /// <summary>
    /// Modifica una adquisición existente en el sistema.
    /// </summary>
    public async Task ModificarAdquisicionAsync(
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
)
    {
        var adquisicion = await repositorioAdquisiciones.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"No se encontró la adquisición con ID {id}.");

        // 📌 Lista de cambios para el historial
        var cambios = new List<(string Campo, string ValorAnterior, string ValorNuevo)>();

        // 📌 Comparación de valores antes y después
        if (adquisicion.Presupuesto != presupuesto)
            cambios.Add(("Presupuesto", adquisicion.Presupuesto.ToString(), presupuesto.ToString()));

        if (adquisicion.Cantidad != cantidad)
            cambios.Add(("Cantidad", adquisicion.Cantidad.ToString(), cantidad.ToString()));

        if (adquisicion.Proveedor != proveedor)
            cambios.Add(("Proveedor", adquisicion.Proveedor, proveedor));

        if (adquisicion.FechaAdquisicion != fechaAdquisicion)
            cambios.Add(("Fecha de Adquisición", adquisicion.FechaAdquisicion.ToString("yyyy-MM-dd"), fechaAdquisicion.ToString("yyyy-MM-dd")));

        if (adquisicion.UnidadAdministrativa != unidadAdministrativa)
            cambios.Add(("Unidad Administrativa", adquisicion.UnidadAdministrativa, unidadAdministrativa));

        if (adquisicion.TipoBienServicio != tipoBienServicio)
            cambios.Add(("Tipo de Bien o Servicio", adquisicion.TipoBienServicio, tipoBienServicio));

        if (adquisicion.ValorUnitario != valorUnitario)
            cambios.Add(("Valor Unitario", adquisicion.ValorUnitario.ToString(), valorUnitario.ToString()));

        if (adquisicion.Documentacion != documentacion)
            cambios.Add(("Documentación", adquisicion.Documentacion, documentacion));

        // 📌 Registrar los cambios en el historial
        foreach (var cambio in cambios)
        {
            await servicioHistorial.RegistrarCambioAsync(id, cambio.Campo, cambio.ValorAnterior, cambio.ValorNuevo, usuarioModificador);
        }

        // 📌 Modificar los valores en la entidad
        adquisicion.ModificarPresupuesto(presupuesto, usuarioModificador);
        adquisicion.ModificarCantidad(cantidad, usuarioModificador);
        adquisicion.ModificarProveedor(proveedor, usuarioModificador);
        adquisicion.ModificarFechaAdquisicion(fechaAdquisicion, usuarioModificador);
        adquisicion.ModificarUnidadAdministrativa(unidadAdministrativa, usuarioModificador);
        adquisicion.ModificarTipoBienServicio(tipoBienServicio, usuarioModificador);
        adquisicion.ModificarValorUnitario(valorUnitario, usuarioModificador);
        adquisicion.ModificarDocumentacion(documentacion, usuarioModificador);

        // 📌 Guardar los cambios en la base de datos
        await repositorioAdquisiciones.ActualizarAsync(adquisicion);
    }


    /// <summary>
    /// Desactiva una adquisición específica.
    /// </summary>
    public async Task DesactivarAdquisicionAsync(int id, string usuarioModificador)
    {
        var adquisicion = await repositorioAdquisiciones.ObtenerPorIdAsync(id)
            ?? throw new KeyNotFoundException($"No se encontró la adquisición con ID {id}.");

        if (adquisicion.Activo)
        {
            adquisicion.Desactivar(usuarioModificador);
            await servicioHistorial.RegistrarCambioAsync(id, "Estado", "Activo", "Inactivo", usuarioModificador);
            await repositorioAdquisiciones.ActualizarAsync(adquisicion);
        }
    }
}
