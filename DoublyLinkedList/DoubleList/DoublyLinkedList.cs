using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DoubleList;

 public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }
    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }
    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }
    public void InsertOrdered(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }

        else if (Comparer<T>.Default.Compare(data, _head.Data) < 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }
        else
        {
            var current = _head;
            while (current != null)
            {
                int comparison = Comparer<T>.Default.Compare(data, current.Data);
                if (comparison < 0)
                {
                    newNode.Next = current;
                    newNode.Prev = current.Prev;
                    if (current.Prev != null)
                        current.Prev.Next = newNode;
                    else
                        _head = newNode;
                    current.Prev = newNode;
                    return;
                }
                else if (comparison == 0)
                {
                    while (current.Next != null && Comparer<T>.Default.Compare(data, current.Next.Data) == 0)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    if (current.Next != null)
                        current.Next.Prev = newNode;
                    else
                        _tail = newNode;
                    current.Next = newNode;
                    return;
                }
                else
                {
                    current = current.Next;
                }
            }
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }
    public void Reverse()
    {
        var current = _head;
        while (current != null)
        {
            var temp = current.Next;
            current.Next = current.Prev;
            current.Prev = temp;
            current = temp;
        }
        var auxHead = _head;
        _head = _tail;
        _tail = auxHead;
    }
    public string GetForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        if (output.Length >= 5)
            output = output.Remove(output.Length - 5);
        return output;
    }
    public string GetBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        if (output.Length >= 5)
            output = output.Remove(output.Length - 5);
        return output;
    }
    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }
                break;
            }
            current = current.Next;
        }
    }
}




