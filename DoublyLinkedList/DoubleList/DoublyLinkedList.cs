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
    private bool _isDescending = false;
    private bool _isContaining = false;
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
        if (_isDescending)
        {
            Reverse();
            _isDescending = false;
        }
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = _tail = newNode;
            return;
        }
        var cmp = Comparer<T>.Default;
        if (cmp.Compare(data, _head.Data) < 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }
        var current = _head;
        while (current.Next != null && cmp.Compare(data, current.Next.Data) >= 0)
            current = current.Next;

        newNode.Next = current.Next;
        newNode.Prev = current;
        if (current.Next != null)
            current.Next.Prev = newNode;
        else
            _tail = newNode;
        current.Next = newNode;
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
        var aux = _head;
        _head = _tail;
        _tail = aux;
        _isDescending = !_isDescending;
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
    public bool Contains(T data)
    {
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                Console.WriteLine("Sí el elemento está.");
                return true;
            }
            current = current.Next;
            _isContaining = !_isContaining;
        }
        Console.WriteLine("No, el elemento no está.");
        return false;
    }
    public bool Remove(T data)
    {
        if (_head == null)
            return false;
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next; 
                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev; 
                return true; 
            }
            current = current.Next;
        }
        return false; 
    }
    public int RemoveAll(T data)
    {
        if (_head == null)
            return 0;
        int contRem = 0;
        var actual = _head;

        while (actual != null)
        {
            var next = actual.Next;

            if (actual.Data!.Equals(data))
            {
                if (actual.Prev != null)
                {
                    actual.Prev.Next = actual.Next;
                }
                else
                {
                    _head = actual.Next;
                }
                if (actual.Next != null)
                {
                    actual.Next.Prev = actual.Prev;
                }
                else
                {
                    _tail = actual.Prev;
                }
                actual.Next = null;
                actual.Prev = null;
                contRem++;
            }
            actual = next;
        }
        if (_head == null)
            _tail = null;
        return contRem;
    }
   }





