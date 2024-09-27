using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items and ensure they are added to the back of the queue in the order they are enqueued.
    // Expected Result: The queue maintains insertion order when enqueuing.
    // Defect(s) Found: None expected, as enqueue operation is simple and doesn't alter priority.
    public void TestPriorityQueue_EnqueueOrder()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        priorityQueue.Enqueue("Task 2", 2);
        priorityQueue.Enqueue("Task 3", 3);

        // Check the string representation of the queue to verify order
        Assert.AreEqual("[Task 1 (Pri:1), Task 2 (Pri:2), Task 3 (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue the item with the highest priority from a queue with unique priorities.
    // Expected Result: The item with the highest priority is dequeued.
    // Defect(s) Found: Possible issue if the loop in Dequeue skips items due to boundary issues.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        priorityQueue.Enqueue("Task 2", 3);
        priorityQueue.Enqueue("Task 3", 2);

        // Dequeue should return "Task 2" because it has the highest priority (3)
        Assert.AreEqual("Task 2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue an item from a queue where multiple items share the highest priority.
    // Expected Result: The item closest to the front (earliest enqueued) is dequeued first.
    // Defect(s) Found: Possible issue in Dequeue if priority comparison doesn't handle equal priorities.
    public void TestPriorityQueue_DequeueSamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 2);
        priorityQueue.Enqueue("Task 2", 3);
        priorityQueue.Enqueue("Task 3", 3);
        priorityQueue.Enqueue("Task 4", 1);

        // Dequeue should return "Task 2" (highest priority, first enqueued with priority 3)
        Assert.AreEqual("Task 2", priorityQueue.Dequeue());
        
        // Dequeue again, should return "Task 3" (next highest priority, same as Task 2)
        Assert.AreEqual("Task 3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: The Dequeue method might not properly handle an empty queue if no exception is thrown.
    public void TestPriorityQueue_EmptyQueueDequeue()
    {
        var priorityQueue = new PriorityQueue();

        // Verify that an InvalidOperationException is thrown
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test that the queue maintains the correct state after several dequeues.
    // Expected Result: Remaining items in the queue are dequeued in correct priority order.
    // Defect(s) Found: Possible issues with maintaining correct order after multiple dequeues.
    public void TestPriorityQueue_QueueAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task 1", 1);
        priorityQueue.Enqueue("Task 2", 3);
        priorityQueue.Enqueue("Task 3", 2);
        priorityQueue.Enqueue("Task 4", 1);

        // Dequeue highest priority ("Task 2")
        priorityQueue.Dequeue();

        // Now, the highest priority item should be "Task 3"
        Assert.AreEqual("Task 3", priorityQueue.Dequeue());

        // Now, "Task 1" should be dequeued next as it has the highest priority left (FIFO rule)
        Assert.AreEqual("Task 1", priorityQueue.Dequeue());
    }
}
