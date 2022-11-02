using DataStructures.Node;
using DataStructures.Node.Interfaces;
using System;
using Xunit;

namespace UnitTests
{
    public class CustomQueueTests
    {
        [Fact]
        public void TestCustomQueueThrowsExceptionWhenDequeueNoItems()
        {
            // arrange - create new queue
            ICustomQueue<int> testQueue = new CustomQueue<int>();

            // act - Dequeue from empty queue
            // assert - check exception thrown matches
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => testQueue.Dequeue());

            // assert - check exception text matches
            Assert.Equal("Stack Underflow", exception.Message);
        }

        [Fact]
        public void TestCustomQueueAfterEnqueueItemsIsNotEmpty()
        {
            // arrange - create new queue of given size
            int size = 5;
            ICustomQueue<int> testQueue = new CustomQueue<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the queue
                testQueue.Enqueue(i);
            }

            // assert - queue is not empty
            Assert.True(!testQueue.IsEmpty);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void TestCustomQueueAfterEnqueueItemsIsCorrectCount(int size)
        {
            // arrange - create new queue of given size            
            ICustomQueue<int> testQueue = new CustomQueue<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the queue
                testQueue.Enqueue(i);
            }

            // assert - queue count matches
            Assert.Equal(size, testQueue.Count);
        }

        [Fact]
        public void TestCustomQueueAfterDequeueItemsMatchValueAndEmptyQueue()
        {
            // arrange - create new queue of given size
            int size = 5;
            ICustomQueue<int> testQueue = new CustomQueue<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the queue
                testQueue.Enqueue(i);
            }

            for (var i = 0; i < size; i++)
            {
                // act - dequeue items from the queue
                int testDequeue = testQueue.Dequeue();

                // assert - dequeue value equals i
                Assert.Equal(i, testDequeue);
            }

            // assert - empty queue, all items popped
            Assert.True(testQueue.IsEmpty);
        }
    }
}
