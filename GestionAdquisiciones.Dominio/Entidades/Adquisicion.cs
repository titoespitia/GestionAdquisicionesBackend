namespace GestionAdquisiciones.Dominio.Entidades;

public class Adquisicion
{
    public int Id { get; private set; }
    public decimal Presupuesto { get; private set; }
    public string UnidadAdministrativa { get; private set; }
    public string TipoBienServicio { get; private set; }
    public int Cantidad { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public decimal ValorTotal => Cantidad * ValorUnitario;
    public DateTime FechaAdquisicion { get; private set; }
    public string Proveedor { get; private set; }
    public string Documentacion { get; private set; }
    public bool Activo { get; private set; } = true;
    public DateTime FechaCreacion { get; private set; }
    public DateTime FechaModificacion { get; private set; }

    private Adquisicion() { } // Requerido por EF Core

    public Adquisicion(
        decimal presupuesto,
        string unidadAdministrativa,
        string tipoBienServicio,
        int cantidad,
        decimal valorUnitario,
        DateTime fechaAdquisicion,
        string proveedor,
        string documentacion
    )
    {
        if (presupuesto <= 0) throw new ArgumentException("El presupuesto debe ser mayor a 0.");
        if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a 0.");
        if (valorUnitario <= 0) throw new ArgumentException("El valor unitario debe ser mayor a 0.");
        if (string.IsNullOrWhiteSpace(proveedor)) throw new ArgumentException("El proveedor no puede estar vacío.");

        Presupuesto = presupuesto;
        UnidadAdministrativa = unidadAdministrativa;
        TipoBienServicio = tipoBienServicio;
        Cantidad = cantidad;
        ValorUnitario = valorUnitario;
        FechaAdquisicion = fechaAdquisicion;
        Proveedor = proveedor;
        Documentacion = documentacion;
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
        FechaModificacion = DateTime.UtcNow;
    }

    public void ModificarPresupuesto(decimal nuevoPresupuesto, string usuarioModificador)
    {
        if (nuevoPresupuesto <= 0) throw new ArgumentException("El presupuesto debe ser mayor a 0.");
        Presupuesto = nuevoPresupuesto;
        ActualizarFechaModificacion();
    }

    public void ModificarCantidad(int nuevaCantidad, string usuarioModificador)
    {
        if (nuevaCantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a 0.");
        Cantidad = nuevaCantidad;
        ActualizarFechaModificacion();
    }

    public void ModificarProveedor(string nuevoProveedor, string usuarioModificador)
    {
        if (string.IsNullOrWhiteSpace(nuevoProveedor)) throw new ArgumentException("El proveedor no puede estar vacío.");
        Proveedor = nuevoProveedor;
        ActualizarFechaModificacion();
    }

    public void ModificarFechaAdquisicion(DateTime nuevaFecha, string usuarioModificador)
    {
        if (nuevaFecha > DateTime.UtcNow) throw new ArgumentException("La fecha de adquisición no puede ser en el futuro.");
        FechaAdquisicion = nuevaFecha;
        ActualizarFechaModificacion();
    }

    public void ModificarUnidadAdministrativa(string nuevaUnidad, string usuarioModificador)
    {
        if (string.IsNullOrWhiteSpace(nuevaUnidad)) throw new ArgumentException("La unidad administrativa no puede estar vacía.");
        UnidadAdministrativa = nuevaUnidad;
        ActualizarFechaModificacion();
    }

    public void ModificarTipoBienServicio(string nuevoTipo, string usuarioModificador)
    {
        if (string.IsNullOrWhiteSpace(nuevoTipo)) throw new ArgumentException("El tipo de bien o servicio no puede estar vacío.");
        TipoBienServicio = nuevoTipo;
        ActualizarFechaModificacion();
    }

    public void ModificarValorUnitario(decimal nuevoValor, string usuarioModificador)
    {
        if (nuevoValor <= 0) throw new ArgumentException("El valor unitario debe ser mayor a 0.");
        ValorUnitario = nuevoValor;
        ActualizarFechaModificacion();
    }

    public void ModificarDocumentacion(string nuevaDocumentacion, string usuarioModificador)
    {
        Documentacion = nuevaDocumentacion;
        ActualizarFechaModificacion();
    }

    public void Desactivar(string usuarioModificador)
    {
        if (!Activo) throw new InvalidOperationException("La adquisición ya está desactivada.");
        Activo = false;
        ActualizarFechaModificacion();
    }

    private void ActualizarFechaModificacion() => FechaModificacion = DateTime.UtcNow;
}
