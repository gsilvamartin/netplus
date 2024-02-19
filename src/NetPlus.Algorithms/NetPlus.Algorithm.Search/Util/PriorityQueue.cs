namespace NetPlus.Algorithms.Search.Util;

/// <summary>
/// Priority Queue implementation using a min-heap.
/// </summary>
/// <typeparam name="T">Type of the elements in the priority queue.</typeparam>
public class PriorityQueue<T>
{
    // Internal representation of the priority queue as a min-heap.
    private readonly List<(T, int)> _heap = [];

    /// <summary>
    /// Gets the number of elements in the priority queue.
    /// </summary>
    public int Count => _heap.Count;

    /// <summary>
    /// Enqueues an item with the specified priority.
    /// </summary>
    /// <param name="item">The item to enqueue.</param>
    /// <param name="priority">The priority of the item.</param>
    public void Enqueue(T item, int priority)
    {
        _heap.Add((item, priority));
        HeapifyUp(_heap.Count - 1);
    }

    /// <summary>
    /// Dequeues the item with the highest priority.
    /// </summary>
    /// <returns>A tuple containing the dequeued item and its priority.</returns>
    public (T, int) Dequeue()
    {
        if (_heap.Count == 0)
            throw new InvalidOperationException("PriorityQueue is empty.");

        var item = _heap[0];
        _heap[0] = _heap[^1];
        _heap.RemoveAt(_heap.Count - 1);

        if (_heap.Count > 1) HeapifyDown(0);

        return item;
    }

    /// <summary>
    /// Maintains the heap property by bubbling up the element at the given index.
    /// </summary>
    /// <param name="index">The index of the element to be bubbled up.</param>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;

            if (_heap[index].Item2 < _heap[parentIndex].Item2)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    /// <summary>
    /// Maintains the heap property by bubbling down the element at the given index.
    /// </summary>
    /// <param name="index">The index of the element to be bubbled down.</param>
    private void HeapifyDown(int index)
    {
        var leftChildIndex = 2 * index + 1;
        var rightChildIndex = 2 * index + 2;
        var smallest = index;

        if (leftChildIndex < _heap.Count && _heap[leftChildIndex].Item2 < _heap[smallest].Item2)
            smallest = leftChildIndex;

        if (rightChildIndex < _heap.Count && _heap[rightChildIndex].Item2 < _heap[smallest].Item2)
            smallest = rightChildIndex;

        if (smallest == index) return;

        Swap(index, smallest);
        HeapifyDown(smallest);
    }

    /// <summary>
    /// Swaps the elements at the specified indices in the heap.
    /// </summary>
    /// <param name="i">Index of the first element to swap.</param>
    /// <param name="j">Index of the second element to swap.</param>
    private void Swap(int i, int j)
    {
        (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
    }
}