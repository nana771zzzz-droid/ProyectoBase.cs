// Nathalia cespedes villa 2025-0999
using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public Producto(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Producto> menu = new List<Producto>();
        bool activo = true;

        while (activo)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("--- MENU CAFETERIA ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Buscar Producto");
                Console.WriteLine("3. Modificar Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("5. Listar Menu");
                Console.WriteLine("6. Salir");
                Console.Write("Elija una opcion: ");
                string opcion = Console.ReadLine();

                if (opcion == "6")
                {
                    activo = false;
                    continue;
                }

                if (opcion == "1")
                {
                    Console.Clear();
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Precio: ");
                    double precio = Convert.ToDouble(Console.ReadLine());

                    menu.Add(new Producto(nombre, precio));
                    Console.WriteLine("Producto agregado correctamente.");
                }
                else if (opcion == "2")
                {
                    Console.Clear();
                    Console.Write("Ingrese el nombre a buscar: ");
                    string criterio = Console.ReadLine();
                    bool encontrado = false;

                    for (int i = 0; i < menu.Count; i++)
                    {
                        if (menu[i].Nombre.ToLower().Contains(criterio.ToLower()))
                        {
                            Console.WriteLine("ID: " + i + " | Producto: " + menu[i].Nombre + " | Precio: $" + menu[i].Precio);
                            encontrado = true;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine("No se encontraron coincidencias.");
                    }
                }
                else if (opcion == "3")
                {
                    Console.Clear();
                    if (menu.Count == 0)
                    {
                        Console.WriteLine("El menu esta vacio.");
                    }
                    else
                    {
                        for (int i = 0; i < menu.Count; i++)
                        {
                            Console.WriteLine("ID: " + i + " -> " + menu[i].Nombre + " ($" + menu[i].Precio + ")");
                        }
                        Console.Write("Ingrese el ID del producto a modificar: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (id >= 0 && id < menu.Count)
                        {
                            Console.Write("Nuevo nombre: ");
                            menu[id].Nombre = Console.ReadLine();
                            Console.Write("Nuevo precio: ");
                            menu[id].Precio = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Producto modificado.");
                        }
                        else
                        {
                            Console.WriteLine("ID fuera de rango.");
                        }
                    }
                }
                else if (opcion == "4")
                {
                    Console.Clear();
                    if (menu.Count == 0)
                    {
                        Console.WriteLine("El menu esta vacio.");
                    }
                    else
                    {
                        for (int i = 0; i < menu.Count; i++)
                        {
                            Console.WriteLine("ID: " + i + " -> " + menu[i].Nombre);
                        }
                        Console.Write("Ingrese el ID del producto a eliminar: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (id >= 0 && id < menu.Count)
                        {
                            menu.RemoveAt(id);
                            Console.WriteLine("Producto eliminado.");
                        }
                        else
                        {
                            Console.WriteLine("ID fuera de rango.");
                        }
                    }
                }
                else if (opcion == "5")
                {
                    Console.Clear();
                    Console.WriteLine("--- LISTA DE PRODUCTOS ---");
                    if (menu.Count == 0)
                    {
                        Console.WriteLine("No hay productos registrados.");
                    }
                    else
                    {
                        for (int i = 0; i < menu.Count; i++)
                        {
                            Console.WriteLine("[" + i + "] " + menu[i].Nombre + " - $" + menu[i].Precio);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Opcion no valida.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Datos invalidos ingresados.");
            }

            if (activo)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
