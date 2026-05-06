using System;
using System.Collections;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System.Model
{

    public class LinkedListNode<T>
    {   
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        // Constructor: 
        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }


    public class SinglyLinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        private int count;
        public int Count { get { return count; } private set { count = value; } }

        // Start with an empty list
        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        // AddFirst(value) — convenience overload: builds a node and pass it on
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        // AddFirst(node) 
        public void AddFirst(LinkedListNode<T> node)
        {
            // Save where Head currently points
            LinkedListNode<T> temp = Head;

            // The new node's Next now points to what used to be the Head
            node.Next = temp;

            // The new node IS the new Head
            Head = node;

            // If the list was empty, this node is also the Tail
            if (count == 0)
                Tail = Head;

            count++;
        }


        // AddLast(value) — convenience overload: builds a node pass it on
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        // AddLast(node)
        public void AddLast(LinkedListNode<T> node)
        {
            if (count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            count++;
        }


        // AddAt(index, value) 
        public void AddAt(int index, T value)
        {
            // Guard: index must be between 0 and Count (inclusive)
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Index {index} is out of range. Valid range is 0 to {count}.");
 
            // inserting at the very beginning
            if (index == 0)
            {
                AddFirst(value);
                return;
            }
 
            // inserting at the very end
            if (index == count)
            {
                AddLast(value);
                return;
            }
 
            // walk to the node just BEFORE the target index.
            // Stop at index-1 because we need that node's Next pointer.
            LinkedListNode<T> current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
 
            // current is now the node at index-1.
            // Create the new node and wire it in:
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
 
            // New node points forward to what current was pointing to
            newNode.Next = current.Next;
 
            // Current now points to new node instead
            current.Next = newNode;
 
            count++;
        }

        // RemoveFirst()
        // The old Head becomes unreferenced and the garbage collector cleans it up.
        public void RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot remove from an empty list.");

            // Slide Head to the second node
            Head = Head.Next;
            count--;

            // If the list is now empty, Tail must also be null
            if (count == 0)
                Tail = null;
        }


        // RemoveLast()
        // find the SECOND-TO-LAST node (it has no Previous pointer).
        public void RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot remove from an empty list.");

            if (count == 1)
            {
                // Only one node — list becomes empty
                Head = null;
                Tail = null;
            }
            else
            {
                // walk the whole chain until current.Next == Tail.
                LinkedListNode<T> current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                // Detach the tail — current is now the last node
                current.Next = null;
                Tail = current;
            }

            count--;
        }

        // Add(item)
        // Add to the end of the list instead of the beginning. More intuitive
        public void Add(T item)
        {
            AddLast(item);
        }


        // Contains(item) 
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }


        // GetAt an specific index
        public T GetAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            LinkedListNode<T> current = Head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Value;
        }


        // Remove(item) — finds and removes the first node with matching value
        // We need to keep track of the PREVIOUS node so we can re-wire
        // its Next pointer to skip over the node being removed.
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if ( current.Next == null)
                        {
                            Tail = previous;
                        }
                        
                        count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;  //we have removed a node
                }

                previous = current;
                current = current.Next;
            }

            return false; // Item not found
        }

        // CopyTo(array, arrayIndex) — copies all node values into an array
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }


        // IsReadOnly — our list is not read-only, so always returns false.
        public bool IsReadOnly { get { return false; } }


        // Clear() — empties the list by resetting all references
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        // -----------------------------------------------------------------
        // GetEnumerator() — allows foreach to work on our list
        //
        // The yield return statement returns each element of the collection one at a time. 
        // When the yield return statement is reached, the current location in the code is remembered, 
        // and execution is paused. The next time the enumerator is called, execution resumes from this point. 
        // Without yield return, you would need to manually implement the IEnumerator<T> interface.
        // -----------------------------------------------------------------
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        // The non-generic version required by the older IEnumerable interface.
        // We just delegate to the generic version above.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
