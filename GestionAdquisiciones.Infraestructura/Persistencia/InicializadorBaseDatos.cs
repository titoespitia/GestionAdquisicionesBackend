using GestionAdquisiciones.Dominio.Entidades;

namespace GestionAdquisiciones.Infraestructura.Persistencia;

public static class InicializadorBaseDatos
{
    public static void Seed(ContextoBaseDatos contexto)
    {
        contexto.Database.EnsureCreated();

        if (contexto.Adquisiciones.Any()) return;

        var adquisiciones = new List<Adquisicion>
        {
            new(
                presupuesto: 50000,
                unidadAdministrativa: "Unidad de Compras",
                tipoBienServicio: "Computadoras",
                cantidad: 10,
                valorUnitario: 5000,
                fechaAdquisicion: DateTime.UtcNow.AddDays(-30),
                proveedor: "Tech Solutions S.A.",
                documentacion: "Orden de compra #123"
            ),
            new(
                presupuesto: 20000,
                unidadAdministrativa: "Departamento de Infraestructura",
                tipoBienServicio: "Escritorios",
                cantidad: 15,
                valorUnitario: 1333,
                fechaAdquisicion: DateTime.UtcNow.AddDays(-15),
                proveedor: "Muebles Globales",
                documentacion: "Factura #456"
            ),
            new(
                presupuesto: 30000,
                unidadAdministrativa: "TI",
                tipoBienServicio: "Servidores",
                cantidad: 2,
                valorUnitario: 15000,
                fechaAdquisicion: DateTime.UtcNow.AddDays(-7),
                proveedor: "CloudData Inc.",
                documentacion: "Contrato de compra #789"
            )
        };

        contexto.Adquisiciones.AddRange(adquisiciones);
        contexto.SaveChanges();

        var historial = new List<HistorialAdquisicion>
        {
            new(adquisiciones[0].Id, "Admin", "Presupuesto", "50000", "55000"),
            new(adquisiciones[0].Id, "Admin", "Cantidad", "10", "12"),
            new(adquisiciones[1].Id, "Comprador1", "Proveedor", "Muebles Globales", "Muebles Express"),
            new(adquisiciones[2].Id, "Supervisor", "ValorUnitario", "15000", "14000")
        };

        contexto.HistorialAdquisiciones.AddRange(historial);
        contexto.SaveChanges();
    }
}
