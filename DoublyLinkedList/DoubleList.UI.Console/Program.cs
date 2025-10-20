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
            Console.WriteLine(list.GetForward());
            break;
        case "3":
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            list.Reverse();
            Console.WriteLine("La lista ha sido invertida (forma descendente).");
            break;
        case "5":
            Console.WriteLine("Entre el dato a buscar: ");
            list.Contains(Console.ReadLine()!);
            break;
        case "6":
            Console.WriteLine("Ingrese ocurrencia: ");
            var dataRemove = Console.ReadLine();
            bool eliminado = list.Remove(dataRemove!);
            if (eliminado)
                Console.WriteLine("Ocurrencia eliminada correctamente.");
            else
                Console.WriteLine("El dato no está en la lista o la lista está vacía.");
            break;
        case "7":
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
    Console.WriteLine("1. Adicionar dato.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostarr hacia atras.");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Contiene el dato.");
    Console.WriteLine("6. Eliminar ocurrencia.");
    Console.WriteLine("7. Eliminar todas ocurrencias.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("ENTER YOUR OPTION");
    return Console.ReadLine()!;
}