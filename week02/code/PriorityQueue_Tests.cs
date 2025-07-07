using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("Low", 5);     // Priority 5
        queue.Enqueue("High", 1);    // Priority 1
        queue.Enqueue("Medium", 3);  // Priority 3

        Assert.AreEqual("High", queue.Dequeue());   // Priority 1
        Assert.AreEqual("Medium", queue.Dequeue()); // Priority 3
        Assert.AreEqual("Low", queue.Dequeue());    // Priority 5
}


    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue(); 
;
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 2); // Same priority

        Assert.AreEqual("A", queue.Dequeue()); // FIFO
        Assert.AreEqual("B", queue.Dequeue());
    }

    // Add more test cases as needed below.
}