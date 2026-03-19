using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    public class Utility
    {
        /// <summary>
        /// Performs a sequential (linear) search on an array and returns
        /// the index of the first matching item, or -1 if not found.
        ///
        /// Pseudocode:
        /// 1. Start at index 0
        /// 2. Compare each array element with the target
        /// 3. If a match is found, return that index
        /// 4. If the end of the array is reached, return -1
        /// </summary>
        /// <typeparam name="T">Any type that implements IComparable&lt;T&gt;.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <param name="target">The item to find.</param>
        /// <returns>The index of the target if found; otherwise -1.</returns>
        public static int LinearSeachArray<T>(T[] array, T target) where T : IComparable<T>
        {
                if (array == null)
                    throw new ArgumentNullException(nameof(array), "Array cannot be null.");
                
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].CompareTo(target) == 0)
                        return i;
                }

                return -1;
        }

        /// <summary>
        /// Performs a binary search on a sorted array and returns
        /// the index of the matching item, or -1 if not found.
        ///
        /// Pseudocode:
        /// 1. Set low to first index and high to last index
        /// 2. While low is less than or equal to high:
        /// 3. Find the middle index
        /// 4. Compare the middle element with the target
        /// 5. If equal, return the middle index
        /// 6. If target is greater, search the upper half
        /// 7. If target is smaller, search the lower half
        /// 8. If not found, return -1
        /// </summary>
        /// <typeparam name="T">Any type that implements IComparable&lt;T&gt;.</typeparam>
        /// <param name="array">The sorted array to search.</param>
        /// <param name="target">The item to find.</param>
        /// <returns>The index of the target if found; otherwise -1.</returns>
        public static int BinarySearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
                if (array == null)
                    throw new ArgumentNullException(nameof(array), "Array cannot be null.");

                int min = 0;
                int max = array.Length - 1;

                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    int comparison = array[mid].CompareTo(target);

                    if (comparison == 0)
                    {
                        return mid;
                    }

                    if (comparison < 0)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid - 1;
                    }
                }

                return -1;
            
        }

        /// <summary>
        /// Sorts an array in ascending order using selection sort.
        /// </summary>
        /// <typeparam name="T">Any type that implements IComparable&lt;T&gt;.</typeparam>
        /// <param name="array">The array to sort.</param>
        public static void SelectionSortAscending<T>(T[] array) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    T temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Sorts an array in descending order using selection sort.
        /// </summary>
        /// <typeparam name="T">Any type that implements IComparable&lt;T&gt;.</typeparam>
        /// <param name="array">The array to sort.</param>
        public static void SelectionSortDescending<T>(T[] array) where T : IComparable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }

                if (maxIndex != i)
                {
                    T temp = array[i];
                    array[i] = array[maxIndex];
                    array[maxIndex] = temp;
                }
            }
        }
    }
}
