using System;
using System.Collections;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System.Model
{

    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }


    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        private int count;
        public int Count { get { return count; } private set { count = value; } }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        // AddFirst(value) — convenience overload
        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }

        // AddFirst(node)
        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = Head;

            // Wire forward: new node points TO old head
            node.Next = temp;

            // New node has nothing before it
            node.Previous = null;

            // Head is now our new node
            Head = node;

            // Wire backward: old head now points BACK to new node
            if (temp != null)
                temp.Previous = node;

            // If the list was empty, this node is also the Tail
            if (count == 0)
                Tail = Head;

            count++;
        }

        // AddLast(value) — convenience overload
        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        // AddLast(node)
        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                // Wire backward first: new node knows who came before it
                node.Previous = Tail;

                // Wire forward: old tail now points to new node
                Tail.Next = node;

                // Update Tail
                Tail = node;
            }

            count++;
        }


        // AddAt(index, value)
        public void AddAt(int index, T value)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Index {index} is out of range. Valid range is 0 to {count}.");

            // Delegate the edge cases
            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            if (index == count)
            {
                AddLast(value);
                return;
            }

            // Walk to the node currently sitting AT the target index.
            // This becomes the successor — the new node goes just before it.
            DoublyLinkedListNode<T> successor = Head;
            for (int i = 0; i < index; i++)
            {
                successor = successor.Next;
            }

            // The predecessor is whatever successor was pointing back to
            DoublyLinkedListNode<T> predecessor = successor.Previous;

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);

            // Wire all four pointers:
            newNode.Next = successor;           // new node points forward to successor
            newNode.Previous = predecessor;     // new node points back to predecessor
            predecessor.Next = newNode;         // predecessor skips forward to new node
            successor.Previous = newNode;       // successor points back to new node

            count++;
        }


        // RemoveFirst()
        public void RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot remove from an empty list.");

            // Slide Head forward
            Head = Head.Next;

            if (Head != null)
            {
                // The new Head has no predecessor
                Head.Previous = null;
            }
            else
            {
                // List is now empty — Tail must also be null
                Tail = null;
            }

            count--;
        }

        // RemoveLast()
        public void RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot remove from an empty list.");

            if (count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }

            count--;
        }

        // Add(item) — delegates to AddLast
        public void Add(T item)
        {
            AddLast(item);
        }

        // Contains(item) — walks from Head to Tail looking for a match
        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // GetAt and specific index
        public T GetAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            DoublyLinkedListNode<T> current = Head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Value;
        }

        // Remove(item) — finds and removes the first matching node
        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // if current is NOT the head
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        Head = current.Next;    // current was the Head
                    Head.Previous = null;

                    // if current is NOT the tail
                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        Tail = current.Previous;    // current was the Tail
                    Tail.Next = null;
                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false; //no nodes removed
        }

        // CopyTo — copies values into an array starting at arrayIndex
        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }


        public bool IsReadOnly { get { return false; } }

        // Clear — empties the list
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        // GetEnumerator — enables foreach traversal (Head → Tail)
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
