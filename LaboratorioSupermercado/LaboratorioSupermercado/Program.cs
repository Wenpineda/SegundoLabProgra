using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LaboratorioSupermercado
{
    internal class Program
    {
        static void Main(string[] args)
        {

           ForegroundColor = ConsoleColor.Yellow;
           WriteLine("**************************************************************");
           WriteLine("*                                                            *");
           WriteLine("*                                                            *");
           WriteLine("*    ¡Bienvenido al sistema del supermercado la comadre!     *");
           WriteLine("*                                                            *");
           WriteLine("*                                                            *");
           WriteLine("**************************************************************");
           ResetColor();

            // Crear una lista de usuarios de ejemplo
            List<Usuario> users = new List<Usuario>
            {
                new Usuario { Username = "Jordy", Password = "admin123", IsAdmin = true },
                new Usuario { Username = "Wendy", Password = "cliente123", IsAdmin = false },
                 new Usuario { Username = "jordy", Password = "admin123", IsAdmin = true },
                new Usuario { Username = "wendy", Password = "cliente123", IsAdmin = false }
            };

            // Crear una lista de productos de ejemplo
            List<Product> products = new List<Product>
            {
                new Product { Name = "Coca-Cola", Price = 1.5,Stock = 80, proveedor = "Coca-Cola", FechaCaducidad = new DateTime(2020, 6, 2), detalles = "Pta que rica eh" },
                new Product { Name = "Pepsi", Price = 1.4, Stock = 45,  proveedor = "Pepsi", FechaCaducidad = new DateTime(2021, 9, 8), detalles = "Pepsi owo"},
                new Product { Name = "Fanta", Price = 1.3, Stock = 60,  proveedor = "Coca-Cola", FechaCaducidad = new DateTime(2020, 3, 4),detalles = "Rico owo"}
            };

            ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nCREDENCIALES PARA EL INGENIERO");
            ResetColor();
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ADMINISTRADOR:\n Usuario: Jordy     Contraseña: admin123\n\n CLIENTE:\n Usuario: Wendy     Contraseña: cliente123");
            ResetColor();
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("\nIngrese su nombre de usuario (Admin/Cliente):");
            string username = Console.ReadLine();

            Console.WriteLine("\nIngrese su contraseña:");
            string password = Console.ReadLine();

            // Buscar el usuario en la lista de usuarios y verificar su contraseña
            Usuario user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                Console.WriteLine("\nNombre de usuario o contraseña incorrectos.");
                return;
            }

            if (user.IsAdmin)
            {
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBienvenido tú Rol es ADMINISTRADOR.\n");
                ResetColor();
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seleccione una opción:");
                ResetColor();
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool addingProducts = true;
                        do
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------------------------");
                            ResetColor();
                            Console.WriteLine("Estos son los productos disponibles:");
                            for (int i = 0; i < products.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {products[i].Name} Precio: ${products[i].Price} Proveedor: {products[i].proveedor} Stock: {products[i].Stock} Fecha de caducidad: {products[i].FechaCaducidad}");
                            }
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------------------------");
                            ResetColor();

                            // Pedir al administrador que ingrese los detalles del nuevo producto
                            Console.WriteLine("\nIngrese el nombre del producto:");
                            string productName = Console.ReadLine();

                            Console.WriteLine("Ingrese el precio del producto:");
                            double productPrice = double.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el proveedor del producto:");
                            string productProveedor = Console.ReadLine();

                            Console.WriteLine("Ingrese la fecha de entrada del producto (formato dd/MM/yyyy): ");
                            DateTime productEntrada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                            Console.WriteLine("Ingrese la fecha de caducidad (formato dd/MM/yyyy): ");
                            DateTime productCaducidad = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                            Console.WriteLine("Ingrese el stock del producto:");
                            int productStock = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese el stock del producto:");
                            string detalles = Console.ReadLine();

                            // Agregar el nuevo producto a la lista de productos
                            Product newProduct = new Product { Name = productName, proveedor = productProveedor ,Price = productPrice, Stock = productStock, detalles = detalles, FechaEntrada = productEntrada, FechaCaducidad = productCaducidad };
                            products.Add(newProduct);

                            Console.WriteLine($"\nEl nuevo producto {newProduct.Name} ha sido agregado.");

                            Console.WriteLine("\n¿Desea agregar otro producto? (s/n)");
                            string answer = Console.ReadLine();

                            addingProducts = answer.ToLower() == "s";
                        } while (addingProducts);
                        return;   
                    case 2:

                        return;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nBienvenido al menu del cliente.\n");
                ResetColor();
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seleccione una opción:");
                ResetColor();
                Console.WriteLine("1. Comprar producto");
                Console.WriteLine("2. Salir");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool addingProducts = true;
                        do
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("------------------------------------------------------------------------");
                            ResetColor();
                            Console.WriteLine("Productos disponibles:");
                            for (int i = 0; i < products.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {products[i].Name} Precio: ${products[i].Price} STOCK: {products[i].Stock}  Detalles del producto: {products[i].detalles}");
                            }
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("------------------------------------------------------------------------");
                            ResetColor();

                            // Pedir al cliente que seleccione un producto
                            Console.WriteLine("\nSeleccione un producto para comprar:");
                            int selectedProductIndex = int.Parse(Console.ReadLine()) - 1;

                            if (selectedProductIndex < 0 || selectedProductIndex >= products.Count)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El Producto no se encuentra.");
                                ResetColor();
                                return;
                            }

                            Console.WriteLine($"Ingrese la cantidad de unidades que desea comprar de {products[selectedProductIndex].Name}:");
                            int quantity = int.Parse(Console.ReadLine());

                            // Verificar que hay suficiente stock del producto seleccionado
                            if (quantity > products[selectedProductIndex].Stock)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Lo siento, no hay suficiente stock del producto {products[selectedProductIndex].Name}.");
                                ResetColor();
                                return;
                            }

                            // Restar la cantidad comprada del stock del producto
                            products[selectedProductIndex].Stock -= quantity;

                            // Mostrar un mensaje de confirmación al cliente
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------------------------");
                            ResetColor();
                            // Mostrar un mensaje de confirmación al cliente
                            Console.WriteLine($"\nEl precio del producto con el nombre  {products[selectedProductIndex].Name} es de ${products[selectedProductIndex].Price}.");
                            ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("----------------------------------------------");
                            ResetColor();
                            // Calcular el precio total de la compra y mostrar un mensaje de confirmación al cliente
                            double total = products[selectedProductIndex].Price * quantity;
                            ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Ha comprado {quantity} unidades del producto {products[selectedProductIndex].Name} por un total de ${total}.");
                            ResetColor();
                            Console.WriteLine("\n¿Desea comprar otro producto? (s/n)");
                            string answer = Console.ReadLine();
                            addingProducts = answer.ToLower() == "s";
                        } while (addingProducts);

                        return;

                    case 2:
                        return;
                }
            }

            Console.ReadLine();
        }
    }
}
