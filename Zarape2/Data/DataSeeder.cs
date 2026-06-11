using Zarape2.Controllers;
using Zarape2.Models;

namespace Zarape2.Data
{
    public static class DataSeeder
    {
        private static bool _seeded;

        public static void Seed()
        {
            if (_seeded) return;
            _seeded = true;

            SeedSucursales();
            SeedAlimentos();
            SeedBebidas();
            SeedCombos();
            SeedUsuarios();
            SeedComandas();
        }

        private static void SeedSucursales()
        {
            if (SucursalesController.sucursales.Count > 0) return;

            SucursalesController.sucursales.AddRange(new[]
            {
                new Sucursal { Id = 1, Nombre = "Sucursal Centro", Direccion = "Av. Principal 123", Telefono = "555-0101", Activa = true },
                new Sucursal { Id = 2, Nombre = "Sucursal Norte", Direccion = "Blvd. Norte 456", Telefono = "555-0102", Activa = true },
                new Sucursal { Id = 3, Nombre = "Sucursal Sur", Direccion = "Calle Sur 789", Telefono = "555-0103", Activa = true }
            });
        }

        private static void SeedAlimentos()
        {
            if (AlimentoController.alimentos.Count > 0) return;

            AlimentoController.alimentos.AddRange(new[]
            {
                new Alimento { Id = 1, Nombre = "Tacos al pastor", Descripcion = "Orden de 3 tacos con piña", Precio = 45m, Disponible = true },
                new Alimento { Id = 2, Nombre = "Quesadilla", Descripcion = "Quesadilla de flor de calabaza", Precio = 55m, Disponible = true },
                new Alimento { Id = 3, Nombre = "Enchiladas verdes", Descripcion = "Tres enchiladas con crema", Precio = 65m, Disponible = true }
            });
        }

        private static void SeedBebidas()
        {
            if (BebidaController.bebidas.Count > 0) return;

            BebidaController.bebidas.AddRange(new[]
            {
                new Bebida { Id = 1, Nombre = "Agua natural", Descripcion = "Botella 500 ml", Precio = 20m, Disponible = true },
                new Bebida { Id = 2, Nombre = "Refresco", Descripcion = "Lata 355 ml", Precio = 25m, Disponible = true },
                new Bebida { Id = 3, Nombre = "Cerveza", Descripcion = "Cerveza nacional", Precio = 40m, Disponible = true }
            });
        }

        private static void SeedCombos()
        {
            if (ComboController.combos.Count > 0) return;

            var tacos = AlimentoController.alimentos.First(a => a.Id == 1);
            var enchiladas = AlimentoController.alimentos.First(a => a.Id == 3);
            var refresco = BebidaController.bebidas.First(b => b.Id == 2);
            var cerveza = BebidaController.bebidas.First(b => b.Id == 3);

            var comboExpress = new Combo
            {
                Id = 1,
                Nombre = "Combo Express",
                Descripcion = "Tacos al pastor + refresco",
                Precio = 65m,
                Disponible = true,
                Alimentos = new List<ComboAlimento>(),
                Bebidas = new List<ComboBebida>()
            };

            comboExpress.Alimentos.Add(new ComboAlimento
            {
                Id = 1,
                ComboId = 1,
                AlimentoId = 1,
                Cantidad = 1,
                Combo = comboExpress,
                Alimento = tacos
            });

            comboExpress.Bebidas.Add(new ComboBebida
            {
                Id = 1,
                ComboId = 1,
                BebidaId = 2,
                Cantidad = 1,
                Combo = comboExpress,
                Bebida = refresco
            });

            var comboFamiliar = new Combo
            {
                Id = 2,
                Nombre = "Combo Familiar",
                Descripcion = "Enchiladas verdes + 2 cervezas",
                Precio = 130m,
                Disponible = true,
                Alimentos = new List<ComboAlimento>(),
                Bebidas = new List<ComboBebida>()
            };

            comboFamiliar.Alimentos.Add(new ComboAlimento
            {
                Id = 2,
                ComboId = 2,
                AlimentoId = 3,
                Cantidad = 1,
                Combo = comboFamiliar,
                Alimento = enchiladas
            });

            comboFamiliar.Bebidas.Add(new ComboBebida
            {
                Id = 2,
                ComboId = 2,
                BebidaId = 3,
                Cantidad = 2,
                Combo = comboFamiliar,
                Bebida = cerveza
            });

            ComboController.combos.Add(comboExpress);
            ComboController.combos.Add(comboFamiliar);
        }

