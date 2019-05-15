using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.AlgorithmsToInclude
{
    // TODO - implement this single linked list and use for something (perhaps your own stack)
    public class List
    {
        public LinkedList Head { get; set; }
        public LinkedList Tail { get; set; }

        public void Append(LinkedList linkedList, int Value) 
        {
            throw new NotImplementedException();
        }
        public void PrePend(LinkedList linkedList, int value)
        {
            throw new NotImplementedException();
        }
        public int Length() 
        {
            throw new NotImplementedException();
        }
        public LinkedList NodeAt(int index)
        {
            throw new NotImplementedException();
        }
        public LinkedList NodeAtEnd(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class LinkedList
    {
        public int Value { get; set; }
        public LinkedList Next { get; set; }
    }
}
