using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDevExtensions.Algorithms.Sorting;

public static class MergeSort
{
    public static T[] Sort<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length <= 1) return array;

        int middle = array.Length / 2;
        T[] left = new T[middle];
        T[] right = new T[array.Length - middle];

        Array.Copy(array, 0, left, 0, middle);
        Array.Copy(array, middle, right, 0, right.Length);

        Sort(left);
        Sort(right);

        return Merge(left, right, array);
    }

    private static T[] Merge<T>(T[] left, T[] right, T[] array) where T : IComparable<T>
    {
        int leftIndex = 0, rightIndex = 0, outputIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
            {
                array[outputIndex++] = left[leftIndex++];
            }
            else
            {
                array[outputIndex++] = right[rightIndex++];
            }
        }

        while (leftIndex < left.Length)
        {
            array[outputIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            array[outputIndex++] = right[rightIndex++];
        }

        return array;
    }
}

