using System;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System.Model
{

    public class BinarySearchTreeNode<T>
    {
        public T Value { get; set; }
        public BinarySearchTreeNode<T> Left { get; set; }    // smaller values
        public BinarySearchTreeNode<T> Right { get; set; }   // larger values

        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }


    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> root;

        public BinarySearchTree()
        {
            root = null;
        }


        // Add(value) — public entry point; delegates to recursive helper
        public void Add(T value)
        {
            root = AddRecursive(root, value);
        }

        // AddRecursive 
        private BinarySearchTreeNode<T> AddRecursive(BinarySearchTreeNode<T> node, T value)
        {
            // Base case: we've found an empty spot — create the node here
            if (node == null)
                return new BinarySearchTreeNode<T>(value);

            int comparison = value.CompareTo(node.Value);

            if (comparison < 0)
            {
                // value is smaller → it belongs in the LEFT subtree
                node.Left = AddRecursive(node.Left, value);
            }
            else if (comparison > 0)
            {
                // value is larger → it belongs in the RIGHT subtree
                node.Right = AddRecursive(node.Right, value);
            }
            // If comparison == 0, value already exists — we skip duplicates

            return node; // return the (possibly updated) node back to the caller
        }


        // Contains(value) — searches for a value in the tree
        public bool Contains(T value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(BinarySearchTreeNode<T> node, T value)
        {
            if (node == null)
                return false;   // fell off the tree — not here

            int comparison = value.CompareTo(node.Value);

            if (comparison == 0)
                return true;    // found it

            if (comparison < 0)
                return ContainsRecursive(node.Left, value);
            else
                return ContainsRecursive(node.Right, value);
        }

        // THE THREE TRAVERSAL METHODS

        // InOrder: LEFT → CURRENT → RIGHT
        // For a BST, InOrder always produces values in
        // ASCENDING sorted order.
        public IEnumerable<T> InOrder()
        {
            return InOrderRecursive(root);
        }

        private IEnumerable<T> InOrderRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
                yield break;    // nothing here, stop this branch

            // First: recurse into LEFT subtree (all smaller values)
            foreach (T value in InOrderRecursive(node.Left))
                yield return value;

            // Then: yield the CURRENT node's value
            yield return node.Value;

            // Finally: recurse into RIGHT subtree (all larger values)
            foreach (T value in InOrderRecursive(node.Right))
                yield return value;
        }

        // PreOrder: CURRENT → LEFT → RIGHT
        // Useful for: copying/cloning a tree (root must come first),
        // or printing a directory structure (folder before its contents).
        public IEnumerable<T> PreOrder()
        {
            return PreOrderRecursive(root);
        }

        private IEnumerable<T> PreOrderRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
                yield break;

            // Current node first
            yield return node.Value;

            // Then left subtree
            foreach (T value in PreOrderRecursive(node.Left))
                yield return value;

            // Then right subtree
            foreach (T value in PreOrderRecursive(node.Right))
                yield return value;
        }

        // PostOrder: LEFT → RIGHT → CURRENT
        // Useful for: deleting a tree (delete children before parent),
        // or calculating folder sizes (need subfolder sizes first).
        public IEnumerable<T> PostOrder()
        {
            return PostOrderRecursive(root);
        }

        private IEnumerable<T> PostOrderRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
                yield break;

            // Left subtree first
            foreach (T value in PostOrderRecursive(node.Left))
                yield return value;

            // Then right subtree
            foreach (T value in PostOrderRecursive(node.Right))
                yield return value;

            // Current node last
            yield return node.Value;
        }
    }
}
