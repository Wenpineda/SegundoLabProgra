using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema del Supermercado");

            // Crear categorías
            Categoria lacteos = new Categoria { Nombre = "Lácteos", Productos = new List<Producto>() };
            Categoria panaderia = new Categoria { Nombre = "Panadería", Productos = new List<Producto>() };
            Categoria frutas_verduras = new Categoria { Nombre = "Frutas y verduras", Productos = new List<Producto>() };

            // Crear áreas
            Area alimentos = new Area { Nombre = "Alimentos", Categorias = new List<Categoria> { lacteos, panaderia, frutas_verduras } };
            Area aseo = new Area { Nombre = "Aseo", Categorias = new List<Categoria>() };

            // Agregar áreas al supermercado
            Supermercado supermercado = new Supermercado { Areas = new List<Area> { alimentos, aseo } };

            // Crear productos
            Producto leche = new Producto { Nombre = "Leche", Proveedor = "Lácteos S.A.", FechaCaducidad = new DateTime(2023, 12, 31), FechaEntrada = new DateTime(2023, 4, 12), Detalles = "Leche entera en botella", Precio = 1.50m, Unidades = 50 };
            Producto pan = new Producto
            {
                Nombre = "Pan",
                Proveedor = "Panadería Artesanal",
                FechaCaducidad = new DateTime(2023, 4, 12),
                FechaEntrada = new DateTime(2023, 4, 10),
                Detalles = "Pan francés recién horneado",
                Precio = 0.50m,
                Unidades = 100
            };
            Producto manzanas = new Producto { Nombre = "Manzanas", Proveedor = "Frutas del Campo", FechaCaducidad = new DateTime(2023, 4, 15), FechaEntrada = new DateTime(2023, 4, 11), Detalles = "Manzanas rojas frescas", Precio = 2.50m, Unidades = 30 };

            // Agregar productos a las categorías predefinidas
            lacteos.Productos.Add(leche);
            panaderia.Productos.Add(pan);
            frutas_verduras.Productos.Add(manzanas);

            // Crear usuarios
            Usuario usuario1 = new Usuario { Id = 1, Nombres = "Juan Pérez", Edad = 30, Nivel = 1 };
            Usuario usuario2 = new Usuario { Id = 2, Nombres = "María Gómez", Edad = 25, Nivel = 2 };

            // Agregar usuarios al supermercado
            supermercado.Usuarios = new List<Usuario> { usuario1, usuario2 };

            // Agregar usuarios al supermercado
            supermercado.Usuarios = new List<Usuario> { usuario1, usuario2 };

            // Mostrar las áreas disponibles
            foreach (var area in supermercado.Areas)
            {
                Console.WriteLine(area.Nombre);
            }

            // Pedir al usuario que seleccione un área
            Console.WriteLine("Seleccione un área:");
            string areaSeleccionada = Console.ReadLine();

            // Buscar la categoría correspondiente y mostrar sus productos
            Console.WriteLine("Seleccione una categoría:");
            var categoriaSeleccionada = supermercado.Areas.FirstOrDefault(a => a.Nombre == areaSeleccionada)?.Categorias;
            if (categoriaSeleccionada != null)
            {
                foreach (var categoria in categoriaSeleccionada)
                {
                    Console.WriteLine(categoria.Nombre);
                   
                }
            }
            var productosCategoria = categoriaSeleccionada.Productos;
            foreach (var producto in productosCategoria)
            {
                Console.WriteLine(producto.Nombre);
                Console.WriteLine("Proveedor: " + producto.Proveedor);
                Console.WriteLine("Fecha de caducidad: " + producto.FechaCaducidad.ToString("dd/MM/yyyy"));
                Console.WriteLine("Fecha de entrada: " + producto.FechaEntrada.ToString("dd/MM/yyyy"));
                Console.WriteLine("Detalles: " + producto.Detalles);
                Console.WriteLine("Precio: " + producto.Precio.ToString("0.00"));
                Console.WriteLine("Unidades: " + producto.Unidades);

            }

            decimal total = 0;
            List<Producto> productosComprados = new List<Producto>();

            while (true)
            {
                Console.WriteLine("Seleccione un producto:");
                string productoSeleccionado = Console.ReadLine();
                // Buscar el producto correspondiente y agregarlo a la lista de comprados
                var producto = productosCategoria.FirstOrDefault(p => p.Nombre == productoSeleccionado);
                if (producto != null)
                {
                    total += producto.Precio;
                    productosComprados.Add(producto);
                }
                Console.WriteLine("¿Desea seguir comprando? (s/n)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() == "n")
                {
                    break;
                }
            }
            Console.WriteLine("Ingrese el nombre del cliente:");
            string nombreCliente = Console.ReadLine();

            // Mostrar el listado de productos comprados y el total a pagar
            Console.WriteLine("Productos comprados:");
            foreach (var producto in productosComprados)
            {
                Console.WriteLine(producto.Nombre + " - Precio: " + producto.Precio.ToString("0.00"));
            }

            Console.WriteLine("Total a pagar: " + total.ToString("0.00"));
            Console.WriteLine("Cliente: " + nombreCliente);

            if (usuario.Nivel == 2)
            {
                // Permitir realizar la venta
            }
            else
            {
                Console.WriteLine("No tiene permisos para realizar ventas.");
            }
        }
    }


        class Producto
        {
            public string Nombre { get; set; }
            public string Proveedor { get; set; }
            public DateTime FechaCaducidad { get; set; }
            public DateTime FechaEntrada { get; set; }
            public string Detalles { get; set; }
            public decimal Precio { get; set; }
            public int Unidades { get; set; }
        }

        class Categoria
        {
            public string Nombre { get; set; }
            public List<Producto> Productos { get; set; }
        }

        class Area
        {
            public string Nombre { get; set; }
            public List<Categoria> Categorias { get; set; }
        }

        class Usuario
        {
            public int Id { get; set; }
            public string Nombres { get; set; }
            public int Edad { get; set; }
            public int Nivel { get; set; }
        }

        class Supermercado
        {
            public List<Area> Areas { get; set; }
            public List<Usuario> Usuarios { get; set; }
        }
    
}
