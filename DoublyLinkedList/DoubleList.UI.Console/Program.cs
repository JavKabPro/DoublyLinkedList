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
            Console.Write("Ingresa el dato a adicionar: ");
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
            Console.WriteLine("Enter the data  to remove: ");
            var dataRemove = Console.ReadLine();
            if (dataRemove != null)
            {
                list.Remove(dataRemove);
                Console.WriteLine("Item removed");
            }
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
    Console.WriteLine("0. Exit.");
    Console.WriteLine("ENTER YOUR OPTION");
    return Console.ReadLine()!;
}