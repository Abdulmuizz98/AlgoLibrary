using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary.DataStructures
{
    public class DoublyLinkedList<T>
    {
        private int size = 0;
        private Node<T> Head = default(Node<T>);
        private Node<T> Tail = default(Node<T>);
        private class Node<T>
        {
            public T Data;
            public Node<T> Next;
            public Node<T> Prev;
            public override string ToString()
            {
                return Data.ToString();
            }
            public Node(T data, Node<T> prev, Node<T> next)
            {
                this.Data = data;
                this.Prev = prev;
                this.Next = next;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }
        public bool IsEmpty() { return Size == 0; }

        public void Clear()
        {
            Node<T> trav = Head;
            while (trav != default(Node<T>))
            {
                Node<T> next = trav.Next;
                trav.Next = trav.Prev = default(Node<T>);
                trav.Data = default(T);
                trav = next;
            }
            Head = Tail = default(Node<T>);
            size = 0;
        }
        public void Add(T elem)
        {
            AddLast(elem);
        }
        public void AddFirst(T elem)
        {
            if (size == 0) Head = Tail = new Node<T>(elem, default(Node<T>), default(Node<T>));
            else
            {
                Head.Prev = new Node<T>(elem, default(Node<T>), Head);
                Head = Head.Prev;
            }
            size++;
        }
        public void AddLast(T elem)
        {
            if (size == 0) Head = Tail = new Node<T>(elem, default(Node<T>), default(Node<T>));
            else
            {
                Tail.Next = new Node<T>(elem, Tail, default(Node<T>));
                Tail = Tail.Next;
            }
            size++;
        }
        public T PeekFirst()
        {
            if (size == 0) throw new Exception("Empty List");
            else return Head.Data;
        }
        public T PeekLast()
        {
            if (size == 0) throw new Exception("Empty List");
            else return Tail.Data;
        }
        public T RemoveFirst()
        {
            if (size == 0) throw new Exception("Empty List");

            T Data = Head.Data;
            Head = Head.Next;
            --size;

            if (IsEmpty()) Tail = default(Node<T>);

            else Head.Prev = default(Node<T>);

            return Data;
        }
        public T RemoveLast()
        {
            if (size == 0) throw new Exception("Empty List");

            T Data = Tail.Data;
            Tail = Tail.Prev;
            --size;

            if (IsEmpty()) Head = default(Node<T>);

            else Tail.Next = default(Node<T>);

            return Data;
        }
        //    get
        public T Get(int index)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");
            int i = 0;

            T data = default(T);
            Node<T> trav = Head;

            for (; i < size; i++, trav = trav.Next)
                if (i == index) data = trav.Data;

            return data;
        }
        //    set
        public void Set(int index, T data)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");

            int i = 0;
            Node<T> trav = Head;

            for (; i < size; i++, trav = trav.Next)
                if (i == index)
                {
                    trav.Data = data;
                    break;
                }
        }
        //    remove
        private T Remove(Node<T> node)
        {
            if (node.Prev == default(Node<T>)) return RemoveFirst();
            if (node.Next == default(Node<T>)) return RemoveLast();

            T data = node.Data;
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            --size;

            node = node.Prev = node.Next = default(Node<T>);
            node.Data = default(T);

            return data;
        }
        //removeAT
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new Exception("Out of range!");

            int i = 0;
            Node<T> trav;
            if (i < size / 2)
            {
                for (i = 0, trav = Head; i != index; i++)
                    trav = trav.Next;
            }
            else
            {
                for (i = size - 1, trav = Tail; i != index; i--)
                    trav = trav.Prev;
            }
            return Remove(trav);
        }
        //    remove
        public bool Remove(Object obj)
        {
            Node<T> trav;
            if (obj == default(Object))
            {
                for (trav = Head; trav != default(Node<T>); trav = trav.Next)
                    if (trav.Data.Equals(default(T)))
                    {
                        Remove(trav);
                        return true;
                    }
            }
            else
            {
                for (trav = Head; trav != default(Node<T>); trav = trav.Next)
                    if (trav.Data.Equals(obj))
                    {
                        Remove(trav);
                        return true;
                    }
            }
            return false;
        }
        //    indexof
        public int IndexOf(Object obj)
        {
            int i;
            Node<T> trav;
            if (obj == default(Node<T>))
            {
                for (i = 0, trav = Head; trav != default(Node<T>); i++, trav = trav.Next)
                    if (trav.Data.Equals(default(T)))
                    {
                        Remove(trav);
                        return i;
                    }
            }
            else
            {
                for (i = 0, trav = Head; trav != default(Node<T>); i++, trav = trav.Next)
                    if (trav.Data.Equals(obj))
                    {
                        return i;
                    }
            }
            return -1;
        }
        //    contains
        public bool Contains(Object obj)
        {
            return IndexOf(obj) != -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            Node<T> trav = Head;
            while (trav != default(Node<T>))
            {
                sb.Append(trav.Data + ", ");
            }
            sb.Append("]");

            return sb.ToString();
        }

    }
}
