using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue.
    // Expected Result: The item with the highest priority is removed and returned.
    // Defect(s) Found: The loop condition `index < _queue.Count - 1` prevented checking the last item. 
    // If the highest priority item was at the end of the list, it was ignored.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 2); // Highest priority is at the end

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the exact same priority.
    // Expected Result: The item closest to the front (FIFO) is removed and returned.
    // Defect(s) Found: The comparison `>=` updated the index for equal priorities, 
    // causing it to return the last added item instead of the first. Changed to `>`.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Dequeue an item and then attempt to dequeue again from the now-empty queue.
    // Expected Result: The first dequeue returns the item. The second throws InvalidOperationException.
    // Defect(s) Found: The `Dequeue` method did not remove the item from the underlying list. 
    // Added `_queue.RemoveAt(highPriorityIndex)` to fix this.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 1);

        string result1 = priorityQueue.Dequeue();
        Assert.AreEqual("Only", result1);

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}