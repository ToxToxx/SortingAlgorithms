namespace SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 1, 5, 2, 40, 23, 96, 28 };

            Console.WriteLine("Original array: ");
            foreach (var num in numbersArray)
            {
                Console.Write(num + " ");
            }

            //InsertionSort(numbersArray);
            //BubbleSort(numbersArray);
            //SelectionSort(numbersArray);           
            //WriteQuickSort(numbersArray);

        }

        static int[] InsertionSort(int[] numbers)
        {
            for (int j = 2; j < numbers.Length; j++)
            {
                int key = numbers[j];
                int i = j - 1;
                while(i >= 0 && numbers[i] > key)
                {
                    numbers[i + 1] = numbers[i];
                    i -= 1;
                }
                numbers[i + 1] = key;
            }
            Console.WriteLine();
            Console.WriteLine("Insertion sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }

        static int[] BubbleSort(int[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                for (int j = numbers.Length - 1 - 1; j >= 0; j--)
                {
                    if (numbers[j] <= numbers[j + 1]) continue;
                    int temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Bubble sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }

        static int[] SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minNumber = i;
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minNumber])
                    {
                        minNumber = j;
                    }
                }
                int temp = numbers[minNumber];
                numbers[minNumber] = numbers[i];
                numbers[i] = temp;
            }
            Console.WriteLine();
            Console.WriteLine("Selection sort: ");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            return numbers;
        }
        static void SwapQuickSort(ref int firstElement, ref int secondElement)
        {
            var temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        static int PartitionQuickSort(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    SwapQuickSort(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            SwapQuickSort(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = PartitionQuickSort(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        static void WriteQuickSort(int[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Quick Sort: ");
            int[] quickSortOutput = QuickSort(array);
            foreach (var num in quickSortOutput)
            {
                Console.Write(num + " ");
            }
        }
    }
}