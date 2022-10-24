using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PrevNode { get; set; }
        }


        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PrevNode = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PrevNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;

            if (Count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.NextNode;
                head.PrevNode = null;
            }

            Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;

            if (Count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.PrevNode;
                tail.NextNode = null;
            }

            Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = head;

            //while (currNode != null)
            //{
            //    action(currNode.Value);
            //    currNode = currNode.NextNode;
            //}

            for (int i = 1; i <= Count; i++)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];

            var currNode = head;
            for (int i = 0; i < Count; i++)
            {
                array[i] = currNode.Value;
                currNode = currNode.NextNode;
            }

            return array;
        }
    }
}
