using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDevExtensions.Algorithms.Sorting;

public static class HeapSort
{
    public static T[] Sort<T>(T[] array) where T : IComparable<T>
    {
        int n = array.Length;

        for (int i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            (array[0], array[i]) = (array[i], array[0]);
            Heapify(array, i, 0);
        }

        return array;
    }

    private static void Heapify<T>(T[] array, int n, int i) where T : IComparable<T>
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left].CompareTo(array[largest]) > 0)
        {
            largest = left;
        }

        if (right < n && array[right].CompareTo(array[largest]) > 0)
        {
            largest = right;
        }

        if (largest != i)
        {
            (array[i], array[largest]) = (array[largest], array[i]);
            Heapify(array, n, largest);
        }
    }
}

