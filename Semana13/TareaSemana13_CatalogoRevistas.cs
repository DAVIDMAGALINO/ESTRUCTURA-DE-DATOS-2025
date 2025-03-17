using System;

public class Nodo
{
    public string Titulo;  // Título de la revista.
    public Nodo Izquierdo; // Nodo izquierdo en el árbol (revistas con títulos menores).
    public Nodo Derecho;   // Nodo derecho en el árbol (revistas con títulos mayores).

    public Nodo(string titulo)
    {
        Titulo = titulo;    // Asigna el título al nodo.
        Izquierdo = Derecho = null;  // Los nodos izquierdo y derecho inicialmente son nulos.
    }
}

public class ArbolBinarioBusqueda
{
    public Nodo Raiz;  // Raíz del árbol de búsqueda binaria.

    // Inserción de un nuevo título en el árbol binario de búsqueda.
    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);  // Llamada recursiva a la función InsertarRecursivo.
    }

    // Función recursiva para insertar un título en el árbol binario de búsqueda.
    private Nodo InsertarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null)
        {
            raiz = new Nodo(titulo);  // Si el nodo es nulo, se crea uno nuevo.
            return raiz;
        }

        // Inserción en el árbol binario de búsqueda (BST).
        // Compara el título con el nodo actual para decidir en qué subárbol insertar el nuevo nodo.
        if (string.Compare(titulo, raiz.Titulo) < 0)
            raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, titulo);  // Insertar en el subárbol izquierdo.
        else if (string.Compare(titulo, raiz.Titulo) > 0)
            raiz.Derecho = InsertarRecursivo(raiz.Derecho, titulo);  // Insertar en el subárbol derecho.

        return raiz;
    }

    // Función para buscar un título en el árbol binario de búsqueda.
    public string Buscar(string titulo)
    {
        Nodo resultado = BuscarRecursivo(Raiz, titulo);  // Llamada recursiva a la función BuscarRecursivo.
        return resultado != null ? "Encontrado" : "No encontrado";  // Si lo encuentra, devuelve "Encontrado", si no, "No encontrado".
    }

    // Función recursiva para buscar un título en el árbol binario de búsqueda.
    private Nodo BuscarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null || raiz.Titulo == titulo)  // Caso base: si el nodo es nulo o el título es igual al del nodo actual.
            return raiz;

        // Búsqueda recursiva en el árbol binario de búsqueda (BST).
        if (string.Compare(titulo, raiz.Titulo) < 0)
            return BuscarRecursivo(raiz.Izquierdo, titulo);  // Buscar en el subárbol izquierdo.
        
        return BuscarRecursivo(raiz.Derecho, titulo);  // Buscar en el subárbol derecho.
    }

    // Función para mostrar todo el catálogo en orden.
    public void MostrarCatalogo()
    {
        MostrarCatalogoRecursivo(Raiz);  // Llamada recursiva a la función MostrarCatalogoRecursivo.
    }

    // Función recursiva para mostrar todo el catálogo (recorrido en orden).
    private void MostrarCatalogoRecursivo(Nodo raiz)
    {
        if (raiz != null)
        {
            MostrarCatalogoRecursivo(raiz.Izquierdo);  // Primero muestra el subárbol izquierdo.
            Console.WriteLine(raiz.Titulo);  // Muestra el título de la revista.
            MostrarCatalogoRecursivo(raiz.Derecho);  // Luego muestra el subárbol derecho.
        }
    }
}

class Programa
{
    static void Main()
    {
        ArbolBinarioBusqueda bst = new ArbolBinarioBusqueda();

        // Insertando títulos en el catálogo de revistas.
        bst.Insertar("Vistazo");
        bst.Insertar("Expreso");
        bst.Insertar("Cosas");
        bst.Insertar("¡Hola! Ecuador");
        bst.Insertar("Guayaquil al Día");
        bst.Insertar("Caras Ecuador");
        bst.Insertar("Mujer");
        bst.Insertar("Tendencias");
        bst.Insertar("Bocado");
        bst.Insertar("Vanguardia");

        // Menú interactivo.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Catálogo de Revistas");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string titulo = Console.ReadLine();
                string resultado = bst.Buscar(titulo);
                Console.WriteLine(resultado);

                // Submenú para ver el catálogo completo.
                Console.WriteLine("¿Desea ver todo el catálogo actual? (S/N)");
                string opcionMostrarCatalogo = Console.ReadLine().ToUpper();
                if (opcionMostrarCatalogo == "S")
                {
                    Console.WriteLine("\nCatálogo completo de revistas:");
                    bst.MostrarCatalogo();  // Mostrar todo el catálogo usando el recorrido en orden (in-order traversal).
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else if (opcion == "2")
            {
                break;  // Termina el programa si elige salir.
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
