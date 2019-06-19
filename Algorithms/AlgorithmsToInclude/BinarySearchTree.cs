using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.AlgorithmsToInclude
{
    public class BinarySearchTree
    {
        public BinarySearchTree()
        {
            Run();
        }

        private void Run() 
        {
            throw new NotImplementedException();
            // TODO - functions to implement
            //
            // 1 -----------------
            // Population/Insertion (non-self balancing) - Recursive function that tests inserts root node
            // and then checks left/right for existing node and either adds value/creates a new node and 
            // adds it.

            // 2 -----------------
            // Search - only touch nodes in search path
            // Starting with root node, is the search value less than initial value and then 
            // testing left and right for <> and moving down a search path accordingly until the value
            // is found or does not exist.
            // 

            // 3 -----------------
            // Traversal - touch every node in tree
            // inorder - (use stack, aka depth search?, can be used for sorting)
            // -- process - left side all the way to the bottom until u hit a leaf...process that terminal node
            //              and go right and find the next left terminal node and process it.  Continue until
            //              u have no more nodes
            
            // preorder - 
            // -- process - start at node and process it...next left side and process it...no more left? go right

            // postorder - (aka breadth search?, used for delete, use queue)
            // -- process - find each terminal node (left to right) in the bottom most row and process each in that order
            //              until you work your way up to the root node.
        }
    }
}
