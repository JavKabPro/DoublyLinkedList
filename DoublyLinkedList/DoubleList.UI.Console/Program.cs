using DoubleList;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "0":
            Console.WriteLine("¡Regresa para otra lista con Taran!");
            break;
        case "1":
            Console.WriteLine("Ingresa el dato a adicionar: ");
            list.InsertOrdered(Console.ReadLine()!);
            break;
        case "2":
            if (list.IsEmpty())
            {
                Console.WriteLine("La lista está vacia.");
            }
            else
            {
                Console.WriteLine(list.GetForward());
            }
            break;
        case "3":
            if (list.IsEmpty())
            {
                Console.WriteLine("La lista está vacia.");
            }
            else
            {
                Console.WriteLine(list.GetBackward());
            }
            break;
        case "4":
            list.Reverse();
            var inver = list.ShowMode();
            if (inver.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                Console.WriteLine("La lista ha sido invertida (forma descendente).");
            }
            break;
        case "5":
            var modas = list.ShowMode();
            if (modas.Count == 0)
            {
                Console.WriteLine("La lista está vacía o no tiene modas.");
            }
            else
            {
                Console.Write("La(s) moda(s) es/son: ");
                Console.WriteLine(string.Join(", ", modas));
            }
            break;
        case "6":
            var graph = list.ShowGraph();
            if (graph.Count == 0)
            {
                Console.WriteLine("La lista está vacía, no hay gráfico para mostrar.");
            }
            else
            {
                foreach (var line in graph)
                    Console.WriteLine(line);
            }
            break;
        case "7":
            Console.WriteLine("Entre el dato a buscar: ");
            list.Contains(Console.ReadLine()!);
            break;
        case "8":
            Console.WriteLine("Ingrese ocurrencia: ");
            var dataRemove = Console.ReadLine();
            bool eliminado = list.Remove(dataRemove!);
            if (eliminado)
                Console.WriteLine("Ocurrencia eliminada correctamente.");
            else
                Console.WriteLine("El dato no está en la lista o la lista está vacía.");
            break;
        case "9":
            Console.WriteLine("Ingrese ocurrencias a eliminar: ");
            var dataRemoveAll = Console.ReadLine();
            int eliminados = list.RemoveAll(dataRemoveAll!);
            if (eliminados > 0)
                Console.WriteLine("Ocurrencias eliminadas correctamente.");
            else
                Console.WriteLine("No se encontraron coincidencias o lista vacía.");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }
} while (opc != "0");
string Menu()
{
    Console.WriteLine();
    Console.WriteLine("1. Adicionar.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostarr hacia atras.");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar la(s) moda(s).");
    Console.WriteLine("6. Mostrar gárfico.");
    Console.WriteLine("7. Existe.");
    Console.WriteLine("8. Eliminar ocurrencia.");
    Console.WriteLine("9. Eliminar todas ocurrencias.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("ENTER YOUR OPTION");
    return Console.ReadLine()!;
}