namespace GestionAdquisiciones.Dominio.Entidades;

public class HistorialAdquisicion
{
    public int Id { get; private set; }
    public int AdquisicionId { get; private set; }
    public string ModificadoPor { get; private set; }
    public DateTime FechaCambio { get; private set; }
    public string CampoModificado { get; private set; }
    public string ValorAnterior { get; private set; }
    public string ValorNuevo { get; private set; }

    private HistorialAdquisicion() { } // Requerido por EF Core

    public HistorialAdquisicion(
        int adquisicionId,
        string modificadoPor,
        string campoModificado,
        string valorAnterior,
        string valorNuevo
    )
    {
        if (adquisicionId <= 0) throw new ArgumentException("El ID de la adquisición debe ser válido.");
        if (string.IsNullOrWhiteSpace(modificadoPor)) throw new ArgumentException("El usuario modificador no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(campoModificado)) throw new ArgumentException("El campo modificado no puede estar vacío.");

        AdquisicionId = adquisicionId;
        ModificadoPor = modificadoPor;
        CampoModificado = campoModificado;
        ValorAnterior = valorAnterior;
        ValorNuevo = valorNuevo;
        FechaCambio = DateTime.UtcNow;
    }
}
