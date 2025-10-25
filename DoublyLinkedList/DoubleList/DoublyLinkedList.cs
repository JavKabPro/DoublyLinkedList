using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleList;

public class DoublyLinkedList<T> where T : notnull
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
        public bool IsEmpty()
    {
        return _head == null;
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
        Console.WriteLine("No, el elemento no está o lista vacia.");
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
        int removed = 0;
        for (var node = _head; node != null; )
        {
            var next = node.Next;
            if (node.Data!.Equals(data))
            {
                if (node.Prev is not null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    _head = node.Next;
                }
                if (node.Next is not null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    _tail = node.Prev;
                }
                node.Next = node.Prev = null;
                removed++;
            }
            node = next;
        }
        if (_head is null) _tail = null;
        return removed;
    }

    public List<T> ShowMode()
    {
        var counts = new Dictionary<T, int>();
        int maxCount = 0;

        for (var node = _head; node != null; node = node.Next)
        {
            var key = node.Data;
            if (key != null)
            {
                counts[key] = counts.GetValueOrDefault(key, 0) + 1;
                if (counts[key] > maxCount) maxCount = counts[key];
            }
        }
        return maxCount == 0 ? new List<T>() : counts.Where(kv => kv.Value == maxCount).Select(kv => kv.Key).ToList();
    }
    public List<string> ShowGraph()
    {
        var result = new List<string>();
        var counts = new Dictionary<T, int>();

        for (var node = _head; node != null; node = node.Next)
        {
            var key = node.Data;
            if (key != null)
            counts[key] = counts.GetValueOrDefault(key, 0) + 1;
        }
        var keys = counts.Keys.OrderBy(k => k);
        foreach (var k in keys)
        {
            var stars = new string('*', counts[k]);
            result.Add($"{k}. {stars}");
        }
        return result;
    }
}





