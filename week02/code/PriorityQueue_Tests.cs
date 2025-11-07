using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix? But initially, the code did not remove the item and had loop issues.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "The queue is empty.");
    }

    [TestMethod]
    // Scenario: Enqueue one item and Dequeue it
    // Expected Result: The item is returned and the queue becomes empty.
    // Defect(s) Found: Initially, Dequeue did not remove the item.
    public void TestPriorityQueue_OneItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        // Now queue should be empty
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities. Dequeue should return the highest priority item.
    // Expected Result: The highest priority item is returned.
    // Defect(s) Found: Initially, the loop did not check all items and did not remove the item.
    public void TestPriorityQueue_MultipleItemsDifferentPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 2);
        // Highest priority is 3: Item2
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        // Now highest priority is 2: Item3
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        // Then Item1
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority. Dequeue should return the first one added (FIFO).
    // Expected Result: The first item with the highest priority is returned.
    // Defect(s) Found: Initially, the code used >= which would take the last one with the same priority.
    public void TestPriorityQueue_MultipleItemsSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);
        // All have same priority, so should return first added: Item1
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        // Then Item2
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        // Then Item3
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same high priority and one with lower. Dequeue should return the first high priority.
    // Expected Result: The first high priority item is returned.
    // Defect(s) Found: Initially, the loop did not check all items and condition was >=.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 5);
        priorityQueue.Enqueue("Item4", 3);
        // Highest priority is 5, and first one with 5 is Item2
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        // Now highest priority is 5, next is Item3
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        // Then priority 3: Item4
        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        // Then Item1
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}