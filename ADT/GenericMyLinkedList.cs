using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<T> where T : IComparable
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    private Node head;

    public int Count { get; private set; } = 0;
    public T First
    {
        get { return ItemAt(0); }
    }
    public T Last
    {
        get { return ItemAt(Count - 1); }
    }

    /// <summary>
    /// The Insert(T data, int index = 0) method inserts data as a node in the list
    /// at the position indicated by index. 
    /// The list is 0-indexed and the default value of the index parameter is 0.
    /// If index is less than 0 or larger than Count, an InvalidOperationException is thrown.
    /// </summary>
    public void Insert(T data, int index = 0)
    {
        if (index < 0 || index > Count) throw new InvalidOperationException();

        Node n = new Node(data);

        if (index == 0)
        {
            n.Next = head;
            head = n;
        }
        else
        {
            Node position = head;
            for (int i = 0; i < index - 1; i++)
            {
                position = position.Next;
            }
            n.Next = position.Next;
            position.Next = n;
        }
        Count++;
    }

    /// <summary>
    /// The Append(T data) method appends data at the end of the list.
    /// </summary>
    public void Append(T data)
    {
        Insert(data, Count);
    }

    /// <summary>
    /// The Delete(int index = 0) method deletes the node in the list at index-position. 
    /// The list is 0-indexed and the default value of the index parameter is 0.
    /// If index is less than 0 or larger than or equal to Count, an InvalidOperationException is thrown.
    /// </summary>
    public void Delete(int index = 0)
    {
        if (index < 0 || index >= Count) throw new InvalidOperationException();
        Node position = head;
        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            Node behindPosition = position;
            position = position.Next;
            for (int i = 0; i < index - 1; i++)
            {
                behindPosition = position;
                position = position.Next;
            }
            behindPosition.Next = position.Next;
        }
        position.Next = null; // actually remove element from list
        Count--;
    }

    /// <summary>
    /// The ItemAt(int index) method returns the data from the list 
    /// at the position indicated by index. 
    /// The list is 0-indexed. 
    /// If index is less than 0 or larger than or equal to Count, an InvalidOperationException is thrown.
    /// </summary>
    public T ItemAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new InvalidOperationException();
        }

        Node position = head;
        for (int i = 0; i < index; i++)
        {
            position = position.Next;
        }
        return position.Data;
    }

    public void Sort()
    {
        int n = Count;

        for (int i = 0; i < n - 1; i++)
        {
            Node position = head;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (position.Data.CompareTo(position.Next.Data) > 0)
                {
                    Swap(position);
                }
                position = position.Next;
            }
        }
    }

    public void Sort(IComparer<T> ic)
    {
        int n = Count;

        for (int i = 0; i < n - 1; i++)
        {
            Node position = head;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (ic.Compare(position.Data, position.Next.Data) > 0)
                {
                    Swap(position);
                }
                position = position.Next;
            }
        }
    }

    private void Swap(Node position)
    {
        T temp = position.Data;
        position.Data = position.Next.Data;
        position.Next.Data = temp;
    }

    /// <summary>
    /// The ToString() method returns a string representation of the whole list by 
    /// concatenating all the ToString()-values of each data object in the list.
    /// </summary>
    public override string ToString()
    {
        string result = "";

        Node position = head;
        while (position != null)
        {
            result = result + position.Data.ToString() + "\n";
            position = position.Next;
        }
        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyLinkedListEnumerator(head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class MyLinkedListEnumerator : IEnumerator<T>
    {
        private Node _head;
        private T _currentT;
        private Node _currentNode;

        public MyLinkedListEnumerator(Node head)
        {
            this._head = head;
            _currentNode = null;
            _currentT = default(T);
        }

        public T Current
        {
            get { return _currentT; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_head == null) // no list at all
            {
                return false;
            }
            else if (_currentNode == null) // not started yet
            {
                _currentNode = _head;
                _currentT = _currentNode.Data;
            }
            else if (_currentNode.Next == null) // at end of list
            {
                _currentNode = null;
                _currentT = default(T);
                return false;
            }
            else // get to next node
            {
                _currentNode = _currentNode.Next;
                _currentT = _currentNode.Data;
            }
            return true;
        }

        public void Reset()
        {
            _currentNode = null;
            _currentT = default(T);
        }
    }
}