        private static void SeedUsuarios()
        {
            if (UsuariosController.usuarios.Count > 0) return;

            var sucursales = SucursalesController.sucursales;

            UsuariosController.usuarios.AddRange(new[]
            {
                new Usuario
                {
                    Id = 1,
                    Nombre = "Administrador",
                    UsuarioLogin = "admin",
                    Password = "1234",
                    Rol = "Administrador",
                    Activo = true,
                    SucursalId = 1,
                    Sucursal = sucursales.First(s => s.Id == 1)
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Carlos Mesero",
                    UsuarioLogin = "mesero1",
                    Password = "1234",
                    Rol = "Mesero",
                    Activo = true,
                    SucursalId = 1,
                    Sucursal = sucursales.First(s => s.Id == 1)
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Ana Cajera",
                    UsuarioLogin = "cajero1",
                    Password = "1234",
                    Rol = "Cajero",
                    Activo = true,
                    SucursalId = 2,
                    Sucursal = sucursales.First(s => s.Id == 2)
                }
            });
        }

        private static void SeedComandas()
        {
            if (ComandaController.comandas.Count > 0) return;

            var sucursalCentro = SucursalesController.sucursales.First(s => s.Id == 1);
            var sucursalNorte = SucursalesController.sucursales.First(s => s.Id == 2);

            var comanda1 = new Comanda
            {
                Id = 1,
                Fecha = DateTime.Today.AddHours(-2),
                Mesa = 3,
                Estado = "Abierta",
                SucursalId = 1,
                Sucursal = sucursalCentro,
                Total = 90m,
                Detalles = new List<ComandaDetalle>()
            };

            comanda1.Detalles.Add(new ComandaDetalle
            {
                Id = 1,
                ComandaId = 1,
                Comanda = comanda1,
                TipoProducto = "Alimento",
                ProductoId = 1,
                Descripcion = "Tacos al pastor",
                PrecioUnitario = 45m,
                Cantidad = 1,
                Importe = 45m
            });

            comanda1.Detalles.Add(new ComandaDetalle
            {
                Id = 2,
                ComandaId = 1,
                Comanda = comanda1,
                TipoProducto = "Bebida",
                ProductoId = 2,
                Descripcion = "Refresco",
                PrecioUnitario = 25m,
                Cantidad = 1,
                Importe = 25m
            });

            comanda1.Detalles.Add(new ComandaDetalle
            {
                Id = 3,
                ComandaId = 1,
                Comanda = comanda1,
                TipoProducto = "Bebida",
                ProductoId = 1,
                Descripcion = "Agua natural",
                PrecioUnitario = 20m,
                Cantidad = 1,
                Importe = 20m
            });

            comanda1.Total = comanda1.Detalles.Sum(d => d.Importe);

            var comanda2 = new Comanda
            {
                Id = 2,
                Fecha = DateTime.Today.AddHours(-5),
                Mesa = 7,
                Estado = "Cerrada",
                SucursalId = 2,
                Sucursal = sucursalNorte,
                Total = 130m,
                Detalles = new List<ComandaDetalle>()
            };

            comanda2.Detalles.Add(new ComandaDetalle
            {
                Id = 1,
                ComandaId = 2,
                Comanda = comanda2,
                TipoProducto = "Combo",
                ProductoId = 2,
                Descripcion = "Combo Familiar",
                PrecioUnitario = 130m,
                Cantidad = 1,
                Importe = 130m
            });

            ComandaController.comandas.Add(comanda1);
            ComandaController.comandas.Add(comanda2);
        }
    }
}
