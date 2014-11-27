namespace Structures.Tree
{
    using System.Collections.Generic;

    /// <summary>
    /// A strongly typed list of objects representing children of a tree node.
    /// </summary>
    /// <typeparam name="T">The type of node in the node list.</typeparam>
    public class NodeList<T> : List<Node<T>>
    {
    
        private readonly Node<T> parent;

        public NodeList(Node<T> parent)
        {
            this.parent = parent;
        }       

        public Node<T> Add(T value)
        {
            var node = new Node<T>(value) { Parent = this.parent };
            this.Add(node);
            return node;
        }      
    }
}
