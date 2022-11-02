using System;
using DataStructures.Array;
using DataStructures.Array.Interfaces;
using DataStructures.Node;
using DataStructures.Node.Interfaces;

namespace DataStructures
{
    /// <summary>
    /// Demonstrates some of the functionality of 3 different types of custom data structures.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structures");

            // ICustomStackUsingArray

            ICustomStackUsingArray<int> testCustomStackUsingArray = new CustomStackUsingArray<int>(5);
            
            testCustomStackUsingArray.Push(1);
            testCustomStackUsingArray.Push(2);

            bool empty = testCustomStackUsingArray.IsEmpty;

            var popValue = testCustomStackUsingArray.Pop();

            testCustomStackUsingArray.Push(5);

            int TestInt = 0;
            var tryPeak = testCustomStackUsingArray.TryPeek(out TestInt);

            testCustomStackUsingArray.Clear();
            testCustomStackUsingArray.Push(1);
            testCustomStackUsingArray.Push(2);

            var contains = testCustomStackUsingArray.Contains(1);

            // enumerates from 0 to N
            foreach (var item in testCustomStackUsingArray)
            {
                var enumeratedResult = item;
                
                Console.WriteLine($"ICustomStackUsingArray value: {enumeratedResult}");
            }

            // ICustomQueue

            ICustomQueue<int> testCustomQueue = new CustomQueue<int>();

            testCustomQueue.Enqueue(10);
            testCustomQueue.Enqueue(20);
            testCustomQueue.Enqueue(30);
            testCustomQueue.Enqueue(40);
            testCustomQueue.Enqueue(50);

            int dequeue1 = testCustomQueue.Dequeue();
            int dequeue2 = testCustomQueue.Dequeue();

            // enumerates from 0 to N
            foreach (var item in testCustomQueue)
            {
                var enumeratedResult = item;

                Console.WriteLine($"ICustomQueue value: {enumeratedResult}");
            }

            // ICustomStack

            ICustomStack<int> testCustomStack = new CustomStack<int>();

            testCustomStack.Push(111);
            testCustomStack.Push(112);
            testCustomStack.Push(113);
            testCustomStack.Push(114);
            testCustomStack.Push(115);

            int pop1 = testCustomStack.Pop();

            // enumerates from 0 to N
            foreach (var item in testCustomStack)
            {
                var enumeratedResult = item;

                Console.WriteLine($"ICustomStack value: {enumeratedResult}");
            }

            Console.ReadLine();
        }
    }    
}