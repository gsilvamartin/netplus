namespace NetDevExtensions.Algorithms.Search.Util;

public class PriorityQueue<T>
{
    private readonly List<(T, int)> _heap = [];
    public int Count => _heap.Count;

    public void Enqueue(T item, int priority)
    {
        _heap.Add((item, priority));
        HeapifyUp(_heap.Count - 1);
    }

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
            else break;
        }
    }

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

    private void Swap(int i, int j)
    {
        (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
    }
}