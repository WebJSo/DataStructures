using DataStructures.Array;
using DataStructures.Array.Interfaces;
using System;
using Xunit;

namespace UnitTests
{
    public class CustomStackUsingArrayTests
    {
        [Fact]
        public void TestCustomStackThrowsExceptionWhenPopNoItems()
        {
            // arrange - create new stack of given size
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(5);

            // act - pop from empty stack
            // assert - check exception thrown matches
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => testStack.Pop());

            // assert - check exception text matches
            Assert.Equal("Stack Underflow", exception.Message);
        }

        [Fact]
        public void TestCustomStackThrowsExceptionWhenPeakNoItems()
        {
            // arrange - create new stack of given size
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(5);

            // act - pop from empty stack
            // assert - check exception thrown matches
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => testStack.Peek());

            // assert - check exception text matches
            Assert.Equal("Stack Underflow", exception.Message);
        }

        [Fact]
        public void TestCustomStackThrowsExceptionWhenPushTooManyItems()
        {
            // arrange - create new stack of given size
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(0);

            // act - push new item to stack
            // assert - check exception thrown matches
            StackOverflowException exception = Assert.Throws<StackOverflowException>(() => testStack.Push(2));

            // assert - check exception text matches
            Assert.Equal("Stack Overflow", exception.Message);
        }

        [Fact]
        public void TestCustomStackAfterPushingItemsIsNotEmpty()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

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
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            // assert - stack is not empty
            Assert.Equal(size, testStack.Count);
        }

        [Fact]
        public void TestCustomStackAfterPoppingItemsMatchValueAndEmptyStack()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

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

        [Fact]
        public void TestCustomStackPeekMatchValue()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            for (var i = size - 1; i >= 0; i--)
            {
                // act - Peek items from the stack
                int testPeek = testStack.Peek();

                testStack.Pop();

                // assert - pop value equals i
                Assert.Equal(i, testPeek);
            }
        }

        [Fact]
        public void TestCustomStackTryPeekMatchValue()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            for (var i = size - 1; i >= 0; i--)
            {
                // act - TryPeek items from the stack
                int testTryPeek = 0;
                bool foundTryPeek = testStack.TryPeek(out testTryPeek);

                testStack.Pop();

                // assert - pop value equals i
                Assert.Equal(i, testTryPeek);

                // assert - found item
                Assert.True(foundTryPeek);
            }
        }

        [Fact]
        public void TestClearStackMatchValue()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            // act - clear stack
            testStack.Clear();

            // assert - no more items
            Assert.True(testStack.IsEmpty);
        }

        [Fact]
        public void TestEnumeratesValuesOnly()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(size);

            for (var i = 0; i < size; i++)
            {
                // act - add items to the stack
                testStack.Push(i);
            }

            // act - pop stack
            testStack.Pop();

            int countEnumerations = 0;

            foreach(int item in testStack)
            {
                // act - iterate enumerations
                countEnumerations++;
            }
            
            // assert - equal enumerations, shouldnt enumerate popped items
            Assert.Equal(size-1, countEnumerations);
        }

        [Fact]
        public void TestCountWhenPassingIEnumerableToConstructor()
        {
            // arrange - create new stack of given size
            int size = 5;
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(new int[] { 1, 2, 3, 4, 5 });

            // act - get count
            // assert - equal count of items added to stack
            Assert.Equal(size, testStack.Count);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(20, false)]
        [InlineData(50, false)]
        public void TestContainsWhenPassingIEnumerable(int value, bool outcome)
        {
            // arrange - create new stack of given size            
            ICustomStackUsingArray<int> testStack = new CustomStackUsingArray<int>(new int[] { 1, 2, 3, 4, 5 });

            // act - check if stack contains value
            // assert - equal outcome and contains return
            Assert.Equal(outcome, testStack.Contains(value));
        }
    }
}
