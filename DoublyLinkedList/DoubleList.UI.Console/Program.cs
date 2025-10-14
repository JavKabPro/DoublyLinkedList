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
            Console.WriteLine("¿donde quieres adicionar el nuevo dato? ");
            Console.WriteLine("a. Al inicio.");
            Console.WriteLine("b. Al final.");
            Console.Write("Elige una opción.");
            var subopc = Console.ReadLine();

            Console.Write("Ingresa el dato a adicionar: ");
            var data = Console.ReadLine();

            if (data != null)
            {
                if (subopc == "a" || subopc == "A")
                {
                    list.InsertAtBeginning(data);
                    Console.WriteLine("Dato adicionado al inicio.");
                }
                else if (subopc == "b" || subopc == "B")
                {
                    list.InsertAtEnd(data);
                    Console.WriteLine("Dato adicionado al inicio.");
                }
                else
                {
                    Console.WriteLine("Opción invlida");
                }
            }
            break;
        case "2":
            Console.WriteLine(list.GetForward());
            break;
        case "3":
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            Console.WriteLine("Enter the data  to remove: ");
            var dataRemove = Console.ReadLine();
            if (dataRemove != null)
            {
                list.Remove(dataRemove);
                Console.WriteLine("Item removed");
            }
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (opc != "0");
string Menu()
{
    Console.WriteLine();
    Console.WriteLine("1. Adicionar dato.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostarr hacia atras.");
    Console.WriteLine("4. Remover de la lista.");
    Console.WriteLine("5. Remove the list.");
    Console.WriteLine("0. Exit.");
    Console.WriteLine("ENTER YOUR OPTION");
    return Console.ReadLine()!;
}