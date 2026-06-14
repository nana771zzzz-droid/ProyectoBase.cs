// Nathalia cespedes villa 2025-0999
using System.Collections.Generic;

List<Producto> inventario = new List<Producto>();
int opcionMenu;
bool ejecutando = true;

while (ejecutando)
{
    try
    {
        Console.Clear();
        Console.WriteLine("=== SISTEMA DE CAFETERIA ===");
        Console.WriteLine("1. Agregar Producto");
        Console.WriteLine("2. Buscar Producto");
        Console.WriteLine("3. Modificar Producto");
        Console.WriteLine("4. Eliminar Producto");
        Console.WriteLine("5. Listar Inventario");
        Console.WriteLine("6. Salir");
        Console.Write("\nSeleccione una opcion: ");

        opcionMenu = int.Parse(Console.ReadLine());

        switch (opcionMenu)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("--- AGREGAR PRODUCTO ---");
                Console.Write("Nombre del producto: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Precio del producto: ");
                double nuevoPrecio = double.Parse(Console.ReadLine());

                inventario.Add(new Producto { Nombre = nuevoNombre, Precio = nuevoPrecio });
                Console.WriteLine("\nProducto agregado correctamente.");
                break;

            case 2:
                Console.Clear();
                Console.WriteLine("--- BUSCAR PRODUCTO ---");
                Console.Write("Ingrese el nombre a buscar: ");
                string buscarNombre = Console.ReadLine();
                bool encontrado = false;

                for (int i = 0; i < inventario.Count; i++)
                {
                    if (inventario[i].Nombre.ToLower().Contains(buscarNombre.ToLower()))
                    {
                        Console.WriteLine($"[ID: {i}] - {inventario[i].Nombre} - ${inventario[i].Precio}");
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("\nNo se encontraron productos con ese nombre.");
                }
                break;

            case 3:
                Console.Clear();
                Console.WriteLine("--- MODIFICAR PRODUCTO ---");
                Console.Write("Ingrese el ID del producto a modificar: ");
                int idModificar = int.Parse(Console.ReadLine());

                if (idModificar >= 0 && idModificar < inventario.Count)
                {
                    Console.Write($"Nuevo nombre (Actual: {inventario[idModificar].Nombre}): ");
                    inventario[idModificar].Nombre = Console.ReadLine();
                    Console.Write($"Nuevo precio (Actual: ${inventario[idModificar].Precio}): ");
                    inventario[idModificar].Precio = double.Parse(Console.ReadLine());
                    Console.WriteLine("\nProducto modificado correctamente.");
                }
                else
                {
                    Console.WriteLine("\nID de producto no valido.");
                }
                break;

            case 4:
                Console.Clear();
                Console.WriteLine("--- ELIMINAR PRODUCTO ---");
                Console.Write("Ingrese el ID del producto a eliminar: ");
                int idEliminar = int.Parse(Console.ReadLine());

                if (idEliminar >= 0 && idEliminar < inventario.Count)
                {
                    inventario.RemoveAt(idEliminar);
                    Console.WriteLine("\nProducto eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("\nID de producto no valido.");
                }
                break;

            case 5:
                Console.Clear();
                Console.WriteLine("--- INVENTARIO DE LA CAFETERIA ---");
                if (inventario.Count == 0)
                {
                    Console.WriteLine("El inventario esta vacio.");
                }
                else
                {
                    for (int i = 0; i < inventario.Count; i++)
                    {
                        Console.WriteLine($"[ID: {i}] - {inventario[i].Nombre} - ${inventario[i].Precio}");
                    }
                }
                break;

            case 6:
                ejecutando = false;
                Console.WriteLine("\nCerrando sistema de cafeteria...");
                break;

            default:
                Console.WriteLine("\nOpcion no valida. Intente de nuevo.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("\nError: Entrada de datos invalida.");
    }

    if (ejecutando)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}


class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
}
