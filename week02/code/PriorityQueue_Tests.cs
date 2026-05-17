using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Scenario: Enqueue several items with varying priorities, including
    // two items that share the highest priority. Dequeue repeatedly and
    // verify that the highest-priority items are returned first, and that
    // when multiple items share the highest priority the one closest to the
    // front (FIFO) is removed first.
    // Expected Result: Dequeue returns values in this order: B, D, C, A
    // Defect(s) Found:
    // - The `Dequeue` implementation iterates with `index < _queue.Count - 1`,
    //   which fails to consider the last element in the list when searching
    //   for the highest priority.
    // - The implementation uses `>=` when comparing priorities, which causes
    //   later items with equal priority to be selected instead of the one
    //   closest to the front; this violates FIFO tie-breaking.
    // - The implementation does not remove the selected item from the
    //   internal list before returning it.
    public void TestPriorityQueue_1()
    {
        var q = new PriorityQueue();

        // Enqueue items in this order: A(1), B(3), C(2), D(3)
        q.Enqueue("A", 1);
        q.Enqueue("B", 3);
        q.Enqueue("C", 2);
        q.Enqueue("D", 3);

        // Expected dequeue order: B (pri 3, earlier), D (pri 3), C (pri 2), A (pri 1)
        Assert.AreEqual("B", q.Dequeue());
        Assert.AreEqual("D", q.Dequeue());
        Assert.AreEqual("C", q.Dequeue());
        Assert.AreEqual("A", q.Dequeue());
    }

    [TestMethod]
    // Scenario: 
    // Scenario: Dequeue from an empty queue should throw the proper
    // InvalidOperationException with the exact message "The queue is empty.".
    // Also verify that Enqueue adds to the back of the queue such that when
    // priorities are equal, the element enqueued earlier is dequeued first.
    // Expected Result: Dequeue throws InvalidOperationException with message
    // "The queue is empty." and tie-breaking follows FIFO order.
    // Defect(s) Found:
    // - If Dequeue does not remove items after returning them, the queue
    //   will not become empty and this test may fail to detect emptiness.
    public void TestPriorityQueue_2()
    {
        var q = new PriorityQueue();

        // Dequeue on empty queue should throw
        try
        {
            q.Dequeue();
            Assert.Fail("Expected InvalidOperationException when dequeuing empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }

        // Now test FIFO tie-breaking for equal priorities
        q.Enqueue("X", 5);
        q.Enqueue("Y", 5);
        q.Enqueue("Z", 5);

        Assert.AreEqual("X", q.Dequeue());
        Assert.AreEqual("Y", q.Dequeue());
        Assert.AreEqual("Z", q.Dequeue());
    }

    // Add more test cases as needed below.
}