using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorting
{
    public static class BubbleSorter
    {
        /// <summary>
        /// Returns array ordered by ascensing summary elements in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByAscensingSumElementsInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arraySum = new int[array.Length];
            for (int i = 0; i < arraySum.Length; i++)
            {
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }
                    try
                    {
                        checked
                        {
                            arraySum[i] += item;
                        }
                    }
                    catch (OverflowException)
                    {

                        throw new OverflowException();
                    }

                }
            }
            result = BubbleSort(arraySum, result, true);
            return result;
        }
        /// <summary>
        /// Returns array ordered by decensing summary elements in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByDecensingSumElementsInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arraySum = new int[array.Length];
            for (int i = 0; i < arraySum.Length; i++)
            {
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }
                    try
                    {
                        checked
                        {
                            arraySum[i] += item;
                        }
                    }
                    catch (OverflowException)
                    {

                        throw new OverflowException();
                    }
                }
            }
            result = BubbleSort(arraySum, result, false);
            return result;
        }
        /// <summary>
        /// Returns array ordered by ascensing max element in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByAscensingMaxElementInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arrayMax = new int[array.Length];
            for (int i = 0; i < arrayMax.Length; i++)
            {
                arrayMax[i] = array[i][0];
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }                    
                    if (arrayMax[i] < item)
                    {
                        arrayMax[i] = item;
                    }
                }
            }
            result = BubbleSort(arrayMax, result, true);
            return result;
        }
        /// <summary>
        /// Returns array ordered by decensing max element in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByDecensingMaxElementInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arrayMax = new int[array.Length];
            for (int i = 0; i < arrayMax.Length; i++)
            {
                arrayMax[i] = array[i][0];
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }                   
                    if (arrayMax[i] < item)
                    {
                        arrayMax[i] = item;
                    }
                }
            }
            result = BubbleSort(arrayMax, result, false);
            return result;
        }
        /// <summary>
        /// Returns array ordered by ascensing min element in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByAscensingMinElementInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arrayMin = new int[array.Length];
            for (int i = 0; i < arrayMin.Length; i++)
            {
                arrayMin[i] = array[i][0];
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }
                    if (arrayMin[i] > item)
                    {
                        arrayMin[i] = item;
                    }
                }
            }
            result = BubbleSort(arrayMin, result, true);
            return result;
        }
        /// <summary>
        /// Returns array ordered by decensing min element in string
        /// </summary>
        /// <param name="array">Unsortered array</param>
        /// <returns>Sortered array</returns>
        public static int[][] OrderByDecensingMinElementInString(this int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            var result = array;
            int[] arrayMin = new int[array.Length];
            for (int i = 0; i < arrayMin.Length; i++)
            {
                arrayMin[i] = array[i][0];
                foreach (var item in array[i])
                {
                    if (array[i] == null)
                    {
                        throw new NullReferenceException();
                    }
                    if (arrayMin[i] > item)
                    {
                        arrayMin[i] = item;
                    }
                }
            }
            result = BubbleSort(arrayMin, array, false);
            return result;
        }
        /// <summary>
        /// Swaps two integet number by reference
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        /// <summary>
        /// Swaps two arrays by reference
        /// </summary>
        /// <param name="a">first array</param>
        /// <param name="b">second array</param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
        /// <summary>
        /// Sorts jugged array by bubble method
        /// </summary>
        /// <param name="array">Unsortered sing array</param>
        /// <param name="juggerArray">Unsortered jugger array</param>
        /// <param name="ascending">true if ascensing,false is decending</param>
        /// <returns></returns>
        private static int[][] BubbleSort(int[] array, int[][] juggerArray, bool ascending = true)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (ascending)
                    {
                        if (array[j] > array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            Swap(ref juggerArray[j], ref juggerArray[j + 1]);
                        }
                    }
                    else
                    {
                        if (array[j] < array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                            Swap(ref juggerArray[j], ref juggerArray[j + 1]);
                        }
                    }
                }
            }
            return juggerArray;
        }

    }
}
