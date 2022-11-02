using DataStructures.Node;
using DataStructures.Node.Interfaces;
using System;
using Xunit;

namespace UnitTests
{
    public class CustomStackTests
    {
        [Fact]
        public void TestCustomStackThrowsExceptionWhenPopNoItems()
        {
            // arrange - create new stack
            ICustomStack<int> testStack = new CustomStack<int>();

            // act - pop from empty stack
            // assert - check exception thrown matches
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => testStack.Pop());

            // assert - check exception text matches
            Assert.Equal("Stack Underflow", exception.Message);
        }

        [Fact]
        public void TestCustomStackAfterPushingItemsIsNotEmpty()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStack<int> testStack = new CustomStack<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            // assert - stack is not empty
            Assert.True(!testStack.IsEmpty);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void TestCustomStackAfterPushingItemsIsCorrectCount(int size)
        {
            // arrange - create new stack of given size            
            ICustomStack<int> testStack = new CustomStack<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            // assert - stack count matches
            Assert.Equal(size, testStack.Count);
        }

        [Fact]
        public void TestCustomStackAfterPoppingItemsMatchValueAndEmptyStack()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStack<int> testStack = new CustomStack<int>();

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            for (var i = size - 1; i >= 0; i--)
            {
                // act - pop items from the stack
                int testPop = testStack.Pop();

                // assert - pop value equals i
                Assert.Equal(i, testPop);
            }

            // assert - empty stack, all items popped
            Assert.True(testStack.IsEmpty);
        }
    }
}
