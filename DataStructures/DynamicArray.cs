using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLibrary.DataStructures
{
    public class DynamicArray<T>
    {
        private T[] Arr;
        private int length = 0; //user thinks length
        private int capacity = 0; //actual capacity

        //public DynamicArray() {  }
        public DynamicArray(int capacity=16)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException($"Illegal Capacity: {capacity}", "capacity");

            this.capacity = capacity;
            Arr = new T[capacity];
        }

        public int Size() { return length; }
        public bool IsEmpty() { return Size() == 0; }
        public T Get(int index) { return Arr[index]; }
        public void Set(int index, T elem) { Arr[index] = elem; }
        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
                Arr[i] = default(T);

            length = 0;
        }
        public void Add(T elem)
        {
            //Resize
            if (length + 1 >= capacity)
            {
                if (capacity == 0) capacity = 1;
                else capacity *= 2; // double the size. 

                T[] new_arr = new T[capacity];
                for (int i = 0; i < length; i++)
                    new_arr[i] = Arr[i];
                Arr = new_arr; // Has extra nulls padded.
            }
            Arr[length++] = elem;
        }
        public T RemoveAt(int rm_index)
        {
            if (rm_index >= length || rm_index < 0) throw new IndexOutOfRangeException();
            T data = Arr[rm_index];
            T[] new_arr = new T[length - 1];
            for (int i = 0, j = 0; i < length; i++, j++)
                if (i == rm_index) j--; // Skip over the index by fixing j temporarily
                else new_arr[j] = Arr[i];
            Arr = new_arr;
            capacity = --length;
            return data;
        }

        public bool Remove(T elem)
        {
            for (int i = 0; i < length; i++)
            {
                if (Arr[i].Equals(elem))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T elem)
        {
            for (int i = 0; i < length; i++)
                if (Arr[i].Equals(elem)) return i;

            return -1;
        }
        public bool Contains(T elem)
        {
            return IndexOf(elem) != -1;
        }
        public override string ToString()
        {
            if (length == 0) return "[]";
            else
            {
                StringBuilder sb = new StringBuilder(length).Append("[");
                for (int i = 0; i < length - 1; i++)
                    sb.Append($"{Arr[i]}, ");
                return sb.Append(Arr[length - 1] + "]").ToString();
            }
        }
    }

}
